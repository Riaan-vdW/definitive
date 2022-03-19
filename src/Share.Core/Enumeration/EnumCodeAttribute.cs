namespace Share;

/// <summary>
/// Enum Code Attribute
/// </summary>
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public sealed class EnumCodeAttribute : Attribute
{
    #region Members
    private readonly string _code;
    #endregion

    #region Constructor
    /// <summary>
    /// Default Constructor
    /// </summary>
    /// <param name="code">Code</param>
    public EnumCodeAttribute(string code)
    {
        _code = code;
    }
    #endregion

    #region Public
    /// <summary>
    /// Code
    /// </summary>
    public string Code => _code;
    #endregion
}