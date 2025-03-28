using Microsoft.AspNetCore.Mvc;
using Sistema_27_03_25.Models;
using Sistema_27_03_25.Repositorio;
using System.Diagnostics;

namespace Sistema_27_03_25.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProdutoRepositorio _produtoRepositorio;

        public ProdutoController(ProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _produtoRepositorio.AdicionarProduto(produto);
                return RedirectToAction("Cadastro");
            }
            return View(produto);
        }
    }
}
