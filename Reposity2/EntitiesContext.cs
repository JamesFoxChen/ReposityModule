using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReposityModule.Reposity2
{
    public class EntitiesContext : DbContext
    {
        public EntitiesContext() : base("TestDBConnStr") {
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

        //public IDbSet<ShipmentType> ShipmentTypes { get; set; }
        //public IDbSet<Affiliate> Affiliates { get; set; }
        //public IDbSet<Shipment> Shipments { get; set; }
        //public IDbSet<ShipmentState> ShipmentStates { get; set; }

        public IDbSet<UserInfo> UserInfos { get; set; }
        //public IDbSet<Role> Roles { get; set; }
        //public IDbSet<UserInRole> UserInRoles { get; set; }
    }
}
