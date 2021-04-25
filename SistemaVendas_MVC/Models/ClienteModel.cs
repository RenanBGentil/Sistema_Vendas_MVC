using SistemaVendas_MVC.Uteis.DAL;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace SistemaVendas_MVC.Models
{
    public class ClienteModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage ="Informe o Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o CPF/CNPJ")]
        public string Cpf_Cnpj { get; set; }

        [Required(ErrorMessage = "Informe o Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="O e-mail informado é inválido")]
        public string Email { get; set; }

        public string Senha { get; set; }

        public List<ClienteModel> ListarTodosOsClientes()
        {
            List<ClienteModel> lista = new List<ClienteModel>();
            ClienteModel item;
            DAL objDal = new DAL();
            string sql = "SELECT id, nome,cnpj_cpf, email, senha FROM Cliente ORDER BY nome ASC";
            DataTable dt = objDal.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ClienteModel
                {
                Id = dt.Rows[i]["Id"].ToString(),
                Nome = dt.Rows[i]["Nome"].ToString(),
                Cpf_Cnpj = dt.Rows[i]["cnpj_cpf"].ToString(),
                Email = dt.Rows[i]["Email"].ToString(),
                Senha = dt.Rows[i]["Senha"].ToString()
            };
            lista.Add(item);
            }
            return lista;
        }
        
        public ClienteModel RetornarCliente(int? id)
        {
            ClienteModel item;
            DAL objDal = new DAL();
            string sql = $"SELECT id, nome,cnpj_cpf, email, senha FROM Cliente WHERE id='{id}' ORDER BY nome ASC";
            DataTable dt = objDal.RetDataTable(sql);


            item = new ClienteModel
            {
                Id = dt.Rows[0]["Id"].ToString(),
                Nome = dt.Rows[0]["Nome"].ToString(),
                Cpf_Cnpj = dt.Rows[0]["cnpj_cpf"].ToString(),
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
                sql = $"UPDATE CLIENTE SET NOME = '{Nome}', CNPJ_CPF = '{Cpf_Cnpj}', EMAIL = '{Email}' where id = '{Id}'";
            }
            else
            {
                sql = $"insert into cliente (nome, cnpj_cpf, email, senha) values ('{Nome}','{Cpf_Cnpj}','{Email}','123456')";
            }

            objDAL.ExecutarComandoSql(sql);
        }      
        
        public void Excluir(int id)
        {
            DAL objDAL = new DAL();
            string sql = $"DELETE FROM CLIENTE WHERE ID = '{id}'";
            objDAL.ExecutarComandoSql(sql);
        }
    }
}
