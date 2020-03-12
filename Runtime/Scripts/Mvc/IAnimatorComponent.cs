namespace Vrlife.Core.Mvc
{
    public interface IAnimatorComponent : IViewComponent
    {
        void SetLayerWeight(int layerId, float value);
        
        void SetParameter(int id, float value);
        void SetParameter(int id, bool value);
        void SetParameter(int id, int value);

        bool GetBoolParameter(int id);
        int GetIntParameter(int id);
        float GetFloatParameter(int id);
    }
}