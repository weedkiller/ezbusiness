using EzBusiness_BL_Interface;
using EzBusiness_BL_Service;
using EzBusiness_ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzBusiness_Web.HtmlHelpers
{
    public static class MDIHelper
    {
        static IMasterService _masterService = new MasterService();

        
        public static List<SelectListItem> FormsDDLList(string cmpyCode)
        {
            return _masterService.FormsDDLList(cmpyCode);
        }

        public static List<SelectListItem> FormsDDLListWithParentFormValue(string cmpyCode)
        {
            return _masterService.FormsDDLListWithParentValue(cmpyCode);
        }


        //void RenderMenu(MenuItemsVM menuItem)
        //{

        //    if (menuItem.Children.Count > 0)
        //    {
        //        Response.Write(@"<li> <a href='#'><i class='fa fa-sitemap fa-fw'></i>" + menuItem.FormName + "<span class='glyphicon glyphicon-chevron-right'></span></a>");
        //        switch (menuItem.Levels)
        //        {
        //            case 2: Response.Write(@"<ul class='nav nav-second-level'>");
        //                break;
        //            case 3: Response.Write(@"<ul class='nav nav-third-level'>");
        //                break;
        //            case 4: Response.Write(@"<ul class='nav nav-fourth-level'>");
        //                break;
        //            default: Response.Write(@"<ul class='nav nav-second-level'>");
        //                break;

        //        }

        //        foreach (var child in menuItem.Children)
        //        {
        //            RenderMenu(child);
        //        }
        //        Response.Write("</ul>");
        //    }
        //    else
        //    {
        //        Response.Write(@"<li><a href='#'><i class='fa fa-sitemap fa-fw'></i>" + menuItem.FormName + "</a>");
        //    }
        //    Response.Write("</li>");
        //}
    }
}