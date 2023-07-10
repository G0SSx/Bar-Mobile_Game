using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace _Code.Minigames.ContainerMinigame
{
    public class ContainerMinigame : MonoBehaviour
    {
        private const float FillPercentage = 0.05f;
        
        [SerializeField] private TextMeshProUGUI _fullnessText;
        [SerializeField] private HoldButton _button;
        [SerializeField] private Image _firstDrinkVisual;

        private float _cocktailFullnessPercentage;

        private void Update()
        {
            if (_button.IsHolding)
            {
                FillGlass();
                UpdateFullnessText();
            }
        }

        private void FillGlass()
        {
            float nextFrameCapacity = _cocktailFullnessPercentage + FillPercentage;
            
            if (nextFrameCapacity > 100)
                _cocktailFullnessPercentage = 100;
            else
                _cocktailFullnessPercentage += FillPercentage;

            _firstDrinkVisual.fillAmount = _cocktailFullnessPercentage / 100;
        }

        private void UpdateFullnessText()
        {
            if (_cocktailFullnessPercentage >= 100)
                _fullnessText.gameObject.SetActive(true);
        }
    }
}