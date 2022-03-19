namespace Share;

/// <summary>
/// Error
/// </summary>
public record Error
{
    /// <summary>
    /// Message
    /// </summary>
    public string Message { get; init; } = default!;

    /// <summary>
    /// Message Context
    /// </summary>
    public string Context { get; init; } = default!;

    /// <summary>
    /// Message Context Key
    /// </summary>
    public string? ContextKey { get; init; }
}