using System;
using UnityEngine;
using Vrlife.Core.Mvc.Implementations;

namespace Vrlife.Core.Mvc
{
    public interface IAnimatorComponent : IViewComponent
    {
        event EventHandler<MonoAnimatorStateEventHandler> StateExited; 
        event EventHandler<MonoAnimatorStateEventHandler> StateEntered; 
        void SetLayerWeight(int layerId, float value);
        void SetTrigger(int id);
        void ResetTrigger(int id);
        void SetParameter(int id, float value);
        void SetParameter(int id, bool value);
        void SetParameter(int id, int value);

        bool GetBoolParameter(int id);
        int GetIntParameter(int id);
        float GetFloatParameter(int id);
        void SetSpeed(float value);
        void PlayState(string stateName);

        int GetLayerIndex(string layerName);
        float GetLayerWeight(int layerId);

        string GetLayerName(int layerId);

        void StopParameter(Coroutine coroutine);

        Coroutine SetFloatParameterAnimated(int id,
            AnimationCurve curve,
            float speed = 1,
            float? axisXMaxValue = null);

        Coroutine SetIntParameterAnimated(int id,
            AnimationCurve curve,
            float speed = 1,
            float? axisXMaxValue = null);
    }
}