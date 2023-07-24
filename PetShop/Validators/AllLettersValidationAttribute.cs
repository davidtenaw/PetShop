﻿using System.ComponentModel.DataAnnotations;

namespace PetShop.Validators
{
    public class AllLettersValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return (value != null) && ((string)value).All(char.IsLetter);
        }
    }
}
