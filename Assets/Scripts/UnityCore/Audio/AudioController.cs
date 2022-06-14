using System.Collections;
using UnityEngine;

namespace UnityCore.Audio
{
    public class AudioController : MonoBehaviour
    {
        /*Members*/
        public static AudioController instance; /**Single instance for controller for simpler projects, can be removed to allow for more complex projects*/

        public bool debug;
        public AudioTrack[] tracks;

        private Hashtable m_AudioTable; /**Relationship between audio types [key] and audio tracks [value]*/
        private Hashtable m_JobTable; /**Relationship between audio types [key] and jobs [value] (Coroutine, Ienumerator)*/

        [System.Serializable]
        public class AudioObject
        {
            public AudioType type;
            public AudioClip clip;
        }

        [System.Serializable]
        public class AudioTrack
        {
            public AudioSource source;
            public AudioObject[] audio;
        }



        #region Unity Functions

        private void Awake()
        {
            /**Singleton instance can be removed if project requires multiple audio controllers*/
            if (!instance)
            {
                Configure();
            }
        }

        private void OnDisable()
        {
            Dispose();
        }

        #endregion Unity Functions

        #region Public Functions

        public void PlayAudio(AudioType _type, bool _fade = false, float _delay = 0.0F)
        {
        }

        #endregion Public Functions

        #region Private Functions

        private void Configure()
        {
            instance = this;
            m_AudioTable = new Hashtable();
            m_JobTable = new Hashtable();
            GenerateAudioTable();
        }

        private void Dispose()
        {
        }

        private void GenerateAudioTable()
        {
        }

        private void Log(string _msg)
        {
            if (!debug) return;
            Debug.Log("[AudioController]: " + _msg);
        }

        private void LogWarning(string _msg)
        {
            if (!debug) return;
            Debug.LogWarning("[AudioController]: " + _msg);
        }

        #endregion Private Functions
    }
}