#pragma checksum "C:\Users\Usuario\Desktop\papeles\PruebasPractica\ApplicationProgramming\src\BP.API.Web\Views\Shared\Components\LanguageSelection\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "06e3d2f41b77ddf5598b1a0e6aa1195db527c85e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_LanguageSelection_Default), @"mvc.1.0.view", @"/Views/Shared/Components/LanguageSelection/Default.cshtml")]
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
#line 1 "C:\Users\Usuario\Desktop\papeles\PruebasPractica\ApplicationProgramming\src\BP.API.Web\Views\_ViewImports.cshtml"
using Abp.Localization;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"06e3d2f41b77ddf5598b1a0e6aa1195db527c85e", @"/Views/Shared/Components/LanguageSelection/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"43c1c3d5c91170c35a4ff78c3b097ff0f696bb4d", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_LanguageSelection_Default : BP.API.Web.Views.CorporateRazorPage<BP.API.Web.Views.Shared.Components.LanguageSelection.LanguageSelectionViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<li class=\"dropdown\">\r\n    <a href=\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\">\r\n        <div");
            BeginWriteAttribute("class", " class=\"", 188, "\"", 223, 1);
#line 4 "C:\Users\Usuario\Desktop\papeles\PruebasPractica\ApplicationProgramming\src\BP.API.Web\Views\Shared\Components\LanguageSelection\Default.cshtml"
WriteAttributeValue("", 196, Model.CurrentLanguage.Icon, 196, 27, false);

#line default
#line hidden
            EndWriteAttribute();
            WriteLiteral("></div>\r\n        <span>");
#line 5 "C:\Users\Usuario\Desktop\papeles\PruebasPractica\ApplicationProgramming\src\BP.API.Web\Views\Shared\Components\LanguageSelection\Default.cshtml"
         Write(Model.CurrentLanguage.DisplayName);

#line default
#line hidden
            WriteLiteral("</span>\r\n        <b class=\"caret\"></b>\r\n    </a>\r\n    <ul class=\"dropdown-menu\">\r\n");
#line 9 "C:\Users\Usuario\Desktop\papeles\PruebasPractica\ApplicationProgramming\src\BP.API.Web\Views\Shared\Components\LanguageSelection\Default.cshtml"
         foreach (var language in Model.Languages)
        {
            if (language.Name != Model.CurrentLanguage.Name)
            {

#line default
#line hidden
            WriteLiteral("                <li><a");
            BeginWriteAttribute("href", " href=\"", 525, "\"", 638, 5);
#line 13 "C:\Users\Usuario\Desktop\papeles\PruebasPractica\ApplicationProgramming\src\BP.API.Web\Views\Shared\Components\LanguageSelection\Default.cshtml"
WriteAttributeValue("", 532, Url.Action("ChangeCulture", "AbpLocalization"), 532, 47, false);

#line default
#line hidden
            WriteAttributeValue("", 579, "?cultureName=", 579, 13, true);
#line 13 "C:\Users\Usuario\Desktop\papeles\PruebasPractica\ApplicationProgramming\src\BP.API.Web\Views\Shared\Components\LanguageSelection\Default.cshtml"
WriteAttributeValue("", 592, language.Name, 592, 16, false);

#line default
#line hidden
            WriteAttributeValue("", 608, "&returnUrl=", 608, 11, true);
#line 13 "C:\Users\Usuario\Desktop\papeles\PruebasPractica\ApplicationProgramming\src\BP.API.Web\Views\Shared\Components\LanguageSelection\Default.cshtml"
WriteAttributeValue("", 619, Model.CurrentUrl, 619, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            WriteLiteral("><div");
            BeginWriteAttribute("class", " class=\"", 644, "\"", 666, 1);
#line 13 "C:\Users\Usuario\Desktop\papeles\PruebasPractica\ApplicationProgramming\src\BP.API.Web\Views\Shared\Components\LanguageSelection\Default.cshtml"
WriteAttributeValue("", 652, language.Icon, 652, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            WriteLiteral("></div> ");
#line 13 "C:\Users\Usuario\Desktop\papeles\PruebasPractica\ApplicationProgramming\src\BP.API.Web\Views\Shared\Components\LanguageSelection\Default.cshtml"
                                                                                                                                                                       Write(language.DisplayName);

#line default
#line hidden
            WriteLiteral("</a></li>\r\n");
#line 14 "C:\Users\Usuario\Desktop\papeles\PruebasPractica\ApplicationProgramming\src\BP.API.Web\Views\Shared\Components\LanguageSelection\Default.cshtml"
            }
        }

#line default
#line hidden
            WriteLiteral("    </ul>\r\n</li>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BP.API.Web.Views.Shared.Components.LanguageSelection.LanguageSelectionViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591