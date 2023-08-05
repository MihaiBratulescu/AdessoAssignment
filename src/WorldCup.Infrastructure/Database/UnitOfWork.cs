using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.Application.Interfaces.Repositories;
using WorldCup.Infrastructure.Database.Context;

namespace WorldCup.Infrastructure.Database
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly WorldCupDbContext ctx;

        public UnitOfWork(WorldCupDbContext ctx)
        {
            this.ctx = ctx;
        }

        public Task<int> SaveChangesAsync() => ctx.SaveChangesAsync();

        #region Dispose
        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    ctx.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
