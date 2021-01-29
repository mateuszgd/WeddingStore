using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WeddingStore.Models;

namespace WeddingStore.HtmlHelpers
{
    public static class HelperMethods
    {
        public static MvcHtmlString LinksPage(this HtmlHelper helper, PageLink pageLink, Func<int, string> url)
        {
            var result = new StringBuilder();
            for (int i = 1; i <= pageLink.NumberPages; i++)
            {
                var builder = new TagBuilder("a");
                builder.MergeAttribute("href", url(i));
                builder.InnerHtml = i.ToString();
                
                if (i == pageLink.SelectedPage)
                {
                    builder.AddCssClass("btn btn-outline-secondary active");
                }
                builder.AddCssClass("btn btn-outline-secondary");
                
                result.Append(builder.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}