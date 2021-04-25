using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas_MVC.Models;

namespace SistemaVendas_MVC.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ListaClientes = new ClienteModel().ListarTodosOsClientes();
            return View();
        }  

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            if (id != null)
            {
                ViewBag.Cliente = new ClienteModel().RetornarCliente(id);
            }

            return View();
        } 
        
        [HttpPost]
        public IActionResult Cadastro(ClienteModel clienteModel)
        {
            if (ModelState.IsValid)
            {
                clienteModel.Gravar();
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Excluir(int id)
        {
            ViewData["idExcluir"] = id;
            return View();
        }   
        
        public IActionResult ExcluirCliente(int id)
        {
            new ClienteModel().Excluir(id);
            return View();
        }
    }
}
