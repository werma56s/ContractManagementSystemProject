using ContractManagementSystem.BL.BusinessLogicServices.Interfaces;
using ContractManagementSystem.Core.Domain;
using ContractManagementSystem.DAL.Assemblers;
using ContractManagementSystem.DAL.DTOs.Category;
using ContractManagementSystem.DAL.Services;
using ContractManagementSystem.DAL.Services.Interfaces;

namespace ContractManagementSystem.BL.BusinessLogicServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CategoryAssemblers _categoryAssemblers;
        public CategoryService(IUnitOfWork unitOfWork, CategoryAssemblers categoryAssemblers)
        {
            _unitOfWork = unitOfWork;
            _categoryAssemblers = categoryAssemblers;
        }

        public List<CategoryDto> GetAllCategories()
        {
            return _unitOfWork.Categories.GetAll().Where(x => x.IsDeleted == false).Select(_categoryAssemblers.ExpGetCategoryDto).ToList();
        }

        public CategoryDto GetCategoryById(Guid id)
        {
            return _unitOfWork.Categories.GetAll().Where(x => x.IsDeleted == false).Where(c => c.Id == id)
                               .Select(_categoryAssemblers.ExpGetCategoryDto)
                               .First();
        }
        public void AddCategory(UpsertCategoryDto categoryDto)
        {
            // Mapowanie ContractDto -> Contract
            var category = _categoryAssemblers.MapToCategory(categoryDto);
            // Dodanie nowej kategorii do bazy danych
            _unitOfWork.Categories.Add(category);
            // Zapisanie zmian
            _unitOfWork.SaveChanges();
        }

        public void UpdateCategory(Guid id, UpsertCategoryDto categoryDto)
        {
            if (_unitOfWork.Categories.GetById(id) == null || _unitOfWork.Categories.GetById(id).IsDeleted)
                return; // Jeśli kategoria nie istnieje lub jest usunięta, kończymy metodę.

            //jesli rekord znaleziony nie ma Deleted na true to uataualnij dane
            var category = _categoryAssemblers.MapToCategory(categoryDto,id);
            _unitOfWork.Categories.Update(category);
            _unitOfWork.SaveChanges();
            
        }

        public void DeleteCategory(Guid id)
        {
            var category = _unitOfWork.Categories.GetAll().Where(x => x.IsDeleted == false).Where(c => c.Id == id).First();
            if (category != null)
            {
                // Ustawiamy flagę IsDeleted na true
                category.IsDeleted = true;
                // Zapisujemy zmiany w bazie danych
                _unitOfWork.SaveChanges();
            }
        }

    }
}
