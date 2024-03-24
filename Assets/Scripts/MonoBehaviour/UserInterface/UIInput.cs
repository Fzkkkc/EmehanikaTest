using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UserInterface
{
    public class UIInput : MonoBehaviour, IPointerDownHandler
    {
        public event Action OnInputDown;
        
        public void OnPointerDown(PointerEventData eventData)
        { 
            OnInputDown?.Invoke();
        }
    }
}