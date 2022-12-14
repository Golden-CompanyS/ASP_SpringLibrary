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
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Image = System.Drawing.Image;

namespace ASP_SpringLibrary.Areas.Dashboard.Controllers
{
    [CustomAuthorize("Funcionário")]
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
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(CadastrarLivroViewModel livro, HttpPostedFileBase imgLiv)
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var funcId = identity.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
                                                      .Select(c => c.Value).SingleOrDefault();
            livro.funcIdLiv = int.Parse(funcId);
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

            if (imgLiv != null && imgLiv.ContentLength > 0)
            {
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

                            var width = Image.FromStream(imgLiv.InputStream).Width;
                            var height = Image.FromStream(imgLiv.InputStream).Height;
                            bool imgSaved = new ImageCrop().SaveCroppedImage(Image.FromStream(imgLiv.InputStream), width, height, imgPath);

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

                        // Tirar autores repetidos
                        var tempAllAutIdList = new List<int>();
                        for (var i = 0; i < livro.autLiv.Count; i++)
                        {
                            tempAllAutIdList.Add(livro.autLiv[i].idAut);
                        }
                        var tempUniqueAutIdList = new HashSet<int>(tempAllAutIdList);

                        // Passar valores à classe Livro para cadastrar
                        var tempLiv = new Livro();
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
                        foreach (var autId in tempUniqueAutIdList)
                        {
                            var tempAut = new Autor { idAut = autId };
                            tempAutList.Add(tempAut);
                        }

                        tempLiv.autLiv = tempAutList;
                        tempLiv.funcLiv = new Funcionario { idFunc = livro.funcIdLiv };

                        new Livro().cadLiv(tempLiv);

                        return RedirectToAction("Index");
                    }
                }

                ModelState.AddModelError("imgLiv", "Selecione a imagem novamente"); // Quando a página recarrega, devolvendo o erro, a imagem deve ser selecionada novamente
            }
            else
            {
                livro.imgLiv = "/Photos/imgLiv/livrodefault.jpg";
            }
            passDropDownListValues();
            return View(livro);
        }

        private void passDropDownListValues()
        {
            // DropDown Editoras
            var tempEditList = new Editora().checkAllEdit();
            var tempEditDropList = new List<EditoraDropDownViewModel>();

            for (var i = 0; i < tempEditList.Count; i++)
            {
                var tempEditDrop = new EditoraDropDownViewModel();
                    tempEditDrop.idEdit = tempEditList[i].idEdit;
                    tempEditDrop.nomEdit = tempEditList[i].nomEdit;

                tempEditDropList.Add(tempEditDrop);
            }

            ViewBag.Editoras = tempEditDropList;

            // DropDown Generos
            var tempGenList = new Genero().checkAllGen();
            var tempGenDropList = new List<GeneroDropDownViewModel>();

            for (var i = 0; i < tempGenList.Count; i++)
            {
                var tempGenDrop = new GeneroDropDownViewModel();
                    tempGenDrop.idGen = tempGenList[i].idGen;
                    tempGenDrop.nomGen = tempGenList[i].nomGen;

                tempGenDropList.Add(tempGenDrop);
            }

            ViewBag.Generos = tempGenDropList;

            // DropDown Autores
            var tempAutList = new Autor().checkAllAut();
            var tempAutDropList = new List<AutorDropDownViewModel>();

            for (var i = 0; i < tempAutList.Count; i++)
            {
                var tempAutDrop = new AutorDropDownViewModel();
                tempAutDrop.idAut = tempAutList[i].idAut;
                tempAutDrop.nomAut = tempAutList[i].nomAut;

                tempAutDropList.Add(tempAutDrop);
            }

            ViewBag.Autores = tempAutDropList;
        }


        [HttpGet]
        public ActionResult Alterar(string ISBNLiv)
        {
            var tempLiv = new Livro().checkLivByISBN(ISBNLiv);

            var viewmodel = new CadastrarLivroViewModel();
                viewmodel.ISBNLiv = tempLiv.ISBNLiv;
                viewmodel.titLiv = tempLiv.titLiv;
                viewmodel.titOriLiv = tempLiv.titOriLiv;
                viewmodel.sinopLiv = tempLiv.sinopLiv;
                viewmodel.imgLiv = tempLiv.imgLiv;
                viewmodel.pratLiv = tempLiv.pratLiv;
                viewmodel.numPagLiv = tempLiv.numPagLiv;
                viewmodel.numEdicaoLiv = tempLiv.numEdicaoLiv;
                viewmodel.anoLiv = tempLiv.anoLiv;
                viewmodel.precoLiv = tempLiv.precoLiv;
                viewmodel.qtdLiv = tempLiv.qtdLiv;
                viewmodel.ativoLiv = tempLiv.ativoLiv;
                viewmodel.editLiv = new EditoraDropDownViewModel { idEdit = tempLiv.editLiv.idEdit };
                viewmodel.genLiv = new GeneroDropDownViewModel { idGen = tempLiv.genLiv.idGen };

            var tempAutList = new List<AutorDropDownViewModel>();
            foreach (var aut in tempLiv.autLiv)
            {
                var tempAut = new AutorDropDownViewModel { idAut = aut.idAut };
                tempAutList.Add(tempAut);
            }

            viewmodel.autLiv = tempAutList;
            tempLiv.funcLiv = new Funcionario { idFunc = tempLiv.funcLiv.idFunc };

            passDropDownListValues();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Alterar(CadastrarLivroViewModel livro, HttpPostedFileBase imgLiv)
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var funcId = identity.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
                                                      .Select(c => c.Value).SingleOrDefault();
            livro.funcIdLiv = int.Parse(funcId);

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

                        string imgPath = Path.Combine(Server.MapPath("/Photos/imgFunc/"), fileName);

                        bool imgSaved = new ImageCrop().SaveCroppedImage(Image.FromStream(imgLiv.InputStream), 256, 256, imgPath);

                        if (imgSaved)
                        {
                            if (livro.imgLiv != "/Photos/imgLiv/livrodefault.jpg")
                            {
                                System.IO.File.Delete(Server.MapPath(livro.imgLiv));
                            }

                            livro.imgLiv = "/Photos/imgLiv/" + fileName;
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("imgLiv", "A imagem deve ser do tipo .jpg/.png/.jpeg");
                        return View(livro);
                    }
                }

                //livro.CPFFunc = String.Concat(funcionario.CPFFunc.Where(Char.IsDigit));
                //livro.celFunc = String.Concat(funcionario.celFunc.Where(Char.IsDigit));
                //livro.senhaFunc = Hash.GenerateBCrypt(funcionario.senhaFunc); // Criptografar a senha em BCrypt

                //new Livro().altLiv(livro);

                return RedirectToAction("Index");
            }

            return View(livro);
        }
    }
}