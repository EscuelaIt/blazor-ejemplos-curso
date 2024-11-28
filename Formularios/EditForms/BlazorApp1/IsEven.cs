using System.ComponentModel.DataAnnotations;

namespace BlazorApp1;

public class IsEvenAttribute : ValidationAttribute
{
    public bool IsZeroValid { get; set; }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var intValue = value is not null ? (int)value : 0;

        var isEven = intValue % 2 == 0;


        if (!isEven)
        {
            return new ValidationResult($"Value {value} must be even");
        }

        return null;
    }
}