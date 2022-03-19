namespace Share;

/// <summary>
/// Valid RuleBuilder Rule
/// </summary>
public class ValidRuleBuilderRule : Rule, IRule
{
    #region IRule
    /// <summary>
    /// Evaluate Rule
    /// </summary>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns>void</returns>
    public Task EvaluateAsync(CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }
    #endregion

    #region Public        
    /// <summary>
    /// Error Message
    /// </summary>
    public string Message
    {
        set
        {
            Error = new Error { Message = $"RuleBuilder failed Evaluating rules [{value}]", Context = "Global.Exception" };
        }
    }
    #endregion
}