#pragma checksum "C:\Users\Administrador\Documents\desa\TicketTurno\TicketParcial\Areas\Identity\Pages\_AuthLayout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "394faf487493342dee744f9f372dc9f0e5e3d1db"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Identity_Pages__AuthLayout), @"mvc.1.0.view", @"/Areas/Identity/Pages/_AuthLayout.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Administrador\Documents\desa\TicketTurno\TicketParcial\Areas\Identity\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Administrador\Documents\desa\TicketTurno\TicketParcial\Areas\Identity\Pages\_ViewImports.cshtml"
using TicketParcial.Areas.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Administrador\Documents\desa\TicketTurno\TicketParcial\Areas\Identity\Pages\_ViewImports.cshtml"
using TicketParcial.Areas.Identity.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Administrador\Documents\desa\TicketTurno\TicketParcial\Areas\Identity\Pages\_ViewImports.cshtml"
using TicketParcial.Areas.Identity.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"394faf487493342dee744f9f372dc9f0e5e3d1db", @"/Areas/Identity/Pages/_AuthLayout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12944a7e8ca92b001d698e10b68e38acc28109cb", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    public class Areas_Identity_Pages__AuthLayout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Administrador\Documents\desa\TicketTurno\TicketParcial\Areas\Identity\Pages\_AuthLayout.cshtml"
  
    Layout = "/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row d-flex justify-content-center"">
    <div class=""col-12 col-sm-10 col-md-8 col-lg-6"">
        <div class=""card shadow"">
            <div class=""card-header font-weight-bold"">
                Iniciar sesión
            </div>
            <div class=""card-content p-4"">
                ");
#nullable restore
#line 12 "C:\Users\Administrador\Documents\desa\TicketTurno\TicketParcial\Areas\Identity\Pages\_AuthLayout.cshtml"
           Write(RenderBody());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 19 "C:\Users\Administrador\Documents\desa\TicketTurno\TicketParcial\Areas\Identity\Pages\_AuthLayout.cshtml"
Write(RenderSection("Scripts", required: false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
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
