#pragma checksum "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\Doctor\GetAllDoctor.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "abd6d136e0d7f6f4a98598720ce760915f3f7ef3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Doctor_GetAllDoctor), @"mvc.1.0.view", @"/Views/Doctor/GetAllDoctor.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"abd6d136e0d7f6f4a98598720ce760915f3f7ef3", @"/Views/Doctor/GetAllDoctor.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9ceee7b858d32b94a434911555cb57883b4b2c71", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Doctor_GetAllDoctor : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CmsClientApp.Models.Doctor>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\Doctor\GetAllDoctor.cshtml"
  
    ViewData["Title"] = "GetAllDoctor";

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\Doctor\GetAllDoctor.cshtml"
Write(Html.Partial("_Navbarmenu"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<h1>GetAllDoctors</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "abd6d136e0d7f6f4a98598720ce760915f3f7ef33965", async() => {
                WriteLiteral("Create New");
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
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\Doctor\GetAllDoctor.cshtml"
           Write(Html.DisplayNameFor(model => model.DoctorId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 20 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\Doctor\GetAllDoctor.cshtml"
           Write(Html.DisplayNameFor(model => model.Firstname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 23 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\Doctor\GetAllDoctor.cshtml"
           Write(Html.DisplayNameFor(model => model.Lastname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 26 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\Doctor\GetAllDoctor.cshtml"
           Write(Html.DisplayNameFor(model => model.Sex));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 29 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\Doctor\GetAllDoctor.cshtml"
           Write(Html.DisplayNameFor(model => model.Specialization));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 32 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\Doctor\GetAllDoctor.cshtml"
           Write(Html.DisplayNameFor(model => model.StartTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 35 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\Doctor\GetAllDoctor.cshtml"
           Write(Html.DisplayNameFor(model => model.EndTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 41 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\Doctor\GetAllDoctor.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 45 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\Doctor\GetAllDoctor.cshtml"
               Write(Html.DisplayFor(modelItem => item.DoctorId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 48 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\Doctor\GetAllDoctor.cshtml"
               Write(Html.DisplayFor(modelItem => item.Firstname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 51 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\Doctor\GetAllDoctor.cshtml"
               Write(Html.DisplayFor(modelItem => item.Lastname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 54 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\Doctor\GetAllDoctor.cshtml"
               Write(Html.DisplayFor(modelItem => item.Sex));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 57 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\Doctor\GetAllDoctor.cshtml"
               Write(Html.DisplayFor(modelItem => item.Specialization));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 60 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\Doctor\GetAllDoctor.cshtml"
               Write(Html.DisplayFor(modelItem => item.StartTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 63 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\Doctor\GetAllDoctor.cshtml"
               Write(Html.DisplayFor(modelItem => item.EndTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 66 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\Doctor\GetAllDoctor.cshtml"
               Write(Html.ActionLink("Edit", "Edit", new {  id=item.DoctorId  }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                    ");
#nullable restore
#line 67 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\Doctor\GetAllDoctor.cshtml"
               Write(Html.ActionLink("Delete", "Delete", new { id = item.DoctorId }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 70 "C:\Users\RAM-1\Downloads\Project CMS\CmsClientApp\Views\Doctor\GetAllDoctor.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CmsClientApp.Models.Doctor>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
