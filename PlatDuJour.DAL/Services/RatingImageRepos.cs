using PlatDuJour.DAL.IServices;
using PlatDuJour.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatDuJour.DAL.Services
{
    public class RatingImageRepos :GenericRepos<RatingImage>, IRatingImageRepos
    {
        public RatingImageRepos(ApplicationDbContext context):base(context)
        {

        }
    }
}
