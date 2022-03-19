namespace Share;

/// <summary>
/// Command
/// </summary>
public interface ICommand
{
    /// <summary>
    /// Execute Command
    /// </summary>
    /// <param name="response">Response</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>Task</returns>
    Task ExecuteAsync(IResponse response, CancellationToken cancellationToken = default);
}