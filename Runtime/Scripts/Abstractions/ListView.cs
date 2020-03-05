using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Vrlife.Core.Abstractions
{
    public abstract class ListView<TListItem> : MonoBehaviour where TListItem : Object
    {
        [SerializeField]
        protected TListItem listItem;

        [SerializeField]
        protected Transform container;
        
        private void Awake()
        {
            OnAwake();
        }

        protected virtual void OnAwake()
        {
            
        }
        
        public void BindData<TDataModel>(IEnumerable<TDataModel> models, Action<TDataModel, TListItem> onBind)
        {
            container.ClearChildren();

            foreach (var dataModel in models)
            {
                //Todo: Factory this!
                var itemInstance = Instantiate(listItem, container);
                
                onBind(dataModel, itemInstance);
            }
        }
    }
}