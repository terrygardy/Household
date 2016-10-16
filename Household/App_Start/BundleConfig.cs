using System.Web.Optimization;

namespace Household
{
	public class BundleConfig
	{
		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-{version}.js",
						"~/Scripts/jquery-ui.min.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/jquery.validate*",
						"~/Scripts/validation.js"));

			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
					  "~/Scripts/bootstrap.js",
					  "~/Scripts/respond.js"));

			bundles.Add(new ScriptBundle("~/bundles/pleaseWait").Include(
					  "~/Scripts/jquery-pleaseWait.js"));

			bundles.Add(new ScriptBundle("~/bundles/Helpers").Include(
					  "~/Scripts/Helpers/*.js"));

			bundles.Add(new ScriptBundle("~/bundles/highcharts").Include(
					  "~/Scripts/highcharts/4.2.0/highcharts.js",
					  "~/Scripts/highcharts/4.2.0/themes/grid-light.js",
					  "~/Scripts/highcharts/4.2.0/modules/exporting.js",
					  "~/Scripts/highcharts/highcharts.helpers.js"));

			bundles.Add(new ScriptBundle("~/bundles/Finance").Include(
					  "~/Scripts/Helpers/*.js",
					  "~/Scripts/MasterData/MasterData.js",
					  "~/Scripts/Finance/Finance.js"));

			bundles.Add(new ScriptBundle("~/bundles/Purchase").Include(
				"~/Scripts/jquery-knockout.js",
				"~/Scripts/Finance/Purchase.js"));

			bundles.Add(new ScriptBundle("~/bundles/Expense").Include(
				"~/Scripts/jquery-knockout.js",
				"~/Scripts/Finance/Expense.js"));

			bundles.Add(new ScriptBundle("~/bundles/Report").Include(
				"~/Scripts/Finance/Report.js"));

			bundles.Add(new ScriptBundle("~/bundles/MasterData").Include(
					  "~/Scripts/Helpers/*.js",
					  "~/Scripts/MasterData/MasterData.js"));

			bundles.Add(new ScriptBundle("~/bundles/Person").Include(
				"~/Scripts/jquery-knockout.js",
				"~/Scripts/MasterData/Person.js"));

			bundles.Add(new ScriptBundle("~/bundles/BankAccount").Include(
				"~/Scripts/jquery-knockout.js",
				"~/Scripts/MasterData/BankAccount.js"));

			bundles.Add(new ScriptBundle("~/bundles/Company").Include(
				"~/Scripts/jquery-knockout.js",
				"~/Scripts/MasterData/Company.js"));

			bundles.Add(new ScriptBundle("~/bundles/Day").Include(
				"~/Scripts/jquery-knockout.js",
				"~/Scripts/MasterData/Day.js"));

			bundles.Add(new ScriptBundle("~/bundles/Interval").Include(
				"~/Scripts/jquery-knockout.js",
				"~/Scripts/MasterData/Interval.js"));

			bundles.Add(new ScriptBundle("~/bundles/Shop").Include(
				"~/Scripts/jquery-knockout.js",
				"~/Scripts/MasterData/Shop.js"));

			bundles.Add(new ScriptBundle("~/bundles/Income").Include(
				"~/Scripts/jquery-knockout.js",
				"~/Scripts/MasterData/Income.js"));

			bundles.Add(new ScriptBundle("~/bundles/WorkDay").Include(
				"~/Scripts/jquery-knockout.js",
				"~/Scripts/Work/WorkHours.js"));

			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/Content/Bootstrap/bootstrap.css",
					  "~/Content/*.css",
					  "~/Content/jquery-ui.min.css"));

			BundleTable.EnableOptimizations = true;
		}
	}
}
