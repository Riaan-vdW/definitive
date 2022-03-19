namespace Share;

/// <summary>
/// Element Class
/// </summary>
public class ElementClass
{
    #region Members
    private readonly List<string> _items;
    #endregion

    #region Constructors
    /// <summary>
    /// Default Constructor
    /// </summary>
    public ElementClass()
    {
        _items = new List<string>();
    }
    #endregion

    #region Operators
    /// <summary>
    /// Assign Operator
    /// </summary>
    /// <param name="name">Class Name</param>
    public static implicit operator ElementClass(string name)
    {
        var cssClass = new ElementClass();
        cssClass.Add(name);

        return cssClass;
    }

    /// <summary>
    /// Get Operator
    /// </summary>
    /// <param name="instance"></param>
    public static implicit operator string(ElementClass instance) => instance.Value;
    #endregion

    #region Public
    /// <summary>
    /// Add CSS class
    /// </summary>
    /// <param name="name"></param>
    public void Add(string name)
    {
        if (!string.IsNullOrEmpty(name))
        {
            if (!_items.Any(w => w.Equals(name, StringComparison.CurrentCultureIgnoreCase)))
            {
                _items.Add(name);
            }
        }
    }

    /// <summary>
    /// Remove CSS class
    /// </summary>
    /// <param name="name"></param>
    public void Remove(string name)
    {
        if (!string.IsNullOrEmpty(name))
        {
            var index = _items.FindIndex(w => w.Equals(name, StringComparison.CurrentCultureIgnoreCase));
            if (index != -1)
                _items.RemoveAt(index);
        }
    }

    /// <summary>
    /// Replace CSS Class
    /// </summary>
    /// <param name="oldName">Old Name</param>
    /// <param name="newName">New Name</param>
    public void Replace(string oldName, string newName)
    {
        var index = _items.FindIndex(w => w.Equals(oldName, StringComparison.CurrentCultureIgnoreCase));
        if (index != -1)
            _items[index] = newName;
    }

    /// <summary>
    /// Clear all CSS classes
    /// </summary>
    public void Clear()
    {
        _items.Clear();
    }
    #endregion

    #region Private
    private string Value
    {
        get
        {
            var value = new StringBuilder();
            foreach (var item in _items)
            {
                value.Append($"{item} ");
            }

            return value.ToString().Trim();
        }
    }
    #endregion
}