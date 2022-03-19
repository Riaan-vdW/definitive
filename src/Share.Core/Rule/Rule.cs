namespace Share;

/// <summary>
/// Rule
/// </summary>
public abstract class Rule
{
    /// <summary>
    /// Is the Rule valid
    /// </summary>
    public bool IsValid { get; protected set; }

    /// <summary>
    /// Rule's Error
    /// </summary>
    public Error? Error { get; set; }
}