using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Art_VR
{
    [RequireComponent(typeof(AudioSource))]
    public class ChangeSoundtrack : MonoBehaviour
    {
        AudioSource audioSource;
        private bool hasBeenPlayed;
        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            
        }

        public void PlayAnarchyMusic()
        {
            if (hasBeenPlayed == false)
            {
                audioSource.Play();
                hasBeenPlayed = !hasBeenPlayed;
            }
        }
    }
}
