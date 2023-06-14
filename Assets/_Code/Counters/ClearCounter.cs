using _Code.Counters.Logic;
using _Code.KitchenObjects;
using _Code.KitchenObjects.PlateLogic;

namespace _Code.Counters
{
    public class ClearCounter : ContainmentCounter
    {
        public override KitchenObject Interact(KitchenObject playersObject)
        {
            if (kitchenObject == null && playersObject == null)
                return null;

            if (kitchenObject == null)
            {
                TakeKitchenObject(playersObject);
            }
            else if (playersObject == null)
            {
                return ReturnKitchenObject();
            }
            else if (playersObject.IsCooked && kitchenObject is Plate plate && plate.CanTakeKitchenObject(playersObject))
            {
                plate.TakeKitchenObject(playersObject);
            }
            else if (playersObject is Plate playersPlate && playersPlate.CanTakeKitchenObject(kitchenObject))
            {
                playersPlate.TakeKitchenObject(ReturnKitchenObject());
            }

            return null;
        }
    }
}