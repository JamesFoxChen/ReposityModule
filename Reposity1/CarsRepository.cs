using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReposityModule.Reposity1
{
    public interface ICarsRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// 自定义方法
        /// </summary>
        Cars GetById(int id);
    }

    public class CarsRepository : BaseRepository<Cars>, ICarsRepository<Cars>
    {
        private readonly ProjectContext _context;
        public CarsRepository(ProjectContext context)
            : base(context)
        {
            _context = context;
        }


        public Cars GetById(int id)
        {
            return _context.Cars.Where(p => p.Id == id).FirstOrDefault();
        }


    }
}
