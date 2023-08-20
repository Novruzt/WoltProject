using FluentValidation.Results;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.BLL.Things
{
    public static class ValidationExtensions
    {
        public static string GetErrorMessages(this ValidationResult validationResult)
        {
            if (!validationResult.IsValid)
               return  string.Join(Environment.NewLine, validationResult.Errors.Select(error => error.ErrorMessage));
            
            return null;
        }
    }
}
