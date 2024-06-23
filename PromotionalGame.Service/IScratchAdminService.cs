namespace PromotionalGame.Service;

public interface IScratchAdminService
{
    public Task InitializeNewGame(int numberOfFields);
}
