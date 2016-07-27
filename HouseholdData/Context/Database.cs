using Helpers.Exceptions;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Reflection;
using System.Linq.Expressions;
using System.Collections;

namespace Household.Data.Context
{
	public class Database : DataModel
	{
		public Database() : base() { }

		public Database(string pv_strConnString) : base(pv_strConnString) { }

		public override int SaveChanges()
		{
			try
			{
				return base.SaveChanges();
			}
			catch (DbUpdateException ex)
			{
				throw new UpdateException(ex);
			}
			catch (DbEntityValidationException ex)
			{
				throw new ValidationException(ex);
			}
			catch (NotSupportedException ex)
			{
				throw new BehaviourException(ex);
			}
			catch (ObjectDisposedException ex)
			{
				throw new DisposedException(ex);
			}
			catch (InvalidOperationException ex)
			{
				throw new OperationException(ex);
			}
		}

		public int AttachRange<T>(List<T> pv_lstEntities, bool pv_blnSave)
			where T : class
		{
			foreach (T cEntity in pv_lstEntities)
			{
				Attach(cEntity, false);
			}

			if (pv_blnSave) return SaveChanges();

			return 0;
		}

		public int Attach<T>(T pv_cEntity, bool pv_blnSave)
			where T : class
		{
			long lngID = getID(pv_cEntity);

			if (lngID > -1)
			{
				Entry(pv_cEntity).State = lngID == 0 ?
								   EntityState.Added :
								   EntityState.Modified;
			}

			if (pv_blnSave) return SaveChanges();

			return 0;
		}

		public int Remove<T>(T pv_cEntity, bool pv_blnSave)
			where T : class
		{
			Entry(pv_cEntity).State = EntityState.Deleted;

			if (pv_blnSave) return SaveChanges();

			return 0;
		}

		public int RemoveRange<T>(List<T> pv_lstEntities, bool pv_blnSave)
			where T : class
		{
			IEnumerable<T> objReturn = Set<T>().RemoveRange(pv_lstEntities);

			if (pv_blnSave) return SaveChanges();

			return 0;
		}

		public T GetEntity<T>(Expression<Func<T, bool>> pv_fnWhere)
			where T : class
		{
			IQueryable<T> iqResults = Set<T>();

			if (pv_fnWhere != null)
			{
				iqResults = iqResults.Where(pv_fnWhere);
			}

			return iqResults.FirstOrDefault();
		}

		public List<T> GetEntities<T, Tob, Ttb>(Expression<Func<T, bool>> pv_fnWhere, Expression<Func<T, Tob>> pv_fnOrderBy, Expression<Func<T, Ttb>> pv_fnThenBy)
			where T : class
		{
			IQueryable<T> iqResults = Set<T>();

			if (pv_fnWhere != null) iqResults = iqResults.Where(pv_fnWhere);

			return iqResults.OrderBy(pv_fnOrderBy).ThenBy(pv_fnThenBy).ToList();
		}

		private long getID<T>(T pv_cEntity)
			where T : class
		{
			PropertyInfo piID = pv_cEntity.GetType().GetProperty("ID", typeof(long));

			if (piID == null) { return -1; }

			return (long)piID.GetValue(pv_cEntity);
		}

		public static void UpdateDatabase()
		{
			var obj = new MigrateDatabaseToLatestVersion<DataModel, Migrations.Configuration>();
			obj.InitializeDatabase(new Database());
		}
	}
}
