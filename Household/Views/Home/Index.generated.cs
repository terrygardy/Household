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
    
    #line 4 "..\..\Views\Home\Index.cshtml"
    using Household.Localisation.Main.Work;
    
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
WriteLiteral("\r\n");

            
            #line 6 "..\..\Views\Home\Index.cshtml"
  
	ViewBag.Title = "Main Page";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"jumbotron\"");

WriteLiteral(">\r\n\t<h1>");

            
            #line 11 "..\..\Views\Home\Index.cshtml"
   Write(GeneralText.Household);

            
            #line default
            #line hidden
WriteLiteral("</h1>\r\n\t<p");

WriteLiteral(" class=\"lead\"");

WriteLiteral(">");

            
            #line 12 "..\..\Views\Home\Index.cshtml"
               Write(GeneralText.WelcomeToOurHouseholdManagementSystem);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n</div>\r\n\r\n<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\r\n\t\t<div");

WriteLiteral(" class=\"panel-finance panel-main-clickable\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 436), Tuple.Create("\"", 501)
, Tuple.Create(Tuple.Create("", 446), Tuple.Create("document.location", 446), true)
, Tuple.Create(Tuple.Create(" ", 463), Tuple.Create("=", 464), true)
, Tuple.Create(Tuple.Create(" ", 465), Tuple.Create("\'", 466), true)
            
            #line 17 "..\..\Views\Home\Index.cshtml"
       , Tuple.Create(Tuple.Create("", 467), Tuple.Create<System.Object, System.Int32>(Url.Action("Finance", "Finance")
            
            #line default
            #line hidden
, 467), false)
, Tuple.Create(Tuple.Create("", 500), Tuple.Create("\'", 500), true)
);

WriteLiteral(">\r\n\t\t\t<div>\r\n\t\t\t\t<h2>");

            
            #line 19 "..\..\Views\Home\Index.cshtml"
               Write(FinanceText.Finance);

            
            #line default
            #line hidden
WriteLiteral("</h2>\r\n\t\t\t\t<p>");

            
            #line 20 "..\..\Views\Home\Index.cshtml"
              Write(FinanceText.ExpensesPurchasesAndMonthlyBills);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t</div>\r\n\t<div");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\r\n\t\t<div");

WriteLiteral(" class=\"panel-work panel-main-clickable\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 709), Tuple.Create("\"", 769)
, Tuple.Create(Tuple.Create("", 719), Tuple.Create("document.location", 719), true)
, Tuple.Create(Tuple.Create(" ", 736), Tuple.Create("=", 737), true)
, Tuple.Create(Tuple.Create(" ", 738), Tuple.Create("\'", 739), true)
            
            #line 25 "..\..\Views\Home\Index.cshtml"
    , Tuple.Create(Tuple.Create("", 740), Tuple.Create<System.Object, System.Int32>(Url.Action("Work", "Work")
            
            #line default
            #line hidden
, 740), false)
, Tuple.Create(Tuple.Create("", 767), Tuple.Create("\';", 767), true)
);

WriteLiteral(">\r\n\t\t\t<div>\r\n\t\t\t\t<h2>");

            
            #line 27 "..\..\Views\Home\Index.cshtml"
               Write(WorkText.Work);

            
            #line default
            #line hidden
WriteLiteral("</h2>\r\n\t\t\t\t<p>");

            
            #line 28 "..\..\Views\Home\Index.cshtml"
              Write(WorkText.ManageYourWorkingHours);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t</div>\r\n\t<div");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\r\n\t\t<div");

WriteLiteral(" class=\"panel-homeHDD panel-main-clickable\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 961), Tuple.Create("\"", 1027)
, Tuple.Create(Tuple.Create("", 971), Tuple.Create("document.location", 971), true)
, Tuple.Create(Tuple.Create(" ", 988), Tuple.Create("=", 989), true)
, Tuple.Create(Tuple.Create(" ", 990), Tuple.Create("\'", 991), true)
            
            #line 33 "..\..\Views\Home\Index.cshtml"
       , Tuple.Create(Tuple.Create("", 992), Tuple.Create<System.Object, System.Int32>(Url.Action("HomeHDD", "HomeHDD")
            
            #line default
            #line hidden
, 992), false)
, Tuple.Create(Tuple.Create("", 1025), Tuple.Create("\';", 1025), true)
);

WriteLiteral(">\r\n\t\t\t<div>\r\n\t\t\t\t<h2>");

            
            #line 35 "..\..\Views\Home\Index.cshtml"
               Write(HomeHDDText.HomeHDD);

            
            #line default
            #line hidden
WriteLiteral("</h2>\r\n\t\t\t\t<p>");

            
            #line 36 "..\..\Views\Home\Index.cshtml"
              Write(HomeHDDText.ComeOnInAndManageYourDocumentsAndPictures);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t</div>\r\n\t<div");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\r\n\t\t<div");

WriteLiteral(" class=\"panel-serverManager panel-main-clickable\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 1253), Tuple.Create("\"", 1330)
, Tuple.Create(Tuple.Create("", 1263), Tuple.Create("document.location", 1263), true)
, Tuple.Create(Tuple.Create(" ", 1280), Tuple.Create("=", 1281), true)
, Tuple.Create(Tuple.Create(" ", 1282), Tuple.Create("\'", 1283), true)
            
            #line 41 "..\..\Views\Home\Index.cshtml"
            , Tuple.Create(Tuple.Create("", 1284), Tuple.Create<System.Object, System.Int32>(Url.Action("ServerManager", "ServerManager")
            
            #line default
            #line hidden
, 1284), false)
, Tuple.Create(Tuple.Create("", 1329), Tuple.Create("\'", 1329), true)
);

WriteLiteral(">\r\n\t\t\t<div>\r\n\t\t\t\t<h2>");

            
            #line 43 "..\..\Views\Home\Index.cshtml"
               Write(ServerManagerText.ServerManager);

            
            #line default
            #line hidden
WriteLiteral("</h2>\r\n\t\t\t\t<p>");

            
            #line 44 "..\..\Views\Home\Index.cshtml"
              Write(ServerManagerText.CheckOutTheServerAndLookWhatIsGgoingOnInTheWorld);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t</div>\r\n</div>\r\n");

DefineSection("scripts", () => {

WriteLiteral("\r\n");

WriteLiteral("\t");

            
            #line 50 "..\..\Views\Home\Index.cshtml"
Write(Scripts.Render("~/bundles/Helpers"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n\t\tvar intervalEnvironment;\r\n\r\n\t\t(function () {\r\n\t\t\tsetInterval(setEnvironment," +
" 200);\r\n\t\t})();\r\n\r\n\t\tfunction setEnvironment() {\r\n\t\t\tclearInterval(intervalEnvir" +
"onment);\r\n\r\n\t\t\tHelpers.HttpRequests.CreateAsyncRequestHandlerPOST(\'");

            
            #line 61 "..\..\Views\Home\Index.cshtml"
                                                           Write(Url.Action("SetEnvironment", "Home"));

            
            #line default
            #line hidden
WriteLiteral("\', Helpers.HttpRequests.GetContentTypeText()).send();\r\n\t\t}\r\n\t</script>\r\n");

});

        }
    }
}
#pragma warning restore 1591
