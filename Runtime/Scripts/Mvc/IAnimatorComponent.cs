namespace Vrlife.Core.Mvc
{
    public interface IAnimatorComponent : IViewComponent
    {
        void SetLayerWeight(int layerId, float value);
        void SetTrigger(int id);
        void ResetTrigger(int id);
        void SetParameter(int id, float value);
        void SetParameter(int id, bool value);
        void SetParameter(int id, int value);

        bool GetBoolParameter(int id);
        int GetIntParameter(int id);
        float GetFloatParameter(int id);

        void PlayState(string stateName);
    }
}