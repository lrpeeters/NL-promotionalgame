namespace PromotionalGame.Service.Validations;

public class ValidationResults
{
    public bool IsValid => Results.Count == 0;

    public List<ValidationResult> Results { get; } = [];

    public void Add(ValidationResult result)
    {
        Results.Add(result);
    }
}
