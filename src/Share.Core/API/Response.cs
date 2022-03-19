namespace Share;

/// <summary>
/// API Response
/// </summary>
public abstract class Response : IResponse
{
    #region Members 
    private List<Error> _errors;
    #endregion

    #region Constructors
    /// <summary>
    /// Initialize a new instance of a Response class
    /// </summary>
    protected Response()
    {
        _errors = new List<Error>();
    }
    #endregion

    #region Public                
    /// <summary>
    /// Successful 
    /// </summary>        
    public bool Successful => !_errors.Any();
    #endregion

    #region IResponse
    /// <summary>
    /// Request Errors
    /// </summary>        
    public List<Error> Errors
    {
        get
        {
            return _errors;
        }
        set
        {
            if (value is not null)
            {
                _errors = value;
            }
        }
    }

    /// <summary>
    /// Add Error
    /// </summary>
    /// <param name="error">Error to add</param>
    public void AddError(Error error)
    {
        if (!_errors.Any(w =>
            CleanContextKey(w.ContextKey).Equals(CleanContextKey(error.ContextKey), StringComparison.CurrentCultureIgnoreCase) &&
            w.Context.Equals(error.Context, StringComparison.CurrentCultureIgnoreCase) &&
            w.Message.Equals(error.Message, StringComparison.CurrentCultureIgnoreCase)))
        {
            _errors.Add(error);
        }
    }

    /// <summary>
    /// Add Exception to error
    /// </summary>
    /// <param name="exception">Exception to add</param>
    public void AddError(Exception exception)
    {
        var errors = new List<Error>();

        Exception? internalException = exception;
        while (internalException != null)
        {
            errors.Add(new Error { Message = internalException.Message, Context = "Global.Exception" });
            internalException = internalException.InnerException;
        }

        AddErrorRange(errors);
    }

    /// <summary>
    /// Add list of errors
    /// </summary>
    /// <param name="errors">Errors to add</param>
    public void AddErrorRange(List<Error> errors)
    {
        foreach (var error in errors)
        {
            AddError(error);
        }
    }
    #endregion

    #region Private
    
    private static string CleanContextKey(string? input)
    {
        if (string.IsNullOrEmpty(input))
            return "";
        else
            return input;
    }
    #endregion
}