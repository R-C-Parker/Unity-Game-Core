using System.Collections;
using UnityEngine;

namespace UnityCore.Menu
{
    public class Page : MonoBehaviour
    {
        public static readonly string FLAG_ON = "On";
        public static readonly string FLAG_OFF = "Off";
        public static readonly string FLAG_NONE = "None";

        public PageType type;
        public bool debug;
        public bool useAnimation;
        public string targetState { get; private set; }

        private Animator m_Animator;

        #region Unity Functions

        private void OnEnable()
        {
            CheckAnimatorIntegrity();
        }

        #endregion Unity Functions

        #region Public Functions

        public void Animate(bool _on)
        {
            if (useAnimation)
            {
                m_Animator.SetBool("on", _on);

                StopCoroutine("AwaitAnimation");
                StartCoroutine("AwaitAnimation", _on);
            }
            else
            {
                if (!_on)
                {
                    gameObject.SetActive(false);
                }
            }
        }

        #endregion Public Functions

        #region Private Functions

        private IEnumerator AwaitAnimation(bool _on)
        {
            targetState = _on ? FLAG_ON : FLAG_OFF;

            /**Wait for the animator to reach the target state */
            while (!m_Animator.GetCurrentAnimatorStateInfo(0).IsName(targetState))
            {
                yield return null;
            }
            /**Wait for the animator to finish animating */
            while (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
            {
                yield return null;
            }

            targetState = FLAG_NONE;

            Log("Page [" + type + "] finished transitioning to " + (_on ? "on" : "off"));

            if (!_on)
            {
                gameObject.SetActive(false);
            }
        }

        private void CheckAnimatorIntegrity()
        {
            if (useAnimation)
            {
                m_Animator = GetComponent<Animator>();
                if (!m_Animator)
                {
                    LogWarning("You chose to animate a page of [" + type + "], but no Animator component exists on the object");
                }
            }
        }

        private void Log(string _msg)
        {
            if (!debug) return;
            Debug.Log("[Page]: " + _msg);
        }

        private void LogWarning(string _msg)
        {
            if (!debug) return;
            Debug.Log("[Page]: " + _msg);
        }

        #endregion Private Functions
    }
}