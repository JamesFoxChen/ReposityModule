using Autofac;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReposityModule.Reposity1
{
    public interface IRepositoryCenter : IUnitOfWork
    {
        //TRepository GetRepository() where TRepository : class; 
        void ExecuteProcedure(string procedureCommand, params object[] sqlParams);
    }

    public class RepositoryCenter : IRepositoryCenter
    {
        private readonly IComponentContext _componentContext; 
        protected readonly DbContext Context;
        
        public RepositoryCenter(DbContext context, IComponentContext componentContext)
        {
            Context = context;
            _componentContext = componentContext;
        }

        public TRepository GetRepository<TRepository>() where TRepository : class
        {
            return _componentContext.Resolve<TRepository>();
        }

        public void ExecuteProcedure(string procedureCommand, params object[] sqlParams)
        {
            Context.Database.ExecuteSqlCommand(procedureCommand, sqlParams);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            if (Context != null)
                Context.Dispose();
        }
    }


}
