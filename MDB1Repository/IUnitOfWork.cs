using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDB1Repository;

public interface IUnitOfWork : IDisposable
{
    MDB1Context MDB1Context { get; }
    Task SaveAsync();
}