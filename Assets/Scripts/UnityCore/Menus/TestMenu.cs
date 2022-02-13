using UnityEngine;

namespace UnityCore
{
    namespace Menu
    {
        public class TestMenu : MonoBehaviour
        {
            public PageController pageController;

#if UNITY_EDITOR

            private void Update()
            {
                if (Input.GetKeyUp(KeyCode.F))
                {
                    pageController.TurnPageOn(PageType.Loading);
                }
                if (Input.GetKeyUp(KeyCode.G))
                {
                    pageController.TurnPageOff(PageType.Loading);
                }
            }

#endif
        }
    }
}