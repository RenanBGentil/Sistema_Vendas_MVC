using MySql.Data.MySqlClient;
using SistemaVendas_MVC.Uteis.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendas_MVC.Models
{
    public class LoginModel
    {
        public string Id { get; set; }

        public string Nome { get; set; }

        [Required(ErrorMessage ="Informe o seu email!")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="Email informado esta incorreto!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a sua senha!")]
        public string Senha { get; set; }

        public bool ValidarLogin()
        {
            string sql = $"SELECT ID, NOME FROM VENDEDOR WHERE EMAIL=@email AND SENHA=@senha";

            

            MySqlCommand Command = new MySqlCommand();
            Command.CommandText = sql;
            Command.Parameters.AddWithValue("@email", Email);
            Command.Parameters.AddWithValue("@senha", Senha);

            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(Command);

            if (dt.Rows.Count ==1)
            {
                Id = dt.Rows[0]["ID"].ToString();
                Nome = dt.Rows[0]["NOME"].ToString();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
