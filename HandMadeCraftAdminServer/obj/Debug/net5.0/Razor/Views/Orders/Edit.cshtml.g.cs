#pragma checksum "D:\work\final_year_greenwich_project\HandMadeCraftAdminServer\HandMadeCraftAdminServer\HandMadeCraftAdminServer\Views\Orders\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "91bd183c916f29bd40542c94b308ea574d7d87bd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Orders_Edit), @"mvc.1.0.view", @"/Views/Orders/Edit.cshtml")]
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
#line 1 "D:\work\final_year_greenwich_project\HandMadeCraftAdminServer\HandMadeCraftAdminServer\HandMadeCraftAdminServer\Views\_ViewImports.cshtml"
using HandMadeCraftAdminServer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\work\final_year_greenwich_project\HandMadeCraftAdminServer\HandMadeCraftAdminServer\HandMadeCraftAdminServer\Views\_ViewImports.cshtml"
using HandMadeCraftAdminServer.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\work\final_year_greenwich_project\HandMadeCraftAdminServer\HandMadeCraftAdminServer\HandMadeCraftAdminServer\Views\_ViewImports.cshtml"
using HandMadeCraftAdminServer.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"91bd183c916f29bd40542c94b308ea574d7d87bd", @"/Views/Orders/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aa23f5883907d72b4d74e8e6e9dc25443904a1c6", @"/Views/_ViewImports.cshtml")]
    public class Views_Orders_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HandMadeCraftAdminServer.Models.Order.Order>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\work\final_year_greenwich_project\HandMadeCraftAdminServer\HandMadeCraftAdminServer\HandMadeCraftAdminServer\Views\Orders\Edit.cshtml"
  
    ViewBag.Title = "Edit Order";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container mt-5\">\r\n    <h2>Edit Order</h2>\r\n\r\n    <div class=\"mt-3\">\r\n");
#nullable restore
#line 12 "D:\work\final_year_greenwich_project\HandMadeCraftAdminServer\HandMadeCraftAdminServer\HandMadeCraftAdminServer\Views\Orders\Edit.cshtml"
         using (Html.BeginForm())
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\work\final_year_greenwich_project\HandMadeCraftAdminServer\HandMadeCraftAdminServer\HandMadeCraftAdminServer\Views\Orders\Edit.cshtml"
       Write(Html.HiddenFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"form-group\">\r\n                <label>User ID</label>\r\n                ");
#nullable restore
#line 17 "D:\work\final_year_greenwich_project\HandMadeCraftAdminServer\HandMadeCraftAdminServer\HandMadeCraftAdminServer\Views\Orders\Edit.cshtml"
           Write(Html.TextBoxFor(model => model.UserId, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <!-- Other fields of the order with pre-filled values -->\r\n");
            WriteLiteral("            <button type=\"submit\" class=\"btn btn-primary\">Save</button>\r\n");
#nullable restore
#line 22 "D:\work\final_year_greenwich_project\HandMadeCraftAdminServer\HandMadeCraftAdminServer\HandMadeCraftAdminServer\Views\Orders\Edit.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HandMadeCraftAdminServer.Models.Order.Order> Html { get; private set; }
    }
}
#pragma warning restore 1591