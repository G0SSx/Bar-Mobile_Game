using UnityEngine;
using Zenject;

public class CutterCounter : ContainmentCounter
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CuttableKitchenObjectsConfig _cuttableObjectsConfig;
    [SerializeField] private ProgressBar _progressBar;

    private const string _cutTriggerString = "Cut";
    private const int _maxPercentage = 100;
    private const int _defaultCutPercent = 34;

    private KitchenObjectsFactory _factory;
    private CuttingState _state = CuttingState.WaitingKitchenObject;
    private int _cuttingProgressPercentage;

    private enum CuttingState { WaitingKitchenObject, Cutting, ObjectSliced }

    [Inject]
    private void Construct(KitchenObjectsFactory factory) => 
        _factory = factory;

    public override KitchenObject Interact(KitchenObject playersObject)
    {
        switch (_state)
        {
            case CuttingState.WaitingKitchenObject:
                if (playersObject != null && playersObject.IsCuttable)
                {
                    TakeKitchenObject(playersObject);
                    _state = CuttingState.Cutting;
                    _progressBar.SetGoal(_maxPercentage);
                }
                break;

            case CuttingState.Cutting:
                if (playersObject == null)
                    Cut();
                break;

            case CuttingState.ObjectSliced:
                if (playersObject == null)
                {
                    _state = CuttingState.WaitingKitchenObject;
                    return ReturnKitchenObject();
                }
                else if (playersObject is Plate plate && plate.CanKitchenObjectBeTaken(kitchenObject))
                {
                    _state = CuttingState.WaitingKitchenObject;
                    plate.TakeKitchenObject(ReturnKitchenObject());
                }
                break;
        }

        return null;
    }

    private void Cut()
    {
        PlayInteractionSound();

        _animator.SetTrigger(_cutTriggerString);
        _cuttingProgressPercentage += GetCattingPercent();
        _progressBar.SetValue(_cuttingProgressPercentage);

        if (_cuttingProgressPercentage >= _maxPercentage)
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
        return _defaultCutPercent;
    }

    private void CreateSlicedObject()
    {
        KitchenObjectType type = kitchenObject.Type;
        Destroy(kitchenObject.gameObject);
        TakeKitchenObject(_factory.CreateSliceOfKitchenObject(type));
    }
}