#pragma checksum "C:\dev\ITNews\ITNews\Views\MySpace\MyNews.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "86b277b184ca79a7241a69f32451724ac59458b9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MySpace_MyNews), @"mvc.1.0.view", @"/Views/MySpace/MyNews.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/MySpace/MyNews.cshtml", typeof(AspNetCore.Views_MySpace_MyNews))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86b277b184ca79a7241a69f32451724ac59458b9", @"/Views/MySpace/MyNews.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c3d4f75167dd73c023fe3329fb614ad17028d38e", @"/Views/_ViewImports.cshtml")]
    public class Views_MySpace_MyNews : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/mySpace/myNews.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\dev\ITNews\ITNews\Views\MySpace\MyNews.cshtml"
  
    ViewData["Title"] = "MyNews";

#line default
#line hidden
            BeginContext(44, 57, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "86b277b184ca79a7241a69f32451724ac59458b93953", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(101, 21, true);
            WriteLiteral("\r\n<h1>MyNews</h1>\r\n\r\n");
            EndContext();
#line 8 "C:\dev\ITNews\ITNews\Views\MySpace\MyNews.cshtml"
   Html.RenderPartial("~/Views/News/_NewsListPartial.cshtml");

#line default
#line hidden
            BeginContext(187, 1189, true);
            WriteLiteral(@"
<!--
<script src=""~/js/markDown/MarkDownHelper.js""></script>

<script src=""~/js/markDown/ace/1.1.3/ace.js""></script>
<script src=""~/js/markDown/ace/1.1.3/ext-language_tools.js""></script>
<script src=""~/js/markDown/ace/1.1.3/mode-markdown.js""></script>
<script src=""~/js/markDown/ace/1.1.3/theme-tomorrow.js""></script>
<script src=""~/js/markDown/marked/0.3.2/marked.min.js""></script>
<script src=""~/js/markDown/jquery/2.1.3/jquery.min.js""></script>

<link href=""~/css/markDown/bootstrap-markdown-editor.css"" rel=""stylesheet"">
<script src=""~/lib/bootstap_3.3.1/js/bootstrap.min.js""></script>
<script src=""~/js/markDown/bootstrap-markdown-editor.js""></script>
-->


<script>
    jQuery(document).ready(function ($) {
        let loader = new Loader({ getActionsUrl: domainPath + '/api/news/getActions' });
        loader.getActions()
            .done(function (data) {
                let service = new NewsService(data.actions);
                let viewModel = new NewsViewModel(service);
           ");
            WriteLiteral("     viewModel.newsVue.userForFilter = sessionStorage.getItem(\'currentUserId\');\r\n                viewModel.newsVue.initialize();\r\n            });\r\n    });\r\n</script>");
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
