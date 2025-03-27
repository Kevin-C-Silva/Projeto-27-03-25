using Microsoft.AspNetCore.Mvc;
using Sistema_27_03_25.Models;
using Sistema_27_03_25.Repositorio;
using System.Diagnostics;

namespace Sistema_27_03_25.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;

        private readonly UsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(UsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            var usuario = _usuarioRepositorio.ObterUsuario(email);
            if (usuario != null && usuario.Senha == senha)
            {
                //Autenticação bem-sucedida
                // return RedirectToAction("Index","Home"); a caso esteja errado ter como trocar rapido.
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Email ou senhas inválidos.");
            return View();
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarioRepositorio.AdicionarUsuario(usuario);
                return RedirectToAction("Login");
            }
            return View(usuario);
        }
    }
}
