namespace PromotionalGame.Storage.Models;

public enum ScratchStatus
{
    /// <summary>
    /// The field was already scratched by another user
    /// </summary>
    AlreadyScratched,
    /// <summary>
    /// The scratch was successful
    /// </summary>
    Success,
    /// <summary>
    /// The action to scratch the field contains invalid data
    /// </summary>
    InvalidScratch,
    /// <summary>
    /// An unexpected error occurred
    /// </summary>
    Error
}
