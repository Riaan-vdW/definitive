namespace Share;

/// <summary>
/// Enum Guid Attribute
/// </summary>
[AttributeUsage(AttributeTargets.All)]
public sealed class EnumGuidAttribute : Attribute
{
    #region Members
    private readonly Guid _guid;
    #endregion

    #region Constructor
    /// <summary>
    /// Default Constructor
    /// </summary>
    /// <param name="input">Guid</param>
    public EnumGuidAttribute(string input)
    {
        if (Guid.TryParse(input, out var guid))
            _guid = guid;
        else
            _guid = Guid.Empty;
    }
    #endregion

    #region Public
    /// <summary>
    /// Guid Value
    /// </summary>
    public Guid Guid => _guid;
    #endregion
}