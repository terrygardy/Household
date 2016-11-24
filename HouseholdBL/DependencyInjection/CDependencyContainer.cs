using Household.BL.Management.t.Implementations;
using Household.BL.Management.t.Interfaces;
using Household.BL.Management.txx.Implementations;
using Household.BL.Management.txx.Interfaces;
using Household.Common.Reflection.Implementations;
using Household.Common.Reflection.Interfaces;
using Household.Data.Db;
using Microsoft.Practices.Unity;

namespace Household.BL.DependencyInjection
{
	public static class CDependencyContainer
	{
		private static IUnityContainer _container;

		public static IUnityContainer DependencyContainer
		{
			get
			{
				if (_container == null) BuildContainer();

				return _container;
			}
		}

		private static void BuildContainer()
		{
			_container = new UnityContainer();

			//Common
			_container.RegisterType<IReflectionManager, CReflectionManager>(new ContainerControlledLifetimeManager());

			//Db
			_container.RegisterType<IDb, CDbDefault>(new ContainerControlledLifetimeManager());

			//t
			_container.RegisterType<IExpenseManagement, CExpenseManagement>(new ContainerControlledLifetimeManager());
			_container.RegisterType<IIncomeManagement, CIncomeManagement>(new ContainerControlledLifetimeManager());
			_container.RegisterType<IPersonManagement, CPersonManagement>(new ContainerControlledLifetimeManager());
			_container.RegisterType<IPurchaseManagement, CPurchaseManagement>(new ContainerControlledLifetimeManager());
			_container.RegisterType<IWorkDayManagement, CWorkDayManagement>(new ContainerControlledLifetimeManager());
			_container.RegisterType<IBankingManagement, CBankingManagement>(new ContainerControlledLifetimeManager());

			//txx
			_container.RegisterType<IBankAccountManagement, CBankAccountManagement>(new ContainerControlledLifetimeManager());
			_container.RegisterType<ICompanyManagement, CCompanyManagement>(new ContainerControlledLifetimeManager());
			_container.RegisterType<IDayManagement, CDayManagement>(new ContainerControlledLifetimeManager());
			_container.RegisterType<IIntervalManagement, CIntervalManagement>(new ContainerControlledLifetimeManager());
			_container.RegisterType<IShopManagement, CShopManagement>(new ContainerControlledLifetimeManager());
		}
	}
}
