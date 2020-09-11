using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Aplicacao.Helpers;
using Aplicacao.Servico.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Contexto;
using WebVendas.Models;

namespace Aplicacao.Controllers
{
    public class LoginController : Controller
    {

        readonly ApplicationDbContext mContext;
        readonly IHttpContextAccessor http;

        public LoginController(ApplicationDbContext context, IHttpContextAccessor httpContext)
        {
            mContext = context;
            http = httpContext;
        }

        public IActionResult Index(int? id)
        {
            if(id != null)
            {
                if(id == 0)
                {
                    http.HttpContext.Session.Clear();
                }
            }

            ViewData["Title"] = "Acesso ao sistema";
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel vm)
        {
            ViewData["ErroLogin"] = string.Empty;
            if (ModelState.IsValid)
            {
                var senha = Criptografia.GerarHashMd5(vm.Senha);
                var usuario = mContext.Usuario.Where(x => x.Email == vm.Email && x.Senha == senha).FirstOrDefault();

                if (usuario == null)
                {
                    ViewData["ErroLogin"] = "E-mail ou senha inválidos";
                    return View(vm);
                }
                else
                {
                    http.HttpContext.Session.SetString(Sessao.NOME_USUARIO, usuario.Nome);
                    http.HttpContext.Session.SetString(Sessao.EMAIL_USUARIO, usuario.Email);
                    http.HttpContext.Session.SetInt32(Sessao.CODIGO_USUARIO, (int)usuario.Codigo);
                    http.HttpContext.Session.SetInt32(Sessao.LOGADO, 1);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View(vm);
            }
        }
    }
}
