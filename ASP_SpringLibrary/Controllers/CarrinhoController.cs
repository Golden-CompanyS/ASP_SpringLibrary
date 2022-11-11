using ASP_SpringLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult AdicionarCarrinho(string ISBNLiv)
        {
            if (ISBNLiv == null || ISBNLiv == "")
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            if (Session[nomCart] == null)
            {
                List<Carrinho> prodListCarrinho = new List<Carrinho>
                {
                    new Carrinho()
                    {
                        livroCart = new Livro().checkLivByISBN(ISBNLiv),
                        qtdProdCart = 1
                    }
                };

                Session[nomCart] = prodListCarrinho;
            }
            else
            {
                var prodListCarrinho = (List<Carrinho>) Session[nomCart];
                int checkQtd = jaExisteItem(prodListCarrinho, ISBNLiv);
                if (checkQtd == -1)
                {
                    prodListCarrinho.Add(new Carrinho()
                    {
                        livroCart = new Livro().checkLivByISBN(ISBNLiv),
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

        public int jaExisteItem(List<Carrinho> prodListCarrinho, string ISBNLiv)
        {
            for (int i = 0; i < prodListCarrinho.Count; i++)
            {
                if (prodListCarrinho[i].livroCart.ISBNLiv == ISBNLiv) return i;
            }
            return -1;
        }

        public ActionResult Remover(string ISBNLiv)
        {
            if (ISBNLiv == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var prodListCarrinho = (List<Carrinho>)Session[nomCart];
            int checkQtd = jaExisteItem(prodListCarrinho, ISBNLiv);

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
    }
}