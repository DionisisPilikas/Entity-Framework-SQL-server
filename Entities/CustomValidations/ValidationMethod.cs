using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.CustomValidations
{
    public class ValidationMethod
    {
        public static ValidationResult ValidateGreaterOf2500(int value, ValidationContext context)
        {
            bool isvalid = true;
            if(value<0M || value>2500M)
            {
                isvalid = false;
            }
            if (isvalid) //an einai true
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(string.Format("The field {0} must be greater than zero and less than 2500", context.MemberName), new List<string> { context.MemberName });
            }
        }
    }
}
