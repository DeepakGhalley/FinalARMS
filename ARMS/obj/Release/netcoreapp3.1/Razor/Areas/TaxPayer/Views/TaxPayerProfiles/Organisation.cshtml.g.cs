#pragma checksum "D:\TT\Finalarms\ARMS\Areas\TaxPayer\Views\TaxPayerProfiles\Organisation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "39e9d3d04f144da6717cb6b636dcf6bc3d2627ec"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_TaxPayer_Views_TaxPayerProfiles_Organisation), @"mvc.1.0.view", @"/Areas/TaxPayer/Views/TaxPayerProfiles/Organisation.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"39e9d3d04f144da6717cb6b636dcf6bc3d2627ec", @"/Areas/TaxPayer/Views/TaxPayerProfiles/Organisation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b4a8197006c533ca3077e7e53fa27a725fee456", @"/Areas/_ViewImports.cshtml")]
    public class Areas_TaxPayer_Views_TaxPayerProfiles_Organisation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CORE_BOL.TaxPayerProfileModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("nav-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("tab"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Organisation", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("nav-link active"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Vendor", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateOrganisation", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-danger btn-lg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Add New User"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\TT\Finalarms\ARMS\Areas\TaxPayer\Views\TaxPayerProfiles\Organisation.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "39e9d3d04f144da6717cb6b636dcf6bc3d2627ec6785", async() => {
                WriteLiteral("Revenue Master");
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
                    <li class=""breadcrumb-item active"">Tax Payer Profile Details</li>
                </ol>
            </div><!-- /.col -->
        </div><!-- /.row -->
    </div><!-- /.container-fluid -->
</div>
<!-- /.content-header -->


<div class=""card card-info"">
");
#nullable restore
#line 27 "D:\TT\Finalarms\ARMS\Areas\TaxPayer\Views\TaxPayerProfiles\Organisation.cshtml"
     if (TempData["msg"] != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"alert alert-success alert-dismissible\">\r\n            <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>\r\n            <h5><i class=\"icon fas fa-check\"></i> Alert!</h5>\r\n            <p>");
#nullable restore
#line 32 "D:\TT\Finalarms\ARMS\Areas\TaxPayer\Views\TaxPayerProfiles\Organisation.cshtml"
          Write(TempData["msg"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n");
#nullable restore
#line 34 "D:\TT\Finalarms\ARMS\Areas\TaxPayer\Views\TaxPayerProfiles\Organisation.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <div class=""card-header"">
        <h3 class=""card-title"">ORGANISATION</h3>
    </div>
    <!-- /.card-header -->
    <div class=""card-body"">
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""card card-primary card-tabs"">
                    <div class=""card-header p-0 pt-1"">
                        <ul class=""nav nav-tabs"" id=""custom-tabs-five-tab"" role=""tablist"" style=""cursor:pointer"">
                            <li class=""nav-item"">
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "39e9d3d04f144da6717cb6b636dcf6bc3d2627ec9737", async() => {
                WriteLiteral("Individual");
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
            WriteLiteral("\r\n                            </li>\r\n                            <li class=\"nav-item\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "39e9d3d04f144da6717cb6b636dcf6bc3d2627ec11186", async() => {
                WriteLiteral("Organisation");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </li>\r\n                            <li class=\"nav-item\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "39e9d3d04f144da6717cb6b636dcf6bc3d2627ec12638", async() => {
                WriteLiteral("Vendor");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </li>\r\n                        </ul>\r\n                    </div>\r\n\r\n                    <div class=\"card-body\">\r\n                        <p>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "39e9d3d04f144da6717cb6b636dcf6bc3d2627ec14172", async() => {
                WriteLiteral("<b><i class=\"fas fa-plus\"></i> Add New </b> ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </p>
                    </div>
                    <!-- /.card -->
                </div>
            </div>
        </div>
    </div>
</div>

<!--search-->
<div class=""card card-info"">
    <div class=""card-header"">
        <h3 class=""card-title"">Search Details</h3>
    </div>
    <div class=""card-body"">
        <div class=""row"">
            <div class=""input-group d-flex justify-content-center col-4"">
                <label class=""col-sm-3 col-form-label"">TTIN<span style=""font-weight: bold; color: red;""></span></label>
                <input id=""ttin"" class=""form-control col-6"" />
            </div>
            <div class=""input-group d-flex justify-content-center col-4"">
                <label class=""col-sm-3 col-form-label"">Name<span style=""font-weight: bold; color: red;""></span></label>
                <input id=""name"" class=""form-control col-6"" />
            </div>
            <div class=""input-group-append col-2"">
                <button class=""btn bt");
            WriteLiteral(@"n-primary"" onclick=""return SearchDetailsOrganisation();"">Search</button>
            </div>
            <div class=""input-group-append col-2"">
                <button class=""btn btn-primary"" onclick=""return SearchDetailsOrganisationAll();"">Show all</button>
            </div>
        </div>
    </div>
</div>

<!--Organisation Details-->
<div class=""card card-info"" id=""tbl_Organisation"" style=""display: none;"">
    <div class=""card-header"">
        <h3 class=""card-title"">Organisation Details</h3>
    </div>

    <div class=""card-body"">
        <table id=""example1"" class=""table table-bordered table-striped"">
            <thead style=""background-color:mediumaquamarine"">

                <tr>
                    <th>Sl No</th>
                    <th>TTIN</th>
                    <th>Name</th>
                    <th>Mobile</th>
                    <th>Email</th>
                    <th>Action</th>

                </tr>
            </thead>
            <tbody id=""tbl_body"">
         ");
            WriteLiteral(@"   </tbody>
        </table>
    </div>
</div>


<script>

    //Showing Details
    function SearchDetailsOrganisation() {

        if ($('#ttin').val() == """" && $('#name').val() == """") {
            swal('Empty Fields', '', 'error');
            $('#ttin').focus();
            $('#name').focus();
            return false;
        }

            var ttin = $('#ttin').val();
            var name = $('#name').val();

                $.ajax({
                        type: ""GET"",
                        url: '");
#nullable restore
#line 139 "D:\TT\Finalarms\ARMS\Areas\TaxPayer\Views\TaxPayerProfiles\Organisation.cshtml"
                         Write(Url.Action("fetchOrganisation", "TaxPayerProfiles"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                        data: {
                            ttin: ttin,
                            name: name,
                        },
                        dataType: ""json"",
                        success: function (data) {
                            $('#tbl_body').empty();
                            if (data.length > 0) {
                                $.each(data, function (key, value) {
                                    $('#tbl_Organisation').show(1000);

                                    $('#tbl_body').append(
                                        '<tr>'
                                        + '<td>' + (key + 1) + '</td>'
                                        + '<td>' + value.ttin + '</td>'
                                        + '<td>' + value.name + '</td>'
                                        + '<td>' + value.mobileNo + '</td>'
                                        + '<td>' + value.email + '</td>'
                                        + '<td><b><a sty");
            WriteLiteral(@"le = ""color: #007bff; cursor: pointer;"" onclick = ""return oEdit(' + value.taxPayerId + ' )"" title = ""VendorEdit"" > <i class=""fas fa-edit""></i> </a ></b></td>'
                                        + '</tr>');
                                });
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

    function SearchDetailsOrganisationAll() {

                $.ajax({
                        ty");
            WriteLiteral("pe: \"GET\",\r\n                        url: \'");
#nullable restore
#line 183 "D:\TT\Finalarms\ARMS\Areas\TaxPayer\Views\TaxPayerProfiles\Organisation.cshtml"
                         Write(Url.Action("fetchOrganisationAll", "TaxPayerProfiles"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                        data: {

                        },
                        dataType: ""json"",
                        success: function (data) {
                            $('#tbl_body').empty();
                            if (data.length > 0) {
                                $.each(data, function (key, value) {
                                    $('#tbl_Organisation').show(1000);

                                    $('#tbl_body').append(
                                        '<tr>'
                                        + '<td>' + (key + 1) + '</td>'
                                        + '<td>' + value.ttin + '</td>'
                                        + '<td>' + value.name + '</td>'
                                        + '<td>' + value.mobileNo + '</td>'
                                        + '<td>' + value.email + '</td>'
                                        + '<td><b><a style = ""color: #007bff; cursor: pointer;"" onclick = ""return oEdit(' + value.taxPay");
            WriteLiteral(@"erId + ' )"" title = ""VendorEdit"" > <i class=""fas fa-edit""></i> </a ></b></td>'
                                        + '</tr>');
                                });
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

    //end

    function oEdit(id) {

        window.location.href = ""Edit?id="" + id;
    }

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CORE_BOL.TaxPayerProfileModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
