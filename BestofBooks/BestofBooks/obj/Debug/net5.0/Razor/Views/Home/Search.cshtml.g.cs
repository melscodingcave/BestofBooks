[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Search), @"mvc.1.0.view", @"/Views/Home/Search.cshtml")]
namespace AspNetCore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using BestofBooks;
    using BestofBooks.Models;

    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e6d8c7f8950debfd1ffc9a2fa05355bf190281da", @"/Views/Home/Search.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b92a25b785525b83e619cc547bdaa695cd77e8db", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Search : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<BookModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/css/bootstrap.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/site.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/site.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/js/bootstrap.bundle.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private string __tagHelperStringValueBuffer;
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            ViewData["Title"] = "Search";
            WriteLiteral("\r\n<title>");
            Write(ViewData["Title"]);
            WriteLiteral(" - BestofBooks</title>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e7c94ba3293fff193cb80c52100dd259c0c57e605778", async () =>
            {
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e6d8c7f8950debfd1ffc9a2fa05355bf190281da5907", async () =>
                {
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
                WriteLiteral("\r\n");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e7c94ba3293fff193cb80c52100dd259c0c57e606892", async () =>
                {
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e6d8c7f8950debfd1ffc9a2fa05355bf190281da7021", async () =>
                    {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e7c94ba3293fff193cb80c52100dd259c0c57e608006", async () =>
                    {
                        __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e6d8c7f8950debfd1ffc9a2fa05355bf190281da8135", async () =>
                        {
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
                        WriteLiteral("\r\n");
                        __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e7c94ba3293fff193cb80c52100dd259c0c57e609045", async () =>
                        {
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
<script src=""https://kit.fontawesome.com/f9f4cabcd6.js"" crossorigin=""anonymous""></script>

<div class=""container-fluid my-4"">
    <div class=""text-center"">
        <h1 class=""text-wrap"" style=""color: #0429AC"">Welcome to Best of Books!</h1>
        <img");
                        BeginWriteAttribute("src", " src=\"", 538, "\"", 585, 1);
                        WriteAttributeValue("", 598, Url.Content("~/Images/BestofBooks2.png"), 598, 41, false);
                        WriteAttributeValue("", 544, Url.Content("~/Images/BestofBooks2.png"), 544, 41, false);
                        EndWriteAttribute();
                        WriteLiteral(@" class=""img-fluid"" style=""width:13em; padding-bottom:3em"" />
        <p style=""color: #0429AC"">Enter your search parameters below!!</p>
    </div>
</div>
<div class=""container text-center"" style=""padding: .5em 0 .5em 0"">
    <select name=""searchOptions"" id=""searchOptions"" style=""background-color:#DBD9CA; text-align:center; height:1.6em; color:#004803"">
    ");
                        __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e7c94ba3293fff193cb80c52100dd259c0c57e6011111", async () =>
                        {
                            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e6d8c7f8950debfd1ffc9a2fa05355bf190281da10223", async () =>
                            {
                                WriteLiteral("Select Filter Option");
                            }
                            );
                            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
                            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                            BeginWriteTagHelperAttribute();
                            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                            __tagHelperExecutionContext.AddHtmlAttribute("disabled", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                            BeginWriteTagHelperAttribute();
                            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                            if (!__tagHelperExecutionContext.Output.IsContentModified)
                            {
                                await __tagHelperExecutionContext.SetOutputContentAsync();
                            }
                            Write(__tagHelperExecutionContext.Output);
                            __tagHelperExecutionContext = __tagHelperScopeManager.End();
                            WriteLiteral("\r\n    ");
                            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e7c94ba3293fff193cb80c52100dd259c0c57e6012911", async () =>
                            {
                                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e6d8c7f8950debfd1ffc9a2fa05355bf190281da12023", async () =>
                                {
                                    WriteLiteral("Genre");
                                }
                                );
                                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
                                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                                if (!__tagHelperExecutionContext.Output.IsContentModified)
                                {
                                    await __tagHelperExecutionContext.SetOutputContentAsync();
                                }
                                Write(__tagHelperExecutionContext.Output);
                                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                                WriteLiteral("\r\n    ");
                                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e7c94ba3293fff193cb80c52100dd259c0c57e6014074", async () =>
                                {
                                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e6d8c7f8950debfd1ffc9a2fa05355bf190281da13186", async () =>
                                    {
                                        WriteLiteral("Author Last Name");
                                    }
                                    );
                                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
                                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                                    {
                                        await __tagHelperExecutionContext.SetOutputContentAsync();
                                    }
                                    Write(__tagHelperExecutionContext.Output);
                                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                                    WriteLiteral("\r\n    ");
                                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e7c94ba3293fff193cb80c52100dd259c0c57e6015248", async () =>
                                    {
                                        __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e6d8c7f8950debfd1ffc9a2fa05355bf190281da14360", async () =>
                                        {
                                            WriteLiteral("Author First Name");
                                        }
                                        );
                                        __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                                        __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                                        __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
                                        __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                                        await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                                        if (!__tagHelperExecutionContext.Output.IsContentModified)
                                        {
                                            await __tagHelperExecutionContext.SetOutputContentAsync();
                                        }
                                        Write(__tagHelperExecutionContext.Output);
                                        __tagHelperExecutionContext = __tagHelperScopeManager.End();
                                        WriteLiteral("\r\n    ");
                                        __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e7c94ba3293fff193cb80c52100dd259c0c57e6016423", async () =>
                                        {
                                            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e6d8c7f8950debfd1ffc9a2fa05355bf190281da15535", async () =>
                                            {
                                                WriteLiteral("Title");
                                            }
                                            );
                                            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                                            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                                            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
                                            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                                            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                                            if (!__tagHelperExecutionContext.Output.IsContentModified)
                                            {
                                                await __tagHelperExecutionContext.SetOutputContentAsync();
                                            }
                                            Write(__tagHelperExecutionContext.Output);
                                            __tagHelperExecutionContext = __tagHelperScopeManager.End();
                                            WriteLiteral(@"
    </select>

    <div class=""text-body"" style=""padding: .5em 0 .5em 0"">
        <input type=""text"" id=""textFilter"" name=""Text Filter"" maxlength=""25"" />
    </div>
</div>
<div class=""container text-center"">
    <button id=""SearchBtn"" name=""Search"" style=""color:#004803; border-color:#004803; background-color:#DBD9CA; font-weight:bold"">Search</button>
    <button id=""ClearBtn"" name=""Clear"" style=""color:#004803; border-color:#004803; background-color:#DBD9CA; font-weight:bold"">Clear</button>
</div>
<div class=""container text-center"" style=""padding: .5em 0 .5em 0"" id=""printArea"">
     <button id=""PrintBtn"" name=""searchPrintBtn"">Print</button>
     <table class=""table-hover table-bordered align-items-center text-center"" id=""ListTable"" cellspacing=5 cellpadding=5 border=""1"" style=""visibility:hidden"">
        <tr class=""text-center"">
            <th>ISBN</th>
            <th>Title</th>
            <th>Author First Name</th>
            <th>Author Last Name</th>
            <th>Genre</th>
      ");
                                            WriteLiteral("      <th>Location</th>\r\n            <th>Price</th>\r\n            <th>Quantity</th>\r\n            <th>In Stock</th>\r\n        </tr>\r\n");
                                            for (var i = 0; i < Model.Count(); i++)
                                            {
                                                WriteLiteral("                    <tr>\r\n                        <td>");
                                                Write(Model[i].ISBN);
                                                WriteLiteral("</td>\r\n                        <td>");
                                                Write(Model[i].Title);
                                                WriteLiteral("</td>\r\n                        <td>");
                                                Write(Model[i].AuthorFirst);
                                                WriteLiteral("</td>\r\n                        <td>");
                                                Write(Model[i].AuthorLast);
                                                WriteLiteral("</td>\r\n                        <td>");
                                                Write(Model[i].Genre);
                                                WriteLiteral("</td>\r\n                        <td>");
                                                Write(Model[i].Location);
                                                WriteLiteral("</td>\r\n                        <td>");
                                                Write(Model[i].Price.ToString("C"));
                                                WriteLiteral("</td>\r\n                        <td>");
                                                Write(Model[i].Quantity);
                                                WriteLiteral("</td>\r\n                        <td>");
                                                Write(Model[i].InStock);
                                                WriteLiteral("</td>\r\n                    </tr>\r\n");
                                            }
                                            WriteLiteral("    </table>\r\n</div>\r\n");
                                            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e6d8c7f8950debfd1ffc9a2fa05355bf190281da21146", async () =>
                                            {
                                            }
                                            );
                                            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                                            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                                            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                                            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                                            if (!__tagHelperExecutionContext.Output.IsContentModified)
                                            {
                                                await __tagHelperExecutionContext.SetOutputContentAsync();
                                            }
                                            Write(__tagHelperExecutionContext.Output);
                                            __tagHelperExecutionContext = __tagHelperScopeManager.End();
                                            WriteLiteral("\r\n");
                                            DefineSection("Scripts", async () =>
                                            {
                                                WriteLiteral("\r\n    ");
                                                Write(await Html.PartialAsync("_ValidationScriptsPartial"));
                                                WriteLiteral("\r\n    ");
                                                Write(await Html.PartialAsync("Login", model: new AdminModel()));
                                                WriteLiteral("\r\n");
                                            }
                                            );
                                        });
                                    });
                                });
                            });
                        });
                    });
                });
            });
        }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<BookModel>> Html { get; private set; } = default!;
    }
}
