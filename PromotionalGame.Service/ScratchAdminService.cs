using PromotionalGame.Storage;

namespace PromotionalGame.Service;

internal class ScratchAdminService(IScratchboardInitializer initializer) : IScratchAdminService
{
    public async Task InitializeNewGame(int numberOfFields)
    {
        await initializer.InitializeNewGame(numberOfFields);
    }
}
