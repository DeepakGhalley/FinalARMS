#pragma checksum "D:\TT\Finalarms\ARMS\Areas\Reports\Views\Report\AssetMaintenanceReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d89bca5dbb2ecc555ac012e10df855c3a47bfb2c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Reports_Views_Report_AssetMaintenanceReport), @"mvc.1.0.view", @"/Areas/Reports/Views/Report/AssetMaintenanceReport.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d89bca5dbb2ecc555ac012e10df855c3a47bfb2c", @"/Areas/Reports/Views/Report/AssetMaintenanceReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b4a8197006c533ca3077e7e53fa27a725fee456", @"/Areas/_ViewImports.cshtml")]
    public class Areas_Reports_Views_Report_AssetMaintenanceReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\TT\Finalarms\ARMS\Areas\Reports\Views\Report\AssetMaintenanceReport.cshtml"
  
    ViewData["Title"] = "AssetMaintenanceReport";
    Layout = "~/Views/Shared/_Layout.cshtml";


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d89bca5dbb2ecc555ac012e10df855c3a47bfb2c4215", async() => {
                WriteLiteral(@"
    <div class=""content-header"">
        <div class=""container-fluid"">
            <div class=""row mb-2"">
                <div class=""col-sm-6"">
                    <h1 class=""m-0 text-dark""></h1>
                </div><!-- /.col -->
                <div class=""col-sm-6"">
                    <ol class=""breadcrumb float-sm-right"">
                        <li class=""breadcrumb-item active"">Asset Maintenance Report</li>
                    </ol>
                </div><!-- /.col -->
            </div><!-- /.row -->
        </div><!-- /.container-fluid -->
    </div>
    <!-- /.content-header -->


    <div class=""card card-info"">
");
#nullable restore
#line 28 "D:\TT\Finalarms\ARMS\Areas\Reports\Views\Report\AssetMaintenanceReport.cshtml"
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
#line 33 "D:\TT\Finalarms\ARMS\Areas\Reports\Views\Report\AssetMaintenanceReport.cshtml"
              Write(TempData["msg"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n            </div>\r\n");
#nullable restore
#line 35 "D:\TT\Finalarms\ARMS\Areas\Reports\Views\Report\AssetMaintenanceReport.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
        <div class=""card-header"">
            <h3 class=""card-title"">Asset Maintenance Report</h3>
        </div>
        <!-- /.card-header -->
        <div class=""card-body"">
            <hr />
            <div class=""form-group row"">
                <div class=""input-group d-flex justify-content-center col-4"">
                    <label class=""col-sm-4 col-form-label"">Start Date<span style=""font-weight: bold; color: red;""></span></label>
                    <input id=""lblsdate"" type=""date"" class=""form-control col-6"" required />
                </div>

                <div class=""input-group d-flex justify-content-center col-4"">
                    <label class=""col-sm-4 col-form-label"">End Date<span style=""font-weight: bold; color: red;""></span></label>
                    <input id=""lbledate"" type=""date"" class=""form-control col-6"" required />
                </div>

                <div class=""input-group-append d-flex justify-content-center col-4"">
                    &nbsp;&nbsp;&nbs");
                WriteLiteral("p;&nbsp;&nbsp;&nbsp;\r\n                    <input type=\"button\" value=\"View Report\" class=\"btn btn-primary\" onclick=\"return PrintReport();\" />\r\n                </div>\r\n\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
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
#line 89 "D:\TT\Finalarms\ARMS\Areas\Reports\Views\Report\AssetMaintenanceReport.cshtml"
                        Write(Url.Action("PrintReportAssetMaintenance", "Report"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                       data: {
                           sdate: $(""#lblsdate"").val(),
                           edate: $(""#lbledate"").val()
                       },
                       success: function (data) {
                          if (data.length > 0) {
                              window.open(""");
#nullable restore
#line 96 "D:\TT\Finalarms\ARMS\Areas\Reports\Views\Report\AssetMaintenanceReport.cshtml"
                                      Write(Url.RouteUrl(new
                                     { Area ="Reports",Controller = "Report", Action = "PrintReportAssetMaintenance" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/?sdate="" + $(""#lblsdate"").val() + ""&edate="" + $(""#lbledate"").val(),'_blank');
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
