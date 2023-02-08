using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Art_VR 
{      
public class Ball : MonoBehaviour
{
        [SerializeField]
        GameObject referenceToPrefab;

        Vector3 initialPos;
        Quaternion initalRot;

    // Start is called before the first frame update
    void Start()
    {
            Instantiate(referenceToPrefab, initialPos, initalRot);
            initialPos = transform.position;
            initalRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject == true)
            {
                Instantiate(referenceToPrefab, initialPos, initalRot);
                Destroy(gameObject, 3);
            }
        }
    }
}


