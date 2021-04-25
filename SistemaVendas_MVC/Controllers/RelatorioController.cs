using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas_MVC.Models;

namespace SistemaVendas_MVC.Controllers
{
    public class RelatorioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        } 
        
        [HttpGet]
        public IActionResult Vendas()
        {
            return View();
        }        
        
        [HttpPost]
        public IActionResult Vendas(RelatorioModel relatorio)
        {
            if (relatorio.DataDe.Year == 1)
            {
                ViewBag.ListaVendas = new VendaModel().ListagemVendas();
            }
            else
            {
                string DataDe = relatorio.DataDe.ToString("yyyy/MM/dd");
                string DataAte = relatorio.DataAte.ToString("yyyy/MM/dd");
                ViewBag.ListaVendas = new VendaModel().ListagemVendas(DataDe, DataAte);
            }

            return View();
        }

        public IActionResult Grafico()
        {
            List<GraficoProdutos> lista = new GraficoProdutos().RetornarGrafico();

            string valores = "";
            string labels = "";
            string cores = "";

            var random = new Random();
            for (int i = 0; i < lista.Count; i++)
            {
                valores += lista[i].QtdeVendido.ToString() + ", ";
                labels += "'" + lista[i].DescricaoProduto.ToString() + "',";
                cores += "'" + String.Format("#{0:x6}", random.Next(0x1000000)) + "',";
            }

            ViewBag.Valores = valores;
            ViewBag.Labels = labels;
            ViewBag.Cores = cores;

            return View();
        }

        public IActionResult Comissao()
        {
            return View();
        }
    }
}
