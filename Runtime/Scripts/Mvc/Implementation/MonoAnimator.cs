using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using Vrlife.Core.Mvc.Abstractions;

namespace Vrlife.Core.Mvc.Implementations
{
    [RequireComponent(typeof(Animator))]
    public class MonoAnimator : AViewComponent, IAnimatorComponent
    {
        private Animator _animator;

        public event EventHandler<MonoAnimatorStateEventHandler> StateExited;

        public event EventHandler<MonoAnimatorStateEventHandler> StateEntered;

        public override void OnDestroyed()
        {
            StopAllCoroutines();
        }

        public void SetTrigger(int id)
        {
            _animator.SetTrigger(id);
        }

        public void SetSpeed(float value)
        {
            _animator.speed = value;
        }

        public void ResetTrigger(int id)
        {
            _animator.ResetTrigger(id);
        }

        public void StopParameter(Coroutine coroutine)
        {
            if (coroutine == null) return;

            StopCoroutine(coroutine);
        }

        public Coroutine SetFloatParameterAnimated(int id,
            AnimationCurve curve,
            float speed = 1,
            float? axisXMaxValue = null)
        {
            if (!axisXMaxValue.HasValue)
            {
                axisXMaxValue = curve.keys.Max(x => x.time);
            }

            return StartCoroutine(ValueAnimation(id, speed, curve, axisXMaxValue.Value,
                SetParameter));
        }


        public Coroutine SetIntParameterAnimated(int id,
            AnimationCurve curve,
            float speed = 1,
            float? axisXMaxValue = null)
        {
            if (!axisXMaxValue.HasValue)
            {
                axisXMaxValue = curve.keys.Max(x => x.time);
            }

            return StartCoroutine(ValueAnimation(id, speed, curve, axisXMaxValue.Value,
                (index, value) => { SetParameter(index, (int) value); }));
        }

        public Coroutine SetLayerWeightAnimated(int id, AnimationCurve curve, float speed = 1,
            float? axisXMaxValue = null)
        {
            if (!axisXMaxValue.HasValue)
            {
                axisXMaxValue = curve.keys.Max(x => x.time);
            }

            return StartCoroutine(ValueAnimation(id, speed, curve, axisXMaxValue.Value, SetLayerWeight));
        }

        private IEnumerator ValueAnimation(int paramId, float speed, AnimationCurve curve, float axisXMaxValue,
            Action<int, float> logic)
        {
            var progress = 0f;

            while (progress < axisXMaxValue)
            {
                if (progress >= axisXMaxValue)
                {
                    yield break;
                }

                var value = curve.Evaluate(progress);

                logic(paramId, value);

                SetParameter(paramId, value);

                yield return new WaitForEndOfFrame();

                progress += Time.deltaTime * speed;
            }
        }


        public void SetLayerWeight(int layerId, float value)
        {
            _animator.SetLayerWeight(layerId, value);
        }

        public void SetParameter(int id, float value)
        {
            _animator.SetFloat(id, value);
        }

        public void SetParameter(int id, bool value)
        {
            _animator.SetBool(id, value);
        }

        public void SetParameter(int id, int value)
        {
            _animator.SetInteger(id, value);
        }

        public bool GetBoolParameter(int id)
        {
            return _animator.GetBool(id);
        }

        public int GetIntParameter(int id)
        {
            return _animator.GetInteger(id);
        }

        public float GetFloatParameter(int id)
        {
            return _animator.GetFloat(id);
        }

        public void PlayState(string stateName)
        {
            _animator.Play(stateName);
        }

        public int GetLayerIndex(string layerName)
        {
            return _animator.GetLayerIndex(layerName);
        }

        public float GetLayerWeight(int layerId)
        {
            return _animator.GetLayerWeight(layerId);
        }

        public string GetLayerName(int layerId)
        {
            return _animator.GetLayerName(layerId);
        }

        public void InvokeStateExited(AnimatorStateInfo stateInfo, int layerIndex)
        {
            StateExited?.Invoke(this, new MonoAnimatorStateEventHandler
            {
                LayerIndex = layerIndex,
                AnimatorStateInfo = stateInfo
            });
        }

        public void InvokeStateEntered(AnimatorStateInfo stateInfo, int layerIndex)
        {
            StateEntered?.Invoke(this, new MonoAnimatorStateEventHandler
            {
                LayerIndex = layerIndex,
                AnimatorStateInfo = stateInfo
            });
        }
    }
}