#pragma checksum "D:\work\final_year_greenwich_project\HandMadeCraftAdminServer\HandMadeCraftAdminServer\HandMadeCraftAdminServer\Views\Orders\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ab16f826c128227e65cf06f5e4a46f861962056e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Orders_Details), @"mvc.1.0.view", @"/Views/Orders/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab16f826c128227e65cf06f5e4a46f861962056e", @"/Views/Orders/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aa23f5883907d72b4d74e8e6e9dc25443904a1c6", @"/Views/_ViewImports.cshtml")]
    public class Views_Orders_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HandMadeCraftAdminServer.Models.Order.Order>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\work\final_year_greenwich_project\HandMadeCraftAdminServer\HandMadeCraftAdminServer\HandMadeCraftAdminServer\Views\Orders\Details.cshtml"
  
    ViewBag.Title = "Order Details";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container mt-5"">
    <div class=""row"">
        <div class=""col-md-8 offset-md-2"">
            <div class=""card"">
                <div class=""card-header"">
                    <h2 class=""card-title"">Order Details</h2>
                </div>
                <div class=""card-body"">
                    <dl class=""row"">
                        <dt class=""col-sm-3"">ID</dt>
                        <dd class=""col-sm-9"">");
#nullable restore
#line 18 "D:\work\final_year_greenwich_project\HandMadeCraftAdminServer\HandMadeCraftAdminServer\HandMadeCraftAdminServer\Views\Orders\Details.cshtml"
                                        Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n                        <dt class=\"col-sm-3\">User ID</dt>\r\n                        <dd class=\"col-sm-9\">");
#nullable restore
#line 21 "D:\work\final_year_greenwich_project\HandMadeCraftAdminServer\HandMadeCraftAdminServer\HandMadeCraftAdminServer\Views\Orders\Details.cshtml"
                                        Write(Model.UserId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n                        <dt class=\"col-sm-3\">Items</dt>\r\n                        <dd class=\"col-sm-9\">\r\n                            <ul class=\"list-unstyled\">\r\n");
#nullable restore
#line 26 "D:\work\final_year_greenwich_project\HandMadeCraftAdminServer\HandMadeCraftAdminServer\HandMadeCraftAdminServer\Views\Orders\Details.cshtml"
                                 foreach (var orderItem in Model.Items)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <li>\r\n                                        <strong>Tutorial ID:</strong> ");
#nullable restore
#line 29 "D:\work\final_year_greenwich_project\HandMadeCraftAdminServer\HandMadeCraftAdminServer\HandMadeCraftAdminServer\Views\Orders\Details.cshtml"
                                                                 Write(orderItem.TutorialId);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - <strong>Price:</strong> ");
#nullable restore
#line 29 "D:\work\final_year_greenwich_project\HandMadeCraftAdminServer\HandMadeCraftAdminServer\HandMadeCraftAdminServer\Views\Orders\Details.cshtml"
                                                                                                                 Write(orderItem.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(", <strong>Quantity:</strong> ");
#nullable restore
#line 29 "D:\work\final_year_greenwich_project\HandMadeCraftAdminServer\HandMadeCraftAdminServer\HandMadeCraftAdminServer\Views\Orders\Details.cshtml"
                                                                                                                                                              Write(orderItem.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </li>\r\n");
#nullable restore
#line 31 "D:\work\final_year_greenwich_project\HandMadeCraftAdminServer\HandMadeCraftAdminServer\HandMadeCraftAdminServer\Views\Orders\Details.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </ul>\r\n                        </dd>\r\n\r\n                        <dt class=\"col-sm-3\">Quantity</dt>\r\n                        <dd class=\"col-sm-9\">");
#nullable restore
#line 36 "D:\work\final_year_greenwich_project\HandMadeCraftAdminServer\HandMadeCraftAdminServer\HandMadeCraftAdminServer\Views\Orders\Details.cshtml"
                                        Write(Model.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n                        <dt class=\"col-sm-3\">Total Price</dt>\r\n                        <dd class=\"col-sm-9\">");
#nullable restore
#line 39 "D:\work\final_year_greenwich_project\HandMadeCraftAdminServer\HandMadeCraftAdminServer\HandMadeCraftAdminServer\Views\Orders\Details.cshtml"
                                        Write(Model.TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n                        <dt class=\"col-sm-3\">Address</dt>\r\n                        <dd class=\"col-sm-9\">");
#nullable restore
#line 42 "D:\work\final_year_greenwich_project\HandMadeCraftAdminServer\HandMadeCraftAdminServer\HandMadeCraftAdminServer\Views\Orders\Details.cshtml"
                                        Write(Model.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n                        <dt class=\"col-sm-3\">Buyer Email</dt>\r\n                        <dd class=\"col-sm-9\">");
#nullable restore
#line 45 "D:\work\final_year_greenwich_project\HandMadeCraftAdminServer\HandMadeCraftAdminServer\HandMadeCraftAdminServer\Views\Orders\Details.cshtml"
                                        Write(Model.BuyerEmail);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n                        <dt class=\"col-sm-3\">Seller Email</dt>\r\n                        <dd class=\"col-sm-9\">");
#nullable restore
#line 48 "D:\work\final_year_greenwich_project\HandMadeCraftAdminServer\HandMadeCraftAdminServer\HandMadeCraftAdminServer\Views\Orders\Details.cshtml"
                                        Write(Model.SellerEmail);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n                        <dt class=\"col-sm-3\">Order Date</dt>\r\n                        <dd class=\"col-sm-9\">");
#nullable restore
#line 51 "D:\work\final_year_greenwich_project\HandMadeCraftAdminServer\HandMadeCraftAdminServer\HandMadeCraftAdminServer\Views\Orders\Details.cshtml"
                                        Write(Model.OrderDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n                        <dt class=\"col-sm-3\">Last Updated</dt>\r\n                        <dd class=\"col-sm-9\">");
#nullable restore
#line 54 "D:\work\final_year_greenwich_project\HandMadeCraftAdminServer\HandMadeCraftAdminServer\HandMadeCraftAdminServer\Views\Orders\Details.cshtml"
                                        Write(Model.LastUpdated);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n                        <dt class=\"col-sm-3\">Creator ID</dt>\r\n                        <dd class=\"col-sm-9\">");
#nullable restore
#line 57 "D:\work\final_year_greenwich_project\HandMadeCraftAdminServer\HandMadeCraftAdminServer\HandMadeCraftAdminServer\Views\Orders\Details.cshtml"
                                        Write(Model.CreatorId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n                        <dt class=\"col-sm-3\">Seller Emails</dt>\r\n                        <dd class=\"col-sm-9\">\r\n                            <ul class=\"list-unstyled\">\r\n");
#nullable restore
#line 62 "D:\work\final_year_greenwich_project\HandMadeCraftAdminServer\HandMadeCraftAdminServer\HandMadeCraftAdminServer\Views\Orders\Details.cshtml"
                                 foreach (var email in Model.SellerEmails ?? Enumerable.Empty<string>())
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <li>");
#nullable restore
#line 64 "D:\work\final_year_greenwich_project\HandMadeCraftAdminServer\HandMadeCraftAdminServer\HandMadeCraftAdminServer\Views\Orders\Details.cshtml"
                                   Write(email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 65 "D:\work\final_year_greenwich_project\HandMadeCraftAdminServer\HandMadeCraftAdminServer\HandMadeCraftAdminServer\Views\Orders\Details.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </ul>\r\n                        </dd>\r\n                    </dl>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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