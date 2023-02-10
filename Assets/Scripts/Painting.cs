using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Art_VR
{
    public class Painting : MonoBehaviour
    {
        private Rigidbody rigidBody;

        // Start is called before the first frame update
        void Start()
        {
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
    }

}
