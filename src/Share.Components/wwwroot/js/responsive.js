// Map c# enum
const Breakpoint = {
    MobilePortrait: 1,
    MobileLandscape: 2,
    TabletPortrait: 3,
    TabletLandscape: 4,
    Laptop: 5,
    Desktop: 6
};
Object.freeze(Breakpoint);

// calculate TailwindCSS Breakpoint
function calcBreakpoint(width) {
    if (width < 640)
        return Breakpoint.MobilePortrait;

    if (width >= 640 && width < 768)
        return Breakpoint.MobileLandscape;

    if (width >= 768 && width < 1024)
        return Breakpoint.TabletPortrait;

    if (width >= 1024 && width < 1280)
        return Breakpoint.TabletLandscape;

    if (width >= 1280 && width < 1536)
        return Breakpoint.Laptop;

    if (width >= 1536)
        return Breakpoint.Desktop;
};

// some global variables
var _dotnet;
var _currentBreakpoint = calcBreakpoint(window.innerWidth);

// Add Resize
export function addResize(dotnet) {
    _dotnet = dotnet;
    _dotnet.invokeMethodAsync('OnResized', { Breakpoint: _currentBreakpoint });

    window.addEventListener("resize", onResize);
};

// Remove Resize
export function removeResize() {
    window.removeEventListener("resize", onResize);
};

// On Resize
function onResize() {
    var newBreakpoint = calcBreakpoint(window.innerWidth);

    if (_currentBreakpoint != newBreakpoint) {
        _currentBreakpoint = newBreakpoint;
        _dotnet.invokeMethodAsync('OnResized', { Breakpoint: _currentBreakpoint });
    }
};