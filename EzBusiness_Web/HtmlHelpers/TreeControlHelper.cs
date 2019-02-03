using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzBusiness_Web.HtmlHelpers
{
    public static class TreeControlExtension
    {
        public static MvcHtmlString TreeControl<T>(this HtmlHelper helper, IList<T> source) 
        {
            //Response.Write("<ul>");
            //foreach (var topLevelMenu in topLevelMenus)
            //{
            //    RenderMenu(topLevelMenu);
            //}
            //Response.Write("</ul>");

            return new MvcHtmlString("");
        }

        //void RenderMenu(MenuItemsVM menuItem)
        //{
        //    Response.Write("<li>" + menuItem.FormName);
        //    if (menuItem.Children.Count > 0)
        //    {
        //        Response.Write("<ul>");
        //        foreach (var child in menuItem.Children)
        //        {
        //            RenderMenu(child);
        //        }
        //        Response.Write("</ul>");
        //    }
        //    Response.Write("</li>");
        //}
    }
}