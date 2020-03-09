using UnityEngine;

namespace Vrlife.Core.Mvc.Implementations
{
    public class SimpleControllerProxy :
        MonoViewControllerProxy<SimpleViewModel, ISimpleView, ISimpleController>, ISimpleController
    {
        [SerializeField] private SimpleView view;

        protected override ISimpleView View => view;

        public void SetVisible(bool value)
        {
            Controller.SetVisible(value);
        }

        public void Toggle()
        {
            Controller.Toggle();
        }
    }
}