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
        {   //Using a key to get the audio pool and play sound in it 
            if (this.audioSourcesDic.ContainsKey(type) == false)
                this.audioSourcesDic.Add(type,new());   //if the pool doesnt exist => create a new one
            
            //Check each audiosource in the pool's audiosource
            foreach (AudioSource item in this.audioSourcesDic[type].audioSources)
            {
                if (item.isPlaying == false) //Set value to free audio source then return it 
                {   
                    item.clip = audioClip;
                    item.volume = volume * this.audioSourcesDic[type].volume;
                    item.loop = isLoop;
                    item.Play();
                    return item;
                }
            }

            //if no available pool's audiosource => creating new one
            AudioSource newAudioSource = Instantiate(this.audioSourceSample, this.transform);
            this.audioSourcesDic[type].audioSources.Add(newAudioSource);
            newAudioSource.clip = audioClip;
            newAudioSource.volume = volume * this.audioSourcesDic[type].volume;
            newAudioSource.loop = isLoop;
            newAudioSource.Play();

            return newAudioSource;
        }

        public void SetVolume(eSoundType type, float value = 1f)
        {
            //Do sthing;
            this.audioSourcesDic[type].volume = value;
        }
    }
}