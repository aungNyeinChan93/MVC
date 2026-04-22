using Microsoft.AspNetCore.Mvc;
using SuperMarket.Dtos.Posts;
using SuperMarket.Services;

namespace SuperMarket.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;

        public PostsController(IPostService postService, ICategoryService categoryService)
        {
            _postService = postService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await _postService.GetAllAsync();
            return View(posts);
        }

        public async Task<IActionResult> Create()
        {
            var categoreis = await _categoryService.GetAllAsync();
            return View(categoreis);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePostDto createPostDto)
        {
            var categoreis = await _categoryService.GetAllAsync();

            if (ModelState.IsValid)
            {
                try
                {
                    var newPost = await _postService.CreateAsync(createPostDto);
                    if (newPost is null)
                    {
                        return BadRequest();
                    }
                    TempData["isSuccess"] = true;
                    TempData["message"] = "Create post success!";
                }
                catch (Exception err)
                {
                    TempData["isSuccess"] = false;
                    TempData["message"] = err.Message;
                }

                return RedirectToAction("Index");
            }
            return View(categoreis);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var result = await _postService.DeleteAsync(id);
            if (!result)
            {
                return BadRequest();
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var categoreis = await _categoryService.GetAllAsync();
            ViewBag.categories = categoreis;
            var post = await _postService.GetOneAsync(id);
            return View(post);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,CreatePostDto createPostDto)
        {
            var categoreis = await _categoryService.GetAllAsync();
            ViewBag.categories = categoreis;
            var post = await _postService.GetOneAsync(id);

            if (ModelState.IsValid)
            {
                var result = await _postService.UpdateAsync(id, createPostDto);
                if (!result)
                {
                    return BadRequest();
                }
                return RedirectToAction("Index");
            }
            return View(post);
        }

    }
}
