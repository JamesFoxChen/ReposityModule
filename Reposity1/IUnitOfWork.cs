using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReposityModule.Reposity1
{
    public interface IUnitOfWork : IDisposable { void SaveChanges(); }
}
