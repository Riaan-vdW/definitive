namespace Share;

/// <summary>
/// Rules Engine Rule interface
/// </summary>
public interface IRule
{
    /// <summary>
    /// Evaluate the rule
    /// </summary>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>void</returns>
    Task EvaluateAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Is the rule valid
    /// </summary>
    bool IsValid { get; }

    /// <summary>
    /// Rule's Error
    /// </summary>
    Error? Error { get; set; }
}