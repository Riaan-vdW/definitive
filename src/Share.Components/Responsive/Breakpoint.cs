
namespace Share;

/// <summary>
/// Breakpoint
/// </summary>
public enum Breakpoint
{
    /// <summary>
    /// Mobile Portrait
    /// </summary>
    MobilePortrait = 1,

    /// <summary>
    /// Mobile Landscape
    /// </summary>
    /// <remarks>@media (min-width: 640px)</remarks>
    MobileLandscape = 2,

    /// <summary>
    /// Tablet Portrait
    /// </summary>
    /// <remarks>@media (min-width: 768px)</remarks>
    TabletPortrait = 3,

    /// <summary>
    /// Tablet Landscape
    /// </summary>
    /// <remarks>@media (min-width: 1024px)</remarks>
    TabletLandscape = 4,

    /// <summary>
    /// Laptop
    /// </summary>
    /// <remarks>@media (min-width: 1280px)</remarks>
    Laptop = 5,

    /// <summary>
    /// Desktop
    /// </summary>
    /// <remarks>@media (min-width: 1536px)</remarks>
    Desktop = 6
}