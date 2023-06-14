using System.Linq;
using _Code.KitchenObjects;
using UnityEngine;

namespace _Code.Counters.Logic
{
    public abstract class BaseCounter : MonoBehaviour
    {
        [SerializeField] private GameObject _selectedVisual;

        public abstract KitchenObject Interact(KitchenObject playersObject);

        public void Select() =>
            _selectedVisual.SetActive(true);

        public void Unselect() =>
            _selectedVisual.SetActive(false);
    }
}