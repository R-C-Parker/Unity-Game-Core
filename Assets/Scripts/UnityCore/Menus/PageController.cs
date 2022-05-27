using System.Collections;
using UnityEngine;

namespace UnityCore.Menu
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
            /**Check to see if singleton is iniitalised, if not procceeds with initialisation of the instance and other requisite items */
            if (!instance)
            {
                instance = this;
                m_Pages = new Hashtable();
                RegisterAllPages();
                if (entryPage != PageType.None)
                {
                    TurnPageOn(entryPage);
                }
            }
        }

        #endregion Unity Functions

        #region Public Functions

        public void TurnPageOn(PageType _type)
        {
            if (_type == PageType.None) return;
            /**If the page the function is attempting to turn on has not been registered, send a warning */
            if (!PageExists(_type))
            {
                LogWarning("You are attempting to turn a page on [" + _type + "] that has not been registered.");
                return;
            }
            /**No further _page validation is necessary as it is known from the above that the value is both registered and not null. */
            Page _page = GetPage(_type);
            _page.gameObject.SetActive(true);
            /**If the page has elected to animate, this will use the animator to facilitate that animation, iif the page has no animation there will be no operation */
            _page.Animate(true);
        }

        /**The on parameter allows for an optional second page type to be passed into the function to enable a second parameter.
           The wait for exit parameter is another optional parameter that is pased into the function to enable the function to animate the page transitions.*/

        public void TurnPageOff(PageType _off, PageType _on = PageType.None, bool _waitForExit = false)
        {
            if (_off == PageType.None) return;
            /**If the page the function is attempting to turn off has not been registered, send a warning */
            if (!PageExists(_off))
            {
                LogWarning("You are attempting to turn a page off [" + _off + "] that has not been registered.");
                return;
            }

            Page _offPage = GetPage(_off);
            if (_offPage.gameObject.activeSelf)
            {
                _offPage.Animate(false);
            }
            if (_on != PageType.None)
            {
                Page _onPage = GetPage(_on);
                if (_waitForExit)
                {
                    StopCoroutine("WaitForPageExit");
                    StartCoroutine(WaitForPageExit(_onPage, _offPage));
                }
                else
                {
                    TurnPageOn(_on);
                }
            }
        }

        #endregion Public Functions

        #region Private Functions

        private IEnumerator WaitForPageExit(Page _on, Page _off)
        {
            while (_off.targetState != Page.FLAG_NONE)
            {
                yield return null;
            }
            TurnPageOn(_on.type);
        }

        private void RegisterAllPages()
        {
            foreach (Page _page in pages)
            {
                RegisterPage(_page);
            }
        }

        private void RegisterPage(Page _page)
        {
            if (PageExists(_page.type))
            {
                LogWarning("You are attempting to register a page [" + _page.type + "] that has already been registered: " + _page.gameObject.name);
                return;
            }
            m_Pages.Add(_page.type, _page);
            Log("Registered new page [" + _page.type + "]");
        }

        private Page GetPage(PageType _type)
        {
            if (!PageExists(_type))
            {
                LogWarning("You are attempting to get a page [" + _type + "] that has not been registered. ");
                return null;
            }
            return (Page)m_Pages[_type];
        }

        private bool PageExists(PageType _type)
        {
            return m_Pages.ContainsKey(_type);
        }

        private void Log(string _msg)
        {
            if (!debug) return;
            Debug.Log("[PageController]: " + _msg);
        }

        private void LogWarning(string _msg)
        {
            if (!debug) return;
            Debug.LogWarning("[PageController]: " + _msg);
        }

        #endregion Private Functions
    }
}