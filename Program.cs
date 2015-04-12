using Autofac;
using ReposityModule.Reposity1;
using ReposityModule.Reposity2;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

//https://github.com/JamesFoxChen/PingYourPackage
namespace ReposityModule
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Moduel1();
            Module1IOC();

            //Moduel2();
            //Module2IOC();
        }

        //基类方法+接口方法
        private static void Moduel1()
        {
            //CarsRepository carsRepo = new CarsRepository(new ProjectContext());
            //List<Cars> lstCars = carsRepo.Filter(p => p.Model == "Car1").ToList();
        }

        private static void Module1IOC()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ProjectContext>()
                       .As<DbContext>();
            builder.RegisterGeneric(typeof(BaseRepository<>))
                 .As(typeof(IRepository<>))
                 .InstancePerLifetimeScope();

            using (var container = builder.Build())
            {
                //ICarsRepository<Cars> carsRepo = container.Resolve<ICarsRepository<Cars>>();

                var carsRepo = new CarsRepository(new ProjectContext());
                var cars = carsRepo.All().ToList();
                var car = carsRepo.GetById(1001);
                //一直只能点出ToListAsync方法是因为没有引入System.Linq
                //ToListAsync是EF中的扩展方法
                //var cars = carsRepo.All().ToListAsync(); 
            }
        }

        private static void Module2IOC()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<EntitiesContext>()
                       .As<DbContext>();
            builder.RegisterGeneric(typeof(EntityRepository<>))
                 .As(typeof(IEntityRepository<>));

            using (var container = builder.Build())
            {
                IEntityRepository<UserInfo> userRepo = container.Resolve<IEntityRepository<UserInfo>>();
                UserInfo user = userRepo.GetSingleByUsername("James");
                var user2 = userRepo.FindBy(p => p.Name == "james").ToList();
            }
        }

        //基类方法+扩展方法(PingYourPackage)
        private static void Moduel2()
        {
            IEntityRepository<UserInfo> userRepo = new EntityRepository<UserInfo>(new EntitiesContext());
            userRepo.Add(new UserInfo
                {
                    Key = System.Guid.NewGuid(),
                    Name = "James",
                    CreatedOn = DateTime.Now
                });

            userRepo.Add(new UserInfo
            {
                Key = System.Guid.NewGuid(),
                Name = "Mary",
                CreatedOn = DateTime.Now
            });

            userRepo.Save();

            UserInfo user = userRepo.GetSingleByUsername("James");
        }
    }
}