using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class InfoCard : MonoBehaviour
{
    public UnityEvent onCloseCard;
    
    private IInfoCardManager _infoCardManager;

    [Inject]
    public void Construct(InfoCardManager.Factory factory)
    {
        _infoCardManager = factory.Create(this);
    }
    
    private void Start()
    {
        if (onCloseCard == null)
        {
            onCloseCard = new UnityEvent();
        }
    }

    public void CloseCard()
    {
        _infoCardManager.CloseCard();
        InvokeCardClose();
    }


    // Called by buttons
    private  void InvokeCardClose()
    {
        onCloseCard.Invoke();
    }
}