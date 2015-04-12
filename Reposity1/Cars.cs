using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReposityModule.Reposity1
{
    public class Cars
    {
        public int? Id { get; set; }

        public string Model { get; set; }

        public string Make { get; set; }

        public int Year { get; set; }

        public float Price { get; set; }
    }
}


//--创建表结构
//CREATE TABLE dbo.[Cars] (
//Id INT IDENTITY(1000,1) NOT NULL,
//Model NVARCHAR(50) NULL,
//Make NVARCHAR(50) NULL,
//[Year] INT NOT NULL,
//Price REAL NOT NULL,
//CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED (Id) ON [PRIMARY]
//) ON [PRIMARY];
//GO

//--创建存储过程
//CREATE PROCEDURE [dbo].[sp$GetCars]
//AS
//-- 存储过程执行过程中等待一秒
//WAITFOR DELAY '00:00:01';
//SELECT * FROM Cars;
//GO

//--初始化数据 
//INSERT INTO dbo.Cars VALUES('Car1', 'Model1', 2006, 24950);
//INSERT INTO dbo.Cars VALUES('Car2', 'Model1', 2003, 56829);
//INSERT INTO dbo.Cars VALUES('Car3', 'Model2', 2006, 17382);
//INSERT INTO dbo.Cars VALUES('Car4', 'Model3', 2002, 72733);
