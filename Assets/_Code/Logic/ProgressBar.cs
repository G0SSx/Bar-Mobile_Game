using UnityEngine;
using UnityEngine.UI;

namespace _Code.Logic
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Image _fillImage;
        [SerializeField] private GameObject _visuals;

        public float ProgressPercentage { get; private set; }
        private float _goalValue;

        private void Start()
        {
            if (Camera.main.transform.right == transform.right)
                Flip();

            if (_visuals.gameObject.activeSelf)
                _visuals.gameObject.SetActive(false);
        }

        public void SetGoal(float goalValue) => 
            _goalValue = goalValue;

        public void SetValue(float value)
        {
            ProgressPercentage = value;
            FillSprite();
        }

        private void FillSprite()
        {
            float smallestGoalValue = 0.01f;
            if (_goalValue < smallestGoalValue)
                Debug.LogWarning("Goal value wasn't set!");

            if (_fillImage.enabled)
                _fillImage.fillAmount = ProgressPercentage / _goalValue;
        
            if (ProgressPercentage > 0 && ProgressPercentage < _goalValue)
                _visuals.SetActive(true);
            else
                _visuals.SetActive(false);
        }

        private void Flip()
        {
            transform.rotation = Quaternion.Euler(
                transform.rotation.eulerAngles.x, 
                transform.rotation.eulerAngles.y + 180, 
                transform.rotation.eulerAngles.z);
        }
    }
}