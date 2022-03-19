namespace Share;

/// <summary>
/// Base Components
/// </summary>
public abstract class Component : ComponentBase
{
    #region Members
    private string _id = default!;
    #endregion

    #region Public                
    /// <summary>
    /// Id
    /// </summary>
    [Parameter]
    public string Id
    {
        get
        {
            if (string.IsNullOrEmpty(_id))
            {
                _id = Guid.NewGuid().ToString();
            }

            return _id;
        }

        set => _id = value;
    }
    #endregion
}