using FluentValidation.Results;

namespace Core.Errors;

public class ValidationResponse
{
    public ValidationResponse(ValidationResult validationResult)
    {
        if (validationResult.IsValid)
        {
            return;
        }

        ValidationErrors = validationResult.Errors
            .Select(e => new FieldValidationError(
                e.PropertyName,
                e.ErrorMessage,
                e.ErrorCode
            ));
    }

    public IEnumerable<FieldValidationError>? ValidationErrors { get; }

    public bool IsValid => ValidationErrors == null || !ValidationErrors.Any();
}