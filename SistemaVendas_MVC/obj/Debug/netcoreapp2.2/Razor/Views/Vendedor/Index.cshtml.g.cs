#pragma checksum "C:\Users\renan\Desktop\ASP.NETCoreWebAPIv2\SistemaVendas_MVC\SistemaVendas_MVC\Views\Vendedor\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "00097c3472e99815ea176f8c23ede3af01e651ce"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Vendedor_Index), @"mvc.1.0.view", @"/Views/Vendedor/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Vendedor/Index.cshtml", typeof(AspNetCore.Views_Vendedor_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\renan\Desktop\ASP.NETCoreWebAPIv2\SistemaVendas_MVC\SistemaVendas_MVC\Views\_ViewImports.cshtml"
using SistemaVendas_MVC;

#line default
#line hidden
#line 2 "C:\Users\renan\Desktop\ASP.NETCoreWebAPIv2\SistemaVendas_MVC\SistemaVendas_MVC\Views\_ViewImports.cshtml"
using SistemaVendas_MVC.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"00097c3472e99815ea176f8c23ede3af01e651ce", @"/Views/Vendedor/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0bc79c35a76e6dcb5e26c1b26b3a82190e8d45c1", @"/Views/_ViewImports.cshtml")]
    public class Views_Vendedor_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 294, true);
            WriteLiteral(@"<h2>Vendedor</h2>
<hr />

<table class=""table table-bordered"">
    <thead>
        <tr style=""background-color:gray"">
            <th>#</th>
            <th>#</th>
            <th>Id</th>
            <th>Nome</th>
            <th>Email</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 15 "C:\Users\renan\Desktop\ASP.NETCoreWebAPIv2\SistemaVendas_MVC\SistemaVendas_MVC\Views\Vendedor\Index.cshtml"
         foreach (var item in (List<VendedorModel>)ViewBag.ListaVendedores)
        {

#line default
#line hidden
            BeginContext(382, 69, true);
            WriteLiteral("            <tr>\r\n                <td><button class=\"btn btn-warning\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 451, "\"", 477, 3);
            WriteAttributeValue("", 461, "Editar(", 461, 7, true);
#line 18 "C:\Users\renan\Desktop\ASP.NETCoreWebAPIv2\SistemaVendas_MVC\SistemaVendas_MVC\Views\Vendedor\Index.cshtml"
WriteAttributeValue("", 468, item.Id, 468, 8, false);

#line default
#line hidden
            WriteAttributeValue("", 476, ")", 476, 1, true);
            EndWriteAttribute();
            BeginContext(478, 73, true);
            WriteLiteral(">Editar</button></td>\r\n                <td><button class=\"btn btn-danger\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 551, "\"", 578, 3);
            WriteAttributeValue("", 561, "Excluir(", 561, 8, true);
#line 19 "C:\Users\renan\Desktop\ASP.NETCoreWebAPIv2\SistemaVendas_MVC\SistemaVendas_MVC\Views\Vendedor\Index.cshtml"
WriteAttributeValue("", 569, item.Id, 569, 8, false);

#line default
#line hidden
            WriteAttributeValue("", 577, ")", 577, 1, true);
            EndWriteAttribute();
            BeginContext(579, 44, true);
            WriteLiteral(">Excluir</button></td>\r\n                <td>");
            EndContext();
            BeginContext(624, 7, false);
#line 20 "C:\Users\renan\Desktop\ASP.NETCoreWebAPIv2\SistemaVendas_MVC\SistemaVendas_MVC\Views\Vendedor\Index.cshtml"
               Write(item.Id);

#line default
#line hidden
            EndContext();
            BeginContext(631, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(659, 9, false);
#line 21 "C:\Users\renan\Desktop\ASP.NETCoreWebAPIv2\SistemaVendas_MVC\SistemaVendas_MVC\Views\Vendedor\Index.cshtml"
               Write(item.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(668, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(696, 10, false);
#line 22 "C:\Users\renan\Desktop\ASP.NETCoreWebAPIv2\SistemaVendas_MVC\SistemaVendas_MVC\Views\Vendedor\Index.cshtml"
               Write(item.Email);

#line default
#line hidden
            EndContext();
            BeginContext(706, 26, true);
            WriteLiteral("</td>\r\n            </tr>\r\n");
            EndContext();
#line 24 "C:\Users\renan\Desktop\ASP.NETCoreWebAPIv2\SistemaVendas_MVC\SistemaVendas_MVC\Views\Vendedor\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(743, 441, true);
            WriteLiteral(@"    </tbody>
</table>
<button type=""button"" class=""btn btn-block btn-primary"" onclick=""Cadastrar()"">Cadastrar Vendedor</button>
<script>

    function Editar(Id) {
        window.location.href = ""../Vendedor/Cadastro/"" + Id;
    }

    function Excluir(Id) {
        window.location.href = ""../Vendedor/Excluir/"" + Id;
    }

    function Cadastrar() {
        window.location.href = ""../Vendedor/Cadastro"";
    }

</script>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591