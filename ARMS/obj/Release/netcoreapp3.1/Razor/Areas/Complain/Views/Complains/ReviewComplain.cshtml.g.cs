#pragma checksum "D:\TT\Finalarms\ARMS\Areas\Complain\Views\Complains\ReviewComplain.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6fad4781f9bed9cd3a2ad8a0ff9daef539611b42"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Complain_Views_Complains_ReviewComplain), @"mvc.1.0.view", @"/Areas/Complain/Views/Complains/ReviewComplain.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6fad4781f9bed9cd3a2ad8a0ff9daef539611b42", @"/Areas/Complain/Views/Complains/ReviewComplain.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b4a8197006c533ca3077e7e53fa27a725fee456", @"/Areas/_ViewImports.cshtml")]
    public class Areas_Complain_Views_Complains_ReviewComplain : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CORE_BOL.ComplainDetail>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/jquery/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\TT\Finalarms\ARMS\Areas\Complain\Views\Complains\ReviewComplain.cshtml"
  
    ViewData["Title"] = "ReviewComplain";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6fad4781f9bed9cd3a2ad8a0ff9daef539611b425157", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6fad4781f9bed9cd3a2ad8a0ff9daef539611b425822", async() => {
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
                        <li class=""breadcrumb-item active"">Review Complain Details</li>
                    </ol>
                </div><!-- /.col -->
            </div><!-- /.row -->
        </div><!-- /.container-fluid -->
    </div>
    <!-- /.content-header -->


    <div class=""card card-info"">
");
#nullable restore
#line 28 "D:\TT\Finalarms\ARMS\Areas\Complain\Views\Complains\ReviewComplain.cshtml"
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
#line 33 "D:\TT\Finalarms\ARMS\Areas\Complain\Views\Complains\ReviewComplain.cshtml"
              Write(TempData["msg"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n            </div>\r\n");
#nullable restore
#line 35 "D:\TT\Finalarms\ARMS\Areas\Complain\Views\Complains\ReviewComplain.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        <div class=\"card-header\">\r\n            <h3 class=\"card-title\">Review Complain Details</h3>\r\n        </div>\r\n");
                WriteLiteral(@"
        <div class=""card-body"">
            <div class=""row"">
                <div class=""input-group d-flex justify-content-center col-5"">
                    <label class=""col-sm-4 col-form-label"">Consumer No: <span style=""font-weight: bold; color: red;""></span></label>
                    <input id=""ConsumerNoSearch"" class=""form-control col-6"" style=""text-transform:uppercase"" />
                </div>

                <div class=""input-group-append col-3"">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input type=""button"" value=""Search"" class=""btn btn-primary"" onclick=""return DisplayWaterConnection();"" />
");
                WriteLiteral("                </div>\r\n");
                WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            WriteLiteral(@"
<div class=""card card-info"" style=""display:none;"" id=""waterconnectiondetails"">
    <div class=""card-header"">
        <h3 class=""card-title"">Water Connection Details</h3>
    </div>
    <div class=""card-body"">
        <table class=""table table-bordered table-striped"">
            <thead style=""background-color:mediumaquamarine"">

                <tr>
                    <th>#</th>
                    <th>Plot No</th>
                    <th>Zone</th>
                    <th>Consumer No</th>
                    <th>Water Meter No</th>
                    <th>Name</th>
                    <th>Billing Address</th>
                    <th>Action</th>
                </tr>
            </thead>
            <tbody id=""tbl_waterconnection"">
            </tbody>
        </table>
    </div>
</div>

<div class=""card card-info"" style=""display:none;"" id=""complaindetails"">
    <input type=""hidden"" id=""CDID"" />
    <div class=""card-header"">
        <h3 class=""card-title"">Complain Details</h3>
 ");
            WriteLiteral(@"   </div>
    <div class=""card-body"">
        <table class=""table table-bordered table-striped"">
            <thead style=""background-color:mediumaquamarine"">

                <tr>
                    <th>#</th>
                    <th>Complain Type</th>
                    <th>Complain Status</th>
                    <th>Instruction</th>
                    <th>DeadLine</th>
                    <th>Action</th>
                </tr>
            </thead>
            <tbody id=""tbl_complaindetails"">
            </tbody>
        </table>
    </div>
</div>
<div class=""card card-info"" style=""display:none;"" id=""ReviewComplain"">
    <input type=""hidden"" id=""hdnComplainDetailId"" />
    <div class=""card-header"">
        <h3 class=""card-title"">Review Complain Details</h3>
    </div>
    <div class=""card-body"">
        <div class=""form-group row"">
            <label class=""col-sm-1 col-form-label"">Remarks </label>
            <div class=""col-sm-3"">
                <textarea class=""form-contro");
            WriteLiteral(@"l"" id=""ReviewedRemarks"" placeholder=""Enter Remarks"" rows=""3"" required></textarea>
            </div>
        </div>

        <div class=""form-group row"">
            <label class=""col-sm-1 col-form-label""></label>
            <div class=""col-sm-2"">
                <button type=""submit"" class=""btn btn-primary"" onclick=""return SaveReviewComplainDetail();"">Save</button>
                <button type=""reset"" id=""btnCancel"" class=""btn btn-warning"">Cancel</button>
            </div>
        </div>
    </div>
</div>
<div class=""card card-info"" style=""display:none;"" id=""DisplayRadioButtton"">
<div class=""card-body"">
    <div class=""form-check"">
        <input class=""form-check-input"" type=""radio"" id=""Approve"" name=""flexRadioDefault1"" onchange="" return ApprovalComplainDetail();"" value=""1"">
        <label class=""form-check-label col-sm-3"" for=""ApprovalComplain"" id=""ACD"">
            Approve
        </label>
        <input class=""form-check-input"" type=""radio"" id=""Reject"" name=""flexRadioDefault1"" oncha");
            WriteLiteral(@"nge=""return RejectComplainDetail();"" value=""2"">
        <label class=""form-check-label"" for=""RejectApproval"" id=""RCD"">
            Reject
        </label>
    </div>
</div>
</div>

<div class=""card card-info"" style=""display:none;"" id=""ApprovalComplain"">
    <input type=""hidden"" id=""AComplainDetailId"" />
    <div class=""card-header"">
        <h3 class=""card-title"">Approval Complain Details</h3>
    </div>
    <div class=""card-body"">
        <div class=""form-group row"">
            <label class=""col-sm-1 col-form-label"">Remarks </label>
            <div class=""col-sm-3"">
                <textarea class=""form-control"" id=""ApprovalRemarks"" placeholder=""Enter Remarks"" rows=""3"" required></textarea>
            </div>
        </div>

        <div class=""form-group row"">
            <label class=""col-sm-1 col-form-label""></label>
            <div class=""col-sm-2"">
                <button type=""submit"" class=""btn btn-primary"" onclick=""return SaveApprovalComplainDetail();"">Save</button>
       ");
            WriteLiteral(@"         <button type=""reset"" id=""btnCancel1"" class=""btn btn-warning"">Cancel</button>
            </div>
        </div>
    </div>
</div>

<div class=""card card-info"" style=""display:none;"" id=""RejectComplain"">
    <input type=""hidden"" id=""RComplainDetailId"" />
    <div class=""card-header"">
        <h3 class=""card-title"">Reject Complain Details</h3>
    </div>
    <div class=""card-body"">
        <div class=""form-group row"">
            <label class=""col-sm-1 col-form-label"">Remarks </label>
            <div class=""col-sm-3"">
                <textarea class=""form-control"" id=""RejectRemarks"" placeholder=""Enter Remarks"" rows=""3"" required></textarea>
            </div>
        </div>

        <div class=""form-group row"">
            <label class=""col-sm-1 col-form-label""></label>
            <div class=""col-sm-2"">
                <button type=""submit"" class=""btn btn-primary"" onclick=""return SaveRejectComplainDetail();"">Save</button>
                <button type=""reset"" id=""btnCancel2"" class=");
            WriteLiteral("\"btn btn-warning\">Cancel</button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6fad4781f9bed9cd3a2ad8a0ff9daef539611b4216245", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
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

        $('input[type=radio][name=flexRadioDefault1]').change(function () {

            if (this.value != null) {
                $('#hdnComplainDetailId').val(this.value);
            }
        });
    });

//*************************************************************      LAND OWNERSHIP DETAILS      ********************************************************************************************

    function DisplayWaterConnection() {
        $('#CreateComplain').hide(1000);
        $('#complaindetails').hide(1000);
        $('#ApprovalComplain').hide(1000);
        $('#RejectComplain').hide(1000);
        $('#DisplayRadioButtton').hide(1000);
        if ($('#ConsumerNoSearch').val() == """") {
                swal('Empty Fields!', '', 'error');
            $('#ConsumerNoSearch').focus();
                return false;
                }

                $.ajax({
                    type: ""GET"",
                    url: '");
#nullable restore
#line 220 "D:\TT\Finalarms\ARMS\Areas\Complain\Views\Complains\ReviewComplain.cshtml"
                     Write(Url.Action("GetWaterConnection", "Complains"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                    data: {
                        ConsumerNo: $('#ConsumerNoSearch').val()
                    },
                    success: function (data) {
                        $('#tbl_waterconnection').empty();
                        if (data.length > 0) {
                            $.each(data, function (key, value) {
                                $('#waterconnectiondetails').show(1000);
                                $('#tbl_waterconnection').append(
                                    '<tr>'
                                    + '<td>' + (key + 1) + '</td>'
                                    + '<td>' + value.plotNo + '</td>'
                                    + '<td>' + value.zoneName + '</td>'
                                    + '<td>' + value.consumerNo + '</td>'
                                    + '<td>' + value.waterMeterNo + '</td>'
                                    + '<td>' + value.taxPayerName + '</td>'
                                    + '<td>' + value.");
            WriteLiteral(@"billingAddress + '</td>'
                                    + '<td>'
                                    + '<a style = ""color: #007bff; cursor: pointer;"" onclick = ""return CreateComplainDetail(' + value.waterConnectionId + ' )"" title = ""CreateComplainDetail"">View</a >'
                                    + '</td>'
                                    + '</tr>');

                            });

                        } else {
                            $('#waterconnectiondetails').show(1000);
                            $('#tbl_waterconnection').append(
                                '<tr><td colspan=""8"" style=""color: red;"">No record found!</td></tr>');
                        }

                    },

                    error: function () {
                        alert('error');
                    }

                });
        }

    //****************************************************     SAVE COMPLAIN DETAILS     ************************************************************");
            WriteLiteral("******************\r\n    function CreateComplainDetail(waterConnectionId) {\r\n        $(\'#CDID\').val(waterConnectionId);\r\n        $.ajax({\r\n                    type: \"GET\",\r\n                    url: \'");
#nullable restore
#line 265 "D:\TT\Finalarms\ARMS\Areas\Complain\Views\Complains\ReviewComplain.cshtml"
                     Write(Url.Action("GetReviewComplainDetail", "Complains"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                    data: {
                        WCID: waterConnectionId
                    },
                    success: function (data) {
                        $('#tbl_complaindetails').empty();
                        if (data.length > 0) {
                            var res = null;
                            $.each(data, function (key, value) {
                                $('#complaindetails').show(1000);
                                res = (value.complainStatusId == 1) ? '<a style=""cursor: pointer; color: forestgreen;"" onclick=""return Review(' + value.complainDetailId + ');"">Review</a>' : '<b><a style=""cursor: pointer; color: forestgreen;"" title=""Accept/Reject"" onclick=""return ApprovalReject(' + value.complainDetailId + ');"">Approve/Reject</a></b>';

                                $('#tbl_complaindetails').append(
                                    '<tr>'
                                    + '<td>' + (key + 1) + '</td>'
                                    + '<td>' + v");
            WriteLiteral(@"alue.complainType + '</td>'
                                    + '<td>' + value.complainStatus + '</td>'
                                    + '<td>' + value.instruction + '</td>'
                                    + '<td>' + value.deadLine + '</td>'
                                    + '<td>' + res + '</td>'
                                    + '</tr>');

                            });

                        } else {
                            $('#complaindetails').show(1000);
                            $('#tbl_complaindetails').append(
                                '<tr><td colspan=""5"" style=""color: red;"">No record found!</td></tr>');
                        }

                    },

                    error: function () {
                        alert('error');
                    }

                });
    }
    function Review(complainDetailId) {
        $('#hdnComplainDetailId').val(complainDetailId);
        $('#ReviewComplain').show(1000);
    }
    function Sav");
            WriteLiteral(@"eReviewComplainDetail() {
    var myarray = [];
        var ComplainDetail = {};

        ComplainDetail.ComplainDetailId = parseInt($(""#hdnComplainDetailId"").val());
        ComplainDetail.ComplainReviewRemarks = $(""#ReviewedRemarks"").val();

        myarray.push(ComplainDetail);

        var json_data = JSON.stringify(myarray);
        console.log(json_data);
        $('#img').hide();

        $.ajax({
            type: ""POST"",
            url: '");
#nullable restore
#line 322 "D:\TT\Finalarms\ARMS\Areas\Complain\Views\Complains\ReviewComplain.cshtml"
             Write(Url.Action("ReviewComplainDetail", "Complains"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
            data: json_data,
            contentType: ""application/json; charset=utf-8"",
            dataType: ""json"",
            success: function (response) {
                if (response > 0) {
                    swal('Reviewed Complain Detail Saved Successfully!');
                    $('#ReviewComplain').hide(1000);
                    CreateComplainDetail($('#CDID').val());
                        
                }
                else {
                    swal('Reviewed Complain Detail Saving Failed!');
                    $('#img').hide();
                    return false;
                }
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
    }

    function ApprovalReject() {
        $('#DisplayRadioButtton').show(1000);
");
            WriteLiteral(@"        $('input[name=flexRadioDefault1]').prop('checked', false);
    }
    function ApprovalComplainDetail() {
        $('#ApprovalComplain').show(1000);
        $('#RejectComplain').hide(1000);
    }

    function RejectComplainDetail() {
        $('#RejectComplain').show(1000);
        $('#ApprovalComplain').hide(1000);
    }

    function SaveApprovalComplainDetail() {
    var myarray = [];
        var ComplainDetail = {};

        ComplainDetail.ComplainDetailId = parseInt($(""#hdnComplainDetailId"").val());
        ComplainDetail.ComplainApprovalRemarks = $(""#ApprovalRemarks"").val();

        myarray.push(ComplainDetail);

        var json_data = JSON.stringify(myarray);
        console.log(json_data);
        $('#img').hide();

        $.ajax({
            type: ""POST"",
            url: '");
#nullable restore
#line 379 "D:\TT\Finalarms\ARMS\Areas\Complain\Views\Complains\ReviewComplain.cshtml"
             Write(Url.Action("ApproveComplainDetail", "Complains"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
            data: json_data,
            contentType: ""application/json; charset=utf-8"",
            dataType: ""json"",
            success: function (response) {
                if (response > 0) {
                    swal('Complain Detail is Approved!');
                    $('#ApprovalComplain').hide(1000);
                    $('#DisplayRadioButtton').hide(1000);                    

                }
                else {
                    swal('Complain Detail Approved Failed!');
                    $('#img').hide();
                    return false;
                }
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
    }

    function SaveRejectComplainDetail() {
    var myarray = [];
        var ComplainDetail = {};

     ");
            WriteLiteral(@"   ComplainDetail.ComplainDetailId = parseInt($(""#hdnComplainDetailId"").val());
        ComplainDetail.ComplainRejectRemarks = $(""#RejectRemarks"").val();

        myarray.push(ComplainDetail);

        var json_data = JSON.stringify(myarray);
        console.log(json_data);
        $('#img').hide();

        $.ajax({
            type: ""POST"",
            url: '");
#nullable restore
#line 422 "D:\TT\Finalarms\ARMS\Areas\Complain\Views\Complains\ReviewComplain.cshtml"
             Write(Url.Action("RejectComplainDetail", "Complains"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
            data: json_data,
            contentType: ""application/json; charset=utf-8"",
            dataType: ""json"",
            success: function (response) {
                if (response > 0) {
                    swal('Complain Detail is Rejected!');
                    $('#RejectComplain').hide(1000);
                    $('#DisplayRadioButtton').hide(1000);
                }
                else {
                    swal('Complain Detail Rejection Failed!');
                    $('#img').hide();
                    return false;
                }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CORE_BOL.ComplainDetail>> Html { get; private set; }
    }
}
#pragma warning restore 1591
