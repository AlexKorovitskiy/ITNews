#pragma checksum "C:\dev\ITNews\ITNews\Views\News\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0fb4731a6f57028e28b33cc84e9f8a92ed69a301"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_News_Index), @"mvc.1.0.view", @"/Views/News/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/News/Index.cshtml", typeof(AspNetCore.Views_News_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0fb4731a6f57028e28b33cc84e9f8a92ed69a301", @"/Views/News/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c3d4f75167dd73c023fe3329fb614ad17028d38e", @"/Views/_ViewImports.cshtml")]
    public class Views_News_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\dev\ITNews\ITNews\Views\News\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(90, 19, true);
            WriteLiteral("\r\n<h1>News</h1>\r\n\r\n");
            EndContext();
#line 9 "C:\dev\ITNews\ITNews\Views\News\Index.cshtml"
   Html.RenderPartial("~/Views/News/_NewsListPartial.cshtml");

#line default
#line hidden
            BeginContext(174, 414, true);
            WriteLiteral(@"

<script>
    $(document).ready(function () {
        let loader = new Loader({ getActionsUrl: domainPath + '/api/news/getActions' });
        loader.getActions()
            .done(function (data) {
                let service = new NewsService(data.actions);
                let viewModel = new NewsViewModel(service);
                viewModel.newsVue.initialize();
            });
    });
</script>");
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
