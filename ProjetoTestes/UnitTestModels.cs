using SistemaVendas_MVC.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace ProjetoTestes
{
    public class UnitTestModels
    {
        [Fact]
        public void TestLoginOk()
        {
            LoginModel loginModel = new LoginModel();
            loginModel.Email = "exemplo@email.com";
            loginModel.Senha = "123456";
            bool result = loginModel.ValidarLogin();
            Assert.True(result);
        }     
        
        [Fact]
        public void TestLoginFail()
        {
            LoginModel loginModel = new LoginModel();
            loginModel.Email = "exemplo@email.com";
            loginModel.Senha = "teste";
            bool result = loginModel.ValidarLogin();
            Assert.False(result);
        }        
        
        [Fact]
        public void TestListaProdutos()
        {
            ProdutoModel produtoModel = new ProdutoModel();
            var lista = produtoModel.ListarTodosOsProdutos();
            Assert.IsType<List<ProdutoModel>>(lista);
        }
    }
}
