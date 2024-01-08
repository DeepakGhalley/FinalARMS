#pragma checksum "D:\TT\Finalarms\ARMS\Views\Shared\_SidebarMenu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f3ca53c6d887917dfaf7dcc705a759a1b92be338"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__SidebarMenu), @"mvc.1.0.view", @"/Views/Shared/_SidebarMenu.cshtml")]
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
#line 1 "D:\TT\Finalarms\ARMS\Views\_ViewImports.cshtml"
using ARMS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\TT\Finalarms\ARMS\Views\_ViewImports.cshtml"
using ARMS.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\TT\Finalarms\ARMS\Views\Shared\_SidebarMenu.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f3ca53c6d887917dfaf7dcc705a759a1b92be338", @"/Views/Shared/_SidebarMenu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b4a8197006c533ca3077e7e53fa27a725fee456", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__SidebarMenu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("nav-link active"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("nav-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/jquery/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\TT\Finalarms\ARMS\Views\Shared\_SidebarMenu.cshtml"
  

    CORE_BLL.MenuBLL m_obj = new CORE_BLL.MenuBLL();
    var p_roleid = Convert.ToInt32(Context.Session.GetInt32("RoleId"));

    List<CORE_BOL.MenuViewModel> menuLst = new List<CORE_BOL.MenuViewModel>();
    menuLst = m_obj.GetMenus(p_roleid);


#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div id='cssmenu'>
    <ul class=""nav nav-pills nav-sidebar flex-column dropdownmenu"" data-widget=""treeview"" role=""menu"" data-accordion=""false"">
        <!-- Add icons to the links using the .nav-icon class
        with font-awesome or any other icon font library -->
");
#nullable restore
#line 16 "D:\TT\Finalarms\ARMS\Views\Shared\_SidebarMenu.cshtml"
          
            if (Context.Session.GetInt32("user_id") != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"nav-item has-treeview menu-open\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f3ca53c6d887917dfaf7dcc705a759a1b92be3386333", async() => {
                WriteLiteral("\r\n                        <i style=\"color:aquamarine;\" class=\"nav-icon fas fa-tachometer-alt\"></i>\r\n                        <p>\r\n                            Dashboard\r\n                        </p>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </li>\r\n");
#nullable restore
#line 27 "D:\TT\Finalarms\ARMS\Views\Shared\_SidebarMenu.cshtml"

            }
            else
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "D:\TT\Finalarms\ARMS\Views\Shared\_SidebarMenu.cshtml"
                           
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 44 "D:\TT\Finalarms\ARMS\Views\Shared\_SidebarMenu.cshtml"
          
            if (menuLst != null)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "D:\TT\Finalarms\ARMS\Views\Shared\_SidebarMenu.cshtml"
                 foreach (var item in menuLst)
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "D:\TT\Finalarms\ARMS\Views\Shared\_SidebarMenu.cshtml"
                                                
                {
                    //var id = (int)item["MenuId"];

                    if (item.MenuParentId == 0)
                    {

                        var submenu = menuLst.Where(n => n.MenuParentId == item.MenuId).ToList();
                        if (submenu != null && submenu.Count > 0)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <li class=""nav-item has-treeview dropdownsubmenu"">
                                <a class=""nav-link"" style=""cursor: pointer;"">
                                    <i style=""color:aquamarine;"" class=""nav-icon fas fa-copy""></i>
                                    <p class=""text-white"">
                                        ");
#nullable restore
#line 62 "D:\TT\Finalarms\ARMS\Views\Shared\_SidebarMenu.cshtml"
                                   Write(item.MenuName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        <i class=\"fas fa-angle-left right\"></i>\r\n");
            WriteLiteral("                                    </p>\r\n                                </a>\r\n\r\n                                <ul class=\"nav nav-treeview dropdownmenu\" >\r\n");
#nullable restore
#line 69 "D:\TT\Finalarms\ARMS\Views\Shared\_SidebarMenu.cshtml"
                                     foreach (var e in submenu)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <li class=\"nav-item\" style=\"font-size:12px;\">\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f3ca53c6d887917dfaf7dcc705a759a1b92be33810927", async() => {
                WriteLiteral("\r\n                                                <i style=\"color:gold; margin-left: 5px;\" class=\"far fa-arrow-alt-circle-right nav-icon\"></i>\r\n                                                <p class=\"text-warning\">");
#nullable restore
#line 74 "D:\TT\Finalarms\ARMS\Views\Shared\_SidebarMenu.cshtml"
                                                                   Write(e.MenuName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n\r\n                                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 72 "D:\TT\Finalarms\ARMS\Views\Shared\_SidebarMenu.cshtml"
                                                              WriteLiteral(e.AreaName);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-area", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 72 "D:\TT\Finalarms\ARMS\Views\Shared\_SidebarMenu.cshtml"
                                                                                           WriteLiteral(e.ControllerName);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-controller", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 72 "D:\TT\Finalarms\ARMS\Views\Shared\_SidebarMenu.cshtml"
                                                                                                                          WriteLiteral(e.ActionName);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-action", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "title", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 72 "D:\TT\Finalarms\ARMS\Views\Shared\_SidebarMenu.cshtml"
AddHtmlAttributeValue("", 3163, e.MenuName, 3163, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        </li>\r\n");
#nullable restore
#line 81 "D:\TT\Finalarms\ARMS\Views\Shared\_SidebarMenu.cshtml"
                                                   
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </ul>\r\n                            </li>\r\n");
#nullable restore
#line 85 "D:\TT\Finalarms\ARMS\Views\Shared\_SidebarMenu.cshtml"

                        }
                        else
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 89 "D:\TT\Finalarms\ARMS\Views\Shared\_SidebarMenu.cshtml"
                                                                                                                           
                        }
                    }


                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 94 "D:\TT\Finalarms\ARMS\Views\Shared\_SidebarMenu.cshtml"
                 
            }

        

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    </ul>\r\n</div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f3ca53c6d887917dfaf7dcc705a759a1b92be33816269", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"


<script>

    $(document).ready(function () {

        $('.dropdownsubmenu a.nav-link').on(""click"", function (e) {
            
            $(this).parent().parent().find('.dropdownmenu').hide();
            $(this).next('ul').toggle(""open"");
            e.stopPropagation();
            //e.preventDefault();
           
        });

    });

  


</script>");
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