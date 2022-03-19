
namespace Share;

/// <summary>
/// Body
/// </summary>
public partial class Responsive : IAsyncDisposable
{
    #region Members
    private IJSObjectReference _responsiveModule = default!;
    private Breakpoint _breakpoint = default!;
    #endregion

    #region Private
    [Inject]
    private IJSRuntime JSRuntime { get; set; } = default!;
    #endregion

    #region Override
    /// <summary>
    /// On After Render
    /// </summary>
    /// <param name="firstRender">First Render</param>
    /// <returns></returns>
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _responsiveModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/Share.Components/js/responsive.js");

            var dotnet = DotNetObjectReference.Create(this);
            await _responsiveModule.InvokeVoidAsync("addResize", dotnet);
        }
    }
    #endregion

    #region IAsyncDisposable
    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources asynchronously.
    /// </summary>
    /// <returns></returns>
    [SuppressMessage("Usage", "CA1816:Dispose methods should call SuppressFinalize", Justification = "<Pending>")]
    public async ValueTask DisposeAsync()
    {
        await _responsiveModule.InvokeVoidAsync("removeResize");
        await _responsiveModule.DisposeAsync();
    }
    #endregion

    #region Public
    /// <summary>
    /// On Resized
    /// </summary>
    /// <param name="args"></param>
    [JSInvokable]
    public void OnResized(BreakpointEventArgs args)
    {
        _breakpoint = args.Breakpoint;
        StateHasChanged();
    }

    /// <summary>
    /// Breakpoint
    /// </summary>
    public Breakpoint Breakpoint => _breakpoint;

    /// <summary>
    /// All
    /// </summary>
    [Parameter]
    public RenderFragment ChildContent { get; set; } = default!;
    #endregion
}
