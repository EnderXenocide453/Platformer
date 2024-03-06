using UnityEngine;

namespace Storytelling
{
    public class GameNotificator : MonoBehaviour
    {
        [SerializeField] GameNotification targetNotification;
        [SerializeField] Notification info;

        public void Notify()
        {
            if (!targetNotification)
                targetNotification = GameNotification.baseNotification;

            targetNotification.Notify(info);
        }
    }
}

