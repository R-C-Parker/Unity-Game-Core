using UnityEngine;

namespace UnityCore.Data
{
    public class TestData : MonoBehaviour
    {
        public DataController dataController;

        #region Unity Functions

#if UNITY_EDITOR


        public void Update()
        {
            if (Input.GetKeyUp(KeyCode.R))
            {
                TestAddScore(1);
            }
            if (Input.GetKeyUp(KeyCode.T))
            {
                TestAddScore(-1);
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                TestResetScore();
            }
        }

#endif

        #endregion Unity Functions

        #region Private Functions

        private void TestAddScore(int _delta)
        {
            dataController.Score += _delta;
            Log("Score = " + dataController.Score + " | Highscore = " + dataController.Highscore);
        }

        private void TestResetScore()
        {
            dataController.Score = 0;
            Log("Score = " + dataController.Score + " | Highscore = " + dataController.Highscore);
        }

        private void Log(string _msg)
        {
            Debug.Log("[TestData]: " + _msg);
        }

        #endregion Private Functions
    }
}