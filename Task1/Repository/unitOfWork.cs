﻿
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using Task1.Data;
using Task1.Models;

namespace Task1.Repository
{
    public class unitOfWork : IUnitOfWork
    {
        public VehicleRepository _vehicleRepository { get; }
        public IGenericRepository<Categories> _categoriesRepository { get; }
        public IGenericRepository<Brands> _brandsRepository { get; }
        public IGenericRepository<Colours> _coloursRepository { get; }
        public IGenericRepository<Stocks> _stocksRepository { get; }


        bool isDisposed;
        private readonly ProgramDbContext _context;

        public IDbContextTransaction _TransactionObj = null;

        public unitOfWork(ProgramDbContext context)
        {
            _context = context;
            _vehicleRepository = new VehicleRepository(_context);
            _categoriesRepository = new GenericRepository<Categories>(_context);
            _brandsRepository = new GenericRepository<Brands>(_context);
            _coloursRepository = new GenericRepository<Colours>(_context);
            _stocksRepository = new GenericRepository<Stocks>(_context);
        }

        public async Task CreateTransaction()
        {
            _TransactionObj = await _context.Database.BeginTransactionAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }


        public void Dispose()
        {
            _context.Dispose();
        }

        public void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                    GC.SuppressFinalize(this);
                }
                isDisposed = true;
            }

        }

    }
}
