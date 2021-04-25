using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas_MVC.Models;

namespace SistemaVendas_MVC.Controllers
{
    public class VendedorController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ListaVendedores = new VendedorModel().ListarTodosOsVendedores();
            return View();
        }  

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            if (id != null)
            {
                ViewBag.Vendedor = new VendedorModel().RetornarVendedor(id);
            }

            return View();
        } 
        
        [HttpPost]
        public IActionResult Cadastro(VendedorModel vendedorModel)
        {
            if (ModelState.IsValid)
            {
                vendedorModel.Gravar();
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Excluir(int id)
        {
            ViewData["idExcluir"] = id;
            return View();
        }   
        
        public IActionResult ExcluirVendedor(int id)
        {
            new VendedorModel().Excluir(id);
            return View();
        }
    }
}
