#pragma checksum "D:\TT\Finalarms\ARMS\Areas\Stall\Views\StallDetails\StallRenewal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "107212b7e0900e8e2cfb47a12d73abba95efe380"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Stall_Views_StallDetails_StallRenewal), @"mvc.1.0.view", @"/Areas/Stall/Views/StallDetails/StallRenewal.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"107212b7e0900e8e2cfb47a12d73abba95efe380", @"/Areas/Stall/Views/StallDetails/StallRenewal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b4a8197006c533ca3077e7e53fa27a725fee456", @"/Areas/_ViewImports.cshtml")]
    public class Areas_Stall_Views_StallDetails_StallRenewal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CORE_BOL.StallDetailVM>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "StallRenewal", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/jquery/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\TT\Finalarms\ARMS\Areas\Stall\Views\StallDetails\StallRenewal.cshtml"
  
    ViewData["Title"] = "StallRenewal";
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "107212b7e0900e8e2cfb47a12d73abba95efe3805770", async() => {
                WriteLiteral("Lease");
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
            WriteLiteral("</li>\r\n                    <li class=\"breadcrumb-item active\">Stall Renewal</li>\r\n                </ol>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "107212b7e0900e8e2cfb47a12d73abba95efe3807097", async() => {
                WriteLiteral("\r\n\r\n    <div class=\"card card-info\">\r\n");
#nullable restore
#line 24 "D:\TT\Finalarms\ARMS\Areas\Stall\Views\StallDetails\StallRenewal.cshtml"
         if (TempData["msg"] != null)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"            <div class=""alert alert-danger alert-dismissible"">
                <button type=""button"" class=""close"" data-dismiss=""alert"" aria-hidden=""true"">&times;</button>
                <h5><i class=""icon fas fa-ban""></i> Alert!</h5>
                <p>");
#nullable restore
#line 29 "D:\TT\Finalarms\ARMS\Areas\Stall\Views\StallDetails\StallRenewal.cshtml"
              Write(TempData["msg"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n            </div>\r\n");
#nullable restore
#line 31 "D:\TT\Finalarms\ARMS\Areas\Stall\Views\StallDetails\StallRenewal.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"    <div class=""card-header"">
        <h3 class=""card-title"">Tax Payer Search</h3>
        <input type=""hidden"" id=""hdnStallAllocationId"" />

    </div>
        <div class=""card-body"">
            <div class=""form-group row"">
                <label class=""col-sm-2 col-form-label text-center"">CID </label>
                <div class=""col-sm-3"">
                    <input class=""form-control"" maxlength=""11"" placeholder=""Search by CID"" id=""CIDinput"" />
                </div>
                <label class=""col-sm-2 col-form-label text-center"">TTIN </label>
                <div class=""col-sm-3"">
                    <input class=""form-control"" placeholder=""Search by TTIN"" id=""TTINinput"" />
                </div>

                <div class=""col-sm-2"">
                    <button type=""button"" class=""btn btn-outline-success"" onclick=""return SearchTaxPayer();"">Search</button>

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
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
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
<div class=""card card-info""  id=""taxpayerdetails"" style=""display: none;"">
    <table id=""example1"" class=""table table-bordered table-striped"">
        <thead>

            <tr>
                <th>Name</th>
                <th>CID</th>
                <th>Address</th>
                <th>Phone Number</th>
                <th>Action</th>

            </tr>
        </thead>
        <tbody id=""mybody"">
        </tbody>
    </table>
</div>
<div class=""card card-info"" id=""stalldetail"" style=""display: none;"">
    <div class=""card-header"">
        <h3 class=""card-title"">Stall Details</h3>
    </div>
    <div class=""card-body"">
        <div class=""form-group row"">
            <table");
            BeginWriteAttribute("id", " id=\"", 2829, "\"", 2834, 0);
            EndWriteAttribute();
            WriteLiteral(@" class=""table table-bordered table-striped"">
                <thead style=""background-color:mediumaquamarine"">
                    <tr>
                        <th>Stall No</th>
                        <th>Stall Name</th>
                        <th>Stall Area</th>
                        <th>Stall Location</th>
                        <th>Billing Schedule</th>
                        <th>Rental Amount</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody id=""tblstalldetail"">
                </tbody>
            </table>
        </div>
    </div>
</div>

<div class=""card card-info"" id=""stallallocationdetail"" style=""display:none;"">
    <div class=""card-header"">
        <h3 class=""card-title"">Stall Allocation Detail</h3>
    </div>
    <div class=""card-body"">
        <div class=""form-group row"">
            <table id=""example1"" class=""table table-bordered table-striped"">
                <thead style=""background-color:medi");
            WriteLiteral(@"umaquamarine"">
                    <tr>
                        <th>Billing Schedule</th>
                        <th>Rental Amount</th>
                        <th>Security Amount</th>
                        <th>Allocation Date</th>
                        <th>Start Date</th>
                        <th>End Date</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody id=""tblstallallocation"">
                </tbody>
            </table>
        </div>
    </div>
</div>

<div class=""card card-info"" id=""renewstallallocation"" style=""display: none;"">
    <div class=""card-header"" style=""background-color:cornflowerblue"">
        <h3 class=""card-title"" style=""color:white"">Renew Stall Allocation</h3>

    </div>
    <div class=""card-body"">

        <div class=""form-group row"">
            <label class=""col-sm-2 col-form-label"">Start Date <span style=""font-weight: bold; color: red;"">*</span></label>
            <div class=""col-");
            WriteLiteral(@"sm-4"">
                <input class=""form-control"" id=""iddstartdate"" type=""date"" />
            </div>
       
            <label class=""col-sm-2 col-form-label"">End Date <span style=""font-weight: bold; color: red;"">*</span></label>
            <div class=""col-sm-4"">
                <input class=""form-control"" id=""iddenddate"" type=""date"" />
            </div>
        </div>
        <div class=""form-group row"">

            <label class=""col-sm-2 col-form-label"">Rental Amount <span style=""font-weight: bold; color: red;"">*</span></label>
            <div class=""col-sm-4"">
                <input class=""form-control"" id=""idrentalamount""/>
            </div>
            <label class=""col-sm-2 col-form-label"">Remarks </label>
            <div class=""col-sm-4"">
                <textarea class=""form-control"" id=""idremarks"" placeholder=""Enter Remarks"" rows=""3""></textarea>
            </div>
        </div>
        <div class=""form-group row"">
            <label class=""col-sm-2 col-form-label""></lab");
            WriteLiteral(@"el>
            <div class=""col-sm-10"">
                <button type=""button"" class=""btn btn-primary"" id=""SaveRenew"">Save</button>
                <button id=""btnCancel"" class=""btn btn-warning"">Cancel</button>
            </div>
        </div>
    </div>
</div>
<div class=""form-group row"" style=""display: none;"" id=""closebutton"">
    <div class=""col-sm-5"">    </div>
    <button type=""button"" class=""btn btn-primary"" id=""CloseButton"" style=""width:100px; height:50px;"">Close</button>
</div>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "107212b7e0900e8e2cfb47a12d73abba95efe38015507", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<script>


                //Display Tax Prayer Profile
      function SearchTaxPayer() {
            $('#CIDinput').insertAfter(function () {
                var Cid = $('#CIDinput').val();
                var Ttin = $('#TTINinput').val();
                if (Cid == Cid || Ttin == Ttin) {
                    $('#taxpayerdetails').show(1000);
                    $('#mybody').show(1000);

                    $.ajax({
                        type: ""GET"",
                        url: '");
#nullable restore
#line 184 "D:\TT\Finalarms\ARMS\Areas\Stall\Views\StallDetails\StallRenewal.cshtml"
                         Write(Url.Action("GetTaxPayer", "StallDetails"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                        data: {
                            cid: Cid,
                            ttin: Ttin
                        },
                        success: function (data) {
                            $('#mybody').empty();


                            $.each(data, function (key, value) {
                                $('#taxpayerdetails').show(1000);
                                $('#mybody').append(
                                    '<tr>'
                                    + '<td>' + value.fullName + '</td>'
                                    + '<td>' + value.cid + '</td>'
                                    + '<td>' + value.cAddress + '</td>'
                                    + '<td>' + value.phoneNo + '</td>'
                                    + '<td><b><a style=""cursor: pointer; color: forestgreen;"" onclick=""return displayStallDetail(' + value.taxPayerId + ');"">View</a></b></td>'
                                    + '</tr>');
                            })");
            WriteLiteral(@";
                            $('#hdnTaxPayerId').val(data[0].taxPayerId);


                        },
                        error: function () {
                            alert('error');
                        }

                    });
                }
                else {
                    $('#mybody').append(
                        '<tr><td colspan=""3"" style=""color: red;"">No record found!</td></tr>');

                }
            });
        }
        //Stall Allocation Entry
    function displayStallDetail(taxPayerId) {
            $.ajax({
                type: ""GET"",
                url: '");
#nullable restore
#line 225 "D:\TT\Finalarms\ARMS\Areas\Stall\Views\StallDetails\StallRenewal.cshtml"
                 Write(Url.Action("GetRenewalStallDetail", "StallDetails"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                data: {
                    id: taxPayerId
                },
                success: function (data) {

                    console.log(data);
                    $('#tblstalldetail').empty();
                    $('#stalldetail').show(1000);

                    if (data.length > 0) {

                        $.each(data, function (key, value) {
                            $('#tblstalldetail').append(
                                '<tr>'
                                + '<td>' + value.stallNo + '</td>'
                                + '<td>' + value.stallName + '</td>'
                                + '<td>' + value.stallArea + '</td>'
                                + '<td>' + value.stallLocation + '</td>'
                                + '<td>' + value.billingScheduleName + '</td>'
                                + '<td>' + value.rentalAmount + '</td>'

                                + '<td><b><a style=""cursor: pointer; color: forestgreen;"" onclick=""return ");
            WriteLiteral(@"displayStallAllocation(' + value.stallAllocationId + ');"">Select</a></b></td>'
                                + '</tr>');


                        });

                    }
                    else {
                        $('#tblstalldetail').append(
                            '<tr><td colspan=""7"" style=""color: red;"">No record found!</td></tr>');
                    }

                },
                error: function () {
                    $('#img').hide();
                    alert('Error occured');
                }
            });
        }

    function displayStallAllocation(stallAllocationId) {

        $('#hdnStallAllocationId').val(stallAllocationId);
       // $('#stallrentdetails').show(1000);
        //$('html,body').animate({
        //    scrollTop: $(""#stallrentdetails"").offset().top
       // }, 'slow');
                    $.ajax({
                    type: ""GET"",
                    url: '");
#nullable restore
#line 276 "D:\TT\Finalarms\ARMS\Areas\Stall\Views\StallDetails\StallRenewal.cshtml"
                     Write(Url.Action("GetRenewalStallAllocation", "StallDetails"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                    data: {
                        id: stallAllocationId,
                    },
                        success: function (data) {
                            $('#tblstallallocation').empty();
                            $('#stallallocationdetail').show(1000);
                        if (data.length > 0) {
                            $.each(data, function (key, value) {
                                $('#tblstallallocation').append(
                                    '<tr>'
                                    + '<td>' + value.billingSchedule + '</td>'
                                    + '<td>' + value.rentalAmount + '</td>'
                                    + '<td>' + value.securityAmount + '</td>'
                                    + '<td>' + value.allocationDate + '</td>'
                                    + '<td>' + value.startDate + '</td>'
                                    + '<td>' + value.endDate + '</td>'

                                    + '<td><b><a");
            WriteLiteral(@" style=""cursor: pointer; color: forestgreen;"" onclick=""return displayStallRenewal(' + value.stallAllocationId + ');"">Renew</a></b></td>'

                                    + '</td>'
                                    + '</tr>');
                            });
                        

                        } else {
                            $('#tblstallallocation').append(
                                '<tr><td colspan=""6"" style=""color: red;"">No record found!</td></tr>');

                        }

                    },

                    error: function () {
                        alert('error');
                    }

                });
    }
        //Save Renew
        $(""#SaveRenew"").click(function () {

        var myarray = [];
            var StallPeriodVM = {};

            StallPeriodVM.StallAllocationId = parseInt($(""#hdnStallAllocationId"").val());
            StallPeriodVM.StartDate = $(""#iddstartdate"").val();
            StallPeriodVM.EndDate = $(""#idd");
            WriteLiteral(@"enddate"").val();
            StallPeriodVM.Remarks = $(""#idremarks"").val();
            StallPeriodVM.RevisedRent = parseInt($(""#idrentalamount"").val());

            myarray.push(StallPeriodVM);

        var json_data = JSON.stringify(myarray);
        console.log(json_data);

        $('#img').show();

        $.ajax({
            type: ""POST"",
            url: '");
#nullable restore
#line 336 "D:\TT\Finalarms\ARMS\Areas\Stall\Views\StallDetails\StallRenewal.cshtml"
             Write(Url.Action("CreateRenewStallAllocation", "StallDetails"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
            data: json_data,
            contentType: ""application/json; charset=utf-8"",
            dataType: ""json"",
            success: function (response) {
                $('#renewstallallocation').hide(1000);
                $('#closebutton').show(1000);
                displayStallAllocation($('#hdnStallAllocationId').val());
                    
                $('#img').hide();
                swal(response);
            },
            failure: function (response) {
                $('#img').hide();
                swal(""Creation Failed"");
            },
            error: function (response) {
                $('#img').hide();
                swal(""Error while inserting"");
            }

        });

        });



    function displayStallRenewal()
    {
        $('#iddstartdate').val('');
        $('#iddenddate').val('');
        $('#idremarks').val('');
        $('#closebutton').hide(1000);
        $('#renewstallallocation').toggle(1000);
        $('html,bod");
            WriteLiteral(@"y').animate({
            scrollTop: $(""#renewstallallocation"").offset().top
        }, 'slow');
        }

    $('#CloseButton').click(function () {
      
        location.reload();
})
        
    $('#btnCancel').click(function () {
        $('#renewstallallocation').hide(1000);
    })

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CORE_BOL.StallDetailVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591