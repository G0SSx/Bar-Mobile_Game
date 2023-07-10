using UnityEngine;

namespace _Code.Logic
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform _secondaryCameraTransform;
        [SerializeField] private Transform _mainCameraTransform;

        public void ActivateSecondaryCamera(Transform parent)
        {
            _secondaryCameraTransform.SetParent(parent);
            ResetSecondaryCameraTransform();

            SecondaryCameraSetActive(true);
            MainCameraSetActive(false);
        }

        public void TurnOnMainCamera()
        {
            MainCameraSetActive(true);
            DisableSecondaryCamera();
        }

        private void ResetSecondaryCameraTransform()
        {
            _secondaryCameraTransform.localPosition = Vector3.zero;
            _secondaryCameraTransform.localRotation = Quaternion.Euler(Vector3.zero);
        }

        private void MainCameraSetActive(bool isVisible) => 
            _mainCameraTransform.gameObject.SetActive(isVisible);

        private void DisableSecondaryCamera()
        {
            _secondaryCameraTransform.SetParent(null);
            SecondaryCameraSetActive(false);
        }

        private void SecondaryCameraSetActive(bool isVisible) => 
            _secondaryCameraTransform.gameObject.SetActive(isVisible);
    }
}