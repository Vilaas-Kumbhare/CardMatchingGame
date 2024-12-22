using System;
using CardMatching.Scripts.Data;
using UnityEngine;

namespace CardMatching.Scripts.Audio
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioContainer _audioContainer;
        
        
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
            {
                Destroy(gameObject);
            }
        }

        public void PlayAudio(String clipName)
        {
            if (_audioContainer == null || _audioSource == null)
            {
                Debug.LogWarning("AudioManager is not properly configured.");
                return;
            }

            AudioClip clip = _audioContainer.GetAudioClip(clipName);

            if (clip == null)
            {
                Debug.LogWarning($"Audio clip with name {clipName} not found.");
                return;
            }

            _audioSource.clip = clip;
            _audioSource.Play();
        }
    }
}
