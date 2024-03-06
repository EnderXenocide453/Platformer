using System.Collections;
using UnityEngine;

namespace MoveBehaviours
{
    public abstract class MoveBehaviour : MonoBehaviour
    {
        [SerializeField] bool continueMoveWhenWait = false;

        protected bool isMove = true;
        private Coroutine _waitCoroutine;

        public Vector2 Direction
        {
            get
            {
                if (continueMoveWhenWait || isMove)
                    return GetDirection().normalized;

                return Vector3.zero;
            }
        }

        public void Wait(float delay)
        {
            if (_waitCoroutine != null)
                StopCoroutine(_waitCoroutine);

            _waitCoroutine = StartCoroutine(WaitForDelay(delay));
        }

        protected abstract Vector2 GetDirection();

        protected virtual void OnStartWaiting()
        {
            isMove = false;
        }

        protected virtual void OnEndWaiting()
        {
            isMove = true;
        }

        private IEnumerator WaitForDelay(float delay)
        {
            OnStartWaiting();
            yield return new WaitForSeconds(delay);
            _waitCoroutine = null;
            OnEndWaiting();
        }
    }
}

