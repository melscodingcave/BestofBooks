[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_AvailableInventoryListReport), @"mvc.1.0.view", @"/Views/Home/AvailableInventoryListReport.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b92a25b785525b83e619cc547bdaa695cd77e8db", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_AvailableInventoryListReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AvailableReportModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/css/bootstrap.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/site.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/inventorylist-jquery.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/site.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "irGenre", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("irGenre"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("background-color:#F5F5F5; text-align:center; height:1.6em"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("Search..."), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("authorInput"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onkeyup", new global::Microsoft.AspNetCore.Html.HtmlString("filterFunction()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "all", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_14 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "in stock", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_15 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "out stock", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_16 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "irInStock", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_17 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("irInStock"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_18 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("availableInventoryForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "69d4944960640406adc48bbdad2132d3911294b711131", async () => {
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d96f201fbca6efb1da43182246a07c2864dd877910894", async () => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "69d4944960640406adc48bbdad2132d3911294b712246", async () => {
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d96f201fbca6efb1da43182246a07c2864dd877912009", async () => {
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
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "69d4944960640406adc48bbdad2132d3911294b713361", async () => {
                        __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d96f201fbca6efb1da43182246a07c2864dd877913124", async () => {
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
                        __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "69d4944960640406adc48bbdad2132d3911294b714401", async () => {
                            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d96f201fbca6efb1da43182246a07c2864dd877914164", async () => {
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
                            BeginWriteAttribute("src", " src=\"", 607, "\"", 654, 1);
                            EndWriteAttribute();
                            WriteLiteral(" class=\"img-fluid\" style=\"width:13em; padding-bottom:1em\" />\r\n    </div>\r\n</div>\r\n\r\n<div class=\"container text-center\">\r\n    <p style=\"color: #0429AC; font-weight:bold; font-size:30px\">Available Inventory List Report</p>\r\n\r\n    ");
                            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "69d4944960640406adc48bbdad2132d3911294b716358", async () => {
                                WriteLiteral("\r\n        ");
                                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "69d4944960640406adc48bbdad2132d3911294b716627", async () => {
                                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d96f201fbca6efb1da43182246a07c2864dd877916143", async () => {
                                        WriteLiteral("\r\n        ");
                                        __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d96f201fbca6efb1da43182246a07c2864dd877916412", async () => {
                                            WriteLiteral("Select Genre");
                                        }
                                        );
                                        __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                                        __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                                        __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_5.Value;
                                        __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
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
                                    }
                                    );
                                    __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                                    __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_6.Value;
                                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                                    {
                                        await __tagHelperExecutionContext.SetOutputContentAsync();
                                    }
                                    Write(__tagHelperExecutionContext.Output);
                                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                                    WriteLiteral("\r\n\r\n");
                                    WriteLiteral("    <div class=\"dropdown\">\r\n        <button onclick=\"dropdownState()\" class=\"dropbtn\" style=\"height:1.6em\">Select Author</button>\r\n        <div id=\"authorDropdown\" class=\"dropdown-content\">\r\n            ");
                                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "69d4944960640406adc48bbdad2132d3911294b720840", async () => {
                                        WriteLiteral("\r\n\r\n    <div class=\"dropdown\">\r\n        <button onclick=\"dropdownState()\" class=\"dropbtn\" style=\"height:1.6em\">Select Author</button>\r\n        <div id=\"authorDropdown\" class=\"dropdown-content\">\r\n            ");
                                        __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d96f201fbca6efb1da43182246a07c2864dd877920638", async () => {
                                        }
                                        );
                                        __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                                        __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                                        __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_9.Value;
                                        __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
                                        __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
                                        __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
                                        __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
                                        __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                                        await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                                        if (!__tagHelperExecutionContext.Output.IsContentModified)
                                        {
                                            await __tagHelperExecutionContext.SetOutputContentAsync();
                                        }
                                        Write(__tagHelperExecutionContext.Output);
                                        __tagHelperExecutionContext = __tagHelperScopeManager.End();
                                        WriteLiteral("\r\n        </div>\r\n    </div>\r\n\r\n");
                                        WriteLiteral("    ");
                                        __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "69d4944960640406adc48bbdad2132d3911294b722828", async () => {
                                            WriteLiteral("\r\n        ");
                                            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "69d4944960640406adc48bbdad2132d3911294b723097", async () => {
                                                WriteLiteral("\r\n        </div>\r\n    </div>\r\n\r\n    ");
                                                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d96f201fbca6efb1da43182246a07c2864dd877922617", async () => {
                                                    WriteLiteral("\r\n        ");
                                                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d96f201fbca6efb1da43182246a07c2864dd877922886", async () => {
                                                        WriteLiteral("Select In Stock");
                                                    }
                                                    );
                                                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                                                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                                                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_5.Value;
                                                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
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
                                                    WriteLiteral("\r\n        ");
                                                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "69d4944960640406adc48bbdad2132d3911294b724984", async () => {
                                                        __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d96f201fbca6efb1da43182246a07c2864dd877924773", async () => {
                                                            WriteLiteral("All");
                                                        }
                                                        );
                                                        __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                                                        __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                                                        __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_13.Value;
                                                        __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_13);
                                                        await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                                                        if (!__tagHelperExecutionContext.Output.IsContentModified)
                                                        {
                                                            await __tagHelperExecutionContext.SetOutputContentAsync();
                                                        }
                                                        Write(__tagHelperExecutionContext.Output);
                                                        __tagHelperExecutionContext = __tagHelperScopeManager.End();
                                                        WriteLiteral("\r\n        ");
                                                        __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "69d4944960640406adc48bbdad2132d3911294b726215", async () => {
                                                            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d96f201fbca6efb1da43182246a07c2864dd877926004", async () => {
                                                                WriteLiteral("In Stock");
                                                            }
                                                            );
                                                            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                                                            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                                                            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_14.Value;
                                                            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_14);
                                                            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                                                            if (!__tagHelperExecutionContext.Output.IsContentModified)
                                                            {
                                                                await __tagHelperExecutionContext.SetOutputContentAsync();
                                                            }
                                                            Write(__tagHelperExecutionContext.Output);
                                                            __tagHelperExecutionContext = __tagHelperScopeManager.End();
                                                            WriteLiteral("\r\n        ");
                                                            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "69d4944960640406adc48bbdad2132d3911294b727451", async () => {
                                                                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d96f201fbca6efb1da43182246a07c2864dd877927240", async () => {
                                                                    WriteLiteral("Out of Stock");
                                                                }
                                                                );
                                                                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                                                                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                                                                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_15.Value;
                                                                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_15);
                                                                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                                                                if (!__tagHelperExecutionContext.Output.IsContentModified)
                                                                {
                                                                    await __tagHelperExecutionContext.SetOutputContentAsync();
                                                                }
                                                                Write(__tagHelperExecutionContext.Output);
                                                                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                                                                WriteLiteral("\r\n    ");
                                                            }
                                                        );
                                                            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                                                            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                                                            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_16.Value;
                                                            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_16);
                                                            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_17);
                                                            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                                                            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                                                            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                                                            if (!__tagHelperExecutionContext.Output.IsContentModified)
                                                            {
                                                                await __tagHelperExecutionContext.SetOutputContentAsync();
                                                            }
                                                            Write(__tagHelperExecutionContext.Output);
                                                            __tagHelperExecutionContext = __tagHelperScopeManager.End();
                                                            WriteLiteral("\r\n\r\n");
                                                            WriteLiteral("    <div class=\"container text-center\" style=\"padding: 1em 0 1em 0\">\r\n        <button id=\"SearchBtn\" name=\"inventoryReportSearchBtn\">Search</button>\r\n    </div>\r\n\r\n    ");
                                                            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "69d4944960640406adc48bbdad2132d3911294b730515", async () =>
                                                            {
                                                            WriteLiteral("\r\n\r\n    <div class=\"container text-center\" style=\"padding: 1em 0 1em 0\">\r\n        <button id=\"SearchBtn\" name=\"inventoryReportSearchBtn\">Search</button>\r\n    </div>\r\n\r\n    ");
                                                            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d96f201fbca6efb1da43182246a07c2864dd877930295", async () =>
                                                            {
                                                                WriteLiteral(@"
                                                                    <table class=""table-hover table-bordered align-items-center"" id=""ListTable"" cellspacing=5 cellpadding=5 border=""1"">
                                                                        <tr class=""text-center"">
                                                                            <th>ISBN</th>
                                                                            <th>Title</th>
                                                                            <th>Author First Name</th>
                                                                            <th>Author Last Name</th>
                                                                            <th>Genre</th>
                                                                            <th>Location</th>
                                                                            <th>Price</th>
                                                                            <th>Quantity</th>
                                                                        </tr>
");
                                                                for (var i = 0; i < Model.Books.Count(); i++)
                                                                {
                                                                    Write(Model.Books[i].ISBN);
                                                                    WriteLiteral("</td>\r\n                                <td>");
                                                                    Write(Model.Books[i].Title);
                                                                    WriteLiteral("</td>\r\n                                <td>");
                                                                    Write(Model.Books[i].AuthorFirst);
                                                                    WriteLiteral("</td>\r\n                                <td>");
                                                                    Write(Model.Books[i].AuthorLast);
                                                                    WriteLiteral("</td>\r\n                                <td>");
                                                                    Write(Model.Books[i].Genre);
                                                                    WriteLiteral("</td>\r\n                                <td>");
                                                                    Write(Model.Books[i].Location);
                                                                    WriteLiteral("</td>\r\n                                <td>");
                                                                    Write(Model.Books[i].Price.ToString("C"));
                                                                    WriteLiteral("</td>\r\n                                <td>");
                                                                    Write(Model.Books[i].Quantity);
                                                                    WriteLiteral("</td>\r\n                                <td>");
                                                                    Write(Model.Books[i].InStock);
                                                                    WriteLiteral("</td>\r\n                            </tr>\r\n");
                                                                }
                                                                WriteLiteral("            </table>\r\n    ");
                                                            }
                                                            );
                                                            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                                                            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                                                            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                                                            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                                                            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_18);
                                                            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                                                            if (!__tagHelperExecutionContext.Output.IsContentModified)
                                                            {
                                                                await __tagHelperExecutionContext.SetOutputContentAsync();
                                                            }
                                                            Write(__tagHelperExecutionContext.Output);
                                                            __tagHelperExecutionContext = __tagHelperScopeManager.End();
                                                            WriteLiteral("\r\n\r\n    <div class=\"container text-center\" style=\"padding: 1em 0 1em 0\">\r\n        <button id=\"PrintBtn\" name=\"inventoryReportPrintBtn\">Print</button>\r\n    </div>\r\n\r\n</div>\r\n\r\n");
                                                            DefineSection("Scripts", async () =>
                                                            {
                                                                WriteLiteral("\r\n    ");
                                                                Write(await Html.PartialAsync("_ValidationScriptsPartial"));
                                                                WriteLiteral("\r\n    ");
                                                                Write(await Html.PartialAsync("Login", model: new AdminModel()));
                                                                WriteLiteral("\r\n");
                                                            }
                                                            );
                                                            WriteLiteral("\r\n\r\n");
                                                            }
                                                        ); }
                                                    ); }
                                                ); }
                                            ); }
                                        ); }
                                    ); }
                                ); }
                            ); }
                        ); }
                    ); }
                ); }
            ); }
        );} 
    } 
}