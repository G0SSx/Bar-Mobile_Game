using _Code.Configs;
using _Code.Counters.Logic;
using _Code.Counters.SoundLogic;
using _Code.KitchenObjects;
using _Code.KitchenObjects.Factory;
using _Code.KitchenObjects.PlateLogic;
using _Code.Logic;
using UnityEngine;
using Zenject;

namespace _Code.Counters
{
    public class CutterCounter : ContainmentCounter
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private KitchenObjectsCutPercentage _cuttableObjectsConfig;
        [SerializeField] private ProgressBar _progressBar;
        [SerializeField] private CookingSoundCounter _sounds;

        private const string CutTriggerName = "Cut";
        private const int MaxPercentage = 100;
        private const int DefaultCutPercent = 34;

        private IKitchenObjectsFactory _factory;
        private CuttingState _state = CuttingState.WaitingKitchenObject;
        private int _cuttingProgressPercentage;

        private enum CuttingState { WaitingKitchenObject, Cutting, ObjectSliced }

        [Inject]
        private void Construct(IKitchenObjectsFactory factory) => 
            _factory = factory;

        public override KitchenObject Interact(KitchenObject playersObject)
        {
            switch (_state)
            {
                case CuttingState.WaitingKitchenObject:
                    if (AbleToTake(playersObject))
                        TakeKitchenObject(playersObject);
                    break;
                case CuttingState.Cutting:
                    if (playersObject == null)
                        CutWithSound();
                    break;
                case CuttingState.ObjectSliced:
                    if (playersObject == null)
                    {
                        return ReturnKitchenObject();
                    }
                    else if (playersObject is Plate plate && plate.CanTakeKitchenObject(kitchenObject))
                    {
                        plate.TakeKitchenObject(ReturnKitchenObject());
                    }
                    break;
            }

            return null;
        }

        protected override KitchenObject ReturnKitchenObject()
        {
            _state = CuttingState.WaitingKitchenObject;
            return base.ReturnKitchenObject();
        }

        protected override void TakeKitchenObject(KitchenObject kitchenObject)
        {
            _state = CuttingState.Cutting;
            _progressBar.SetGoal(MaxPercentage);
            base.TakeKitchenObject(kitchenObject);
        }

        private bool AbleToTake(KitchenObject kitchenObject) =>
            kitchenObject != null && kitchenObject.IsCuttable;

        private void CutWithSound()
        {
            _sounds.PlayInteractionSound();
            _animator.SetTrigger(CutTriggerName);
            _cuttingProgressPercentage += GetCattingPercent();
            _progressBar.SetValue(_cuttingProgressPercentage);

            if (_cuttingProgressPercentage >= MaxPercentage)
            {
                _cuttingProgressPercentage = 0;
                _progressBar.SetValue(0);
                CreateSlicedObject();
                _state = CuttingState.ObjectSliced;
            }
        }

        private int GetCattingPercent()
        {
            if (kitchenObject.Type == KitchenObjectType.Tomato)
                return _cuttableObjectsConfig.TomatoCutPercent;
            else if (kitchenObject.Type == KitchenObjectType.Cheese)
                return _cuttableObjectsConfig.CheeseCutPercent;
            else if (kitchenObject.Type == KitchenObjectType.Cabbage)
                return _cuttableObjectsConfig.CabbageCutPercent;

            Debug.LogWarning("Cutting percentage wasn't found for the object you tried to cut!");
            return DefaultCutPercent;
        }

        private void CreateSlicedObject()
        {
            KitchenObjectType type = kitchenObject.Type;
            Destroy(kitchenObject.gameObject);
            TakeKitchenObject(_factory.CreateSlicedKitchenObject(type));
        }
    }
}