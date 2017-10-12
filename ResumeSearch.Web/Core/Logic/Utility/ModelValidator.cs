using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ResumeSearch.Web.Core.Logic.Utility
{
    public interface IModelValidator
    {
        bool Validate(object model, out List<ValidationResult> results);
    }
    public class ModelValidator : IModelValidator
    {
        public bool Validate(object model, out List<ValidationResult> results)
        {
            var context = new ValidationContext(model, serviceProvider: null, items: null);
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(model, context, results, true);
        }
    }
}