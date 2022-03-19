namespace Share;

/// <summary>
/// Query Request
/// </summary>
public interface IQueryRequest
{
    /// <summary>
    /// Convert object to parameter string
    /// </summary>
    /// <returns>HTTP Parameter string</returns>
    string ToParameters();
}