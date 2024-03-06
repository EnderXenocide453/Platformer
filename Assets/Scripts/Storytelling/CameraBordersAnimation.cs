using UnityEngine;
using UnityEngine.UI;

namespace Storytelling
{
    public class CameraBordersAnimation : MonoBehaviour
    {
        static CameraBordersAnimation _instance;

        [SerializeField] Image[] borders;
        [SerializeField] float animationSpeed;

        private static float _currentFillTarget = 1;

        public static bool isActive { get; private set; }
        private static float _fillStep => _instance.borders[0].fillAmount + _instance.animationSpeed * Time.deltaTime * (isActive ? 1 : -1);

        private void Start()
        {
            if (_instance != null) {
                Destroy(this);
                return;
            }

            _instance = this;
        }

        private void Update()
        {
            Animate();
        }

        public static void ToggleState()
        {
            isActive = !isActive;
            _currentFillTarget = isActive ? 1 : 0;

            _instance.enabled = true;
        }

        private void Animate()
        {
            if (borders.Length == 0)
                return;

            for (int i = borders.Length - 1; i >= 0; i--)
                borders[i].fillAmount = _fillStep;

            if (borders[0].fillAmount == _currentFillTarget) {
                enabled = false;
                return;
            }
        }
    }
}

