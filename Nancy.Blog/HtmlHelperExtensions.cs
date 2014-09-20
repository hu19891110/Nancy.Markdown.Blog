﻿using System.IO;
using Nancy.ViewEngines.Razor;

namespace Nancy.Markdown.Blog
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlString Markdown<TModel>(this HtmlHelpers<TModel> helpers, string text, string baseUri = null)
        {
            var md = new MarkdownDeep.Markdown {ExtraMode = true, UrlBaseLocation = baseUri};
            var html = md.Transform(text);
            return new NonEncodedHtmlString(html);
        }

        public static IHtmlString MarkdownLoad<TModel>(this HtmlHelpers<TModel> helpers, string path, string baseUri = null)
        {
            return helpers.Markdown(File.ReadAllText(path), baseUri);
        }
    }
}