using ASP_SpringLibrary.Areas.Dashboard.ViewModels.Editora;
using ASP_SpringLibrary.Models;
using ASP_SpringLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace ASP_SpringLibrary.Controllers
{
    public class CarrinhoController : Controller
    {
        private string nomCart = "SpringCarrinho";

        // GET: Carrinho
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdicionarCarrinho(string id)
        {
            if (id == null || id == "")
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            if (Session[nomCart] == null)
            {
                List<Carrinho> prodListCarrinho = new List<Carrinho>
                {
                    new Carrinho()
                    {
                        livroCart = new Livro().checkLivByISBN(id),
                        qtdProdCart = 1
                    }
                };

                Session[nomCart] = prodListCarrinho;
            }
            else
            {
                var prodListCarrinho = (List<Carrinho>) Session[nomCart];
                int checkQtd = jaExisteItem(prodListCarrinho, id);
                if (checkQtd == -1)
                {
                    prodListCarrinho.Add(new Carrinho()
                    {
                        livroCart = new Livro().checkLivByISBN(id),
                        qtdProdCart = 1
                    });
                }
                else
                {
                    prodListCarrinho[checkQtd].qtdProdCart++;
                }

                Session[nomCart] = prodListCarrinho;
            }

            return RedirectToAction("Index");
        }

        public int jaExisteItem(List<Carrinho> prodListCarrinho, string id)
        {
            for (int i = 0; i < prodListCarrinho.Count; i++)
            {
                if (prodListCarrinho[i].livroCart.ISBNLiv == id) return i;
            }
            return -1;
        }

        public ActionResult Remover(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var prodListCarrinho = (List<Carrinho>) Session[nomCart];
            int checkQtd = jaExisteItem(prodListCarrinho, id);

            if (checkQtd == -1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                prodListCarrinho.RemoveAt(checkQtd);
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [CustomAuthorize("Cliente")]
        public ActionResult Comprar()
        {
            var tempNotaFiscal = getNotaFiscal();
            passDropDownListValues();

            if (tempNotaFiscal.livrosNF != null)
            {
                return View(tempNotaFiscal);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [CustomAuthorize("Cliente")]
        public ActionResult Comprar(NotaFiscal notaFiscal)
        {
            var tempNotaFiscal = getNotaFiscal();

                notaFiscal.valNF = tempNotaFiscal.valNF;
                notaFiscal.livrosNF = tempNotaFiscal.livrosNF;
                notaFiscal.clienteNF = tempNotaFiscal.clienteNF;
                notaFiscal.dateNF = DateTime.Now;
            if (notaFiscal.isDelivNF)
            {
                notaFiscal.deliveryNF = new Delivery { dtPrevDel = notaFiscal.dateNF.AddDays(9) };
            }
            else
            {
                notaFiscal.deliveryNF = new Delivery { dtPrevDel = notaFiscal.dateNF };
            }
                
            if (ModelState.IsValid)
            {
                new NotaFiscal().sellNF(notaFiscal);
                notaFiscal.idNF = new NotaFiscal().getLastNotafiscal();

                return RedirectToAction("Confirmar", new { id = notaFiscal.idNF });
            }

            passDropDownListValues();
            return View(notaFiscal);
        }

        [HttpGet]
        [CustomAuthorize("Cliente")]
        public ActionResult Confirmar(int? id)
        {
            if (id != 0 && id != null)
            {
                var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
                var idCli = identity.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
                                                          .Select(c => c.Value).SingleOrDefault();

                var tempNotaFiscal = new NotaFiscal().checkNFById((int) id, int.Parse(idCli));

                if (tempNotaFiscal.idNF != 0)
                {
                    Session[nomCart] = null;
                    return View(tempNotaFiscal);
                }
                else
                {
                    return View("Permissao");
                }
            };

            return RedirectToAction("Index");
        }

        public NotaFiscal getNotaFiscal()
        {
            var notaFiscal = new NotaFiscal();
            var carrinho = (List<Carrinho>) Session[nomCart];

            if (carrinho != null && carrinho.Count > 0)
            {
                var tempLivList = new List<Livro>();
                decimal tempTotal = 0;
                foreach (var produto in carrinho)
                {
                    tempLivList.Add(new Livro { ISBNLiv = produto.livroCart.ISBNLiv, 
                                                qtdLiv = produto.qtdProdCart, 
                                                precoLiv = produto.livroCart.precoLiv });
                    tempTotal += (produto.livroCart.precoLiv * produto.qtdProdCart);
                }

                notaFiscal.valNF = tempTotal;
                notaFiscal.livrosNF = tempLivList;

                var identity = (ClaimsPrincipal) Thread.CurrentPrincipal;
                var idCli = identity.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
                                                          .Select(c => c.Value).SingleOrDefault();

                notaFiscal.clienteNF = new Cliente().checkCliById(int.Parse(idCli));
            }

            return notaFiscal;
        }

        public void passDropDownListValues()
        {
            // DropDown Pagamentos
            ViewBag.Pagamentos = new List<string> {
                "Cartão de crédito",
                "Cartão de débito",
                "PIX",
                "Boleto"
            };
        }
    }
}