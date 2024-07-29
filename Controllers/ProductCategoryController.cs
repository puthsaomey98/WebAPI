using WebAPI.Helpers;
using WebAPI.Model;
using WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")] //    /api/OurHero
    [ApiController]
    [Authorize]
    public class ProductCategoryController : ControllerBase
    {
        private IProductCategoryService _ProductCategoriesService;
        
        public ProductCategoryController(IProductCategoryService ProductCategoryService)
        {
            _ProductCategoriesService = ProductCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] bool? isActive = null)
        {
            var productCategories = await _ProductCategoriesService.GetAll(isActive);
            return Ok(productCategories);
        }

        [HttpGet("{id}")]
        //[Route("{id}")] // /api/OurHero/:id
        public async Task<IActionResult> Get(int id)
        {
            var productCategory = await _ProductCategoriesService.GetProductCategoriesByID(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            return Ok(productCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddUpdateProductCategory productCategoryObject)
        {
            var productCategory = await _ProductCategoriesService.AddProductCategory(productCategoryObject);

            if (productCategory == null)
            {
                return BadRequest();
            }

            return Ok(new
            {
                message = "Super Hero Created Successfully!!!",
                id = productCategory!.Id
            });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] AddUpdateProductCategory productCategoryObject)
        {
            var hero = await _ProductCategoriesService.UpdateProductCategory(id, productCategoryObject);
            if (hero == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Super Hero Updated Successfully!!!",
                id = hero!.Id
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!await _ProductCategoriesService.DeleteProductCategoryByID(id))
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Super Hero Deleted Successfully!!!",
                id = id
            });
        }
    }
}
