namespace Vrlife.Core.Mvc
{
    public interface IController<in TView>
    {
        void BindView(TView view);
    }
}