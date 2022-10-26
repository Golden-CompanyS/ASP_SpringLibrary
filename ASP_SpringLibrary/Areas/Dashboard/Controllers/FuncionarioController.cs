using ASP_SpringLibrary.Models;
using ASP_SpringLibrary.Utils;
using Org.BouncyCastle.Crypto.Tls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Image = System.Drawing.Image;

namespace ASP_SpringLibrary.Areas.Dashboard.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: Dashboard/Funcionario
        public ActionResult Index()
        {
            var tempFuncList = new Funcionario().checkAllFunc();

            foreach (var tempFunc in tempFuncList)
            {
                tempFunc.celFunc = tempFunc.celFunc.Insert(0, "(").Insert(3, ") ").Insert(10, "-");
            }

            return View(tempFuncList);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Funcionario funcionario, HttpPostedFileBase imgFunc)
        {
            if (ModelState.IsValid)
            {
                if (imgFunc != null && imgFunc.ContentLength > 0)
                {
                    string extension = Path.GetExtension(imgFunc.FileName).ToLower();

                    if (extension.Equals(".jpg") || extension.Equals(".png") || extension.Equals(".jpeg"))
                    {
                        string fileName = Hash.GenerateMD5(
                                string.Format("{0:HH:mm:ss tt}", DateTime.Now) + imgFunc.FileName
                            ) + extension; // Criptografar o nome do arquivo + data em MD5 para torna-lo único

                        string imgPath = Path.Combine(Server.MapPath("/Photos/imgFunc/"), fileName);

                        bool imgSaved = new ImageCrop().SaveCroppedImage(Image.FromStream(imgFunc.InputStream), 256, 256, imgPath);

                        if (imgSaved)
                        {
                            funcionario.imgFunc = "/Photos/imgFunc/" + fileName;
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("imgFunc", "A imagem deve ser do tipo .jpg/.png/.jpeg");
                        return View(funcionario);
                    }
                }
                else
                {
                    funcionario.imgFunc = "/Photos/imgFunc/avatardefault.png";
                }

                funcionario.CPFFunc = String.Concat(funcionario.CPFFunc.Where(Char.IsDigit));
                funcionario.celFunc = String.Concat(funcionario.celFunc.Where(Char.IsDigit));
                funcionario.senhaFunc = Hash.GenerateBCrypt(funcionario.senhaFunc); // Criptografar a senha em BCrypt

                new Funcionario().cadFunc(funcionario);

                return RedirectToAction("Index");
            }

            return View(funcionario);
        }

        public JsonResult FuncExists(int idFunc, string CPFFunc)
        {
            CPFFunc = String.Concat(CPFFunc.Where(Char.IsDigit));
            bool funcExists = new Funcionario().funcExists(idFunc, CPFFunc); // Checar existência do nome (deve ser único), se não já atrelado ao ID

            return Json(!funcExists, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Alterar(int id)
        {
            var tempFunc = new Funcionario().checkFuncById(id);

            return View(tempFunc);
        }

        [HttpPost]
        public ActionResult Alterar(Funcionario funcionario, HttpPostedFileBase imgFunc)
        {
            if (ModelState.IsValid)
            {
                if (imgFunc != null && imgFunc.ContentLength > 0)
                {
                    string extension = Path.GetExtension(imgFunc.FileName).ToLower();

                    if (extension.Equals(".jpg") || extension.Equals(".png") || extension.Equals(".jpeg"))
                    {
                        string fileName = Hash.GenerateMD5(
                                string.Format("{0:HH:mm:ss tt}", DateTime.Now) + imgFunc.FileName
                            ) + extension; // Criptografar o nome do arquivo + data em MD5 para torna-lo único

                        string imgPath = Path.Combine(Server.MapPath("/Photos/imgFunc/"), fileName);

                        bool imgSaved = new ImageCrop().SaveCroppedImage(Image.FromStream(imgFunc.InputStream), 256, 256, imgPath);

                        if (imgSaved)
                        {
                            if (funcionario.imgFunc != "/Photos/imgFunc/avatardefault.png")
                            {
                                System.IO.File.Delete(Server.MapPath(funcionario.imgFunc));
                            }

                            funcionario.imgFunc = "/Photos/imgFunc/" + fileName;
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("imgFunc", "A imagem deve ser do tipo .jpg/.png/.jpeg");
                        return View(funcionario);
                    }
                }

                funcionario.CPFFunc = String.Concat(funcionario.CPFFunc.Where(Char.IsDigit));
                funcionario.celFunc = String.Concat(funcionario.celFunc.Where(Char.IsDigit));
                funcionario.senhaFunc = Hash.GenerateBCrypt(funcionario.senhaFunc); // Criptografar a senha em BCrypt

                new Funcionario().altFunc(funcionario);

                return RedirectToAction("Index");
            }

            return View(funcionario);
        }
    }
}