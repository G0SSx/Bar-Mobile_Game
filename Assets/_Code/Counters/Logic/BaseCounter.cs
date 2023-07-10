using _Code.KitchenObjects;

namespace _Code.Counters.Logic
{
    public abstract class BaseCounter : SelectableCounter
    {
        public abstract KitchenObject Interact(KitchenObject playersObject);
    }
}