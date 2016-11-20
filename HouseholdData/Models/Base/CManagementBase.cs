using Household.Data.Db;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Household.Data.Models.Base
{
	public abstract class CManagementBase<T, Tob, Ttb, Tdata> : IManagementBase<T, Tdata>
		where T : class, IDataBase, new()
		where Tdata : class, new()
	{
		protected readonly IDb Db;

		public CManagementBase(IDb db)
		{
			Db = db;
		}

		#region CRUD

		protected virtual void deleteAllowed(T entity)
		{ }

		public virtual int delete(T entity)
		{
			return delete(entity, true);
		}

		public virtual int delete(T entity, bool runSave)
		{
			deleteAllowed(entity);

			return Db.delete(entity, runSave);
		}

		public virtual int delete(IEnumerable<T> entities)
		{
			foreach (var entity in entities)
			{
				delete(entity, false);
			}

			return Db.saveChanges();
		}

		public int delete(Expression<Func<T, bool>> whereClause)
		{
			return Db.delete(whereClause);
		}

		public int deleteByID(long id)
		{
			return delete(Db.getModelByID<T>(id));
		}

		public virtual int save(Tdata entity)
		{
			return save(entity, true);
		}

		public virtual int save(Tdata entity, bool runSave)
		{
			return Db.save<T, Tdata>(entity, runSave);
		}

		public virtual int save(IEnumerable<Tdata> entities)
		{
			return Db.save<T, Tdata>(entities);
		}

		public virtual int save(T entity)
		{
			return save(entity, true);
		}

		public virtual int save(T entity, bool runSave)
		{
			return Db.save(entity, runSave);
		}

		public virtual int save(IEnumerable<T> entities)
		{
			return Db.save<T>(entities, true);
		}
		#endregion

		#region Gets

		public virtual T getModel(Expression<Func<T, bool>> whereClause)
		{
			return Db.getModel(whereClause);
		}

		public virtual T getModelByID(long id)
		{
			return Db.getModelByID<T>(id);
		}

		public virtual Tdata getDataByID(long id)
		{
			return Db.getDataByID<T, Tdata>(id);
		}

		public virtual IEnumerable<T> getEntities<Tobb, Ttbb>(Expression<Func<T, bool>> whereClause, Expression<Func<T, Tobb>> orderBy, Expression<Func<T, Ttbb>> thenBy)
		{
			return Db.getEntities(whereClause, orderBy, thenBy);
		}
		#endregion

		#region Expressions

		protected abstract Expression<Func<T, Tob>> getStandardOrderBy();

		protected abstract Expression<Func<T, Ttb>> getStandardThenBy();
		#endregion
	}
}