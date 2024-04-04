using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDB2Repository;

public class UnitOfWork2 : IUnitOfWork2
{
    private bool _disposedValue;

    public MDB2Context MDB2Context { get; private set; }

    public UnitOfWork2(MDB2Context context)
    {
        MDB2Context = context;
    }

    public async Task SaveAsync()
    {
        await MDB2Context.SaveChangesAsync();
        MDB2Context.ChangeTracker.Clear();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                this.MDB2Context.Dispose();
                this.MDB2Context = null!;
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