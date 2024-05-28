using Blog.Core.ViewModels;
using Blog.Infrastructure.Data.Entities;
using BlogCleanArchitecture.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : BaseController
    {
       public ICategoryRepository CategoryRepository { get; set; }
        public CategoryController(ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetCategory(int id)
        {
            try
            {
                var catgory = await CategoryRepository.GetById(id);
                return CustomOk(catgory);
            }
            catch(Exception ex)
            {
                return CustomError(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            try
            {
                var catgory = await CategoryRepository.GetALL();
                return CustomOk(catgory);
            }
            catch (Exception ex)
            {
                return CustomError(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(CategoryAddVm categoryAddVm)
        {
            try
            {
                var id = await CategoryRepository.Add(new BlogCleanArchitecture.Domain.Category{Title=categoryAddVm.Title });
                return CustomOk(id);
            }
            catch (Exception ex)
            {
                return CustomError(ex.Message);
            }
        }
        [HttpPut("Id")]
        public async Task<IActionResult> put(int Id,CategoryEditVm categoryEditVm)
        {
            if (Id != categoryEditVm.Id)
            {
                return CustomError();

            }
            try
            {
                await CategoryRepository.Edit(new BlogCleanArchitecture.Domain.Category { Title=categoryEditVm.Title,ID=Id});
                
                return CustomOk(true);
            }
            catch (Exception ex)
            {
                return CustomError(ex.Message);
            }
        }



    }
}
