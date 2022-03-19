namespace Share;

/// <summary>
/// Enum List Item
/// </summary>
public class EnumItem<T>
{
    #region Members
    private readonly T _value;
    private readonly string _name;
    private readonly string _description;
    private readonly string _code;
    private readonly Guid _guid;
    #endregion

    #region Constructor
    /// <summary>
    /// Default Constructor
    /// </summary>
    /// <param name="value">Value</param>
    /// <param name="name">Name</param>
    /// <param name="description">Description</param>
    /// <param name="code">Code</param>
    /// <param name="guid">Guid</param>
    public EnumItem(T value, string name, string description, string code, Guid guid)
    {
        _value = value;
        _name = name;
        _description = description;
        _code = code;
        _guid = guid;
    }
    #endregion

    #region Public
    /// <summary>
    /// Value
    /// </summary>
    public T Value => _value;

    /// <summary>
    /// Name
    /// </summary>
    public string Name => _name;

    /// <summary>
    /// Description
    /// </summary>
    public string Description => _description;

    /// <summary>
    /// Code
    /// </summary>
    public string Code => _code;

    /// <summary>
    /// Guid
    /// </summary>
    public Guid Guid => _guid;
    #endregion
}