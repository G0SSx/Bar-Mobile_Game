using UnityEngine;
using UnityEngine.EventSystems;

namespace _Code.Minigames.ContainerMinigame
{
    public class HoldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public bool IsHolding { get; private set; }

        public void OnPointerDown(PointerEventData eventData) => 
            IsHolding = true;

        public void OnPointerUp(PointerEventData eventData) => 
            IsHolding = false;
    }
}