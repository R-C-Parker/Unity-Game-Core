using UnityEngine;

namespace UnityCore.Menu
{
    public class TestMenu : MonoBehaviour
    {
        public PageController pageController;

#if UNITY_EDITOR

        private void Update()
        {
            /** Test case to check turning on the loading page */
            if (Input.GetKeyUp(KeyCode.F))
            {
                pageController.TurnPageOn(PageType.Loading);
            }
            /** Test case to check turning off the loading page */
            if (Input.GetKeyUp(KeyCode.G))
            {
                pageController.TurnPageOff(PageType.Loading);
            }
            /** Test case to check turning off the loading page and concurrently turning on the menu page */
            if (Input.GetKeyUp(KeyCode.H))
            {
                pageController.TurnPageOff(PageType.Loading, PageType.Menu);
            }
            /** Test case to check turning off the loading page and concurrently turning on the menu page with added boolean parameter for animated transitions */
            if (Input.GetKeyUp(KeyCode.J))
            {
                pageController.TurnPageOff(PageType.Loading, PageType.Menu, true);
            }
        }

#endif
    }
}