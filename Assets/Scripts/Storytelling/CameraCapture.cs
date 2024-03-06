using UnityEngine;
using Cinemachine;
using System.Collections;

namespace Storytelling
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class CameraCapture : MonoBehaviour
    {
        static CameraCapture _activeCameraCapture;

        [SerializeField] float captureDelay;
        [SerializeField] bool timeDeactivation;
        [Space]
        [SerializeField] CinemachineVirtualCamera virtualCamera;

        void Awake()
        {
            virtualCamera = GetComponent<CinemachineVirtualCamera>();
        }

        public static void ResetActive()
        {
            _activeCameraCapture = null;
        }

        public void Capture()
        {
            Deactivate();
            Activate();
        }

        public void Deactivate()
        {
            StopAllCoroutines();
            virtualCamera.enabled = false;

            if (CameraBordersAnimation.isActive)
                CameraBordersAnimation.ToggleState();
        }

        private void Activate()
        {
            _activeCameraCapture?.Deactivate();

            _activeCameraCapture = this;
            virtualCamera.enabled = true;

            if (!CameraBordersAnimation.isActive)
                CameraBordersAnimation.ToggleState();

            if (timeDeactivation) {
                StartCoroutine(CaptureDelay());
                return;
            }
        }

        private IEnumerator CaptureDelay()
        {
            yield return new WaitForSeconds(captureDelay);

            Deactivate();
        }
    }
}