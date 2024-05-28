using Blog.Infrastructure.Data.Entities;
using BlogCleanArchitecture.Domain;
using BlogCleanArchitecture.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryDomains = BlogCleanArchitecture.Domain.Category;
using CategoryEntity = Blog.Infrastructure.Data.Entities.Category;

namespace Blog.Infrastructure.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public BlogDbContext Context { get; }
        public CategoryRepository(BlogDbContext blogDbContext)
        {
            Context = blogDbContext;
        }
        public async Task<int> Add(CategoryDomains category)
        {
            var dbmodel = new CategoryEntity
            {
                CreateDate = DateTime.Now,
                Title = category.Title
            };
            Context.Categories.Add(dbmodel);
            Context.SaveChanges();
            return  dbmodel.Id;
        }
        private CategoryEntity GetCategory(int id)
        {
            var item = Context.Categories.FirstOrDefault(c => c.Id == id);
            if ((item == null))
            {
                throw new Exception("Not Found");
            }
            return item;
        }

        public async Task Delete(int id)
        {
            var finded = GetCategory(id);


            Context.Categories.Remove(finded);
            Context.SaveChanges();
        }

        public async Task Edit(CategoryDomains category)
        {
            var finded = GetCategory(category.ID);
            finded.Title= category.Title; ;
            Context.Categories.Update(finded);
            Context.SaveChanges();
        }

        public async Task<List<CategoryDomains>> GetALL()
        {
            return await Context.Categories.Select(x => new CategoryDomains
            {
                Title = x.Title,
                CreateDate = x.CreateDate,
                ID = x.Id,


            }).ToListAsync();
        }

        public async Task<CategoryDomains> GetById(int Id)
        {
            var item = Context.Categories.Select(x => new CategoryDomains
            {
                ID = x.Id,
                CreateDate = x.CreateDate,
            }).FirstOrDefault(x => x.ID==Id);
            if (item == null)
            {
                throw new Exception("Not Found");
            }
            return item;
        }
    }
}
