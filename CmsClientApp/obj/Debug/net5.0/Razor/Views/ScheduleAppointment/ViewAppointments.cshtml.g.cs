#pragma checksum "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\ScheduleAppointment\ViewAppointments.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d43cf557f6a7ef18fae603045ebb0068550ee344"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ScheduleAppointment_ViewAppointments), @"mvc.1.0.view", @"/Views/ScheduleAppointment/ViewAppointments.cshtml")]
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
#line 1 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\_ViewImports.cshtml"
using CmsClientApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\_ViewImports.cshtml"
using CmsClientApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d43cf557f6a7ef18fae603045ebb0068550ee344", @"/Views/ScheduleAppointment/ViewAppointments.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9ceee7b858d32b94a434911555cb57883b4b2c71", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_ScheduleAppointment_ViewAppointments : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CmsClientApp.Models.Schedule>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SelectDoctor", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "SelectDoctor", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\ScheduleAppointment\ViewAppointments.cshtml"
  
    ViewData["Title"] = "ViewAppointments";

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\ScheduleAppointment\ViewAppointments.cshtml"
Write(Html.Partial("_Navbarmenu"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<h4>View Appointments</h4>\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d43cf557f6a7ef18fae603045ebb0068550ee3444411", async() => {
                WriteLiteral("<h4>Create New Appointment</h4>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 18 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\ScheduleAppointment\ViewAppointments.cshtml"
           Write(Html.DisplayNameFor(model => model.AppointmentId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 21 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\ScheduleAppointment\ViewAppointments.cshtml"
           Write(Html.DisplayNameFor(model => model.PatientId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 24 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\ScheduleAppointment\ViewAppointments.cshtml"
           Write(Html.DisplayNameFor(model => model.Specialization));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 27 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\ScheduleAppointment\ViewAppointments.cshtml"
           Write(Html.DisplayNameFor(model => model.DoctorName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 30 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\ScheduleAppointment\ViewAppointments.cshtml"
           Write(Html.DisplayNameFor(model => model.VisitDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 33 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\ScheduleAppointment\ViewAppointments.cshtml"
           Write(Html.DisplayNameFor(model => model.AppointmentTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 39 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\ScheduleAppointment\ViewAppointments.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 43 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\ScheduleAppointment\ViewAppointments.cshtml"
               Write(Html.DisplayFor(modelItem => item.AppointmentId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 46 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\ScheduleAppointment\ViewAppointments.cshtml"
               Write(Html.DisplayFor(modelItem => item.PatientId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 49 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\ScheduleAppointment\ViewAppointments.cshtml"
               Write(Html.DisplayFor(modelItem => item.Specialization));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 52 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\ScheduleAppointment\ViewAppointments.cshtml"
               Write(Html.DisplayFor(modelItem => item.DoctorName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 55 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\ScheduleAppointment\ViewAppointments.cshtml"
               Write(Html.DisplayFor(modelItem => item.VisitDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 58 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\ScheduleAppointment\ViewAppointments.cshtml"
               Write(Html.DisplayFor(modelItem => item.AppointmentTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 61 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\ScheduleAppointment\ViewAppointments.cshtml"
               Write(Html.ActionLink("Cancel Appointment", "Delete", new { id = item.AppointmentId }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 64 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\ScheduleAppointment\ViewAppointments.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CmsClientApp.Models.Schedule>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
