using Zenject;
using UnityEngine;

public class ConteinerCounter : BaseCounter
{
    [SerializeField] private KitchenObjectType _objectType;
    [SerializeField] private Animator _animator;
    [SerializeField] private InteractAndDenySoundCounter _sounds;

    private const string OpeningAnimationTriggerName = "OpenClose";

    private KitchenObjectsFactory _factory;

    [Inject]
    private void Construct(KitchenObjectsFactory factory) => 
        _factory = factory;

    public override KitchenObject Interact(KitchenObject playersObject)
    {
        if (playersObject != null)
        {
            _sounds.PlayDenySound();
            return null;
        }

        _sounds.PlayInteractSound();
        _animator.SetTrigger(OpeningAnimationTriggerName);
        return _factory.CreateKitchenObject(_objectType);
    }
}