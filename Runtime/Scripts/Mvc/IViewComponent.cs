namespace Vrlife.Core.Mvc
{
    public interface IViewComponent
    {
        void SetEnabled(bool value);
        bool IsEnabled { get; }
    }
}