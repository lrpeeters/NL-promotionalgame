namespace PromotionalGame.Api.Models;

public class GameResponse
{
    public int HttpCode { get; set; }
    public object? Content { get; set; }
    public string? ErrorMessage { get; set; }
    public bool IsSuccessful => HttpCode >= 200 && HttpCode < 300;
}
