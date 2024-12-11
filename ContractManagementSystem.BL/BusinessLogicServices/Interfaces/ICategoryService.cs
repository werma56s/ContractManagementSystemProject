using ContractManagementSystem.DAL.Model;

namespace ContractManagementSystem.BL.BusinessLogicServices.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(Guid id);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Guid id);
    }
}
