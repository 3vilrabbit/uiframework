using System;

namespace deVoid.UIFramework {
    /// <summary>
    /// Interface that all UI Screens must implement directly or indirectly
    /// </summary>
    public interface IUIScreenController {
        string ScreenId { get; set; }
        bool IsVisible { get; }

        void Show(IScreenProperties props = null, bool animate = true);
        void Hide(bool animate = true);

        void ToForeground();
        
        void ToBackground();
        
        Action<IUIScreenController> InTransitionFinished { get; set; }
        Action<IUIScreenController> OutTransitionFinished { get; set; }
        Action<IUIScreenController> CloseRequest { get; set; }
        Action<IUIScreenController> ScreenDestroyed { get; set; }
    }

    /// <summary>
    /// Interface that all Windows must implement
    /// </summary>
    public interface IWindowController : IUIScreenController {
        bool HideOnForegroundLost { get; }
        bool IsPopup { get; }
        WindowPriority WindowPriority { get; }
    }

    /// <summary>
    /// Interface that all Panels must implement
    /// </summary>
    public interface IPanelController : IUIScreenController {
        PanelPriority Priority { get; }
    }
}
