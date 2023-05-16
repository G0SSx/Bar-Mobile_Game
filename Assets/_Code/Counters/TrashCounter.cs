using UnityEngine;

public class TrashCounter : BaseCounter
{
    [SerializeField] private GiveSoundCounter _sounds;

    public override KitchenObject Interact(KitchenObject playersObject)
    {
        if (playersObject != null)
        {
            playersObject.DeleteObject?.Invoke();
            _sounds.PlayGiveSound();
        }

        return null;
    }
}