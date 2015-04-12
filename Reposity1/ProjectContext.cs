using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReposityModule.Reposity1
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
            : base("TestDBConnStr")
        {
            this.Configuration.ProxyCreationEnabled = false; 
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // 移除EF的表名公约
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // 移除对MetaData表的查询验证    
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            base.OnModelCreating(modelBuilder);
        }

        //public IDbSet<DeleteLog> DeleteLogs { get; set; }
        public IDbSet<Cars> Cars { get; set; }
    }


}
