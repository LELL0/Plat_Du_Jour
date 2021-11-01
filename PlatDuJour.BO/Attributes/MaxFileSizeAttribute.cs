using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatDuJour.BO.Attributes
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;
        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IFormFile formFile = value as IFormFile;
            if (formFile != null)
            {
                if (formFile.Length > _maxFileSize)
                {
                    return new ValidationResult($"Maximum file size {_maxFileSize} exceeded!");
                }
            }
            return ValidationResult.Success;
        }

    }
}
