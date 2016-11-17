using Helpers.Exceptions;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Reflection;
using System.Linq.Expressions;
using System.Text;
using Household.Data.Context.Audit;
using Household.Data.Models.Base;

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
				updateDataAudit();

				return base.SaveChanges();
			}
			catch (DbUpdateException ex)
			{
				throw new UpdateException(ex);
			}
			catch (DbEntityValidationException ex)
			{
				var sb = new StringBuilder();

				foreach (var validation in ex.EntityValidationErrors)
				{
					foreach (var error in validation.ValidationErrors)
					{
						sb.Append(Environment.NewLine + error.ErrorMessage);
					}
				}

				throw new ValidationException(sb.ToString());
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

		public int AttachRange<T>(IEnumerable<T> pv_lstEntities, bool pv_blnSave)
			where T : class, IDataBase
		{
			foreach (T cEntity in pv_lstEntities)
			{
				Attach(cEntity, false);
			}

			if (pv_blnSave) return SaveChanges();

			return 0;
		}

		public int Attach<T>(T pv_cEntity, bool pv_blnSave)
			where T : class, IDataBase
		{
			long lngID = pv_cEntity.ID;

			if (lngID > -1)
			{
				Entry(pv_cEntity).State = lngID == 0 ?
								   EntityState.Added :
								   EntityState.Modified;
			}

			if (pv_blnSave)
			{
				try
				{
					return SaveChanges();
				}
				catch (Exception)
				{
					RollbackState(pv_cEntity);

					throw;
				}
			}

			return 0;
		}

		private void RollbackState<T>(T pv_cEntity)
			where T : class
		{
			var entry = Entry(pv_cEntity);

			switch (entry.State)
			{
				case EntityState.Added:
					entry.State = EntityState.Detached;
					break;
				case EntityState.Modified:
					entry.CurrentValues.SetValues(entry.OriginalValues);
					entry.State = EntityState.Unchanged;
					break;
				case EntityState.Deleted:
					entry.State = EntityState.Unchanged;
					break;
			}
		}

		public int Remove<T>(T pv_cEntity, bool pv_blnSave)
			where T : class
		{
			Entry(pv_cEntity).State = EntityState.Deleted;

			if (pv_blnSave) return SaveChanges();

			return 0;
		}

		public int RemoveRange<T>(IEnumerable<T> pv_lstEntities, bool pv_blnSave)
			where T : class
		{
			var objReturn = Set<T>().RemoveRange(pv_lstEntities);

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

		public IQueryable<T> GetEntitiesQueryable<T, Tob, Ttb>(Expression<Func<T, bool>> pv_fnWhere, Expression<Func<T, Tob>> pv_fnOrderBy, Expression<Func<T, Ttb>> pv_fnThenBy)
			where T : class
		{
			IQueryable<T> iqResults = Set<T>();

			if (pv_fnWhere != null) iqResults = iqResults.Where(pv_fnWhere);

			return iqResults.OrderBy(pv_fnOrderBy).ThenBy(pv_fnThenBy);
		}

		public IEnumerable<T> GetEntities<T, Tob, Ttb>(Expression<Func<T, bool>> pv_fnWhere, Expression<Func<T, Tob>> pv_fnOrderBy, Expression<Func<T, Ttb>> pv_fnThenBy)
			where T : class
		{
			return GetEntitiesQueryable(pv_fnWhere, pv_fnOrderBy, pv_fnThenBy).AsEnumerable();
		}

		public IQueryable<T> GetEntitiesReadOnlyQueryable<T, Tob, Ttb>(Expression<Func<T, bool>> pv_fnWhere, Expression<Func<T, Tob>> pv_fnOrderBy, Expression<Func<T, Ttb>> pv_fnThenBy)
			where T : class
		{
			return GetEntitiesQueryable(pv_fnWhere, pv_fnOrderBy, pv_fnThenBy).AsNoTracking();
		}

		public IEnumerable<T> GetEntitiesReadOnly<T, Tob, Ttb>(Expression<Func<T, bool>> pv_fnWhere, Expression<Func<T, Tob>> pv_fnOrderBy, Expression<Func<T, Ttb>> pv_fnThenBy)
			where T : class
		{
			return GetEntitiesQueryable(pv_fnWhere, pv_fnOrderBy, pv_fnThenBy).AsNoTracking().AsEnumerable();
		}

		public static void UpdateDatabase()
		{
			var obj = new MigrateDatabaseToLatestVersion<DataModel, Migrations.Configuration>();
			obj.InitializeDatabase(new Database());
		}

		private void updateDataAudit()
		{
			var addedAuditEntities = getAuditEntities(EntityState.Added);

			var modifiedAuditedEntities = getAuditEntities(EntityState.Modified);

			var now = DateTime.UtcNow;

			foreach (var added in addedAuditEntities)
			{
				added.CreatedOn = now;
				added.LastModifiedOn = now;
			}

			foreach (var modified in modifiedAuditedEntities)
			{
				modified.LastModifiedOn = now;
			}
		}

		private IEnumerable<IDataAudit> getAuditEntities(EntityState state)
		{
			return ChangeTracker.Entries<IDataAudit>()
				.Where(p => p.State == state)
				.Select(p => p.Entity);
		}

		private IEnumerable<IDataAudit> getAuditEntitiesReadOnly(EntityState state)
		{
			return ChangeTracker.Entries<IDataAudit>()
				.Where(p => p.State == state)
				.Select(p => p.Entity).AsQueryable().AsNoTracking().AsEnumerable();
		}
	}
}