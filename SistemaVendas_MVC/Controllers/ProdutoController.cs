using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas_MVC.Models;

namespace SistemaVendas_MVC.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ListaProdutos = new ProdutoModel().ListarTodosOsProdutos();
            return View();
        }  

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            if (id != null)
            {
                ViewBag.Produto = new ProdutoModel().RetornarProduto(id);
            }

            return View();
        } 
        
        [HttpPost]
        public IActionResult Cadastro(ProdutoModel produtoModel)
        {
            if (ModelState.IsValid)
            {
                produtoModel.Gravar();
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Excluir(int id)
        {
            ViewData["idExcluir"] = id;
            return View();
        }   
        
        public IActionResult ExcluirProduto(int id)
        {
            new ProdutoModel().Excluir(id);
            return View();
        }
    }
}
