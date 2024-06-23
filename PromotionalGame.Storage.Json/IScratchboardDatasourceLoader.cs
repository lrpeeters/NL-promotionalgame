
using PromotionalGame.Storage.Json.IO;

namespace PromotionalGame.Storage.Json;

internal interface IScratchboardDatasourceLoader
{
    Task<Stream> Load(AccessTypes accessType, ShareTypes shareType);
}