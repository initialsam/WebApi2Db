using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDB2Repository;

public interface IUnitOfWork2 : IDisposable
{
    MDB2Context MDB2Context { get; }
    Task SaveAsync();
}