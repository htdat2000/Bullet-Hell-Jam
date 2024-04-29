using System.Collections.Generic;
using UnityEngine;

namespace EnedUtil
{
    public class AudioPool
    {
        public float volume = 1f;
        public List<AudioSource> audioSources = new();
    }
}