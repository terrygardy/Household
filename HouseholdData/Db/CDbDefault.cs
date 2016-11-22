using Household.Data.Context;
using Household.Data.Models.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Household.Data.Db
{
	public class CDbDefault : IDb
	{
		private Context.Database _database { get; }

		public CDbDefault()
		{
			_database = CDbConnection.getInstance();
		}

		#region CRUD

		public int delete<T>(T pv_cEntity)
			where T : class
		{
			return delete(pv_cEntity, true);
		}

		public int delete<T>(T pv_cEntity, bool runSave)
			where T : class
		{
			return _database.Remove(pv_cEntity, runSave);
		}

		public int delete<T>(IEnumerable<T> pv_lstEntities)
			where T : class
		{
			return _database.RemoveRange(pv_lstEntities, true);
		}

		public int delete<T>(Expression<Func<T, bool>> pv_fnWhere)
			where T : class
		{
			if (pv_fnWhere != null)
			{
				return _database.Remove(_database.Set<T>().Where(pv_fnWhere).ToList(), true);
			}

			return 0;
		}

		public int deleteByID<T>(long pv_lngID)
			where T : class, IDataBase
		{
			if (pv_lngID > 0)
			{
				return delete(_database.Set<T>().Where(d => d.ID == pv_lngID).FirstOrDefault());
			}

			return 0;
		}

		public int save<T, Tdata>(Tdata pv_objEntity)
			where T : class, IDataBase, new()
			where Tdata : class, IDataBase
		{
			return save<T, Tdata>(pv_objEntity, true);
		}

		public int save<T, Tdata>(Tdata pv_objEntity, bool pv_blnSave)
			where T : class, IDataBase, new()
			where Tdata : class, IDataBase
		{
			T objEntity = new T();

			Helpers.Mapping.Mapping.mapObject(objEntity, pv_objEntity);

			var result = save(objEntity, pv_blnSave);

			pv_objEntity.ID = objEntity.ID;

			return result;
		}

		public int save<T, Tdata>(IEnumerable<Tdata> pv_lstEntity)
			where T : class, IDataBase, new()
			where Tdata : class, IDataBase
		{
			foreach (var objEntity in pv_lstEntity)
			{
				save<T, Tdata>(objEntity, false);
			}

			return saveChanges();
		}

		public int save<T>(T pv_cEntity)
			where T : class, IDataBase, new()
		{
			return save(pv_cEntity, true);
		}

		public int save<T>(T pv_cEntity, bool pv_blnSave)
			where T : class, IDataBase, new()
		{
			T tEntity = pv_cEntity;

			long lngID = tEntity.ID;

			if (lngID > 0)
			{
				if (_database.Entry(tEntity).State == EntityState.Detached)
				{
					tEntity = getModel<T>(x => x.ID == lngID);
					Helpers.Mapping.Mapping.mapObject(tEntity, pv_cEntity);
					pv_cEntity = tEntity;
				}
			}

			return _database.Attach(tEntity, pv_blnSave);
		}

		public int save<T>(IEnumerable<T> pv_lstEntities)
			where T : class, IDataBase
		{
			return save(pv_lstEntities, true);
		}

		public int save<T>(IEnumerable<T> pv_lstEntities, bool runSave)
			where T : class, IDataBase
		{
			return _database.AttachRange(pv_lstEntities, runSave);
		}

		public int saveChanges()
		{
			return _database.SaveChanges();
		}
		#endregion

		#region Gets

		public T getModel<T>(Expression<Func<T, bool>> pv_fnWhere)
			where T : class, IDataBase, new()
		{
			return _database.GetEntity<T>(pv_fnWhere);
		}

		public T getModelByID<T>(long pv_lngID)
			where T : class, IDataBase, new()
		{
			return _database.GetEntity<T>(x => x.ID == pv_lngID);
		}

		public Tdata getDataByID<T, Tdata>(long pv_lngID)
			where T : class, IDataBase, new()
			where Tdata : class, IDataBase,  new()
		{
			T tEntity = getModelByID<T>(pv_lngID);
			Tdata tReturn = new Tdata();

			if (tEntity != null) Helpers.Mapping.Mapping.mapObject<Tdata, T>(tReturn, tEntity);

			return tReturn;
		}

		public IEnumerable<T> getEntities<T, Tobb, Ttbb>(Expression<Func<T, bool>> pv_fnWhere, Expression<Func<T, Tobb>> pv_fnOrderBy, Expression<Func<T, Ttbb>> pv_fnThenBy)
			where T : class, IDataBase, new()
		{
			return _database.GetEntities(pv_fnWhere, pv_fnOrderBy, pv_fnThenBy);
		}
		#endregion

		#region Repository

		public DbSet<T> GetGenericRepository<T>()
		where T : class
		{
			return _database.Set<T>();
		}

		#endregion
	}
}