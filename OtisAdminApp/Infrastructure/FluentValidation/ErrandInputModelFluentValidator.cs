using FluentValidation;
using OtisAdminApp.Models.InputModels.Errands;

namespace OtisAdminApp.Infrastructure.FluentValidation;

public class ErrandInputModelFluentValidator : AbstractValidator<ErrandInputModel>
{
    public ErrandInputModelFluentValidator()
    {
        RuleFor(x => x.Title).NotEmpty().Length(1, 500);
        RuleFor(x => x.ElevatorId).NotEmpty();

        RuleForEach(x => x.ErrandUpdates).SetValidator(new ErrandUpdatesInputModelFluentValidator());
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<ErrandInputModel>.CreateWithOptions((ErrandInputModel)model,
            x => x.IncludeProperties(propertyName)));
        return result.IsValid ? Array.Empty<string>() : result.Errors.Select(e => e.ErrorMessage);
    };
}