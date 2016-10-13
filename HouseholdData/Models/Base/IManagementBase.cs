using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Household.Data.Models.Base
{
	public interface IManagementBase<T, Tob, Ttb, Tdata>
		where T : class, new()
		where Tdata : class, new()
	{
		int delete(T pv_cEntity);

		int delete(List<T> pv_lstEntities);

		int deleteByID(long pv_lngID);

		int save(Tdata pv_objEntity);

		int save(Tdata pv_objEntity, bool pv_blnSave);

		int save(List<Tdata> pv_lstEntity);

		int save(T pv_cEntity);

		int save(T pv_cEntity, bool pv_blnSave);

		int save(List<T> pv_lstEntities);

		Tdata getDataByID(long pv_lngID);

		T getModelByID(long pv_lngID);

		List<T> getEntities<Tobb, Ttbb>(Expression<Func<T, bool>> pv_fnWhere, 
			Expression<Func<T, Tobb>> pv_fnOrderBy, 
			Expression<Func<T, Ttbb>> pv_fnThenBy);
	}
}