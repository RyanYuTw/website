using System.Web.Mvc;

namespace MyWeb.Helpers
{
    public static class ImageHelper
    {
        // 在副檔名前插入 _variant，e.g. /Content/images/products/black-gem-01.jpg → black-gem-01_list.jpg
        public static string ImageVariant(this HtmlHelper html, string imagePath, string variant)
        {
            if (string.IsNullOrEmpty(imagePath)) return null;
            int dot = imagePath.LastIndexOf('.');
            if (dot < 0) return imagePath;
            return imagePath.Substring(0, dot) + "_" + variant + imagePath.Substring(dot);
        }

        public static string NoImage(string variant)
        {
            return "/Content/images/no-image_" + variant + ".png";
        }
    }
}
