using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDB1Repository;

public class UnitOfWork : IUnitOfWork
{
    private bool _disposedValue;

    public MDB1Context MDB1Context { get; private set; }

    public UnitOfWork(MDB1Context context)
    {
        MDB1Context = context;
    }

    public async Task SaveAsync()
    {
        await MDB1Context.SaveChangesAsync();
        MDB1Context.ChangeTracker.Clear();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                this.MDB1Context.Dispose();
                this.MDB1Context = null!;
            }
            _disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}