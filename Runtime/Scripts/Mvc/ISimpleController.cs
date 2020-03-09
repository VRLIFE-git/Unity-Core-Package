namespace Vrlife.Core.Mvc
{
    public interface ISimpleController : IController< ISimpleView>
    {
        void SetVisible(bool value);
        void Toggle();
    }
}