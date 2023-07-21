using Microsoft.EntityFrameworkCore;
using SoloTalentoMX.Data.Data;
using SoloTalentoMX.Data.Interfaces;
using SoloTalentoMX.Data.Utility;
using System.Linq.Expressions;

namespace SoloTalentoMX.Data.Repositories.Base
{
    public class DaoGeneric<TEntity> : IGeneric<TEntity> where TEntity : class
    {
        protected const string sMensAccion = "Ocurrio un error al {0} la entidad ('{1}') en la capa de Dao.";
        private Context _entities = null;

        public DaoGeneric(Context oContext) { _entities = oContext; }

        public DbContext Context
        {
            get
            {
                if (_entities == null)
                { _entities = new Context(); }

                return _entities;
            }
        }

        public List<TEntity> List(ParametersOfList<TEntity> Parameters = null)
        {
            try
            {
                return Parameters == null ? Context.Set<TEntity>().ToList() :
                 (Parameters.filter != null && Parameters.OrderBy != null) ? (Parameters.OrderBy(Context.Set<TEntity>().Where(Parameters.filter))).ToList() :
                        (Parameters.filter != null && Parameters.OrderBy == null) ? Context.Set<TEntity>().Where(Parameters.filter).ToList() : Context.Set<TEntity>().ToList();
            }
            catch (Exception ex)
            {
                throw new CustomExceptions(string.Format(sMensAccion, "List", typeof(TEntity).Name), ex);
            }
        }

        public async Task<List<TEntity>> ListAsync(ParametersOfList<TEntity> Parameters = null)
        {
            try
            {
                var parameter = Parameters == null ? await Context.Set<TEntity>().ToListAsync() :
                    (Parameters.filter != null && Parameters.OrderBy != null) ? await (Parameters.OrderBy(Context.Set<TEntity>().Where(Parameters.filter))).ToListAsync() :
                           (Parameters.filter != null && Parameters.OrderBy == null) ? await Context.Set<TEntity>().Where(Parameters.filter).ToListAsync() :
                           (Parameters.filter != null && Parameters.Include != null) ? await Context.Set<TEntity>().Include(Parameters.Include).Where(Parameters.filter).ToListAsync() :
                           await Context.Set<TEntity>().ToListAsync();

                return parameter;
            }
            catch (Exception ex)
            {
                throw new CustomExceptions(string.Format(sMensAccion, "List async", typeof(TEntity).Name), ex);
            }
        }

        public TEntity Search(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                IQueryable<TEntity> query = Context.Set<TEntity>().Where(predicate);
                return query.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new CustomExceptions(string.Format(sMensAccion, "Search", typeof(TEntity).Name), ex);
            }
        }

        public async Task<TEntity> SearchAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                IQueryable<TEntity> query = Context.Set<TEntity>().Where(predicate);
                return await query.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new CustomExceptions(string.Format(sMensAccion, "Search async", typeof(TEntity).Name), ex);
            }
        }

        public async Task<TEntity> CreateAsync(TEntity oEntity)
        {
            try
            {
                Context.Set<TEntity>().Add(oEntity);
                int x = await Context.SaveChangesAsync();
                return ((x > 0) ? oEntity : null);
            }
            catch (Exception ex)
            {
                throw new CustomExceptions(string.Format(sMensAccion, "Create", typeof(TEntity).Name), ex, Enumerations.eActions.Crear);
            }
        }

        public TEntity Create(TEntity oEntity)
        {
            try
            {
                Context.Set<TEntity>().Add(oEntity);
                int x = Context.SaveChanges();
                return ((x > 0) ? oEntity : null);
            }
            catch (Exception ex) { throw new CustomExceptions(string.Format(sMensAccion, "Create", typeof(TEntity).Name), ex, Enumerations.eActions.Crear); }
        }

        public async Task<bool> ModifyAsync(TEntity oEntity)
        {
            try
            {
                Context.Entry(oEntity).State = EntityState.Modified;
                int x = await Context.SaveChangesAsync();
                return (x > 0);
            }
            catch (Exception ex)
            {
                throw new CustomExceptions(string.Format(sMensAccion, "Modify", typeof(TEntity).Name), ex, Enumerations.eActions.Modificar);
            }
        }

        public bool Modify(TEntity oEntity)
        {
            try
            {
                Context.Entry(oEntity).State = EntityState.Modified;
                int x = Context.SaveChanges();
                return (x > 0);
            }
            catch (Exception ex)
            {
                throw new CustomExceptions(string.Format(sMensAccion, "Modify", typeof(TEntity).Name), ex, Enumerations.eActions.Modificar);
            }
        }

        public async Task<bool> RemoveAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                IQueryable<TEntity> query = Context.Set<TEntity>().Where(predicate);
                if (query != null)
                {
                    Context.Set<TEntity>().RemoveRange(query);
                    int x = await Context.SaveChangesAsync();
                    return (x > 0);
                }
                else
                    return true;
            }
            catch (DbUpdateException ex)
            {
                throw new CustomExceptions(string.Format(sMensAccion, "Remove", typeof(TEntity).Name), ex, Enumerations.eActions.Eliminar);
            }
            catch (Exception ex) { throw new CustomExceptions(string.Format(sMensAccion, "Remove", typeof(TEntity).Name), ex, Enumerations.eActions.Eliminar); }
        }

        public async Task<bool> RemoveAllAsync()
        {
            try
            {
                Context.Set<TEntity>().RemoveRange(Context.Set<TEntity>());
                int x = await Context.SaveChangesAsync();
                return (x > 0);
            }
            catch (Exception ex) { throw new CustomExceptions(string.Format(sMensAccion, "Remove", typeof(TEntity).Name), ex, Enumerations.eActions.Eliminar); }
        }

        public bool RemoveAll()
        {
            try
            {
                Context.Set<TEntity>().RemoveRange(Context.Set<TEntity>());
                int x = Context.SaveChanges();
                return (x > 0);
            }
            catch (Exception ex) { throw new CustomExceptions(string.Format(sMensAccion, "Remove", typeof(TEntity).Name), ex, Enumerations.eActions.Eliminar); }
        }

        public async Task<bool> RemoveRangeAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                IQueryable<TEntity> query = Context.Set<TEntity>().Where(predicate);
                Context.Set<TEntity>().RemoveRange(query.ToList());
                int x = await Context.SaveChangesAsync();
                return (x > 0);
            }
            catch (Exception ex) { throw new CustomExceptions(string.Format(sMensAccion, "Remove", typeof(TEntity).Name), ex, Enumerations.eActions.Eliminar); }
        }

        public bool RemoveRange(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                IQueryable<TEntity> query = Context.Set<TEntity>().Where(predicate);
                Context.Set<TEntity>().RemoveRange(query.ToList());
                int x = Context.SaveChanges();
                return (x > 0);
            }
            catch (Exception ex) { throw new CustomExceptions(string.Format(sMensAccion, "Remove", typeof(TEntity).Name), ex, Enumerations.eActions.Eliminar); }
        }

        public bool AddRange(IEnumerable<TEntity> entities)
        {
            try
            {
                // IQueryable<TEntity> query = Context.Set<TEntity>().Where(predicate);
                Context.Set<TEntity>().AddRange(entities);
                int x = Context.SaveChanges();
                return (x > 0);
            }
            catch (Exception ex) { throw new CustomExceptions(string.Format(sMensAccion, "AddRange", typeof(TEntity).Name), ex, Enumerations.eActions.Crear); }
        }

        public bool Remove(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                IQueryable<TEntity> query = Context.Set<TEntity>().Where(predicate);
                Context.Set<TEntity>().Remove(query.FirstOrDefault());
                int x = Context.SaveChanges();
                return (x > 0);
            }
            catch (Exception ex) { throw new CustomExceptions(string.Format(sMensAccion, "Remove", typeof(TEntity).Name), ex, Enumerations.eActions.Eliminar); }
        }

        public async Task<bool> RemoveAsync(TEntity oObj)
        {
            if (oObj != null)
            {
                try
                {
                    Context.Set<TEntity>().Remove(oObj);
                    int x = await Context.SaveChangesAsync();
                    return (x > 0);
                }
                catch (Exception ex) { throw new CustomExceptions(string.Format(sMensAccion, "Remove", typeof(TEntity).Name), ex, Enumerations.eActions.Eliminar); }
            }
            else
                throw new CustomExceptions(string.Format(sMensAccion, "Remove objeto nulo", typeof(TEntity).Name), Enumerations.eActions.Eliminar);
        }

        public bool Remove(TEntity oObj)
        {
            if (oObj != null)
            {
                try
                {
                    Context.Set<TEntity>().Remove(oObj);
                    int x = Context.SaveChanges();
                    return (x > 0);
                }
                catch (Exception ex) { throw new CustomExceptions(string.Format(sMensAccion, "Remove", typeof(TEntity).Name), ex, Enumerations.eActions.Eliminar); }
            }
            else
                throw new CustomExceptions(string.Format(sMensAccion, "Remove objeto nulo", typeof(TEntity).Name), Enumerations.eActions.Eliminar);
        }

        private List<TEntity> ListPageAndFilter(IQueryable<TEntity> IQuery, ParametersOfList<TEntity> Parameters)
        {
            return ConfigParameters(IQuery, Parameters).ToList();
        }

        public bool ExecuteNoQuerySP(string nameProcedure, object[] sqlparameters)
        {
            try
            {
                Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                Context.Database.ExecuteSqlRaw(nameProcedure, sqlparameters);
            }
            catch (Exception ex) { throw new CustomExceptions(string.Format(sMensAccion, "ExecuteSP", "nameProcedure", ex, Enumerations.eActions.Consultar)); }
            return true;
        }

        public TEntity ExecuteSP(string nameProcedure, object[] sqlparameters)
        {
            TEntity entity = default(TEntity);
            try
            {
                Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                entity = (Context.Set<TEntity>()).FromSqlRaw<TEntity>(nameProcedure, sqlparameters).AsEnumerable().FirstOrDefault(); //Context.Database.SqlQuery<TEntity>(nameProcedure, sqlparameters).FirstOrDefault();
            }
            catch (Exception ex) { throw new CustomExceptions(string.Format(sMensAccion, "ExecuteSP", "nameProcedure", ex, Enumerations.eActions.Consultar)); }
            return entity;
        }

        public List<TEntity> ExecuteListSP(string nameProcedure, object[] sqlparameters)
        {
            List<TEntity> entity = new List<TEntity>();//default(TEntity);
            try
            {
                this.Context.Database.SetCommandTimeout(180);
                entity = (Context.Set<TEntity>()).FromSqlRaw<TEntity>(nameProcedure, sqlparameters).AsEnumerable().ToList();//Context.Database.SqlQuery<TEntity>(nameProcedure, sqlparameters).ToList();
            }
            catch (Exception ex) { throw new CustomExceptions(string.Format(sMensAccion, "ExecuteSP", "nameProcedure", ex, Enumerations.eActions.Consultar)); }
            return entity;
        }

        public int ExecuteNoResultSP(string nameProcedure, object[] sqlparameters)
        {
            int result = 0;
            try
            {
                Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                result = Context.Database.ExecuteSqlRaw(nameProcedure, sqlparameters);
            }
            catch (Exception ex) { throw new CustomExceptions(string.Format(sMensAccion, "ExecuteSP", "nameProcedure", ex, Enumerations.eActions.Consultar)); }
            return result;
        }

        private IQueryable<TEntity> ConfigParameters(IQueryable<TEntity> IQuery, ParametersOfList<TEntity> Parameters)
        {
            if (Parameters != null)
            {
                if (Parameters.Skip > -1)
                    IQuery = IQuery.Skip(Parameters.Skip);

                if (Parameters.Take > -1)
                    IQuery = IQuery.Take(Parameters.Take);

                if (Parameters.filter != null)
                    IQuery = IQuery.Where(Parameters.filter);

                if (Parameters.OrderBy != null)
                    IQuery = Parameters.OrderBy(IQuery);

                if (Parameters.Include != null)
                    IQuery = IQuery.Include(Parameters.Include);
            }

            return IQuery;
        }

        public void Dispose()
        {
            _entities.Dispose();
            _entities = null;
        }
    }
}
