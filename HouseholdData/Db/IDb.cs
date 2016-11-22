using Household.Data.Models.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Household.Data.Db
{
	public interface IDb
	{
		#region CRUD

		int delete<T>(T pv_cEntity)
			where T : class;

		int delete<T>(T pv_cEntity, bool runSave)
			where T : class;

		int delete<T>(IEnumerable<T> pv_lstEntities)
			where T : class;

		int delete<T>(Expression<Func<T, bool>> pv_fnWhere)
			where T : class;

		int deleteByID<T>(long pv_lngID)
			where T : class, IDataBase;

		int save<T, Tdata>(Tdata pv_objEntity)
			where T : class, IDataBase, new()
			where Tdata : class, IDataBase;

		int save<T, Tdata>(Tdata pv_objEntity, bool pv_blnSave)
			where T : class, IDataBase, new()
			where Tdata : class, IDataBase;

		int save<T, Tdata>(IEnumerable<Tdata> pv_lstEntity)
			where T : class, IDataBase, new()
			where Tdata : class, IDataBase;

		int save<T>(T pv_cEntity)
			where T : class, IDataBase, new();

		int save<T>(T pv_cEntity, bool pv_blnSave)
			where T : class, IDataBase, new();

		int save<T>(IEnumerable<T> pv_lstEntities)
			where T : class, IDataBase;

		int save<T>(IEnumerable<T> pv_lstEntities, bool runSave)
			where T : class, IDataBase;

		int saveChanges();
		#endregion

		#region Gets

		T getModel<T>(Expression<Func<T, bool>> pv_fnWhere)
			where T : class, IDataBase, new();

		T getModelByID<T>(long pv_lngID)
			where T : class, IDataBase, new();

		Tdata getDataByID<T, Tdata>(long pv_lngID)
			where T : class, IDataBase, new()
			where Tdata : class, IDataBase, new();

		IEnumerable<T> getEntities<T, Tobb, Ttbb>(Expression<Func<T, bool>> pv_fnWhere, Expression<Func<T, Tobb>> pv_fnOrderBy, Expression<Func<T, Ttbb>> pv_fnThenBy)
			where T : class, IDataBase, new();
		#endregion

		#region Repository

		DbSet<T> GetGenericRepository<T>()
			where T : class;
		#endregion
	}
}