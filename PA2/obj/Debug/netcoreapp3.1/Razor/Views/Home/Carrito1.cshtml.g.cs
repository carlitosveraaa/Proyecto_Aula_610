#pragma checksum "D:\Escuela\6IM10\ProyectoAula\PA2\PA2\Views\Home\Carrito1.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4aeefed2b75d38f37c497ab8a7cbdcdb35768b977c2c2744793f32d738127318"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Carrito1), @"mvc.1.0.view", @"/Views/Home/Carrito1.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Escuela\6IM10\ProyectoAula\PA2\PA2\Views\_ViewImports.cshtml"
using PA2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Escuela\6IM10\ProyectoAula\PA2\PA2\Views\_ViewImports.cshtml"
using PA2.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"4aeefed2b75d38f37c497ab8a7cbdcdb35768b977c2c2744793f32d738127318", @"/Views/Home/Carrito1.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"fd4a3c728920d802e4fa22c315abee3558ce16473e7ea5176cabcdddf0648514", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Carrito1 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\Escuela\6IM10\ProyectoAula\PA2\PA2\Views\Home\Carrito1.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4aeefed2b75d38f37c497ab8a7cbdcdb35768b977c2c2744793f32d7381273183577", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <meta name=""viewport"" content=""width=device, initial-scale=1.0"">
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.2/css/all.min.css""
          integrity=""sha512-SnH5WK+bZxgPHs44uWIX+LLJAJ9/2PkPKZ5QiAj6Ta86w+fsb2TkcmfRyVX3pBnMFcV7oQPJkl9QevSCWr3W6A==""
          crossorigin=""anonymous"" referrerpolicy=""no-referrer"" />
    <script src=""carrito.js"" async></script>
    <link rel=""stylesheet"" href=""Carrito.css"">

    <title>Carrito de compras</title>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4aeefed2b75d38f37c497ab8a7cbdcdb35768b977c2c2744793f32d7381273185183", async() => {
                WriteLiteral(@"
    
    <header>
        <h1>Carrito de compras</h1>
    </header>
    <section class=""contenedor"">
        <div class=""contenedor-items"">
            <div class=""item"">
                <span class=""titulo-item"">Balatas1</span>
                <img src=""img/imgcarrito/balatas1.jpeg""");
                BeginWriteAttribute("alt", " alt=\"", 964, "\"", 970, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""img-item"">
                <span class=""precio-item"">$120.00</span>
                <button class=""boton-item"">Agregar al carrito</button>
            </div>
            <div class=""item"">
                <span class=""titulo-item"">Balatas2</span>
                <img src=""img/imgcarrito/balatas2.jpeg""");
                BeginWriteAttribute("alt", " alt=\"", 1287, "\"", 1293, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""img-item"">
                <span class=""precio-item"">$180.00</span>
                <button class=""boton-item"">Agregar al carrito</button>
            </div>
            <div class=""item"">
                <span class=""titulo-item"">Balatas3</span>
                <img src=""img/imgcarrito/balatas3.jpeg""");
                BeginWriteAttribute("alt", " alt=\"", 1610, "\"", 1616, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""img-item"">
                <span class=""precio-item"">$160.00</span>
                <button class=""boton-item"">Agregar al carrito</button>
            </div>
            <div class=""item"">
                <span class=""titulo-item"">Balatas4</span>
                <img src=""img/imgcarrito/balatas4.jpeg""");
                BeginWriteAttribute("alt", " alt=\"", 1933, "\"", 1939, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""img-item"">
                <span class=""precio-item"">$130.00</span>
                <button class=""boton-item"">Agregar al carrito</button>
            </div>
            <div class=""item"">
                <span class=""titulo-item"">Balatas5</span>
                <img src=""img/imgcarrito/balatas1.jpeg""");
                BeginWriteAttribute("alt", " alt=\"", 2256, "\"", 2262, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""img-item"">
                <span class=""precio-item"">$190.00</span>
                <button class=""boton-item"">Agregar al carrito</button>
            </div>
            <div class=""item"">
                <span class=""titulo-item"">Balatas6</span>
                <img src=""img/imgcarrito/balatas2.jpeg""");
                BeginWriteAttribute("alt", " alt=\"", 2579, "\"", 2585, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""img-item"">
                <span class=""precio-item"">$220.00</span>
                <button class=""boton-item"">Agregar al carrito</button>
            </div>
            <div class=""item"">
                <span class=""titulo-item"">Balatas7</span>
                <img src=""img/imgcarrito/balatas3.jpeg""");
                BeginWriteAttribute("alt", " alt=\"", 2902, "\"", 2908, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""img-item"">
                <span class=""precio-item"">$240.00</span>
                <button class=""boton-item"">Agregar al carrito</button>
            </div>
            <div class=""item"">
                <span class=""titulo-item"">Balatas8</span>
                <img src=""img/imgcarrito/balatas4.jpeg""");
                BeginWriteAttribute("alt", " alt=\"", 3225, "\"", 3231, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""img-item"">
                <span class=""precio-item"">$235.00</span>
                <button class=""boton-item"">Agregar al carrito</button>
            </div>
            <div class=""item"">
                <span class=""titulo-item"">Balatas9</span>
                <img src=""img/imgcarrito/balatas1.jpeg""");
                BeginWriteAttribute("alt", " alt=\"", 3548, "\"", 3554, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""img-item"">
                <span class=""precio-item"">$256.00</span>
                <button class=""boton-item"">Agregar al carrito</button>
            </div>
        </div>

        <div class=""carrito"">
            <div class=""header-carrito"">
                <h2>Tu carrito</h2>
            </div>
            
            <div class=""carrito-items"">
                <!--
                <div class=""carrito-item"">
                    <img src=""img/balatas1.jpeg"" alt="""" width=""80px"">
                    <div class=""carrito-item-detalles"">
                        <span class=""carrito-item-titulo"">Balatas1</span>
                        <div class=""selector-cantidad"">
                            <i class=""fa-solid fa-minus restar-cantidad""></i>
                            <input type=""text"" value=""1"" class=""carrito-item-cantidad"" disabled>
                            <i class=""fa-solid fa-plus sumar-cantidad""></i>
                        </div>
                        <span class=""ca");
                WriteLiteral(@"rrito-item-precio"">$120.00</span>
                    </div>
                    <span class=""btn-eliminar"">
                        <i class=""fa-solid fa-trash""></i>
                    </span>
                </div>
                <div class=""carrito-item"">
                    <img src=""img/balatas2.jpeg"" alt="""" width=""80px"">
                    <div class=""carrito-item-detalles"">
                        <span class=""carrito-item-titulo"">Balatas2</span>
                        <div class=""selector-cantidad"">
                            <i class=""fa-solid fa-minus restar-cantidad""></i>
                            <input type=""text"" value=""2"" class=""carrito-item-cantidad"" disabled>
                            <i class=""fa-solid fa-plus sumar-cantidad""></i>
                        </div>
                        <span class=""carrito-item-precio"">$180.00</span>
                    </div>
                    <span class=""btn-eliminar"">
                        <i class=""fa-solid fa-trash""></i>
");
                WriteLiteral(@"                    </span>
                </div>
                -->
            </div>

            <div class=""carrito-total"">
                <div class=""fila"">
                    <strong>Tu Total</strong>
                    <span class=""carrito-precio-total"">
                        $480.00
                    </span>
                </div>
                <button class=""btn-pagar"">Pagar <i class=""fa-solid fa-bag-shopping""></i></button>
            </div>
        </div>

    </section>

    <script src=""https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js""
            integrity=""sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz""
            crossorigin=""anonymous"">
    </script>

");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
