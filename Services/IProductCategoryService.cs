using WebAPI.Model;

namespace WebAPI.Services
{
    public interface IProductCategoryService
    {
        Task<List<ProductCategory>> GetAll(bool? isActive);
        Task<ProductCategory?> GetProductCategoriesByID(int id);
        Task<ProductCategory?> AddProductCategory(AddUpdateProductCategory obj);
        Task<ProductCategory?> UpdateProductCategory(int id, AddUpdateProductCategory obj);
        Task<bool> DeleteProductCategoryByID(int id);
    }
}
