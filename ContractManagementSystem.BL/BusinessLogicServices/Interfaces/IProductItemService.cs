using ContractManagementSystem.DAL.Model;

namespace ContractManagementSystem.BL.BusinessLogicServices.Interfaces
{
    public interface IProductItemService
    {
        IEnumerable<ProductItem> GetAllProductItems();
        ProductItem GetProductItemById(Guid id);
        void AddProductItem(ProductItem productItem);
        void UpdateProductItem(ProductItem productItem);
        void DeleteProductItem(Guid id);
    }
}
