#pragma checksum "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b2ec2abd659bee3380cee87f3316dd279aa11045"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_WaterMaster_Views_WaterMeterReadings_Delete), @"mvc.1.0.view", @"/Areas/WaterMaster/Views/WaterMeterReadings/Delete.cshtml")]
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
#line 1 "D:\TT\Finalarms\ARMS\Areas\_ViewImports.cshtml"
using ARMS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\TT\Finalarms\ARMS\Areas\_ViewImports.cshtml"
using ARMS.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b2ec2abd659bee3380cee87f3316dd279aa11045", @"/Areas/WaterMaster/Views/WaterMeterReadings/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b4a8197006c533ca3077e7e53fa27a725fee456", @"/Areas/_ViewImports.cshtml")]
    public class Areas_WaterMaster_Views_WaterMeterReadings_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CORE_BOL.Entities.TrnWaterMeterReading>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
  
    ViewData["Title"] = "Delete";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Delete</h1>\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4>TrnWaterMeterReading</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 16 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Bucid));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 19 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Bucid));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 22 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Reading));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 25 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Reading));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 28 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.PreviousReading));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 31 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.PreviousReading));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 34 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.PreviousReadingDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 37 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.PreviousReadingDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 40 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.ReadBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 43 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.ReadBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 46 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.ReadingDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 49 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.ReadingDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 52 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.NoOfUnit));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 55 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.NoOfUnit));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 58 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Consumption));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 61 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Consumption));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 64 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.StandardConsumption));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 67 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.StandardConsumption));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 70 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.IsPermanentConnection));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 73 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.IsPermanentConnection));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 76 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Sewerage));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 79 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Sewerage));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 82 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.SolidWaste));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 85 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.SolidWaste));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 88 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Remarks));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 91 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Remarks));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 94 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.BillingAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 97 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.BillingAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 100 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.TransactionId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 103 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.TransactionId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 106 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.PrimaryMobileNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 109 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.PrimaryMobileNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 112 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.SecondaryMobileNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 115 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.SecondaryMobileNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 118 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.TrnWaterConnection));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 121 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.TrnWaterConnection.BillingAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd class>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 124 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.WaterConnectionStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 127 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.WaterConnectionStatus.WaterConnectionStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd class>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 130 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.WaterConnectionType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 133 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.WaterConnectionType.WaterConnectionType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd class>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 136 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.WaterLineType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 139 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.WaterLineType.WaterLineType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd class>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 142 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.WaterMeterType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 145 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.WaterMeterType.WaterMeterType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd class>\r\n    </dl>\r\n    \r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b2ec2abd659bee3380cee87f3316dd279aa1104519337", async() => {
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b2ec2abd659bee3380cee87f3316dd279aa1104519604", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 150 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.TrnWaterMeterReadingId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Delete\" class=\"btn btn-danger\" /> |\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b2ec2abd659bee3380cee87f3316dd279aa1104521410", async() => {
                    WriteLiteral("Back to List");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CORE_BOL.Entities.TrnWaterMeterReading> Html { get; private set; }
    }
}
#pragma warning restore 1591
