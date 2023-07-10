using _Code.Counters.Logic;
using _Code.Counters.SoundLogic;
using _Code.KitchenObjects;
using _Code.KitchenObjects.Factory;
using _Code.Logic;
using UnityEngine;
using Zenject;

namespace _Code.Counters
{
    public class ContainerCounter : BaseCounter
    {
        public KitchenObjectType KitchenObjectType;

        [SerializeField] private Animator _animator;
        [SerializeField] private InteractAndDenySoundCounter _sounds;
        [SerializeField] private SpriteRenderer _renderer;

        private const string OpeningAnimationTriggerName = "OpenClose";

        private IKitchenObjectsFactory _factory;
        private CameraController _cameraController;

        [Inject]
        private void Construct(IKitchenObjectsFactory factory) => 
            _factory = factory;

        public void SetCameraController(CameraController cameraController) => 
            _cameraController = cameraController;

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
}