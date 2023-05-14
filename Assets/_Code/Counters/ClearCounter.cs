public class ClearCounter : ContainmentCounter
{
    public override KitchenObject Interact(KitchenObject playersObject)
    {
        if (kitchenObject == null && playersObject == null)
            return null;

        if (kitchenObject == null)
        {
            PlayInteractionSound();
            TakeKitchenObject(playersObject);
        }
        else if (playersObject == null)
        {
            PlayInteractionSound();
            return ReturnKitchenObject();
        }
        else if (playersObject.IsCooked && kitchenObject is Plate plate && plate.CanKitchenObjectBeTaken(playersObject))
        {
            PlayInteractionSound();
            plate.TakeKitchenObject(playersObject);
        }
        else if (playersObject is Plate playersPlate && playersPlate.CanKitchenObjectBeTaken(kitchenObject))
        {
            PlayInteractionSound();
            playersPlate.TakeKitchenObject(ReturnKitchenObject());
        }

        return null;
    }
}