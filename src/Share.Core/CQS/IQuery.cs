namespace Share;

/// <summary>
/// Represents a Query
/// </summary>
public interface IQuery<T>
{
    /// <summary>
    /// Execute Query
    /// </summary>
    /// <param name="response">Response</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>Task of T</returns>
    Task<T> ExecuteAsync(IResponse response, CancellationToken cancellationToken = default);
}