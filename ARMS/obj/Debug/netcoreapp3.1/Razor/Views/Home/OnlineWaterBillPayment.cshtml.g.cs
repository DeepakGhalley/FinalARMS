#pragma checksum "D:\TT\Finalarms\ARMS\Views\Home\OnlineWaterBillPayment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a2f58ffe0ee7c264370774c1fca4b068d12bf568"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_OnlineWaterBillPayment), @"mvc.1.0.view", @"/Views/Home/OnlineWaterBillPayment.cshtml")]
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
#line 1 "D:\TT\Finalarms\ARMS\Views\Home\OnlineWaterBillPayment.cshtml"
using CORE_BOL;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\TT\Finalarms\ARMS\Views\Home\OnlineWaterBillPayment.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a2f58ffe0ee7c264370774c1fca4b068d12bf568", @"/Views/Home/OnlineWaterBillPayment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b4a8197006c533ca3077e7e53fa27a725fee456", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_OnlineWaterBillPayment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BfsModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/dist/img/loader.gif"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width: 100px; height: 100px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control col-sm-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PaymentGateWayRedirect", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/sweetalert/sweetalert.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/jquery/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/sweetalert/sweetalert.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/sweetalert/sweetalert.init.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "D:\TT\Finalarms\ARMS\Views\Home\OnlineWaterBillPayment.cshtml"
  
    ViewData["Title"] = "OnlineWaterBillPayment";
    Layout = "~/Views/Shared/_Layout1.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"dialog-background\" style=\"display:none\" id=\"img\">\r\n    <div class=\"dialog-loading-wrapper\">\r\n        <span class=\"dialog-loading-icon\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a2f58ffe0ee7c264370774c1fca4b068d12bf5688655", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</span>\r\n    </div>\r\n</div>\r\n<div class=\"card card-info\" id=\"dvtop\">\r\n\r\n    <div class=\"card-header\">\r\n        <h3 class=\"card-title\">Search Water Bill Details</h3>\r\n    </div>\r\n    <div class=\"card-body\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a2f58ffe0ee7c264370774c1fca4b068d12bf56810007", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 21 "D:\TT\Finalarms\ARMS\Views\Home\OnlineWaterBillPayment.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

        <div class=""form-group row"">
            <label class=""col-sm-2 col-form-label"">Consumer No <span style=""font-weight: bold; color: red;"">*</span></label>
            <div class=""col-sm-3"">
                <input id=""consumerno"" class=""form-control"" />

            </div>
");
            WriteLiteral("            <div class=\"col-sm-3\">\r\n                <button class=\"btn btn-primary\" onclick=\"return GetDemandWithSearchWaterBill();\">Search</button>\r\n\r\n");
            WriteLiteral(@"            </div>
        </div>

    </div>
</div>


<!--Demand Details-->
<div class=""card card-info"" style=""display:none;"" id=""dvDemand"">
    <div class=""card-header"">
        <h3 class=""card-title"">View Water Demand Details</h3>
    </div>
    <input type=""hidden"" id=""hdnTransactionTypeId"" />
    <div class=""card-body"">
        <div class=""col-12 table-responsive"">
            <table id=""example1"" class=""table table-bordered table-striped"">
                <thead style=""background-color:mediumaquamarine"">
                    <tr>
                        <th>#</th>
                        <th>Demand No </th>
                        <th>Demand Amount </th>
                        <th>Exemption Amount</th>
                        <th>Total Amount</th>

                    </tr>
                </thead>
                <tbody id=""tbl_body"">
                </tbody>
            </table>
        </div>

        <div class=""form-group row"">
            <label class=""col-sm-2 col-");
            WriteLiteral(@"form-label""></label>
            <div class=""col-sm-3"">
                <button class=""btn btn-primary"" onclick=""return GetDemandDetailWaterBill();"">Proceed</button>&nbsp;
                <button class=""btn btn-danger"" onclick=""return Cancel1();"">Cancel</button>
            </div>
        </div>



    </div>
</div>

<!--Search Info-->
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a2f58ffe0ee7c264370774c1fca4b068d12bf56813570", async() => {
                WriteLiteral(@"
    <div class=""card card-info"" id=""dvDemandDetail"" style=""display: none;"">
        <div class=""card-header"">
            <h3 class=""card-title"">View Water Bill Details</h3>
        </div>
        <div class=""card-body"">
            <div class=""form-group row"" style=""display: none;"">
                <label class=""col-sm-2 col-form-label"">Meter No</label>
                <div class=""col-sm-4"">
                    <input class=""form-control"" readonly id=""IDmeterNo"" />
                </div>
                <label class=""col-sm-2 col-form-label"">Consumer No</label>
                <div class=""col-sm-4"">
                    <input class=""form-control"" readonly id=""IDconsumerNo"" />
                </div>
            </div>
            <div class=""row"">
                <div class=""col-12 table-responsive"">
                    <table id=""tblDemands"" class=""table table-bordered table-striped"">
                        <thead style=""background-color:mediumaquamarine"">

                            ");
                WriteLiteral(@"<tr>
                                <th>#</th>
                                <th>Tax Name</th>
                                <th>Exemption Amount</th>
                                <th>Penalty</th>
                                <th>Demand Amount</th>
                                <th>Total Amount</th>
                            </tr>
                        </thead>
                        <tbody id=""tbl_body2"">
                        </tbody>
                    </table>

                </div>
            </div>

            <div class=""form-group row"">
                <label class=""col-sm-2 col-form-label"">Net Payable Amount(Nu.):</label>
");
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a2f58ffe0ee7c264370774c1fca4b068d12bf56815670", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 122 "D:\TT\Finalarms\ARMS\Views\Home\OnlineWaterBillPayment.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.BfsTxnAmount);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("readonly", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(" \r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a2f58ffe0ee7c264370774c1fca4b068d12bf56817572", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("hidden", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
#nullable restore
#line 123 "D:\TT\Finalarms\ARMS\Views\Home\OnlineWaterBillPayment.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.DemandIds);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("readonly", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
            </div>

            <div class=""form-group row"">
                <label class=""col-sm-2 col-form-label""></label>
                <div class=""col-sm-5"">

                    <button type=""submit"" class=""btn btn-primary""><i class=""far fa-credit-card""></i> Submit Payment</button> &nbsp;
                    <a class=""btn btn-danger"" style=""color: white;"" onclick=""Cancel();""><i class=""fas fa-times"" style=""color: white;""></i> Cancel</a>
                  
                </div>
                <label class=""col-sm-0 col-form-label""></label>
                <div class=""col-sm-2"">
                    

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
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a2f58ffe0ee7c264370774c1fca4b068d12bf56821964", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a2f58ffe0ee7c264370774c1fca4b068d12bf56823083", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a2f58ffe0ee7c264370774c1fca4b068d12bf56824127", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    <!-- scripit init-->\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a2f58ffe0ee7c264370774c1fca4b068d12bf56825200", async() => {
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
    $(document).ready(function () {
        $('#consumerno').focus();
    });
    /* $('#btnPay').on('click', function () {*/
    function FindDemandIds() {
        $('#img').show();
        var selected = new Array();
        var ids;

        //Reference the CheckBoxes and insert the checked CheckBox value in Array.
        $(""#tblDemands input[type=checkbox]:checked"").each(function () {
            selected.push(this.value);
        });
        //Display the selected CheckBox values.
        if (selected.length > 0) {
            ids = selected.join("","");
        }
        else {
            swal('Please select at least one Demand No to pay.!');
            return false;
        }
        $(""#DemandIds"").val(ids);
        //$(""#BfsTxnAmount"").val($(""#total"").val());
    }

    function payTax1() {
        $('#payFrame').show(1000);
        $('html,body').animate({
            scrollTop: $(""#payFrame"").offset().top
        }, 'slow');

        //document.getEle");
            WriteLiteral(@"mentById(""frame"").innerHTML = ""<iframe src=\""/PaymentGateWayRedirect\"" height=\""200\"" width=\""300\"" ></iframe>"";
    }

    function Cancel1() {
        $('#dvDemand').hide(1000);
        $('html,body').animate({
            scrollTop: $(""#dvtop"").offset().top
        }, 'slow');
    }

    function Cancel() {
        $('#dvDemandDetail').hide(1000);
        $('html,body').animate({
            scrollTop: $(""#dvDemand"").offset().top
        }, 'slow');
    }

    function GetDemandWithSearchWaterBill() {
        if ($(""#consumerno"").val() == """" ) {
            swal('Required','Enter consumer no.!','warning');
            $(""#consumerno"").focus();

            return false;
        }
        //swal($(""#demandNo"").val());
        $('#img').show();

        $.ajax({
                type: ""GET"",
                url: '");
#nullable restore
#line 209 "D:\TT\Finalarms\ARMS\Views\Home\OnlineWaterBillPayment.cshtml"
                 Write(Url.Action("GetDemandWithSearchWaterBill", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                data: {
                    ConsumerNo: ($(""#consumerno"").val()),

            },
                success: function (data) {
                console.log(data);
                    $('#tbl_body').empty();
                    //Changed from == 0 to >0
                    if (data.length > 0) {

                        $(""#dvDemand"").show(1000);
                        $('html,body').animate({
                            scrollTop: $(""#dvDemand"").offset().top
                        }, 'slow');


                        $.each(data, function (key, value) {
                            $('#tbl_body').append(
                                '<tr>' + '<td>' + (key + 1) + '</td>'

                                + '<td><input id=""id_' + key + '"" type=""hidden"" value=""' + value.demandNoId + '"" />'
                                + '<input id=""chk_' + key + '"" type=""checkbox"" checked disabled value=""' + value.demandNoId + '"" class""=checkbox"" style=""display: none;"" /> <label for=c");
            WriteLiteral(@"hk_' + key + '> </label>' + value.demandNo + '</td>'
                                + '<td>' + value.demandAmount + '</td>'
                                + '<td>' + value.exemptionAmount + '</td>'
                                + '<td>' + value.totalAmount + '</td>'

                                + '</tr>');
                        });

                        $('#img').hide();
                        $('html,body').animate({
                            scrollTop: $(""#dvDemand"").offset().top
                        }, 'slow');

                    }
                    else {
                        $('#img').hide();
                        $(""#dvDemand"").hide(1000);
                        swal('Information', 'No pending bills found!', 'info');
                        return false;
                    }

                },
                    error: function () {
                    $('#img').hide();
                    alert('Error occured');
                    }
           ");
            WriteLiteral(@"     });
    }


    function GetDemandDetailWaterBill() {
        var selected = new Array();
        var ids;


        //Reference the CheckBoxes and insert the checked CheckBox value in Array.
        $(""#example1 input[type=checkbox]:checked"").each(function () {
            selected.push(this.value);
        });

        //Display the selected CheckBox values.
        if (selected.length > 0) {
            ids = selected.join("","");
        }
        else {
            swal('Please select at least one Demand No to pay.!');
            return false;
        }
         $.ajax({
            type: ""GET"",
            url: '");
#nullable restore
#line 281 "D:\TT\Finalarms\ARMS\Views\Home\OnlineWaterBillPayment.cshtml"
             Write(Url.Action("FetOnlinePaymentStatus", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                data: {
                    DemandNoIds: ids
                },
            success: function (data) {
                console.log(data);
                $('#tbl_body2').empty();
                if (data.length > 0) {
                    swal(""Please visit/call Thromde to settle your incomplete payment."");
                }
                else {
                  //IF NOT SUCCESS

                        $.ajax({
                            type: ""GET"",
                            url: '");
#nullable restore
#line 296 "D:\TT\Finalarms\ARMS\Views\Home\OnlineWaterBillPayment.cshtml"
                             Write(Url.Action("GetWaterDemandDetail", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\',\r\n                                //url: \'");
#nullable restore
#line 297 "D:\TT\Finalarms\ARMS\Views\Home\OnlineWaterBillPayment.cshtml"
                                   Write(Url.Action("GetDemandDetailWaterBill", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                                data: {
                                    id: ids

                                },
                            success: function (data) {

                                var MeterNo = data[0].meterNo;
                                $('#IDmeterNo').val(MeterNo);
                                var ConsumerNo = data[0].consumerNo;
                                $('#IDconsumerNo').val(ConsumerNo);

                                //fro Total Amount
                                var total = [];

                                console.log(data);
                                $('#tbl_body2').empty();
                                //Changed from == 0 to >0
                                if (data.length > 0) {

                                    $(""#dvDemandDetail"").show(1000);
                                    $('html,body').animate({
                                        scrollTop: $(""#dvDemandDetail"").offset().top
                      ");
            WriteLiteral(@"              }, 'slow');

                                    var tpenalty = 0;
                                    var gttlamt = 0;
                                    var dttlamt = 0;

                                    $.each(data, function (key, value) {

                                        var exmpamt = value.exemptionAmount;
                                        if (value.exemptionAmount == null) {
                                            exmpamt = 0;
                                        }
                                        var ttlamt = 0;
                                        ttlamt = value.totalAmount + value.totalPenaltyAmount;
                                        tpenalty += value.totalPenaltyAmount;

                                        dttlamt += value.demandAmount;

                                        gttlamt += ttlamt;

                                        $('#tbl_body2').append(
                                            '<tr>'
          ");
            WriteLiteral(@"                                  + '<td>' + (key + 1) + '</td>'
                                            + '<td hidden><input id=""id_' + key + '"" type=""hidden"" value=""' + value.demandId + '"" />'
                                            + '<input id=""chk_' + key + '"" type=""checkbox"" checked disabled value=""' + value.demandId + '"" class""=checkbox"" style=""display: none;"" /> <label for=chk_' + key + '> </label>' + value.demandId + '</td>'

                                            + '<td>' + value.taxName + '</td>'
                                            + '<td>' + exmpamt + '</td>'
                                            + '<td>' + value.totalPenaltyAmount.toFixed(2) + '</td>'
                                            + '<td>' + value.totalAmount + '</td>'
                                            + '<td>' + ttlamt.toFixed(2)  + '</td>'


                                            + '</tr>');
                                });
                        //for Calculating Total Am");
            WriteLiteral(@"ount
                        for (var i = 0; i <= data.length; i++) {
                            total[i] = (data[i].totalAmount + data[i].totalPenaltyAmount);
                            var sum = total.reduce(function (a, b) {
                                return a + b;
                            }, 0);

                            $('#BfsTxnAmount').val(sum.toFixed(2));
                            FindDemandIds();
                            $('#img').hide();
                        }

                        //$('#tbl_body2').append('<tr>' + '<td colspan=""5"" align=""Right"" style=""font-weight:bold;""> Grand Total</td>' + '<td colspan=""1"" style=""font-weight:bold;"">' + data[0].grandTotalAmount + '</td>'
                        //    + '</tr>');

                        //$('html,body').animate({
                        //    scrollTop: $(""#dvDemandDetail"").offset().top
                        //}, 'slow');

                    }
                                    else {
              ");
            WriteLiteral(@"          $('#img').hide();
                        $(""#dvDemandDetail"").show(1000);
                        $('#tbl_body2').append(
                            '<tr><td colspan=""7"" style=""color: red;"">No record found!</td></tr>');
                    }

                                },
                                    error: function () {
                                    $('#img').hide();
                                    alert('Error occured');
                                    }
                        });

                  }

                 },
                    error: function () {
                    $('#img').hide();
                    alert('Error occured');
                    }
         });
        //



    }


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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BfsModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
