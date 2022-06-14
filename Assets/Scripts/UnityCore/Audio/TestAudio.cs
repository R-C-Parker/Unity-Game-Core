using UnityEngine;

namespace UnityCore.Audio
{
    public class TestAudio : MonoBehaviour
    {
        public AudioController audioController;

        #region Unity Functions

#if UNITY_EDITOR


        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Y))
            {
                audioController.PlayAudio(AudioType.ST_01);
            }
            if (Input.GetKeyUp(KeyCode.U))
            {
                audioController.StopAudio(AudioType.ST_01);
            }
            if (Input.GetKeyUp(KeyCode.I))
            {
                audioController.RestartAudio(AudioType.ST_01);
            }
            if (Input.GetKeyUp(KeyCode.O))
            {
                audioController.PlayAudio(AudioType.SFX_01);
            }
            if (Input.GetKeyUp(KeyCode.P))
            {
                audioController.StopAudio(AudioType.SFX_01);
            }
            if (Input.GetKeyUp(KeyCode.L))
            {
                audioController.RestartAudio(AudioType.SFX_01);
            }
        }

#endif

        #endregion Unity Functions
    }
}