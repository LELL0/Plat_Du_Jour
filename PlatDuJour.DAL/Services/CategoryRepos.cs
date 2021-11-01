using Microsoft.EntityFrameworkCore;
using PlatDuJour.DAL.IServices;
using PlatDuJour.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatDuJour.DAL.Services
{
    public class CategoryRepos :GenericRepos<Category> , ICategoryRepos
    {
        public CategoryRepos(ApplicationDbContext context):base(context)
        {
                
        }

        public async Task<Category> GetByName(string Name)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.CategoryName.Equals(Name));
        }


    }
}
