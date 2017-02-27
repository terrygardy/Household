﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using Household;
    
    #line 7 "..\..\Views\Home\Index.cshtml"
    using Household.Controllers;
    
    #line default
    #line hidden
    
    #line 1 "..\..\Views\Home\Index.cshtml"
    using Household.Localisation.Common;
    
    #line default
    #line hidden
    
    #line 2 "..\..\Views\Home\Index.cshtml"
    using Household.Localisation.Main;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Views\Home\Index.cshtml"
    using Household.Localisation.Main.Finance;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Views\Home\Index.cshtml"
    using Household.Localisation.Main.ShoppingList;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Views\Home\Index.cshtml"
    using Household.Localisation.Main.Work;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Views\Home\Index.cshtml"
    using Household.MvcExtensions;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Home/Index.cshtml")]
    public partial class _Views_Home_Index_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Home_Index_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\n");

            
            #line 9 "..\..\Views\Home\Index.cshtml"
  
	ViewBag.Title = GeneralText.Home;

            
            #line default
            #line hidden
WriteLiteral("\n\n<div");

WriteLiteral(" class=\"jumbotron\"");

WriteLiteral(">\n\t<h1>");

            
            #line 14 "..\..\Views\Home\Index.cshtml"
   Write(GeneralText.Household);

            
            #line default
            #line hidden
WriteLiteral("</h1>\n\t<p");

WriteLiteral(" class=\"lead\"");

WriteLiteral(">");

            
            #line 15 "..\..\Views\Home\Index.cshtml"
               Write(GeneralText.WelcomeToOurHouseholdManagementSystem);

            
            #line default
            #line hidden
WriteLiteral("</p>\n</div>\n\n<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\n\t<div");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\n\t\t<div");

WriteLiteral(" class=\"panel-finance panel-main-clickable\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 533), Tuple.Create("\"", 618)
, Tuple.Create(Tuple.Create("", 543), Tuple.Create("document.location", 543), true)
, Tuple.Create(Tuple.Create(" ", 560), Tuple.Create("=", 561), true)
, Tuple.Create(Tuple.Create(" ", 562), Tuple.Create("\'", 563), true)
            
            #line 20 "..\..\Views\Home\Index.cshtml"
       , Tuple.Create(Tuple.Create("", 564), Tuple.Create<System.Object, System.Int32>(Url.ActionFinance(nameof(FinanceController.Finance))
            
            #line default
            #line hidden
, 564), false)
, Tuple.Create(Tuple.Create("", 617), Tuple.Create("\'", 617), true)
);

WriteLiteral(">\n\t\t\t<div>\n\t\t\t\t<h2>");

            
            #line 22 "..\..\Views\Home\Index.cshtml"
               Write(FinanceText.Finance);

            
            #line default
            #line hidden
WriteLiteral("</h2>\n\t\t\t\t<p>");

            
            #line 23 "..\..\Views\Home\Index.cshtml"
              Write(FinanceText.ExpensesPurchasesAndMonthlyBills);

            
            #line default
            #line hidden
WriteLiteral("</p>\n\t\t\t</div>\n\t\t</div>\n\t</div>\n\t<div");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\r\n\t\t<div");

WriteLiteral(" class=\"panel-shoppinglist panel-main-clickable\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 827), Tuple.Create("\"", 920)
, Tuple.Create(Tuple.Create("", 837), Tuple.Create("document.location", 837), true)
, Tuple.Create(Tuple.Create(" ", 854), Tuple.Create("=", 855), true)
, Tuple.Create(Tuple.Create(" ", 856), Tuple.Create("\'", 857), true)
            
            #line 28 "..\..\Views\Home\Index.cshtml"
            , Tuple.Create(Tuple.Create("", 858), Tuple.Create<System.Object, System.Int32>(Url.ActionShoppingList(nameof(ShoppingListController.Index))
            
            #line default
            #line hidden
, 858), false)
, Tuple.Create(Tuple.Create("", 919), Tuple.Create("\'", 919), true)
);

WriteLiteral(">\r\n\t\t\t<div>\r\n\t\t\t\t<h2>");

            
            #line 30 "..\..\Views\Home\Index.cshtml"
               Write(ShoppingListItemText.ShoppingList);

            
            #line default
            #line hidden
WriteLiteral("</h2>\r\n\t\t\t\t<p>");

            
            #line 31 "..\..\Views\Home\Index.cshtml"
              Write(ShoppingListItemText.CreateYourShoppingListWishes);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t</div>\n\t<div");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\n\t\t<div");

WriteLiteral(" class=\"panel-work panel-main-clickable\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 1145), Tuple.Create("\"", 1222)
, Tuple.Create(Tuple.Create("", 1155), Tuple.Create("document.location", 1155), true)
, Tuple.Create(Tuple.Create(" ", 1172), Tuple.Create("=", 1173), true)
, Tuple.Create(Tuple.Create(" ", 1174), Tuple.Create("\'", 1175), true)
            
            #line 36 "..\..\Views\Home\Index.cshtml"
   , Tuple.Create(Tuple.Create("", 1176), Tuple.Create<System.Object, System.Int32>(Url.ActionWork(nameof(WorkController.Work))
            
            #line default
            #line hidden
, 1176), false)
, Tuple.Create(Tuple.Create("", 1220), Tuple.Create("\';", 1220), true)
);

WriteLiteral(">\n\t\t\t<div>\n\t\t\t\t<h2>");

            
            #line 38 "..\..\Views\Home\Index.cshtml"
               Write(WorkText.Work);

            
            #line default
            #line hidden
WriteLiteral("</h2>\n\t\t\t\t<p>");

            
            #line 39 "..\..\Views\Home\Index.cshtml"
              Write(WorkText.ManageYourWorkingHours);

            
            #line default
            #line hidden
WriteLiteral("</p>\n\t\t\t</div>\n\t\t</div>\n\t</div>\n\t<div");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\n\t\t<div");

WriteLiteral(" class=\"panel-homeHDD panel-main-clickable\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 1406), Tuple.Create("\"", 1492)
, Tuple.Create(Tuple.Create("", 1416), Tuple.Create("document.location", 1416), true)
, Tuple.Create(Tuple.Create(" ", 1433), Tuple.Create("=", 1434), true)
, Tuple.Create(Tuple.Create(" ", 1435), Tuple.Create("\'", 1436), true)
            
            #line 44 "..\..\Views\Home\Index.cshtml"
      , Tuple.Create(Tuple.Create("", 1437), Tuple.Create<System.Object, System.Int32>(Url.ActionHomeHDD(nameof(HomeHDDController.HomeHDD))
            
            #line default
            #line hidden
, 1437), false)
, Tuple.Create(Tuple.Create("", 1490), Tuple.Create("\';", 1490), true)
);

WriteLiteral(">\n\t\t\t<div>\n\t\t\t\t<h2>");

            
            #line 46 "..\..\Views\Home\Index.cshtml"
               Write(HomeHDDText.HomeHDD);

            
            #line default
            #line hidden
WriteLiteral("</h2>\n\t\t\t\t<p>");

            
            #line 47 "..\..\Views\Home\Index.cshtml"
              Write(HomeHDDText.ComeOnInAndManageYourDocumentsAndPictures);

            
            #line default
            #line hidden
WriteLiteral("</p>\n\t\t\t</div>\n\t\t</div>\n\t</div>\n\t<div");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\n\t\t<div");

WriteLiteral(" class=\"panel-serverManager panel-main-clickable\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 1710), Tuple.Create("\"", 1813)
, Tuple.Create(Tuple.Create("", 1720), Tuple.Create("document.location", 1720), true)
, Tuple.Create(Tuple.Create(" ", 1737), Tuple.Create("=", 1738), true)
, Tuple.Create(Tuple.Create(" ", 1739), Tuple.Create("\'", 1740), true)
            
            #line 52 "..\..\Views\Home\Index.cshtml"
            , Tuple.Create(Tuple.Create("", 1741), Tuple.Create<System.Object, System.Int32>(Url.ActionServerManager(nameof(ServerManagerController.ServerManager))
            
            #line default
            #line hidden
, 1741), false)
, Tuple.Create(Tuple.Create("", 1812), Tuple.Create("\'", 1812), true)
);

WriteLiteral(">\n\t\t\t<div>\n\t\t\t\t<h2>");

            
            #line 54 "..\..\Views\Home\Index.cshtml"
               Write(ServerManagerText.ServerManager);

            
            #line default
            #line hidden
WriteLiteral("</h2>\n\t\t\t\t<p>");

            
            #line 55 "..\..\Views\Home\Index.cshtml"
              Write(ServerManagerText.CheckOutTheServerAndLookWhatIsGgoingOnInTheWorld);

            
            #line default
            #line hidden
WriteLiteral("</p>\n\t\t\t</div>\n\t\t</div>\n\t</div>\n</div>\n");

DefineSection("scripts", () => {

WriteLiteral("\n");

WriteLiteral("\t");

            
            #line 61 "..\..\Views\Home\Index.cshtml"
Write(Scripts.Render("~/bundles/Helpers"));

            
            #line default
            #line hidden
WriteLiteral("\n");

});

        }
    }
}
#pragma warning restore 1591
