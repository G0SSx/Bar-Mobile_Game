using UnityEngine;
using Zenject;

public class ContainerCounter : BaseCounter
{
    public KitchenObjectType KitchenObjectType;

    [SerializeField] private Animator _animator;
    [SerializeField] private InteractAndDenySoundCounter _sounds;
    [SerializeField] private SpriteRenderer _renderer;

    private const string OpeningAnimationTriggerName = "OpenClose";

    private IKitchenObjectsFactory _factory;

    [Inject]
    private void Construct(IKitchenObjectsFactory factory) => 
        _factory = factory;

    private void Start() => 
        _renderer.sprite = _factory.GetSpriteByType(KitchenObjectType);

    public override KitchenObject Interact(KitchenObject playersObject)
    {
        if (playersObject != null)
        {
            _sounds.PlayDenySound();
            return null;
        }

        _sounds.PlayInteractSound();
        _animator.SetTrigger(OpeningAnimationTriggerName);

        return _factory.CreateKitchenObject(KitchenObjectType);
    }
}