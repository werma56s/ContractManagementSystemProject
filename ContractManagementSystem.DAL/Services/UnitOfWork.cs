﻿using ContractManagementSystem.Core;
using ContractManagementSystem.Core.Domain;


//using ContractManagementSystem.DAL.Model;
using ContractManagementSystem.DAL.Services.Interfaces;


namespace ContractManagementSystem.DAL.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContractManagementDbContext _context;

        public UnitOfWork(ContractManagementDbContext context)
        {
            _context = context;
        }

        // Repozytoria
        public IRepository<Contract> Contracts => new Repository<Contract>(_context);
        public IRepository<Annex> Annexes => new Repository<Annex>(_context);
        public IRepository<ProductItem> ProductItems => new Repository<ProductItem>(_context);
        public IRepository<ResponsiblePerson> ResponsiblePersons => new Repository<ResponsiblePerson>(_context);
        public IRepository<Category> Categories => new Repository<Category>(_context);
        public IRepository<Account> Accounts => new Repository<Account>(_context);

        // Zapisuje wszystkie zmiany do bazy
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        // Zwolnienie zasobów
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
