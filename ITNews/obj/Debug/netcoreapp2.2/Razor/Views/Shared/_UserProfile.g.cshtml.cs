#pragma checksum "C:\dev\ITNews\ITNews\Views\Shared\_UserProfile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9e15967cc72cd44f9f306bfb2db2380bdf4e7c87"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__UserProfile), @"mvc.1.0.view", @"/Views/Shared/_UserProfile.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_UserProfile.cshtml", typeof(AspNetCore.Views_Shared__UserProfile))]
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
#line 1 "C:\dev\ITNews\ITNews\Views\_ViewImports.cshtml"
using ITNews;

#line default
#line hidden
#line 2 "C:\dev\ITNews\ITNews\Views\_ViewImports.cshtml"
using ITNews.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e15967cc72cd44f9f306bfb2db2380bdf4e7c87", @"/Views/Shared/_UserProfile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c3d4f75167dd73c023fe3329fb614ad17028d38e", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__UserProfile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/icon/man_default_avatar.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-circle"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Cinque Terre"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(120, 86, true);
            WriteLiteral("\r\n\r\n<div id=\"persanaldataContainer\" class=\"row\">\r\n    <div class=\"col-md-4\">\r\n        ");
            EndContext();
            BeginContext(206, 79, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "9e15967cc72cd44f9f306bfb2db2380bdf4e7c874314", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(285, 2200, true);
            WriteLiteral(@"
    </div>
    <div class=""col-md-8"">
        <div class=""form-group"">
            <label for=""inputEmail"" class=""col-form-label"">Email</label>
            <input id=""inputEmail"" v-model=""user.email""
                   class=""form-control"" type=""text"" name=""name"" value="""" placeholder=""email@example.com"" />
        </div>
        <div class=""form-group"">
            <label for=""inputPassword"" class=""col-form-label"">Password</label>
            <input id=""inputPassword"" v-model=""user.password""
                   class=""form-control"" type=""password"" name=""name"" value="""" placeholder=""password"" />
        </div>
        <div class=""form-group"">
            <label for=""inputName"" class=""col-form-label"">Name</label>
            <input id=""inputName"" v-model=""user.name""
                   class=""form-control"" type=""text"" name=""name"" value="""" placeholder=""Your name"" />
        </div>
        <div class=""form-group"">
            <label>Roles:</label>
            <div v-for=""item in roles"" class=""cu");
            WriteLiteral(@"stom-control custom-switch"">
                <input type=""checkbox"" class=""custom-control-input"" :id=""'inputRole_' + item.id"" v-model=""user.roles"" v-bind:value=""item"" v-bind:disabled=""item.disabled"">
                <label class=""custom-control-label"" v-bind:for=""'inputRole_' + item.id"">{{item.name}}</label>
            </div>
        </div>
        <input type=""button"" class=""btn btn-secondary"" name=""name"" value=""Apply"" v-on:click=""saveUser"" />
    </div>
</div>

<!--

                <div class=""form-check"">
                    <input class=""form-check-input"" type=""radio"" name=""exampleRadios"" id=""exampleRadios2"" value=""option2"">
                    <label class=""form-check-label"" for=""exampleRadios2"">
                        Second default radio
                    </label>
                </div>
                <div class=""form-check"">
                    <input class=""form-check-input"" type=""radio"" name=""exampleRadios"" id=""exampleRadios3"" value=""option3"" disabled>
                    <l");
            WriteLiteral("abel class=\"form-check-label\" for=\"exampleRadios3\">\r\n                        Disabled radio\r\n                    </label>\r\n                </div>\r\n-->\r\n");
            EndContext();
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
