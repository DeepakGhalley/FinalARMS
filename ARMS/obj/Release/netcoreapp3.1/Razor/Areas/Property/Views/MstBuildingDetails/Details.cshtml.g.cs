#pragma checksum "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d2a20feb7acdcdd278f94f1cfc408222400369d8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Property_Views_MstBuildingDetails_Details), @"mvc.1.0.view", @"/Areas/Property/Views/MstBuildingDetails/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d2a20feb7acdcdd278f94f1cfc408222400369d8", @"/Areas/Property/Views/MstBuildingDetails/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b4a8197006c533ca3077e7e53fa27a725fee456", @"/Areas/_ViewImports.cshtml")]
    public class Areas_Property_Views_MstBuildingDetails_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CORE_BOL.Entities.MstBuildingDetail>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>MstBuildingDetail</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 15 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.BuildingClassId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 18 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.BuildingClassId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 21 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.BuildingNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 24 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.BuildingNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 27 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.BuildupArea));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 30 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.BuildupArea));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 33 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PlinthArea));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 36 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.PlinthArea));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 39 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.NoOfUnits));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 42 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.NoOfUnits));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 45 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.NumberOfFloors));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 48 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.NumberOfFloors));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 51 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.OccupancyCertificateNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 54 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.OccupancyCertificateNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 57 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.YearOfConstruction));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 60 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.YearOfConstruction));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 63 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.OccupancyCertificateIssued));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 66 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.OccupancyCertificateIssued));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 69 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.OccupancyCertificateIssueDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 72 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.OccupancyCertificateIssueDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 75 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PaymentCompletionStatusId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 78 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.PaymentCompletionStatusId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 81 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.WaterConnection));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 84 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.WaterConnection));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 87 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SewerageConnection));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 90 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.SewerageConnection));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 93 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Attic));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 96 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.Attic));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 99 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ArchFeature));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 102 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.ArchFeature));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 105 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Roofing));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 108 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.Roofing));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 111 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.TraditionalPainting));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 114 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.TraditionalPainting));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 117 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Plantation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 120 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.Plantation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 123 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.NumberDisplayed));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 126 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.NumberDisplayed));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 129 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.FireExtingusher));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 132 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.FireExtingusher));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 135 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.RoadAccess));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 138 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.RoadAccess));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 141 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DrainToStormWaterDrain));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 144 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.DrainToStormWaterDrain));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 147 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DateOfFinalInspection));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 150 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.DateOfFinalInspection));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 153 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.OccupancyAlteredOn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 156 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.OccupancyAlteredOn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 159 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.OccupancyAlteredBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 162 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.OccupancyAlteredBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 165 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.OccupancyReferenceId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 168 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.OccupancyReferenceId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 171 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.AdvanceInfoFedBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 174 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.AdvanceInfoFedBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 177 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.AdvanceInfoInfoFedOn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 180 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.AdvanceInfoInfoFedOn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 183 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Remarks));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 186 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.Remarks));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 189 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ModificationRemarks));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 192 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.ModificationRemarks));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 195 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ModificationReasonId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 198 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.ModificationReasonId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 201 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.TransactionId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 204 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.TransactionId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 207 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CreatedBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 210 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.CreatedBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 213 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CreatedOn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 216 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.CreatedOn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 219 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ModifiedBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 222 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.ModifiedBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 225 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ModifiedOn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 228 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.ModifiedOn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 231 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.BoundaryType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 234 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.BoundaryType.BoundaryType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 237 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.BuildingColour));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 240 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.BuildingColour.BuildingColourType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 243 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ConstructionType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 246 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.ConstructionType.ConstructionType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 249 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.GarbagServiceAccessibility));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 252 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.GarbagServiceAccessibility.ServiceAccessibilityType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 255 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.LandDetail));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 258 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.LandDetail.PlotAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 261 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.MaterialType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 264 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.MaterialType.MaterialType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 267 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ParkingSlot));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 270 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.ParkingSlot.ParkingSlotName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 273 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.RoofingType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 276 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.RoofingType.RoofingType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 279 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.StreetLightAccessibility));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 282 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.StreetLightAccessibility.ServiceAccessibilityType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 285 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.StructureCategory));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 288 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.StructureCategory.StructureCategory));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 291 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.StructureType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 294 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.StructureType.StructureType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 297 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.WaterSupplyAccessibility));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 300 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.WaterSupplyAccessibility.ServiceAccessibilityType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 303 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.WaterTankLocation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 306 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
       Write(Html.DisplayFor(model => model.WaterTankLocation.WaterTankLocation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d2a20feb7acdcdd278f94f1cfc408222400369d836286", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 311 "D:\TT\Finalarms\ARMS\Areas\Property\Views\MstBuildingDetails\Details.cshtml"
                           WriteLiteral(Model.BuildingDetailId);

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
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d2a20feb7acdcdd278f94f1cfc408222400369d838440", async() => {
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CORE_BOL.Entities.MstBuildingDetail> Html { get; private set; }
    }
}
#pragma warning restore 1591