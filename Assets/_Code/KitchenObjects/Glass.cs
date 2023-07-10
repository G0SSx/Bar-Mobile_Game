using _Code.Minigames.MixerMinigame;
using UnityEngine;

namespace _Code.KitchenObjects
{
    public class Glass : MonoBehaviour
    {
        public Drink FirstDrink;
        public Drink SecondDrink;
        public FoamLevel FoamLevel;

        public bool IsFull => FirstDrink.FillPercentage + SecondDrink.FillPercentage >= 100;
        
        public void SetParent(Transform parent)
        {
            transform.SetParent(parent);
            transform.rotation = parent.transform.rotation;
            transform.localPosition = Vector3.zero;
        }
    }
}