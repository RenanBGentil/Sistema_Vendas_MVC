using SistemaVendas_MVC.Uteis.DAL;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace SistemaVendas_MVC.Models
{
    public class VendedorModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage ="Informe o Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="O e-mail informado é inválido")]
        public string Email { get; set; }

        public string Senha { get; set; }

        public List<VendedorModel> ListarTodosOsVendedores()
        {
            List<VendedorModel> lista = new List<VendedorModel>();
            VendedorModel item;
            DAL objDal = new DAL();
            string sql = "SELECT id, nome, email, senha FROM Vendedor ORDER BY nome ASC";
            DataTable dt = objDal.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new VendedorModel
                {
                Id = dt.Rows[i]["Id"].ToString(),
                Nome = dt.Rows[i]["Nome"].ToString(),
                Email = dt.Rows[i]["Email"].ToString(),
                Senha = dt.Rows[i]["Senha"].ToString(),
            };
            lista.Add(item);
            }
            return lista;
        }
        
        public VendedorModel RetornarVendedor(int? id)
        {
            VendedorModel item;
            DAL objDal = new DAL();
            string sql = $"SELECT id, nome, email, senha FROM Vendedor WHERE id='{id}' ORDER BY nome ASC";
            DataTable dt = objDal.RetDataTable(sql);


            item = new VendedorModel
            {
                Id = dt.Rows[0]["Id"].ToString(),
                Nome = dt.Rows[0]["Nome"].ToString(),
                Email = dt.Rows[0]["Email"].ToString(),
                Senha = dt.Rows[0]["Senha"].ToString()
            };
            return item;
        }

        public void Gravar()
        {
            DAL objDAL = new DAL();
            string sql = string.Empty;

            if (Id != null)
            {
                sql = $"UPDATE VENDEDOR SET NOME = '{Nome}', EMAIL = '{Email}' where id = '{Id}'";
            }
            else
            {
                sql = $"insert into VENDEDOR (nome, email,senha) values ('{Nome}','{Email}','123456')";
            }

            objDAL.ExecutarComandoSql(sql);
        }      
        
        public void Excluir(int id)
        {
            DAL objDAL = new DAL();
            string sql = $"DELETE FROM VENDEDOR WHERE ID = '{id}'";
            objDAL.ExecutarComandoSql(sql);
        }
    }
}
