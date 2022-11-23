using FluentValidation;
using OtisAdminApp.Models.InputModels.Errands;

namespace OtisAdminApp.Infrastructure.FluentValidation.Errands;

public class ErrandUpdatesInputModelFluentValidator : AbstractValidator<ErrandUpdateInputModel>
{
    public ErrandUpdatesInputModelFluentValidator()
    {
        RuleFor(x => x.IsResolved).NotEmpty();
        RuleFor(x => x.Status).NotEmpty().Length(1, 50);
        RuleFor(x => x.Message).NotEmpty().Length(1, 5000);
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<ErrandUpdateInputModel>.CreateWithOptions((ErrandUpdateInputModel)model, x => x.IncludeProperties(propertyName)));
        return result.IsValid ? Array.Empty<string>() : result.Errors.Select(e => e.ErrorMessage);
    };
}