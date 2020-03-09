namespace Vrlife.Core.Mvc
{
    public interface IRendererComponent : IViewComponent
    {
        void SetVisible(bool value);

        bool IsVisible { get; }

        bool ToggleVisible();
    }
}