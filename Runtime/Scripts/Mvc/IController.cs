namespace Vrlife.Core.Mvc
{
    public interface IController<in TView>
    {
        void BindView(TView view);
    }

   
    
    public interface IController<in TView, in TViewModel> : IController<TView>
    {
        void RenderViewModel(TViewModel model);
    }
}