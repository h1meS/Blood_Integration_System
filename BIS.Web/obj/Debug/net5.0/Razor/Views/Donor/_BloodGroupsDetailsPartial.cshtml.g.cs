#pragma checksum "C:\Users\semih\Documents\Blood_Integration_System\BIS.Web\Views\Donor\_BloodGroupsDetailsPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e602bfd22162d40ee9fadc219387d167ea37fe47"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Donor__BloodGroupsDetailsPartial), @"mvc.1.0.view", @"/Views/Donor/_BloodGroupsDetailsPartial.cshtml")]
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
#line 1 "C:\Users\semih\Documents\Blood_Integration_System\BIS.Web\Views\_ViewImports.cshtml"
using BIS.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\semih\Documents\Blood_Integration_System\BIS.Web\Views\Donor\_BloodGroupsDetailsPartial.cshtml"
using BIS.ViewModels.VM;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e602bfd22162d40ee9fadc219387d167ea37fe47", @"/Views/Donor/_BloodGroupsDetailsPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bb0947cfa769db61a19bcb70e477a82b25e1d232", @"/Views/_ViewImports.cshtml")]
    public class Views_Donor__BloodGroupsDetailsPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BloodGroupVm>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<hr/>\r\n<label>Blood Group:</label>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 9 "C:\Users\semih\Documents\Blood_Integration_System\BIS.Web\Views\Donor\_BloodGroupsDetailsPartial.cshtml"
           Write(Html.DisplayNameFor(model => model.Type));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 14 "C:\Users\semih\Documents\Blood_Integration_System\BIS.Web\Views\Donor\_BloodGroupsDetailsPartial.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 17 "C:\Users\semih\Documents\Blood_Integration_System\BIS.Web\Views\Donor\_BloodGroupsDetailsPartial.cshtml"
           Write(Html.DisplayFor(modelItem => item.Type));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 20 "C:\Users\semih\Documents\Blood_Integration_System\BIS.Web\Views\Donor\_BloodGroupsDetailsPartial.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BloodGroupVm>> Html { get; private set; }
    }
}
#pragma warning restore 1591
