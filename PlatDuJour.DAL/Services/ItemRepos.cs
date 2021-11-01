using PlatDuJour.DAL.IServices;
using PlatDuJour.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatDuJour.DAL.Services
{
    public class ItemRepos :GenericRepos<Item>,IItemRepos
    {
        public ItemRepos(ApplicationDbContext context):base(context)
        {

        }
    }
}
