using ContractManagementSystem.Core.Domain;
using ContractManagementSystem.DAL.DTOs.Category;
using System.Linq.Expressions;

namespace ContractManagementSystem.DAL.Assemblers
{
    public class CategoryAssemblers
    {
        // Mapowanie Category -> CategoryDTO

        public Expression<Func<Category, CategoryDto>> ExpGetCategoryDto { get; } = domain => new CategoryDto()
        {
            Id = domain.Id,
            CreatedBy = domain.CreatedBy,
            ModifiedBy = domain.ModifiedBy,
            Name = domain.Name,
            Description = domain.Description,
        };


        // Mapowanie ContractDto -> Contract (tu zwykła metoda)
        public Category MapToCategory(UpsertCategoryDto dto, Guid? Id = null)
        {
            var category = new Category
            {
                Id = Id ?? Guid.NewGuid(),  // Jeśli Id jest null, przypisujemy nowy GUID
                Name = dto.Name,
                Description= dto.Description,
            };

            // Warunkowe przypisanie DateCreated lub DateModified
            if (Id == null)
            {
                category.DateCreated = DateTime.UtcNow;
            }
            else
            {
                category.DateModified = DateTime.UtcNow;
            }

            return category;
        }

    }
}
