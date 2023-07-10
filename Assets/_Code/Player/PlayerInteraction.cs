using _Code.Configs;
using _Code.Counters.Logic;
using _Code.Extensions;
using _Code.Infrastructure.Services.Input;
using _Code.KitchenObjects;
using UnityEngine;
using Zenject;

namespace _Code.Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private Transform _kitchenObjectParent;
        [SerializeField] private LayerMask _interactableLayer;
        [SerializeField] private PlayerConfig _config;

        private const float InteractionYOffset = 0.75f;

        private float _interactionDistance;
        private IInputService _input;
        private BaseCounter _selectedCounter;
        private KitchenObject _kitchenObject;

        [Inject]
        public void Construct(IInputService input) => 
            _input = input;

        private void Awake() => 
            _interactionDistance = _config.InteractionDistance;

        private void Update()
        {
            if (TryRaycastCounter(out BaseCounter counter))
            {
                if (_selectedCounter != counter)
                    SelectNewCounter(counter);
            }
            else if (_selectedCounter != null)
            {
                UnselectCounter();
            }

            if (_input.IsInteractionButtonUp() && _selectedCounter != null)
                Interact();
        }

        private void SelectNewCounter(BaseCounter counter)
        {
            if (_selectedCounter != null)
            {
                UnselectCounter();
                SelectCounter(counter);
            }
            else
                SelectCounter(counter);
        }

        private void SelectCounter(BaseCounter counter)
        {
            _selectedCounter = counter;
            _selectedCounter.Select();
        }

        private void UnselectCounter()
        {
            _selectedCounter.Unselect();
            _selectedCounter = null;
        }

        private void Interact()
        {
            KitchenObject kitchenObject = _selectedCounter.Interact(_kitchenObject);

            if (kitchenObject != null)
                TakeObject(kitchenObject);
        }

        private void TakeObject(KitchenObject kitchenObject)
        {
            _kitchenObject = kitchenObject;
            _kitchenObject.SetParent(_kitchenObjectParent);
            _kitchenObject.HasBeenTaken += KitchenObjectTaken;
            _kitchenObject.ObjectDeleted += KitchenObjectDelete;
        }

        private void KitchenObjectTaken()
        {
            _kitchenObject.HasBeenTaken -= KitchenObjectTaken;
            _kitchenObject.ObjectDeleted -= KitchenObjectDelete;
            _kitchenObject = null;
        }

        private void KitchenObjectDelete()
        {
            if (_kitchenObject != null)
            {
                Destroy(_kitchenObject.gameObject);
                _kitchenObject = null;
            }
        }

        private bool TryRaycastCounter(out BaseCounter counter)
        {
            Vector3 start = transform.position.AddY(InteractionYOffset);
            Physics.Raycast(start, transform.forward, out RaycastHit hit, _interactionDistance, _interactableLayer);
            counter = null;

            if (hit.transform && hit.transform.TryGetComponent(out counter))
                return true;

            return false;
        }
    }
}