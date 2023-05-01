using Zenject;
using UnityEngine;

public class ConteinerCounter : BaseCounter
{
    [SerializeField] private KitchenObjectType _objectType;
    [SerializeField] private Transform _objectParent;
    [SerializeField] private Animator _animator;

    private const string OpeningAnimationTriggerName = "OpenClose";

    private KitchenObjectsFactory _factory;

    [Inject]
    private void Construct(KitchenObjectsFactory factory) => 
        _factory = factory;

    public override KitchenObject Interact(KitchenObject objectInPlayersHands)
    {
        if (objectInPlayersHands != null)
            return null;

        _animator.SetTrigger(OpeningAnimationTriggerName);
        return _factory.CreateKitchenObject(_objectType, _objectParent); ;
    }
}