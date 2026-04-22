using Microsoft.AspNetCore.Mvc;
using SuperMarket.Dtos.Categories;
using SuperMarket.Services;

namespace SuperMarket.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var category = await _categoryService.GetOneAsync(id);
            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto createCategoryDto)
        {
            try
            {
                var category = await _categoryService.CreateAsync(createCategoryDto);
                if (category is not null)
                {
                    TempData["isSuccess"] = true;
                    TempData["message"] = "Create success";
                }
            }
            catch (Exception err)
            {
                TempData["isSuccess"] = false;
                TempData["message"] = err.Message;
            }
           
            return RedirectToAction("Index");

        }


        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryService.GetOneAsync(id);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id,CreateCategoryDto createCategoryDto)
        {
            var result = await _categoryService.UpdateAsync(id, createCategoryDto);
            return result ? RedirectToAction("Index") : BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.DeleteAsync(id);
            return result ? RedirectToAction("Index") : BadRequest();

        }
    }
}
