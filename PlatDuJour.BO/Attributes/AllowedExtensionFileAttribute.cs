using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatDuJour.BO.Attributes
{
    class AllowedExtensionFileAttribute : ValidationAttribute
    {
        private string _extensions;
        public AllowedExtensionFileAttribute(string extensions)
        {
            _extensions = extensions;
        }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IFormFile file = value as IFormFile;
            if (file != null)
            {
                string[] extensionArray = _extensions.Split(',');
                bool validExtension = extensionArray.Any(x => file.FileName.ToLower().EndsWith(x.ToLower()));
                if (!validExtension)
                {
                    return new ValidationResult($"Image Type of this {file.FileName} is not allowed!");
                }
            }
            return ValidationResult.Success;
        }
    }
}
