#pragma checksum "D:\TT\Finalarms\ARMS\Areas\Water\Views\WaterMeterReadings\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "115328d3059e9f2f8ac67144d2346437a97fce6b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Water_Views_WaterMeterReadings_Create), @"mvc.1.0.view", @"/Areas/Water/Views/WaterMeterReadings/Create.cshtml")]
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
#nullable restore
#line 1 "D:\TT\Finalarms\ARMS\Areas\Water\Views\WaterMeterReadings\Create.cshtml"
using CORE_BOL;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"115328d3059e9f2f8ac67144d2346437a97fce6b", @"/Areas/Water/Views/WaterMeterReadings/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b4a8197006c533ca3077e7e53fa27a725fee456", @"/Areas/_ViewImports.cshtml")]
    public class Areas_Water_Views_WaterMeterReadings_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WaterMeterReadingModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-danger btn-lg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Go Back"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("id_zoneid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control col-sm-8 select2bs4"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", new global::Microsoft.AspNetCore.Html.HtmlString("0"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("id_yearid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("id_Pmonthid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control col-sm-6 select2bs4"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/jquery/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\TT\Finalarms\ARMS\Areas\Water\Views\WaterMeterReadings\Create.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""content-header"">
    <div class=""container-fluid"">
        <div class=""row mb-2"">
            <div class=""col-sm-6"">
                <h1 class=""m-0 text-dark""></h1>
            </div>
            <div class=""col-sm-6"">
                <ol class=""breadcrumb float-sm-right"">
                    <li class=""breadcrumb-item"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "115328d3059e9f2f8ac67144d2346437a97fce6b8593", async() => {
                WriteLiteral("Water Meter Reading");
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
            WriteLiteral("</li>\r\n                    <li class=\"breadcrumb-item active\">Water Transaction</li>\r\n                </ol>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "115328d3059e9f2f8ac67144d2346437a97fce6b9942", async() => {
                WriteLiteral("\r\n    <div class=\"card card-info\">\r\n        <div class=\"card-header\">\r\n            <h3 class=\"card-title\">Search Details</h3>\r\n        </div>\r\n        <div class=\"card-body\">\r\n            <p>\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "115328d3059e9f2f8ac67144d2346437a97fce6b10427", async() => {
                    WriteLiteral("<i class=\"fas fa-backward\"></i> Go Back");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            </p>\r\n            <div class=\"row d-flex justify-content-center\">\r\n                <div class=\"input-group d-flex justify-content-center col-3\">\r\n                    <label class=\"col-sm-4 col-form-label\">Zone</label>\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "115328d3059e9f2f8ac67144d2346437a97fce6b12121", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
#nullable restore
#line 36 "D:\TT\Finalarms\ARMS\Areas\Water\Views\WaterMeterReadings\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = (new SelectList (@ViewBag.ZoneId,"Value","Text")) ;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                </div>\r\n                <div class=\"input-group d-flex justify-content-center col-3\">\r\n                    <label class=\"col-sm-4 col-form-label\">Year</label>\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "115328d3059e9f2f8ac67144d2346437a97fce6b14052", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
#nullable restore
#line 41 "D:\TT\Finalarms\ARMS\Areas\Water\Views\WaterMeterReadings\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = (new SelectList (@ViewBag.YearId,"Value","Text")) ;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                </div>\r\n                <div class=\"input-group d-flex justify-content-center col-4\">\r\n                    <label class=\"col-6 col-form-label\">Previous Month</label>\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "115328d3059e9f2f8ac67144d2346437a97fce6b15990", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
#nullable restore
#line 46 "D:\TT\Finalarms\ARMS\Areas\Water\Views\WaterMeterReadings\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = (new SelectList (@ViewBag.MonthId,"Value","Text")) ;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                </div>
                <div class=""input-group-append col-2"">
                    <input type=""button"" value=""search"" class=""btn btn-primary"" onclick=""return createWaterMeterReading();"" />
                </div>
            </div>
        </div>
    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<!--Water Meter Reading-->
<div id=""WMR_table"" style=""display:none;"">
    <div class=""card card-info"">
        <div class=""card-header"">
            <h3 class=""card-title"">Water Meter Reading</h3>
        </div>
        <div class=""form-group row card-body"">
            <table id=""tbl_id_WaterMeterReading"" class=""table table-bordered table-striped"">
                <thead>

                    <tr>
                        <th>#</th>
");
            WriteLiteral(@"                        <th>Acc No</th>
                        <th>Meter No</th>
                        <th>Prev. Reading</th>
                        <th>Prev. Reading Date</th>
                        <th>Current Meter Reading</th>
                        <th>Consumption</th>
                        <th>Current Meter Reading Date</th>
                        <th>Meter Read By</th>
                    </tr>
                </thead>
                <tbody id=""mybody"">
                </tbody>
            </table>
            <div class=""input-group-append col-2 pt-2"">
                <input type=""button"" value=""Submit"" class=""btn btn-primary"" id=""id_SaveWMR""/>
            </div>
        </div>
    </div>
</div>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "115328d3059e9f2f8ac67144d2346437a97fce6b20517", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<script>
    //Display Tax Prayer Profile By CID
    function createWaterMeterReading() {
                $('#WMR_table').hide(1000);
                $('#id_zoneid').insertAfter(function () {
                    var zoneId = $('#id_zoneid').val();
                    var yearId = $('#id_yearid').val();
                    var PmonthId = $('#id_Pmonthid').val();

                    if (zoneId == zoneId && yearId == yearId && PmonthId == PmonthId ) {
                        $.ajax({
                            type: ""GET"",
                            url: '");
#nullable restore
#line 102 "D:\TT\Finalarms\ARMS\Areas\Water\Views\WaterMeterReadings\Create.cshtml"
                             Write(Url.Action("getWaterMeterReadingDetails", "WaterMeterReadings"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                            data: {
                                zone: zoneId,
                                year: yearId,
                                month: PmonthId
                            },
                            success: function (data) {
                                console.log(data);
                                $('#mybody').empty();

                                if (data.length > 0) {
                                    $.each(data, function (key, value) {
                                        $('#WMR_table').show(1000);

                                        //Displaying Date
                                        const d = new Date(value.previousReadingDate);
                                        const previousReadingDate = d.getFullYear() + '-' + (""0"" + (d.getMonth() + 1)).slice(-2) + '-' + (""0"" + d.getDate()).slice(-2)

                                        $('#mybody').append(
                                            '<tr>'
           ");
            WriteLiteral(@"                                 + '<td hidden> <input id=""hdnWCid"" class=""form-control"" value=' + value.waterConnectionId + ' /> </td>'
                                            + '<td hidden> <input id=""hdnWCSid"" class=""form-control"" value=' + value.waterConnectionStatusId + ' /> </td>'
                                            + '<td hidden> <input id=""hdnWCTid"" class=""form-control"" value=' + value.waterConnectionTypeId + ' /> </td>'
                                            + '<td hidden> <input id=""hdnWLTid"" class=""form-control"" value=' + value.waterLineTypeId + ' /> </td>'
                                            + '<td hidden> <input id=""hdnWMTid"" class=""form-control"" value=' + value.waterMeterTypeId + ' /> </td>'
                                            + '<td hidden> <input id=""hdnBillingAddress""  class=""form-control"" value=' + value.billingAddress + ' /> </td>'
                                            + '<td hidden> <input id=""hdnNoOfUnits""  class=""form-control"" value=' + value.");
            WriteLiteral(@"noOfUnit + ' /> </td>'
                                            + '<td hidden> <input id=""hdnPMNo""  class=""form-control"" value=' + value.primaryMobileNo + ' /> </td>'
                                            + '<td hidden> <input id=""id_MeterReadBy"" class=""form-control"" value=' + value.zoneId + ' readonly /> </td>'
                                            + '<td hidden> <input id=""hdnTransactionId"" class=""form-control"" value=' + value.transactionId + ' readonly /> </td>'
                                            + '<td hidden> <input id=""hdnSConsumption"" class=""form-control"" value=' + value.standardConsumption + ' readonly /> </td>'

                                            + '<td>' + (key + 1) + '</td>'
                                            //+ '<td>' + null + '</td>'
                                            + '<td>' + value.consumerNo + '</td>'
                                            + '<td>' + value.waterMeterNo + '</td>'
                                            + '<");
            WriteLiteral(@"td hidden> <input id=""hdnPreviousReading""  class=""form-control"" value=' + value.previousReading + ' /> </td>'
                                            + '<td>' + value.previousReading + '</td>'
                                            + '<td>' + previousReadingDate + '</td>'
                                            + '<td> <input id=""id_CMReading"" type=""number"" class=""form-control"" /> </td>'
                                            + '<td> <input id=""id_Consumption"" onChange=""display(this)"" type=""number"" class=""form-control"" value=' + value.consumption + ' readonly /> </td>'
                                            + '<td> <input id=""id_CMRDate"" type=""date"" class=""form-control"" /></td>'
                                            + '<td> <input style=""width: 100%;""  class=""form-control"" value=' + value.zoneReader + ' readonly /> </td>');
                                    });
                                    

                                }
                                else");
            WriteLiteral(@" {
                                    $('#WMR_table').hide(1000);

                                    swal({
                                        title: 'Please Enter valid Data',
                                        type: 'error',
                                        confirmButtonText: 'OK'
                                    });
                                }
                            },
                            error: function () {
                                alert('error');
                            }

                        });
                    } else {

                        swal({
                            title: 'Fields cannot be empty!',
                            type: 'error',
                            confirmButtonText: 'OK'
                        });
                    }

                });
            }

    //Saving WMR data
    $(""#id_SaveWMR"").click(function () {

        var myarray = [];
        //for (i = 0; i < $(""#tbl_");
            WriteLiteral(@"id_WaterMeterReading TBODY TR"").length - 1; i++) {
            var WaterMeterReadingModel = {};

        WaterMeterReadingModel.Reading = parseInt($(""#id_CMReading"").val());
        WaterMeterReadingModel.Consumption = parseInt($(""#id_Consumption"").val());
        WaterMeterReadingModel.ReadingDate = $(""#id_CMRDate"").val();
        WaterMeterReadingModel.ReadBy = parseInt($(""#id_MeterReadBy"").val());

        WaterMeterReadingModel.WaterConnectionId = parseInt($('#hdnWCid').val());
        WaterMeterReadingModel.WaterConnectionStatusId = parseInt($('#hdnWCSid').val());
        WaterMeterReadingModel.WaterConnectionTypeId = parseInt($('#hdnWCTid').val());
        WaterMeterReadingModel.WaterLineTypeId = parseInt($('#hdnWLTid').val());
        WaterMeterReadingModel.WaterMeterTypeId = parseInt($('#hdnWMTid').val());
        WaterMeterReadingModel.NoOfUnit = parseInt($('#hdnNoOfUnits').val());
        WaterMeterReadingModel.BillingAddress = $('#hdnBillingAddress').val();
        WaterMeterReadingM");
            WriteLiteral(@"odel.PrimaryMobileNo = $('#hdnPMNo').val();
        WaterMeterReadingModel.PreviousReading = parseInt($('#hdnPreviousReading').val());
        WaterMeterReadingModel.TransactionId = parseInt($('#hdnTransactionId').val());
        WaterMeterReadingModel.StandardConsumption = parseInt($('#hdnSConsumption').val());

            myarray.push(WaterMeterReadingModel);
        //}
        var json_data = JSON.stringify(myarray);
        console.log(json_data);
        
         $('#img').show();

        $.ajax({
            type: ""POST"",
            url: '");
#nullable restore
#line 209 "D:\TT\Finalarms\ARMS\Areas\Water\Views\WaterMeterReadings\Create.cshtml"
             Write(Url.Action("CreateWMR", "WaterMeterReadings"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
            data: json_data,
            contentType: ""application/json; charset=utf-8"",
            dataType: ""json"",
            success: function (response) {
                $('#img').hide();
                swal(response);
                               
            },
            failure: function () {
                $('#img').hide();
                swal(""Creation Failed"");
            },
            error: function () {
                $('#img').hide();
                swal(""Error while inserting"");
            }
        });
    });

</script>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WaterMeterReadingModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
