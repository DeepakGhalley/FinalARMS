#pragma checksum "D:\TT\Finalarms\ARMS\Areas\MiscellaneousRecord\Views\MiscellaneousRecords\MiscellaneousReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0bd0bf40cd6dd8c17bf5550a32d5a3f663321207"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_MiscellaneousRecord_Views_MiscellaneousRecords_MiscellaneousReport), @"mvc.1.0.view", @"/Areas/MiscellaneousRecord/Views/MiscellaneousRecords/MiscellaneousReport.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0bd0bf40cd6dd8c17bf5550a32d5a3f663321207", @"/Areas/MiscellaneousRecord/Views/MiscellaneousRecords/MiscellaneousReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b4a8197006c533ca3077e7e53fa27a725fee456", @"/Areas/_ViewImports.cshtml")]
    public class Areas_MiscellaneousRecord_Views_MiscellaneousRecords_MiscellaneousReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CORE_BOL.MiscellaneousRecordModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control select2bs4"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width: 100%;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("TaxId"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", new global::Microsoft.AspNetCore.Html.HtmlString("0"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\TT\Finalarms\ARMS\Areas\MiscellaneousRecord\Views\MiscellaneousRecords\MiscellaneousReport.cshtml"
  
    ViewData["Title"] = "Report";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0bd0bf40cd6dd8c17bf5550a32d5a3f6633212076364", async() => {
                WriteLiteral(@"
    <div class=""content-header"">
        <div class=""container-fluid"">
            <div class=""row mb-2"">
                <div class=""col-sm-6"">
                    <h1 class=""m-0 text-dark""></h1>
                </div><!-- /.col -->
                <div class=""col-sm-6"">
                    <ol class=""breadcrumb float-sm-right"">
                        <li class=""breadcrumb-item"">");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0bd0bf40cd6dd8c17bf5550a32d5a3f6633212077029", async() => {
                    WriteLiteral("Miscellaneous Record");
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
                WriteLiteral(@"</li>
                        <li class=""breadcrumb-item active"">Miscellaneous Record Details</li>
                    </ol>
                </div><!-- /.col -->
            </div><!-- /.row -->
        </div><!-- /.container-fluid -->
    </div>
    <!-- /.content-header -->


    <div class=""card card-info"">
");
#nullable restore
#line 37 "D:\TT\Finalarms\ARMS\Areas\MiscellaneousRecord\Views\MiscellaneousRecords\MiscellaneousReport.cshtml"
         if (TempData["msg"] != null)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"            <div class=""alert alert-success alert-dismissible"">
                <button type=""button"" class=""close"" data-dismiss=""alert"" aria-hidden=""true"">&times;</button>
                <h5><i class=""icon fas fa-check""></i> Alert!</h5>
                <p>");
#nullable restore
#line 42 "D:\TT\Finalarms\ARMS\Areas\MiscellaneousRecord\Views\MiscellaneousRecords\MiscellaneousReport.cshtml"
              Write(TempData["msg"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n            </div>\r\n");
#nullable restore
#line 44 "D:\TT\Finalarms\ARMS\Areas\MiscellaneousRecord\Views\MiscellaneousRecords\MiscellaneousReport.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
        <div class=""card-header"">
            <h3 class=""card-title"">Miscellaneous Record</h3>
        </div>
        <!-- /.card-header -->
        <div class=""card-body"">
        
            <div class=""form-group row"">
                <div class=""input-group d-flex justify-content-center col-5"">
                    <label class=""col-sm-5 col-form-label"">Miscellaneous Type<span style=""font-weight: bold; color:red;"">*</span></label>
                    <div class=""col-sm-5"">
                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0bd0bf40cd6dd8c17bf5550a32d5a3f66332120710176", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
#nullable restore
#line 56 "D:\TT\Finalarms\ARMS\Areas\MiscellaneousRecord\Views\MiscellaneousRecords\MiscellaneousReport.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = (new SelectList (@ViewBag.TaxId,"Value","Text")) ;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                        </div>
                    </div>
                </div>
                <div class=""form-group row"">
                    <div class=""input-group d-flex justify-content-center col-5"">
                        <label class=""col-sm-4 col-form-label"">From Date<span style=""font-weight: bold; color: red;""></span></label>
                        <input id=""idfromdate"" type=""date"" class=""form-control col-5"" />
                    </div>

                    <div class=""input-group d-flex justify-content-center col-5"">
                        <label class=""col-sm-4 col-form-label"">To Date<span style=""font-weight: bold; color: red;""></span></label>
                        <input id=""idtodate"" type=""date"" class=""form-control col-5"" />
                    </div>

                    <div class=""input-group-append col-2"">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input type=""button"" value=""Search"" class=""btn btn-primary"" onclick=""return ");
                WriteLiteral("displaydataDetails();\" />\r\n                    </div>\r\n                </div>\r\n\r\n            </div>\r\n    </div>\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"


<div class=""card card-info"" style=""display:none;"" id=""ec_renewal"">
    <div class=""card card-info"" id=""dvPrint"">
        <div class=""card-header"">
            <h3 class=""card-title"">Miscellaneous Details</h3>
        </div>
        <div class=""card-body"">
            <table id=""example1"" class=""table table-bordered table-striped"" border=""1"" style="" border-collapse: collapse; "" width=""100%"">
                <thead style=""background-color:mediumaquamarine"">

                    <tr>
                        <th>Sl.no</th>
                        <th>Name</th>
                        <th>Address</th>
                        <th>CID No.</th>
                        <th>Mobile No.</th>
                        <th>Quantity</th>

                        <th>Amount</th>

                        <th>Tax</th>


                    </tr>
                </thead>
                <tbody id=""tbl_body"">
                </tbody>
                <tr><td></td><td></td><td></td><td></td><td></td><");
            WriteLiteral("td align=\"right\"><b>Total :</b></td><td><label id=\"tamount\"");
            BeginWriteAttribute("value", " value=\"", 4399, "\"", 4407, 0);
            EndWriteAttribute();
            WriteLiteral(@" class=""col-form-label"" readonly /> </td><td></td></tr>

            </table>
        </div>
    </div>
    <button class=""btn btn-warning"" onclick=""return printPage();""><i class=""fas fa-print""></i>Print</button>
</div>









    <script>


    //Display Details

    function displaydataDetails() {

        var TaxId = ($('#TaxId').val());
            var Name = $('#Name').val();
            var fromdate = $('#idfromdate').val();
            var todate = $('#idtodate').val();

                $.ajax({
                    type: ""GET"",
                    url: '");
#nullable restore
#line 139 "D:\TT\Finalarms\ARMS\Areas\MiscellaneousRecord\Views\MiscellaneousRecords\MiscellaneousReport.cshtml"
                     Write(Url.Action("Report", "MiscellaneousRecords"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                    data: {

                        TaxId: TaxId,
                        fromdate: fromdate,
                        todate: todate
                    },
                    success: function (data) {
                        $('#tbl_body').empty();
                        if (data.length > 0) {
                            var TPA = 0;
                            $.each(data, function (key, value) {
                                $('#ec_renewal').show(1000);
                                TPA += value.amount;
                                $('#tbl_body').append(
                                    '<tr>'
                                    + '<td>' + (key + 1) + '</td>'
                                    + '<td>' + value.name + '</td>'
                                    + '<td>' + value.address + '</td>'
                                    + '<td>' + value.cid + '</td>'
                                    + '<td>' + value.mobileNo + '</td>'
                      ");
            WriteLiteral(@"              + '<td>' + value.quantity + '</td>'

                                    + '<td>' + value.amount + '</td>'

                                    + '<td>' + value.tax + '</td>'


                                    + '</tr>');
                            });

                            $(""#tamount"").html(TPA.toFixed(2));
                       } else {
                            $('#tbl_body').append(
                                '<tr><td colspan=""4"" style=""color: red;"">No record found!</td></tr>');
                            swal({
                                title: 'Please Enter valid Value!',
                                type: 'error',
                                confirmButtonText: 'OK'
                            });
                        }

                    },

                    error: function () {
                        alert('error');
                    }




        });

    }



        function printPage() {


            ");
            WriteLiteral("var dataToPrint = document.getElementById(\"dvPrint\");\r\n            newWin = window.open(\"\");\r\n            newWin.document.write(dataToPrint.outerHTML);\r\n            newWin.print();\r\n            newWin.close();\r\n        }\r\n\r\n\r\n\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CORE_BOL.MiscellaneousRecordModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
