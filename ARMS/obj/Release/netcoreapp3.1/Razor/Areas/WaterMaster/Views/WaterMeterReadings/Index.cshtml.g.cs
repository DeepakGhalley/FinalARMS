#pragma checksum "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1078cc480394ef1cbc01898738b1f4d7deb10bd3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_WaterMaster_Views_WaterMeterReadings_Index), @"mvc.1.0.view", @"/Areas/WaterMaster/Views/WaterMeterReadings/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1078cc480394ef1cbc01898738b1f4d7deb10bd3", @"/Areas/WaterMaster/Views/WaterMeterReadings/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b4a8197006c533ca3077e7e53fa27a725fee456", @"/Areas/_ViewImports.cshtml")]
    public class Areas_WaterMaster_Views_WaterMeterReadings_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CORE_BOL.Entities.TrnWaterMeterReading>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1078cc480394ef1cbc01898738b1f4d7deb10bd34667", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Bucid));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 20 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Reading));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 23 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.PreviousReading));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 26 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.PreviousReadingDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 29 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.ReadBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 32 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.ReadingDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 35 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.NoOfUnit));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 38 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Consumption));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 41 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.StandardConsumption));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 44 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.IsPermanentConnection));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 47 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Sewerage));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 50 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.SolidWaste));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 53 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Remarks));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 56 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.BillingAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 59 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.TransactionId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 62 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.PrimaryMobileNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 65 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.SecondaryMobileNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 68 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.TrnWaterConnection));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 71 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.WaterConnectionStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 74 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.WaterConnectionType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 77 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.WaterLineType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 80 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.WaterMeterType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 86 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 89 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Bucid));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 92 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Reading));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 95 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.PreviousReading));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 98 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.PreviousReadingDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 101 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.ReadBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 104 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.ReadingDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 107 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.NoOfUnit));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 110 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Consumption));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 113 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.StandardConsumption));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 116 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.IsPermanentConnection));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 119 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Sewerage));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 122 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.SolidWaste));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 125 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Remarks));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 128 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.BillingAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 131 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.TransactionId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 134 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.PrimaryMobileNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 137 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.SecondaryMobileNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 140 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.TrnWaterConnection.BillingAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 143 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.WaterConnectionStatus.WaterConnectionStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 146 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.WaterConnectionType.WaterConnectionType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 149 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.WaterLineType.WaterLineType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 152 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.WaterMeterType.WaterMeterType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1078cc480394ef1cbc01898738b1f4d7deb10bd320410", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 155 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
                                       WriteLiteral(item.TrnWaterMeterReadingId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1078cc480394ef1cbc01898738b1f4d7deb10bd322594", async() => {
                WriteLiteral("Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 156 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
                                          WriteLiteral(item.TrnWaterMeterReadingId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1078cc480394ef1cbc01898738b1f4d7deb10bd324784", async() => {
                WriteLiteral("Delete");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 157 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
                                         WriteLiteral(item.TrnWaterMeterReadingId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 160 "D:\TT\Finalarms\ARMS\Areas\WaterMaster\Views\WaterMeterReadings\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CORE_BOL.Entities.TrnWaterMeterReading>> Html { get; private set; }
    }
}
#pragma warning restore 1591
