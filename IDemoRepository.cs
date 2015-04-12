using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReposityModule
{
    public interface IDemoRepository : IRepository
    {
        IList GetRDemo(int id);
    }

    public class DemoRepository : BaseRepository, IDemoRepository
    {
        private readonly ProjectContext _context; public DemoRepository(ProjectContext context) : base(context) { _context = context; }
        public IList<Demo> GetRDemo(int id)
        {
            return _context.GetRDemos.Where(p => p.Id == Id).ToList();
        }


    }

}
