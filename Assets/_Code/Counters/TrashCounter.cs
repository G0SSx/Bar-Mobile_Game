public class TrashCounter : BaseCounter
{
    public override KitchenObject Interact(KitchenObject playersObject)
    {
        if (playersObject != null)
            playersObject.HasBeenDeleted?.Invoke();
        
        return null;
    }
}