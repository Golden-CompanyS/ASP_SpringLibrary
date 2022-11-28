using ASP_SpringLibrary.Areas.Dashboard.ViewModels.Autor;
using ASP_SpringLibrary.Areas.Dashboard.ViewModels.Editora;
using ASP_SpringLibrary.Areas.Dashboard.ViewModels.Genero;
using ASP_SpringLibrary.Models;
using ASP_SpringLibrary.ViewModels.Livro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_SpringLibrary.Controllers
{
    public class LivrosController : Controller
    {
        // GET: Livros
        public ActionResult Index(string filter, string busca)
        {
            var tempLivList = new List<Livro>();
            var tempLivViewList = new List<LivrosHomeViewModel>();

            if (busca == null || filter == null)
            {
                tempLivList = new Livro().checkAllLiv();
            }
            else
            {
                tempLivList = new Livro().checkAllLivByFilter(filter, busca);
                ViewBag.Busca = busca;
            }
            
            foreach(var tempLiv in tempLivList)
            {
                var tempLivView = new LivrosHomeViewModel();
                    tempLivView.ISBNLiv = tempLiv.ISBNLiv;
                    tempLivView.titLiv = tempLiv.titLiv;
                    tempLivView.imgLiv = tempLiv.imgLiv;
                    tempLivView.precoLiv = tempLiv.precoLiv;

                tempLivViewList.Add(tempLivView);
            }

            passDropDownListValues();
            return View(tempLivViewList);
        }

        [HttpGet]
        public ActionResult Detalhes(string id)
        {
            if (id == null || id == "")
            {
                return RedirectToAction("Index");
            }

            var tempLiv = new Livro().checkLivByISBN(id);

            return View(tempLiv);
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
    }
}