using Newtonsoft.Json;
using SistemaVendas_MVC.Uteis.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendas_MVC.Models
{
    public class VendaModel
    {
        public string Id { get; set; }
        public string Data { get; set; }
        public string Cliente_Id { get; set; }
        public string Vendedor_Id { get; set; }
        public string ListaProdutos { get; set; }
        public double TotalVenda { get; set; }


        public List<VendaModel> ListagemVendas(string DataDe, string DataAte)
        {
            return RetornarListagemVendas( DataDe, DataAte);
        }

        public List<VendaModel> ListagemVendas()
        {
            return RetornarListagemVendas("1900/01/01","2200/01/01");
        }

        private List<VendaModel> RetornarListagemVendas(string DataDe, string DataAte)
        {
            List<VendaModel> lista = new List<VendaModel>();
            VendaModel item;
            DAL objDal = new DAL();
            string sql = "SELECT v1.id, v1.data, v1.total, v2.nome as vendedor, c.nome as cliente from " +
                " venda v1 inner join vendedor v2 on v1.vendedor_id = v2.id inner join cliente c " +
                " on v1.cliente_id = c.id " +
                $" where v1.data >='{DataDe}' and v1.data <='{DataAte}' " +
                "order by data, total";

            DataTable dt = objDal.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new VendaModel
                {
                    Id = dt.Rows[i]["Id"].ToString(),
                    Data = DateTime.Parse(dt.Rows[i]["Data"].ToString()).ToString("dd/MM/yyyy"),
                    TotalVenda = double.Parse(dt.Rows[i]["Total"].ToString()),
                    Cliente_Id = dt.Rows[i]["cliente"].ToString(),
                    Vendedor_Id = dt.Rows[i]["vendedor"].ToString()
                };
                lista.Add(item);
            }
            return lista;
        }

        public List<ClienteModel> RetornarListaClientes()
        {
            return new ClienteModel().ListarTodosOsClientes();
        }

        public List<VendedorModel> RetornarListaVendedores()
        {
            return new VendedorModel().ListarTodosOsVendedores();
        }        
        
        public List<ProdutoModel> RetornarListaProdutos()
        {
            return new ProdutoModel().ListarTodosOsProdutos();
        }

        public void Inserir()
        {
            DAL objDal = new DAL();

            string dataVenda = DateTime.Now.Date.ToString("yyyy/MM/dd");

            string sql = "INSERT INTO VENDA(data, total, Vendedor_id, Cliente_id)" +
                $"VALUES('{dataVenda}', {TotalVenda.ToString().Replace(",",".")}, {Vendedor_Id}, {Cliente_Id} )";
            objDal.ExecutarComandoSql(sql);

            sql = $"select id from venda where data='{dataVenda}' and Vendedor_id={Vendedor_Id} and Cliente_id={Cliente_Id} order by id desc limit 1";
            DataTable dt = objDal.RetDataTable(sql);
            string id_venda = dt.Rows[0]["id"].ToString();

            List<ItemVendaModel> lista_produtos = JsonConvert.DeserializeObject<List<ItemVendaModel>>(ListaProdutos);

            for (int i = 0; i < lista_produtos.Count; i++)
            {
                sql = "insert into itens_venda (Venda_id, Produto_id, qtde_produto, preco_produto) " +
                $"values({id_venda}, " +
                $"{lista_produtos[i].CodigoProduto.ToString()}, " +
                $"{lista_produtos[i].QtdeProduto.ToString()}, " +
                $"{lista_produtos[i].PrecoProduto.ToString().Replace(",",".")})";
                objDal.ExecutarComandoSql(sql);

                sql = "update produto " +
                    $" set quantidade_estoque = (quantidade_estoque -" + int.Parse(lista_produtos[i].QtdeProduto.ToString()) + ") " +
                    $" where id = {lista_produtos[i].CodigoProduto.ToString()}";
                objDal.ExecutarComandoSql(sql);
            }
        }
    }
}