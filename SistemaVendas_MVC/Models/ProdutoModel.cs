using SistemaVendas_MVC.Uteis.DAL;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace SistemaVendas_MVC.Models
{
    public class ProdutoModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage ="Informe o nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a descrição")]
        public string Descricao { get; set; }        
        
        [Required(ErrorMessage = "Informe o preco_unitairo")]
        public decimal? Preco_Unitario { get; set; }        
        
        [Required(ErrorMessage = "Informe a quantidade em estoque")]
        public decimal? Quantidade_Estoque { get; set; }
                
        [Required(ErrorMessage = "Informe a unidade de medida")]
        public string Unidade_Medida { get; set; }
                
        [Required(ErrorMessage = "Informe o link da foto")]
        public string Link_Foto { get; set; }

        public List<ProdutoModel> ListarTodosOsProdutos()
        {
            List<ProdutoModel> lista = new List<ProdutoModel>();
            ProdutoModel item;
            DAL objDal = new DAL();
            string sql = "SELECT id, nome, descricao, preco_unitario, quantidade_estoque, unidade_medida, link_foto FROM Produto ORDER BY nome ASC";
            DataTable dt = objDal.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ProdutoModel
                {
                Id = dt.Rows[i]["Id"].ToString(),
                Nome = dt.Rows[i]["Nome"].ToString(),
                Descricao = dt.Rows[i]["Descricao"].ToString(),
                Preco_Unitario = decimal.Parse(dt.Rows[i]["preco_unitario"].ToString()),
                Quantidade_Estoque = decimal.Parse(dt.Rows[i]["quantidade_estoque"].ToString()),
                Unidade_Medida = dt.Rows[i]["unidade_medida"].ToString(),
                Link_Foto = dt.Rows[i]["link_foto"].ToString()
            };
            lista.Add(item);
            }
            return lista;
        }
        
        public ProdutoModel RetornarProduto(int? id)
        {
            ProdutoModel item;
            DAL objDal = new DAL();
            string sql = $"SELECT  id, nome, descricao, preco_unitario, quantidade_estoque, unidade_medida, link_foto FROM PRODUTO WHERE id='{id}' ORDER BY nome ASC";
            DataTable dt = objDal.RetDataTable(sql);


            item = new ProdutoModel
            {
                Id = dt.Rows[0]["Id"].ToString(),
                Nome = dt.Rows[0]["Nome"].ToString(),
                Descricao = dt.Rows[0]["Descricao"].ToString(),
                Preco_Unitario = decimal.Parse(dt.Rows[0]["preco_unitario"].ToString()),
                Quantidade_Estoque = decimal.Parse(dt.Rows[0]["quantidade_estoque"].ToString()),
                Unidade_Medida = dt.Rows[0]["unidade_medida"].ToString(),
                Link_Foto = dt.Rows[0]["link_foto"].ToString()
            };
            return item;
        }

        public void Gravar()
        {
            DAL objDAL = new DAL();
            string sql = string.Empty;

            if (Id != null)
            {
                sql = $"UPDATE PRODUTO SET NOME = '{Nome}', " +
                    $"DESCRICAO = '{Descricao}', " +
                    $"PRECO_UNITARIO = {Preco_Unitario.ToString().Replace(",",".")}, " +
                    $"QUANTIDADE_ESTOQUE = '{Quantidade_Estoque}', " +
                    $"UNIDADE_MEDIDA = '{Unidade_Medida}', " +
                    $"LINK_FOTO = '{Link_Foto}'" +
                    $" where id = '{Id}'";
            }
            else
            {
                sql = $"insert into PRODUTO " +
                    $"( nome, descricao, preco_unitario, quantidade_estoque, unidade_medida, link_foto) values " +
                    $"('{Nome}','{Descricao}','{Preco_Unitario}','{Quantidade_Estoque}','{Unidade_Medida}','{Link_Foto}')";
            }

            objDAL.ExecutarComandoSql(sql);
        }      
        
        public void Excluir(int id)
        {
            DAL objDAL = new DAL();
            string sql = $"DELETE FROM PRODUTO WHERE ID = '{id}'";
            objDAL.ExecutarComandoSql(sql);
        }
    }
}
