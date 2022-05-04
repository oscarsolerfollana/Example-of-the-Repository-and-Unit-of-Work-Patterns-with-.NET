using System;
using DowJones.Models;

namespace DowJones.DAL
{
    public class UnitOfWork : IDisposable
    {
        private DowJonesContext dowJonesContext;
        private GenericRepository<User> usersRepository;
        private GenericRepository<Stock> stocksRepository;

        public UnitOfWork(DowJonesContext dowJonesContext)
        {
            this.dowJonesContext = dowJonesContext;
        }

        public GenericRepository<User> UsersRepository
        {
            get
            {
                if (usersRepository == null)
                {
                    usersRepository = new GenericRepository<User>(dowJonesContext);
                }
                return usersRepository;
            }
        }

        public GenericRepository<Stock> StocksRepository
        {
            get
            {
                if (StocksRepository == null)
                {
                    stocksRepository = new GenericRepository<Stock>(dowJonesContext);
                }
                return stocksRepository;
            }
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    dowJonesContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}