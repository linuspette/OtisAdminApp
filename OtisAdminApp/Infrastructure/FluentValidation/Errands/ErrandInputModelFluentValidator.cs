using FluentValidation;
using OtisAdminApp.Models.InputModels.Errands;

namespace OtisAdminApp.Infrastructure.FluentValidation.Errands;

public class ErrandInputModelFluentValidator : AbstractValidator<ErrandInputModel>
{
    public ErrandInputModelFluentValidator()
    {
        RuleFor(x => x.Title).NotEmpty().Length(1, 500);
        RuleFor(x => x.ElevatorId).NotEmpty();
        RuleFor(x => x.ErrandUpdates.Message).NotEmpty().Length(1, 5000);
        RuleFor(x => x.ErrandUpdates.Status).NotEmpty();
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<ErrandInputModel>.CreateWithOptions((ErrandInputModel)model,
            x => x.IncludeProperties(propertyName)));
        return result.IsValid ? Array.Empty<string>() : result.Errors.Select(e => e.ErrorMessage);
    };
}