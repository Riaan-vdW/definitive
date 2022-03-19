namespace Share;

/// <summary>
/// Response
/// </summary>
public interface IResponse
{        
    /// <summary>
    /// List of Errors
    /// </summary>
    List<Error> Errors { get; }

    /// <summary>
    /// Add Error
    /// </summary>
    /// <param name="error">Error to add</param>
    void AddError(Error error);

    /// <summary>
    /// Add Exception to error
    /// </summary>
    /// <param name="exception">Exception to add</param>
    void AddError(Exception exception);

    /// <summary>
    /// Add list of errors
    /// </summary>
    /// <param name="errors">Errors to add</param>
    void AddErrorRange(List<Error> errors);
}