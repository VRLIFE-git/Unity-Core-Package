namespace Vrlife.Core.Mvc
{
    public interface IAnimatorComponent : IViewComponent
    {
        void SetParameter(int id, float value);
    }
}