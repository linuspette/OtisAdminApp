using FluentValidation;
using OtisAdminApp.Models.InputModels.Users;

namespace OtisAdminApp.Infrastructure.FluentValidation.Employees;

public class EmployeeInputModelFluentValidation : AbstractValidator<EmployeeInputModel>
{
    public EmployeeInputModelFluentValidation()
    {
        RuleFor(x => x.FullName).NotEmpty().Length(1, 100);
        RuleFor(x => x.FirstName).NotEmpty().Length(1, 50);
        RuleFor(x => x.LastName).NotEmpty().Length(1, 50);
        RuleFor(x => x.EmployeeNumber).NotEmpty().GreaterThan(0).LessThan(1000000);
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<EmployeeInputModel>.CreateWithOptions((EmployeeInputModel)model,
            x => x.IncludeProperties(propertyName)));
        return result.IsValid ? Array.Empty<string>() : result.Errors.Select(e => e.ErrorMessage);
    };
}