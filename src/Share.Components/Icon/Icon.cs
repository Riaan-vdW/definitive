namespace Share;

/// <summary>
/// Icon
/// </summary>
public abstract class Icon : ComponentBase
{
    /// <summary>
    /// Class
    /// </summary>
    [Parameter]
    public string Class { get; set; } = default!;
}