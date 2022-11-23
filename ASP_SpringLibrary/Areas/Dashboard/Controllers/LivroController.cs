using Antlr.Runtime.Misc;
using ASP_SpringLibrary.Areas.Dashboard.ViewModels.Autor;
using ASP_SpringLibrary.Areas.Dashboard.ViewModels.Editora;
using ASP_SpringLibrary.Areas.Dashboard.ViewModels.Genero;
using ASP_SpringLibrary.Areas.Dashboard.ViewModels.Livro;
using ASP_SpringLibrary.Models;
using ASP_SpringLibrary.Utils;
using Org.BouncyCastle.Asn1.X509.SigI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Image = System.Drawing.Image;

namespace ASP_SpringLibrary.Areas.Dashboard.Controllers
{
    public class LivroController : Controller
    {
        // GET: Dashboard/Livro
        public ActionResult Index()
        {
            var tempLivList = new Livro().checkAllLiv();

            return View(tempLivList);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            passDropDownListValues();
            ViewBag.Funcionario = "2";
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(CadastrarLivroViewModel livro, HttpPostedFileBase imgLiv)
        {
            if (livro.editLiv.idEdit == 0)
            {
                ModelState.AddModelError("editLiv", "Selecione uma editora.");
            }

            if (livro.genLiv.idGen == 0)
            {
                ModelState.AddModelError("genLiv", "Selecione um gênero.");
            }

            for (int i = 0; i < livro.autLiv.Count; i++)
            {
                var tempIdAut = livro.autLiv[i].idAut;
                if (tempIdAut == 0)
                {
                    if (i == 0)
                    {
                        ModelState.AddModelError("autLiv[0]", "Selecione ao menos um autor.");
                    }
                    else
                    {
                        ModelState.AddModelError("autLiv[" + i + "]", "Selecione um autor ou exclua o campo.");
                    }
                    break;
                }
            }

            if (ModelState.IsValid)
            {
                if (imgLiv != null && imgLiv.ContentLength > 0)
                {
                    string extension = Path.GetExtension(imgLiv.FileName).ToLower();

                    if (extension.Equals(".jpg") || extension.Equals(".png") || extension.Equals(".jpeg"))
                    {
                        string fileName = Hash.GenerateMD5(
                                string.Format("{0:HH:mm:ss tt}", DateTime.Now) + imgLiv.FileName
                            ) + extension; // Criptografar o nome do arquivo + data em MD5 para torna-lo único

                        string imgPath = Path.Combine(Server.MapPath("/Photos/imgLiv/"), fileName);

                        bool imgSaved = new ImageCrop().SaveCroppedImage(Image.FromStream(imgLiv.InputStream), 256, 256, imgPath);

                        if (imgSaved)
                        {
                            livro.imgLiv = "/Photos/imgLiv/" + fileName;
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("imgLiv", "A imagem deve ser do tipo .jpg/.png/.jpeg");
                        return View(livro);
                    }
                }
                else
                {
                    livro.imgLiv = "/Photos/imgLiv/livrodefault.jpg";
                }

                Livro tempLiv = new Livro();
                    tempLiv.ISBNLiv = livro.ISBNLiv;
                    tempLiv.titLiv = livro.titLiv;
                    tempLiv.titOriLiv = livro.titOriLiv;
                    tempLiv.sinopLiv = livro.sinopLiv;
                    tempLiv.imgLiv = livro.imgLiv;
                    tempLiv.pratLiv = livro.pratLiv;
                    tempLiv.numPagLiv = livro.numPagLiv;
                    tempLiv.numEdicaoLiv = livro.numEdicaoLiv;
                    tempLiv.anoLiv = livro.anoLiv;
                    tempLiv.precoLiv = livro.precoLiv;
                    tempLiv.qtdLiv = livro.qtdLiv;
                    tempLiv.ativoLiv = livro.ativoLiv;
                    tempLiv.editLiv = new Editora { idEdit = livro.editLiv.idEdit };
                    tempLiv.genLiv = new Genero { idGen = livro.genLiv.idGen };

                    var tempAutList = new List<Autor>();
                    for (var i = 0; i < livro.autLiv.Count; i++)
                {
                    var tempAut = new Autor { idAut = livro.autLiv[i].idAut };
                    tempAutList.Add(tempAut);
                }
                    tempLiv.autLiv = tempAutList;
                    tempLiv.funcLiv = new Funcionario { idFunc = livro.funcIdLiv };

                new Livro().cadLiv(tempLiv);

                return RedirectToAction("Index");
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors);

            passDropDownListValues();
            return View(livro);
        }

        private void passDropDownListValues()
        {
            // DropDown Editoras
            ViewBag.Editoras = new List<EditoraDropDownViewModel> {
                new EditoraDropDownViewModel { idEdit = 1, nomEdit = "Abril" },
                new EditoraDropDownViewModel { idEdit = 2, nomEdit = "Intríseca" }
            };

            // DropDown Generos
            ViewBag.Generos = new List<GeneroDropDownViewModel> {
                new GeneroDropDownViewModel { idGen = 1, nomGen = "Terror" },
                new GeneroDropDownViewModel { idGen = 2, nomGen = "Humor" }
            };

            // DropDown Autores
            ViewBag.Autores = new List<AutorDropDownViewModel> {
                new AutorDropDownViewModel { idAut = 1, nomAut = "Guimarães de Rosa" },
                new AutorDropDownViewModel { idAut = 2, nomAut = "Maurício de Souza" },
                new AutorDropDownViewModel { idAut = 3, nomAut = "Machado de Assis" },
                new AutorDropDownViewModel { idAut = 4, nomAut = "Fernando Pessoa" },
            };
        }

        
        /*[HttpGet]
        public ActionResult Alterar(string ISBNLiv)
        {
            var tempLiv = new Livro().checkLivByISBN(ISBNLiv);

            return View(tempFunc);
        }*/
    }
}