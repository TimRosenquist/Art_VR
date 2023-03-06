using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Art_VR 
{
    [RequireComponent(typeof(AudioSource))]
    public class Ball : MonoBehaviour
{
        [SerializeField]
        GameObject referenceToPrefab;

        Vector3 initialPos;
        Quaternion initalRot;
        bool hasHit = false;

        AudioSource audioSource;
        public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
            //Instantiate(referenceToPrefab, initialPos, initalRot);
            initialPos = transform.position;
            initalRot = transform.rotation;
            //Get Audiosource component
            audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Room" && hasHit == false)
            {
                audioSource.PlayOneShot(audioClip);
                Instantiate(referenceToPrefab, initialPos, initalRot);
                Destroy(gameObject, 3);

                hasHit = !hasHit;
            }
        }
    }
}


