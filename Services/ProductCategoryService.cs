using WebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly OurHeroDbContext _db;
        public ProductCategoryService(OurHeroDbContext db)
        {
            _db = db;
        }
        public async Task<List<ProductCategory>> GetAll(bool? isActive)
        {
            if (isActive != null)
            {
                return await _db.ProductCategories.Where(m => m.IsActive == isActive).ToListAsync();
            }
            return await _db.ProductCategories.ToListAsync();
        }

        public async Task<ProductCategory?> GetProductCategoriesByID(int id)
        {
            return await _db.ProductCategories.FirstOrDefaultAsync(ProductCategory => ProductCategory.Id == id);
        }

        public async Task<ProductCategory?> AddProductCategory(AddUpdateProductCategory obj)
        {
            var addProductCategory = new ProductCategory()
            {
                Name = obj.Name,
                Description = obj.Description,
                IsActive = obj.IsActive,
            };

            _db.ProductCategories.Add(addProductCategory);
            var result = await _db.SaveChangesAsync();
            return result >= 0 ? addProductCategory : null;
        }

        public async Task<ProductCategory?> UpdateProductCategory(int id, AddUpdateProductCategory obj)
        {
            var ProductCategory = await _db.ProductCategories.FirstOrDefaultAsync(index => index.Id == id);
            if (ProductCategory != null)
            {
                ProductCategory.Name = obj.Name;
                ProductCategory.Description = obj.Description;
                ProductCategory.IsActive = obj.IsActive;

                var result = await _db.SaveChangesAsync();
                return result >= 0 ? ProductCategory : null;
            }
            return null;
        }

        public async Task<bool> DeleteProductCategoryByID(int id)
        {
            var ProductCategory = await _db.ProductCategories.FirstOrDefaultAsync(index => index.Id == id);
            if (ProductCategory != null)
            {
                _db.ProductCategories.Remove(ProductCategory);
                var result = await _db.SaveChangesAsync();
                return result >= 0;
            }
            return false;
        }

    }
}
