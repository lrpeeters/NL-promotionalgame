namespace PromotionalGame.Storage;

public interface IScratchboardInitializer
{
    public Task<string> InitializeNewGame(int numberOfFields);
}
