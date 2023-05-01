public class TrashCounter : BaseCounter
{
    public override KitchenObject Interact(KitchenObject playersObject)
    {
        if (playersObject != null)
        {
            playersObject.HasBeenTaken?.Invoke();
            Destroy(playersObject.transform.gameObject);
        }

        return null;
    }
}