namespace Share;

/// <summary>
/// Enum Description Attribute
/// </summary>
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public sealed class EnumDescriptionAttribute : Attribute
{
    #region Members
    private readonly string _description;
    #endregion

    #region Constructor
    /// <summary>
    /// Default Constructor
    /// </summary>
    /// <param name="description">Description</param>
    public EnumDescriptionAttribute(string description)
    {
        _description = description;
    }
    #endregion

    #region Public
    /// <summary>
    /// Description
    /// </summary>
    public string Description => _description;
    #endregion
}