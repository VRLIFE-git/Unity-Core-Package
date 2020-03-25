using UnityEngine;

namespace Vrlife.Core.Mvc
{
    public interface IRendererComponent : IViewComponent
    {
        void SetVisible(bool value);

        bool IsVisible { get; }

        bool ToggleVisible();

        void SetMaterial(int index, Material material);

        Material GetMaterial(int index);

//        void SetColor(int shaderId, Color color);
//
//        Color GetColor(int shaderId);
//
//        void SetIntParam(int shaderId, int value);
//        void SetFloatParam(int shaderId, float value);
//        void SetBoolParam(int shaderId, bool value);
//
//        int GetIntParam(int shaderId);
//        float GetFloatParam(int shaderId);
//        bool GetBoolParam(int shaderId);
//
//        void SetTexture(int shaderId, Texture2D texture);
//
//        Texture2D GetTexture(int shaderId);
    }
}