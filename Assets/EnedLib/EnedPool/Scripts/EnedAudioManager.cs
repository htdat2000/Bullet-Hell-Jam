using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnedUtil
{
    public class EnedAudioManager : MonoBehaviour
    {
        public enum eSoundType
        {
            Unknown = -1,
            BMG = 0,
            SFX = 1,
        }
        protected Dictionary<eSoundType, AudioPool> audioSourcesDic = new();
        [SerializeField] private AudioSource audioSourceSample;

        public AudioSource PlaySound(AudioClip audioClip, eSoundType type, float volume = 1f, bool isLoop = false)
        {
            if (this.audioSourcesDic.ContainsKey(type) == false)
                this.audioSourcesDic.Add(type,new());

            foreach (AudioSource item in this.audioSourcesDic[type].audioSources)
            {
                if (item.isPlaying == false)
                {
                    item.clip = audioClip;
                    item.volume = volume * this.audioSourcesDic[type].volume;
                    item.loop = isLoop;
                    return item;
                }
            }

            AudioSource newAudioSource = Instantiate(this.audioSourceSample, this.transform);
            this.audioSourcesDic[type].audioSources.Add(newAudioSource);
            newAudioSource.clip = audioClip;
            newAudioSource.volume = volume * this.audioSourcesDic[type].volume;
            newAudioSource.loop = isLoop;

            return newAudioSource;
        }

        public void SetVolume(eSoundType type, float value = 1f)
        {
            //Do sthing;
            this.audioSourcesDic[type].volume = value;
        }
    }
}