#pragma checksum "D:\TT\Finalarms\ARMS\Areas\Reports\Views\Report\rptZoneWiseWaterConsumptionFromToDate.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "714718d76e3a5d2524c2d5e9b2251a197d285aa9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Reports_Views_Report_rptZoneWiseWaterConsumptionFromToDate), @"mvc.1.0.view", @"/Areas/Reports/Views/Report/rptZoneWiseWaterConsumptionFromToDate.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"714718d76e3a5d2524c2d5e9b2251a197d285aa9", @"/Areas/Reports/Views/Report/rptZoneWiseWaterConsumptionFromToDate.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b4a8197006c533ca3077e7e53fa27a725fee456", @"/Areas/_ViewImports.cshtml")]
    public class Areas_Reports_Views_Report_rptZoneWiseWaterConsumptionFromToDate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("idZone"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\TT\Finalarms\ARMS\Areas\Reports\Views\Report\rptZoneWiseWaterConsumptionFromToDate.cshtml"
  
    ViewData["Title"] = "rptZoneWiseWaterConsumptionFromToDate";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "714718d76e3a5d2524c2d5e9b2251a197d285aa95141", async() => {
                WriteLiteral(@"
    <div class=""content-header"">
        <div class=""container-fluid"">
            <div class=""row mb-2"">
                <div class=""col-sm-6"">
                    <h1 class=""m-0 text-dark""></h1>
                </div><!-- /.col -->
                <div class=""col-sm-6"">
                    <ol class=""breadcrumb float-sm-right"">
                        
                        <li class=""breadcrumb-item active"">Zone Wise Water Consumption</li>
                    </ol>
                </div><!-- /.col -->
            </div><!-- /.row -->
        </div><!-- /.container-fluid -->
    </div>
    <!-- /.content-header -->


    <div class=""card card-info"">
");
#nullable restore
#line 27 "D:\TT\Finalarms\ARMS\Areas\Reports\Views\Report\rptZoneWiseWaterConsumptionFromToDate.cshtml"
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
#line 32 "D:\TT\Finalarms\ARMS\Areas\Reports\Views\Report\rptZoneWiseWaterConsumptionFromToDate.cshtml"
              Write(TempData["msg"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n            </div>\r\n");
#nullable restore
#line 34 "D:\TT\Finalarms\ARMS\Areas\Reports\Views\Report\rptZoneWiseWaterConsumptionFromToDate.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
        <div class=""card-header"">
            <h3 class=""card-title"">Zone Wise Water Consumption</h3>
        </div>
        <!-- /.card-header -->
        <div class=""card-body"">
            <hr />
            <div class=""form-group row"">
                <div class=""input-group d-flex justify-content-center col-4"">
                    <label class=""col-sm-4 col-form-label"">From Date</label>
                    <input id=""lblsdate"" type=""date"" class=""form-control col-6"" />
                </div>

                <div class=""input-group d-flex justify-content-center col-4"">
                    <label class=""col-sm-4 col-form-label"">To Date</label>
                    <input id=""lbledate"" type=""date"" class=""form-control col-6"" />
                </div>

                <div class=""input-group d-flex justify-content-center col-4"">
                    <label class=""col-sm-4 col-form-label"">Zone</label>
                    <div class=""col-sm-6"">
                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "714718d76e3a5d2524c2d5e9b2251a197d285aa98164", async() => {
                    WriteLiteral("\r\n                        ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#nullable restore
#line 56 "D:\TT\Finalarms\ARMS\Areas\Reports\Views\Report\rptZoneWiseWaterConsumptionFromToDate.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = (new SelectList (@ViewBag.ZoneId,"Value","Text"));

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                        <span id=""zonecid"" class=""text-danger""></span>
                    </div>
                </div>

            </div>

            <div class=""form-group row"">
                <div class=""input-group-append col-3"">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input type=""button"" value=""Search"" class=""btn btn-primary form-control col-6"" onclick=""return PrintReport();"" />
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
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"


<script>
    
    function PrintReport() {
               if ($(""#lblsdate"").val() == """" || $(""#lbledate"").val() == """") {
                   swal(""Please fill both fields to search.!"");
                   $(""#lblsdate"").focus();

                   return false;
               }
               $('#img').show();

               var today = new Date($(""#lblsdate"").val());
               var date = today.getFullYear() + '' + (""0"" + (today.getMonth() + 1)).slice(-2) + '' +( ""0"" + today.getDate()).slice(-2)
               var sdate = date;

               var today1 = new Date($(""#lbledate"").val());
               var date1 = today1.getFullYear() + '' + (""0"" + (today1.getMonth() + 1)).slice(-2) + '' + (""0"" + today1.getDate()).slice(-2)
               var edate = date1;

               console.log(date);

                   $.ajax({
                       type: ""GET"",
                       url: '");
#nullable restore
#line 100 "D:\TT\Finalarms\ARMS\Areas\Reports\Views\Report\rptZoneWiseWaterConsumptionFromToDate.cshtml"
                        Write(Url.Action("PrintZoneWaterConsumption", "Report"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                       data: {
                           FromDate: $(""#lblsdate"").val(),
                           ToDate: $(""#lbledate"").val(),
                           ZoneId: $(""#idZone"").val()
                       },
                       success: function (data) {
                          if (data.length > 0) {
                              window.open(""");
#nullable restore
#line 108 "D:\TT\Finalarms\ARMS\Areas\Reports\Views\Report\rptZoneWiseWaterConsumptionFromToDate.cshtml"
                                      Write(Url.RouteUrl(new
                                  { Area ="Reports",Controller = "Report", Action = "PrintZoneWaterConsumption" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/?FromDate="" + $(""#lblsdate"").val() + ""&ToDate="" + $(""#lbledate"").val() + ""&ZoneId="" + $(""#idZone"").val() ,'_blank');
                           }
                           $('#img').hide();
                       },
                       error: function () {
                           alert('error');
                           $('#img').hide();
                       }
                   });
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591