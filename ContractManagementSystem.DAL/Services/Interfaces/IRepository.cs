using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagementSystem.DAL.Services.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll(); // Pobierz wszystkie elementy
        T GetById(Guid id);     // Pobierz element po ID
        void Add(T entity);     // Dodaj nowy element
        void Update(T entity);  // Zaktualizuj istniejący element
        void Delete(T entity);  // Usuń element
    }
}
