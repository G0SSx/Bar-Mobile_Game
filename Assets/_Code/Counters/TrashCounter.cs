using _Code.Counters.Logic;
using _Code.Counters.SoundLogic;
using _Code.KitchenObjects;
using UnityEngine;

namespace _Code.Counters
{
    public class TrashCounter : BaseCounter
    {
        [SerializeField] private GiveSoundCounter _sounds;

        public override KitchenObject Interact(KitchenObject playersObject)
        {
            if (playersObject != null)
            {
                playersObject.ObjectDeleted?.Invoke();
                _sounds.PlayGiveSound();
            }

            return null;
        }
    }
}