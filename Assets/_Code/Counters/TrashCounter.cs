public class TrashCounter : BaseCounter
{
    public override KitchenObject Interact(KitchenObject playersObject)
    {
        if (playersObject != null)
        {
            playersObject.DeleteObject?.Invoke();
            PlayInteractionSound();
        }

        return null;
    }
}