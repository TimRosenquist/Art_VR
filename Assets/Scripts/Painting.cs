using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Art_VR
{
    [RequireComponent(typeof(AudioSource))]
    public class Painting : MonoBehaviour
    {
         public AudioClip audioClip;
         AudioSource audioSource;
        private Rigidbody rigidBody;
        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            rigidBody = GetComponent<Rigidbody>();
            rigidBody.isKinematic = true;
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Ball")
            {
                rigidBody.isKinematic = false;
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Trigger")
                audioSource.PlayOneShot(audioClip);
        }
    }

}
