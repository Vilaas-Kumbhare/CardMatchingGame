using System;
using UnityEngine;

namespace CardMatching.Scripts.Data
{
    [CreateAssetMenu(fileName = "AudioContainer", menuName = "MatchingCard/CreateAudioContainer")]
    public class AudioContainer : ScriptableObject
    {
        public AudioProp[] Audios;

        public AudioClip GetAudioClip(String name)
        {
            AudioClip clip = null;

            foreach (var audio in Audios)
            {
                if (audio.name.Equals(name))
                    clip = audio.audioClip;
            }

            return clip;
        }
    }

    [Serializable]
    public class AudioProp
    {
        public string name;
        public AudioClip audioClip;
    }
}
