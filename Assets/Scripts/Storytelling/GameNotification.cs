using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Storytelling
{
    [RequireComponent(typeof(Text))]
    public class GameNotification : MonoBehaviour
    {
        public static GameNotification baseNotification { get; private set; }

        [SerializeField] bool isBaseNotification;

        Text _notificationTextField;
        Notification _currentNotification;

        private void Awake()
        {
            _notificationTextField = GetComponent<Text>();
            if (isBaseNotification)
                baseNotification = this;
        }

        public void Notify(Notification notification)
        {
            Deactivate();

            _currentNotification = notification;
            Activate();

            StartCoroutine(NotifyDelay());
        }

        private void Deactivate()
        {
            gameObject.SetActive(false);
        }

        private void Activate()
        {
            gameObject.SetActive(true);
            _notificationTextField.text = _currentNotification.notificationText;
        }

        private IEnumerator NotifyDelay()
        {
            yield return new WaitForSeconds(_currentNotification.notificationDelay);

            Deactivate();

            _currentNotification.onNotificationEnds?.Invoke();
        }
    }

    [System.Serializable]
    public struct Notification
    {
        [TextArea] public string notificationText;
        public float notificationDelay;
        [Space]
        public UnityEvent onNotificationEnds;
    }
}

