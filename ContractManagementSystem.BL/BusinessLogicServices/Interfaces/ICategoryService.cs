using ContractManagementSystem.Core.Domain;
using ContractManagementSystem.DAL.DTOs.Category;

namespace ContractManagementSystem.BL.BusinessLogicServices.Interfaces
{
    public interface ICategoryService
    {
        List<CategoryDto> GetAllCategories();
        CategoryDto GetCategoryById(Guid id);
        void AddCategory(UpsertCategoryDto category);
        void UpdateCategory(Guid id, UpsertCategoryDto category);
        void DeleteCategory(Guid id);
    }
}
