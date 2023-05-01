using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Transform _kitchenObjectParent;
    [SerializeField] private float _interactDistance = 1.5f;
    [SerializeField] private float _interactionYOffset = 0.75f;
    [SerializeField] private LayerMask _interactableLayer;

    private InputActions _input;
    private BaseCounter _selectedCounter;
    private KitchenObject _kitchenObject;

    [Inject]
    private void Construct(InputActions input)
    {
        _input = input;
        _input.Player.Interact.performed += Interact;
    }

    private void OnDisable() => 
        _input.Player.Interact.performed -= Interact;

    private void OnEnable() => 
        _input.Player.Interact.performed += Interact;

    private void Update()
    {
        if (TryReycastCounter(out BaseCounter counter))
        {
            if (_selectedCounter == counter)
                return;

            SelectNewCounter(counter);
        }
        else if (_selectedCounter != null)
        {
            UnselectCounter();
        }
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

    private void Interact(InputAction.CallbackContext context)
    {
        if (_selectedCounter == null)
            return;
        
        KitchenObject kitchenObject = _selectedCounter.Interact(_kitchenObject);

        if (kitchenObject != null)
            TakeObject(kitchenObject);
    }

    private void TakeObject(KitchenObject kitchenObject)
    {
        _kitchenObject = kitchenObject;
        _kitchenObject.SetParent(_kitchenObjectParent);
        _kitchenObject.HasBeenTaken += KitchenObjectTaken;
    }

    private void KitchenObjectTaken() =>
        _kitchenObject = null;

    private bool TryReycastCounter(out BaseCounter counter)
    {
        Vector3 start = transform.position.AddY(_interactionYOffset);
        Physics.Raycast(start, transform.forward, out RaycastHit hit, _interactDistance, _interactableLayer);
        counter = null;

        if (hit.transform && hit.transform.TryGetComponent(out counter))
            return true;

        return false;
    }
}