using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PlatDuJour.BO
{
    public static class Tools 
    {
        public static async Task<string> SaveImage(this IFormFile formFile,string folderName)
        {
            string path = Path.Combine("wwwroot", "Images", folderName, Guid.NewGuid().ToString() + ".jpg");
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                await formFile.CopyToAsync(fs);
            }
            return path;
        }

        public static async Task<List<string>> SaveImages(List<IFormFile> formFiles , string folderName)
        {
            List<string> result = new List<string>();
            foreach(IFormFile form in formFiles) 
            {
                string path = await form.SaveImage(folderName);
                result.Add(path);
            }
            return result;
        }

        public static string ImageTypes = ".jpg,.bmp,.PNG,.EPS,.gif,.TIFF,.tif,.jfif";
    }
}
