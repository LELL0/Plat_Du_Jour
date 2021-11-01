using PlatDuJour.DAL.IServices;
using PlatDuJour.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatDuJour.DAL.Services
{
    public class IngredientImageRepos : GenericRepos<IngredientImage>, IIngredientImageRepos
    {
        public IngredientImageRepos(ApplicationDbContext context) : base(context)
        {
        }
    }
}
