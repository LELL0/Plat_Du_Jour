using PlatDuJour.DAL.IServices;
using PlatDuJour.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatDuJour.DAL.Services
{
    public class DailyPlateRepos: GenericRepos<DailyPlate>, IDailyPlateRepos
    {
        public DailyPlateRepos(ApplicationDbContext context):base(context)
        {
                
        }


    }
}
