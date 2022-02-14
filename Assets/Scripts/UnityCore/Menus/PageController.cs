using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityCore
{
    namespace Menu
    {
        public class PageController : MonoBehaviour
        {
            public static PageController instance;
            public bool debug;
            public PageType entryPage;
            public Page[] pages;
            /**The below hashtable is used to represent the relationship between pagetypes and pages to ease the location of pages through the pagetypes */
            private Hashtable m_Pages;

            #region Unity Functions

            private void Awake()
            {
            }

            #endregion Unity Functions

            #region Public Functions

            public void TurnPageOn(PageType _type)
            {
            }

            /**The on parameter allows for an optional second page type to be passed into the function to enable a second parameter.
               The wait for exit parameter is another optional parameter that is pased into the function to enable the function to animate the page transitions.*/

            public void TurnPageOff(PageType _off, PageType _on = PageType.None, bool _waitForExit = false)
            {
            }

            #endregion Public Functions

            #region Private Functions

            private IEnumerator WaitForPageExit(Page _on, Page _off)
            {
                yield return null;
            }

            private void RegisterAllPages()
            {
            }

            private void RegisterPage(Page _page)
            {
            }

            private Page GetPage(PageType _type)
            {
                return null;
            }

            private bool PageExists(PageType _type)
            {
                return false;
            }

            private void Log(string _msg)
            {
            }

            private void LogWarning(string _msg)
            {
            }

            #endregion Private Functions
        }
    }
}