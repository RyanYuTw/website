using System;
using System.Text;
using System.Web.Mvc;

namespace MyWeb.Helpers
{
    public static class PagingHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
                                              int currentPage,
                                              int totalPages,
                                              Func<int, string> pageUrl)
        {
            var sb = new StringBuilder();
            sb.Append("<nav><ul class=\"pagination\">");
            for (int idx = 1; idx <= totalPages; idx++)
            {
                var tag = new TagBuilder("li");
                tag.AddCssClass("page-item");
                if (idx == currentPage) tag.AddCssClass("active");
                var link = new TagBuilder("a");
                link.AddCssClass("page-link");
                link.MergeAttribute("href", pageUrl(idx));
                link.InnerHtml = idx.ToString();
                tag.InnerHtml = link.ToString();
                sb.Append(tag.ToString());
            }
            sb.Append("</ul></nav>");
            return MvcHtmlString.Create(sb.ToString());
        }

        public static int TotalPages(int totalCount, int pageSize)
        {
            return (int)Math.Ceiling(totalCount / (double)pageSize);
        }
    }
}
