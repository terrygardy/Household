using Household.Data.Context;
using Household.Data.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Household.Data.Models.Base
{
	public abstract class CModelBase<T, Tob, Ttb, Tdata> : IManagementBase<T, Tob, Ttb, Tdata>
		where T : class, new()
		where Tdata : class, new()
	{
		public static readonly DateTime MinDate = new DateTime(1753, 1, 1);

		protected Database Database { get; set; }

		public CModelBase() { setDatabase(CDbConnection.getInstance()); }

		public CModelBase(Database pv_dmHH_DB) { setDatabase(pv_dmHH_DB); }

		public CModelBase(string pv_strConnString) { setDatabase(new Database(pv_strConnString)); }

		protected void setDatabase(Database pv_dmHH_DB) { Database = pv_dmHH_DB; }

		#region CRUD
		protected virtual void deleteAllowed(T pv_cEntity)
		{ }

		public virtual int delete(T pv_cEntity)
		{
			deleteAllowed(pv_cEntity);

			return Database.Remove(pv_cEntity, true);
		}

		public virtual int delete(List<T> pv_lstEntities)
		{
			return Database.RemoveRange(pv_lstEntities, true);
		}

		protected int delete(Expression<Func<T, bool>> pv_fnWhere)
		{
			if (pv_fnWhere != null)
			{
				return Database.Remove(Database.Set<T>().Where(pv_fnWhere).ToList(), true);
			}

			return 0;
		}

		public int deleteByID(long pv_lngID)
		{
			if (pv_lngID > 0)
			{
				return delete(Database.Set<T>().Where(getStandardWhereID(pv_lngID)).FirstOrDefault());
			}

			return 0;
		}

		public virtual int save(Tdata pv_objEntity)
		{
			T objEntity = new T();
			int intResult;

			Helpers.Mapping.Mapping.mapObject(objEntity, pv_objEntity);

			intResult = save(objEntity);

			Helpers.Mapping.Mapping.mapObject(pv_objEntity, objEntity);

			return intResult;
		}

		public virtual int save(Tdata pv_objEntity, bool pv_blnSave)
		{
			T objEntity = new T();

			Helpers.Mapping.Mapping.mapObject(objEntity, pv_objEntity);

			return save(objEntity, pv_blnSave);
		}

		public virtual int save(List<Tdata> pv_lstEntity)
		{
			foreach (var objEntity in pv_lstEntity)
			{
				save(objEntity, false);
			}

			return Database.SaveChanges();
		}

		public virtual int save(T pv_cEntity)
		{
			return save(pv_cEntity, true);
		}

		public virtual int save(T pv_cEntity, bool pv_blnSave)
		{
			T tEntity = pv_cEntity;

			long lngID = getID(tEntity);

			if (lngID > 0)
			{
				if (Database.Entry(tEntity).State == System.Data.Entity.EntityState.Detached)
				{
					tEntity = getModel(getStandardWhereID(lngID));
					Helpers.Mapping.Mapping.mapObject(tEntity, pv_cEntity);
				}
			}
			else
			{
				Database.Entry(tEntity).State = System.Data.Entity.EntityState.Added;
			}

			return Database.Attach(tEntity, pv_blnSave);
		}

		public virtual int save(List<T> pv_lstEntities)
		{
			return Database.AttachRange(pv_lstEntities, true);
		}
		#endregion

		#region Gets

		private long getID(T pv_cEntity)
		{
			PropertyInfo piID = pv_cEntity.GetType().GetProperty("ID", typeof(long));

			if (piID == null) { return -1; }

			return (long)piID.GetValue(pv_cEntity);
		}

		protected virtual T getModel(Expression<Func<T, bool>> pv_fnWhere)
		{
			return Database.GetEntity<T>(pv_fnWhere);
		}

		protected virtual T getModelByID(long pv_lngID)
		{
			return Database.GetEntity(getStandardWhereID(pv_lngID));
		}

		public virtual Tdata getDataByID(long pv_lngID)
		{
			T tEntity = getModelByID(pv_lngID);
			Tdata tReturn = new Tdata();

			if (tEntity != null) Helpers.Mapping.Mapping.mapObject<Tdata, T>(tReturn, tEntity);

			return tReturn;
		}

		public virtual List<T> getEntities<Tobb, Ttbb>(Expression<Func<T, bool>> pv_fnWhere, Expression<Func<T, Tobb>> pv_fnOrderBy, Expression<Func<T, Ttbb>> pv_fnThenBy)
		{
			return Database.GetEntities(pv_fnWhere, pv_fnOrderBy, pv_fnThenBy);
		}
		#endregion

		#region Expressions
		protected abstract Expression<Func<T, Tob>> getStandardOrderBy();

		protected abstract Expression<Func<T, Ttb>> getStandardThenBy();

		protected abstract Expression<Func<T, bool>> getStandardWhereID(long pv_lngID);
		#endregion
	}
}