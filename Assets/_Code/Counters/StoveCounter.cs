using UnityEngine;
using System.Collections;
using Zenject;

public class StoveCounter : ContainmentCounter
{
    [Header("Dependencies")]
    [SerializeField] private GameObject _stoveOnVisual;
    [SerializeField] private ProgressBar _progressBar;
    [SerializeField] private CookingSoundCounter _sounds;

    [Header("Settings")]
    [SerializeField, Range(2.5f, 6f)] private float _timeToCook;
    [SerializeField, Range(4f, 8f)] private float _timeToBurn;

    private KitchenObjectsFactory _factory;
    private CookingState _state;
    private float _cookingProgress;

    private enum CookingState { WaitingForMeat = 0, Cooking, Burning, MeatBurned }

    [Inject]
    private void Construct(KitchenObjectsFactory factory) => 
        _factory = factory;

    public override KitchenObject Interact(KitchenObject playersObject)
    {
        if (PossibleToTakePlayersObject(playersObject))
        {
            TakeKitchenObject(playersObject);
            StartCooking();
        }
        else if (MeatCookedAndPlayerEmpty(playersObject))
        {
            StopCooking();
            return ReturnKitchenObject();
        }
        else if (playersObject is Plate plate && plate.CanKitchenObjectBeTaken(kitchenObject))
        {
            StopCooking();
            plate.TakeKitchenObject(ReturnKitchenObject());
        }

        return null;
    }

    private void StartCooking()
    {
        _stoveOnVisual.SetActive(true);
        _sounds.StartInteractionSound();
        StartCoroutine(CookingCoroutine());
    }

    private void StopCooking()
    {
        _stoveOnVisual.SetActive(false);
        _sounds.StopInteractionSound();
        StopAllCoroutines();
        _cookingProgress = 0f;
        _progressBar.SetValue(0f);
        _state = CookingState.WaitingForMeat;
    }

    private IEnumerator CookingCoroutine()
    {
        while (_state != CookingState.MeatBurned)
        {
            switch (_state)
            {
                case CookingState.WaitingForMeat:
                    _state = CookingState.Cooking;
                    _progressBar.SetGoal(_timeToCook);
                    yield return StartCoroutine(Cook(_timeToCook));
                    break;

                case CookingState.Cooking:
                    DestoryKitchenObject();
                    TakeKitchenObject(CreateMeatOfType(KitchenObjectType.MeatCooked));
                    _state = CookingState.Burning;
                    _progressBar.SetGoal(_timeToBurn);
                    yield return StartCoroutine(Cook(_timeToBurn));
                    break;

                case CookingState.Burning:
                    DestoryKitchenObject();
                    TakeKitchenObject(CreateMeatOfType(KitchenObjectType.MeatBurned));
                    _state = CookingState.MeatBurned;
                    break;
            }
        }
    }

    private IEnumerator Cook(float timeToWait)
    {
        while (_cookingProgress < timeToWait)
        {
            yield return new WaitForEndOfFrame();
            _cookingProgress += Time.deltaTime;
            _progressBar.SetValue(_cookingProgress);
        }

        _progressBar.SetValue(0f);
        _cookingProgress = 0f;
    }

    private bool PossibleToTakePlayersObject(KitchenObject playersObject) =>
        kitchenObject == null && playersObject != null && 
        playersObject.Type == KitchenObjectType.MeatUncooked && playersObject.IsCooked == false;

    private bool MeatCookedAndPlayerEmpty(KitchenObject playersObject) =>
        kitchenObject != null && _state != CookingState.Cooking && playersObject == null;

    private KitchenObject CreateMeatOfType(KitchenObjectType type) =>
        _factory.CreateKitchenObject(type);

    private void DestoryKitchenObject() => 
        Destroy(kitchenObject.gameObject);
}