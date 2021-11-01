using PlatDuJour.DAL.IServices;
using PlatDuJour.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatDuJour.DAL.Services
{
    public class IngredientItemRepos : GenericRepos<IngredientItem> , IIngredientItemRepos
    {
        public IngredientItemRepos(ApplicationDbContext context):base(context)
        {

        }

        public async Task AddIngredientItem(IngredientItem ingredientITem)
        {
            await Create(ingredientITem);
        }
    }
}
