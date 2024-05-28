using BlogCleanArchitecture.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCleanArchitecture.Interfaces.Repository
{
    public interface ICategoryRepository
    {
        Task<Category> GetById(int Id);
        Task<List<Category>> GetALL();
        Task<int> Add(Category category);
         Task Edit(Category category);
        Task Delete(int id);
    }
}
