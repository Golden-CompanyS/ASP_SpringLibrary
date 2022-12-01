using ASP_SpringLibrary.Models;
using ASP_SpringLibrary.Utils;
using ASP_SpringLibrary.ViewModels.Cliente;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace ASP_SpringLibrary.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(CadastroClienteViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                switch (viewModel.tipoCli)
                {
                    case true:

                        if (viewModel.CNPJCliJ == null)
                        {
                            ModelState.AddModelError("CNPJCliJ", "Informe o CNPJ da empresa.");
                            return View(viewModel);
                        }

                        if (viewModel.fantaCliJ == null)
                        {
                            ModelState.AddModelError("fantaCliJ", "Informe o nome fantasia da empresa.");
                            return View(viewModel);
                        }

                        if (viewModel.represCliJ == null)
                        {
                            ModelState.AddModelError("represCliJ", "Informe o nome do representante da empresa.");
                            return View(viewModel);
                        }

                        var tempCliJ = new ClienteJuridico
                        {
                            nomCli = viewModel.nomCli,
                            emailCli = viewModel.emailCli,
                            senhaCli = Hash.GenerateBCrypt(viewModel.senhaCli),
                            celCli = String.Concat(viewModel.celCli.Where(Char.IsDigit)),
                            CEPCli = String.Concat(viewModel.CEPCli.Where(Char.IsDigit)),
                            numEndCli = viewModel.numEndCli,
                            compEndCli = viewModel.compEndCli,
                            tipoCli = viewModel.tipoCli,
                            CNPJCliJ = String.Concat(viewModel.CNPJCliJ.Where(Char.IsDigit)),
                            fantaCliJ = viewModel.fantaCliJ,
                            represCliJ = viewModel.represCliJ
                        };

                        new ClienteJuridico().cadCliJ(tempCliJ);

                        break;
                    case false:

                        if (viewModel.dtNascCliF == null)
                        {
                            ModelState.AddModelError("dtNascCliF", "Informe sua data de nascimento.");
                            return View(viewModel);
                        }

                        if (viewModel.dtNascCliF == null)
                        {
                            ModelState.AddModelError("dtNascCliF", "Informe sua data de nascimento.");
                            return View(viewModel);
                        }

                        var tempCliF = new ClienteFisico
                        {
                            nomCli = viewModel.nomCli,
                            emailCli = viewModel.emailCli,
                            senhaCli = Hash.GenerateBCrypt(viewModel.senhaCli),
                            celCli = String.Concat(viewModel.celCli.Where(Char.IsDigit)),
                            CEPCli = String.Concat(viewModel.CEPCli.Where(Char.IsDigit)),
                            numEndCli = viewModel.numEndCli,
                            compEndCli = viewModel.compEndCli,
                            tipoCli = viewModel.tipoCli,
                            CPFCliF = String.Concat(viewModel.CPFCliF.Where(Char.IsDigit)),
                            dtNascCliF = viewModel.dtNascCliF
                        };

                        new ClienteFisico().cadCliF(tempCliF);

                        break;
                    default:
                        ModelState.AddModelError("tipoCli", "Selecione sua natureza.");
                        return View(viewModel);
                }

                return RedirectToAction("Login");
            }

            return View(viewModel);
        }

        public JsonResult CliFExists(int idCli, string CPFCliF)
        {
            CPFCliF = String.Concat(CPFCliF.Where(Char.IsDigit));
            bool CliExists = new Cliente().cliExists(idCli, CPFCliF); // Checar existência do nome (deve ser único), se não já atrelado ao ID

            return Json(!CliExists, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CliJExists(int idCli, string CNPJCliJ)
        {
            CNPJCliJ = String.Concat(CNPJCliJ.Where(Char.IsDigit));
            bool CliExists = new Cliente().cliExists(idCli, CNPJCliJ); // Checar existência do nome (deve ser único), se não já atrelado ao ID

            return Json(!CliExists, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EmailExists(int idCli, string emailCli)
        {
            bool EmailExists = new Cliente().emailExists(idCli, emailCli); // Checar existência do nome (deve ser único), se não já atrelado ao ID

            return Json(!EmailExists, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Login(string urlRetorno)
        {
            var identity = (ClaimsPrincipal) Thread.CurrentPrincipal;
            var userName = identity.Claims.Where(c => c.Type == ClaimTypes.Name)
                                                      .Select(c => c.Value).SingleOrDefault();
            if (userName != null)
            {
                return RedirectToAction("Dados");
            }

            var viewModel = new LoginClienteViewModel
            {
                urlRetorno = urlRetorno != null || urlRetorno != "" ? urlRetorno : "~/Home/Index"
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Login(LoginClienteViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var email = viewModel.emailCli;
                var senha = viewModel.senhaCli;

                int idCli = new Cliente().cliIdIfLoginExists(email, senha);
                if (idCli > 0)
                {
                    var tempCli = new Cliente().checkCliById(idCli);
                    this.SignInUser(tempCli.emailCli, false);

                    if (Url.IsLocalUrl(viewModel.urlRetorno))
                    {
                        return Redirect(viewModel.urlRetorno);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    int idFunc = new Funcionario().funcIdIfLoginExists(email, senha);
                    if (idFunc > 0)
                    {
                        var tempFunc = new Funcionario().checkFuncById(idFunc);
                        this.SignInUser(tempFunc.emailFunc, false);

                        if (Url.IsLocalUrl(viewModel.urlRetorno))
                        {
                            return Redirect(viewModel.urlRetorno);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("senhaCli", "Login e/ou senha inválidos.");
                    }
                }
            }

            return View(viewModel);
        }

        private void SignInUser(string email, bool isPersistent)
        {
            var claims = new List<Claim>();

            try
            {
                claims.Add(new Claim(ClaimTypes.Name, email));
                claims.Add(new Claim("Login", email));
                var claimIdenties = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                var ctx = Request.GetOwinContext();
                var authenticationManager = ctx.Authentication;

                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, claimIdenties);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //[CustomAuthorize("Cliente", "Funcionário")]
        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authenticationManager = ctx.Authentication;
            authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login", "Cliente");
        }
    }
}