using PromotionalGame.Storage.Models;

namespace PromotionalGame.Storage.Builders;

public interface IScratchboardBuilder
{
    Scratchboard Build();
    IScratchboardBuilder WithFields(int numberOfFields);
    IScratchboardBuilder WithGrandPrize(int numberOfGrandPrizes);
    IScratchboardBuilder WithConsolationPrize(int numberOfConsolationPrizes);
}