using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Household.Data.Models.Base
{
	public interface IManagementBase<T, Tdata>
		where T : class, new()
		where Tdata : class, new()
	{
		#region CRUD
		int delete(T entity);

		int delete(T entity, bool runSave);

		int delete(IEnumerable<T> entities);

		int delete(Expression<Func<T, bool>> whereClause);

		int deleteByID(long id);

		int save(Tdata entity);

		int save(Tdata entity, bool runSave);

		int save(IEnumerable<Tdata> entities);

		int save(T entity);

		int save(T entity, bool runSave);

		int save(IEnumerable<T> entities);
		#endregion

		#region Gets

		T getModel(Expression<Func<T, bool>> whereClause);

		T getModelByID(long id);

		Tdata getDataByID(long id);

		IEnumerable<T> getEntities<Tobb, Ttbb>(Expression<Func<T, bool>> whereClause, Expression<Func<T, Tobb>> orderBy, Expression<Func<T, Ttbb>> thenBy);
		#endregion
	}
}