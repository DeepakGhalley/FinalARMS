#pragma checksum "D:\TT\Finalarms\ARMS\Views\Home\pgRedirect.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a780699fac9b2485c33d615763b5b53831d6841c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_pgRedirect), @"mvc.1.0.view", @"/Views/Home/pgRedirect.cshtml")]
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
#line 2 "D:\TT\Finalarms\ARMS\Views\Home\pgRedirect.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a780699fac9b2485c33d615763b5b53831d6841c", @"/Views/Home/pgRedirect.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b4a8197006c533ca3077e7e53fa27a725fee456", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_pgRedirect : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/jquery/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("runat", new global::Microsoft.AspNetCore.Html.HtmlString("server"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("form1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("http://uatbfssecure.rma.org.bt/BFSSecure/makePayment"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\TT\Finalarms\ARMS\Views\Home\pgRedirect.cshtml"
  
    ViewData["Title"] = "OnlineWaterBillPayment";
    Layout = "~/Views/Shared/_Layout1.cshtml";

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\TT\Finalarms\ARMS\Views\Home\pgRedirect.cshtml"
  
    var bfs_benfBankCode = Context.Session.GetString("bfs_benfBankCode");
    var BenificiaryID = Context.Session.GetString("BenificiaryID");

    var trnTime = Context.Session.GetString("bfs_benfTxnTime");
    var bfs_msgType = Context.Session.GetString("bfs_msgType");

    var orderNo = Context.Session.GetString("bfs_orderNo");
    var bfs_paymentDesc = Context.Session.GetString("bfs_paymentDesc");

    var email = Context.Session.GetString("bfs_remitterEmail");
    var bfs_txnCurrency = Context.Session.GetString("bfs_txnCurrency");

    var bfs_txnAmount = Context.Session.GetString("bfs_txnAmount");
    var BFSVersion = Context.Session.GetString("bfs_version");
    var SignedString = Context.Session.GetString("bfs_checkSum");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<!DOCTYPE html>\r\n\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a780699fac9b2485c33d615763b5b53831d6841c6750", async() => {
                WriteLiteral("\r\n    <title></title>\r\n\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a780699fac9b2485c33d615763b5b53831d6841c7039", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"

    <script lang=""javascript"" type=""text/javascript"">

        $(document).ready(function () {

            redirectToBFS();

        });
        function redirectToBFS() {
            
            document.forms[0].submit();
        }

    </script>

");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a780699fac9b2485c33d615763b5b53831d6841c9200", async() => {
                WriteLiteral("\r\n\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a780699fac9b2485c33d615763b5b53831d6841c9466", async() => {
                    WriteLiteral("\r\n        <div>\r\n            <input type=\"hidden\"");
                    BeginWriteAttribute("value", " value=\"", 1585, "\"", 1610, 1);
#nullable restore
#line 59 "D:\TT\Finalarms\ARMS\Views\Home\pgRedirect.cshtml"
WriteAttributeValue("", 1593, bfs_benfBankCode, 1593, 17, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" name=\"bfs_benfBankCode\" />\r\n            <input type=\"hidden\"");
                    BeginWriteAttribute("value", " value=\"", 1672, "\"", 1694, 1);
#nullable restore
#line 60 "D:\TT\Finalarms\ARMS\Views\Home\pgRedirect.cshtml"
WriteAttributeValue("", 1680, BenificiaryID, 1680, 14, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" name=\"bfs_benfId\" />\r\n            <input type=\"hidden\"");
                    BeginWriteAttribute("value", " value=\"", 1750, "\"", 1766, 1);
#nullable restore
#line 61 "D:\TT\Finalarms\ARMS\Views\Home\pgRedirect.cshtml"
WriteAttributeValue("", 1758, trnTime, 1758, 8, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" name=\"bfs_benfTxnTime\" />\r\n            <input type=\"hidden\"");
                    BeginWriteAttribute("value", " value=\"", 1827, "\"", 1847, 1);
#nullable restore
#line 62 "D:\TT\Finalarms\ARMS\Views\Home\pgRedirect.cshtml"
WriteAttributeValue("", 1835, bfs_msgType, 1835, 12, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" name=\"bfs_msgType\" />\r\n            <input type=\"hidden\"");
                    BeginWriteAttribute("value", " value=\"", 1904, "\"", 1920, 1);
#nullable restore
#line 63 "D:\TT\Finalarms\ARMS\Views\Home\pgRedirect.cshtml"
WriteAttributeValue("", 1912, orderNo, 1912, 8, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" name=\"bfs_orderNo\" />\r\n            <input type=\"hidden\"");
                    BeginWriteAttribute("value", " value=\"", 1977, "\"", 2001, 1);
#nullable restore
#line 64 "D:\TT\Finalarms\ARMS\Views\Home\pgRedirect.cshtml"
WriteAttributeValue("", 1985, bfs_paymentDesc, 1985, 16, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" name=\"bfs_paymentDesc\" />\r\n            <input type=\"hidden\"");
                    BeginWriteAttribute("value", " value=\"", 2062, "\"", 2076, 1);
#nullable restore
#line 65 "D:\TT\Finalarms\ARMS\Views\Home\pgRedirect.cshtml"
WriteAttributeValue("", 2070, email, 2070, 6, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" name=\"bfs_remitterEmail\" />\r\n            <input type=\"hidden\"");
                    BeginWriteAttribute("value", " value=\"", 2139, "\"", 2161, 1);
#nullable restore
#line 66 "D:\TT\Finalarms\ARMS\Views\Home\pgRedirect.cshtml"
WriteAttributeValue("", 2147, bfs_txnAmount, 2147, 14, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" name=\"bfs_txnAmount\" />\r\n            <input type=\"hidden\"");
                    BeginWriteAttribute("value", " value=\"", 2220, "\"", 2244, 1);
#nullable restore
#line 67 "D:\TT\Finalarms\ARMS\Views\Home\pgRedirect.cshtml"
WriteAttributeValue("", 2228, bfs_txnCurrency, 2228, 16, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" name=\"bfs_txnCurrency\" />\r\n            <input type=\"hidden\"");
                    BeginWriteAttribute("value", " value=\"", 2305, "\"", 2324, 1);
#nullable restore
#line 68 "D:\TT\Finalarms\ARMS\Views\Home\pgRedirect.cshtml"
WriteAttributeValue("", 2313, BFSVersion, 2313, 11, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" name=\"bfs_version\" />\r\n            <input type=\"hidden\"");
                    BeginWriteAttribute("value", " value=\"", 2381, "\"", 2402, 1);
#nullable restore
#line 69 "D:\TT\Finalarms\ARMS\Views\Home\pgRedirect.cshtml"
WriteAttributeValue("", 2389, SignedString, 2389, 13, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" name=\"bfs_checkSum\" />\r\n\r\n            <input type=\"submit\" value=\"Pay via BFS Secure\">\r\n\r\n        </div>\r\n    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
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
            WriteLiteral("\r\n</html>\r\n\r\n");
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
