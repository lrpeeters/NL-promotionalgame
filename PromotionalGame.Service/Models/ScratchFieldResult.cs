namespace PromotionalGame.Service.Models;

public class ScratchFieldResult
{
    public ScratchStatus ScratchStatus { get; set; }

    public ScratchPrizes? Prize { get; set; }

    public string? ErrorMessage { get; set; }
}
