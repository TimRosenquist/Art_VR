using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodMaterial : MonoBehaviour
{
    public Color bloodColor = Color.red;
    public Texture2D bloodTexture;

    private Material bloodMaterial;

    void Start()
    {
        bloodMaterial = new Material(Shader.Find("Standard"));
        bloodMaterial.color = Color.clear; // Start with clear color
        bloodMaterial.SetTexture("_MainTex", bloodTexture);
        GetComponent<Renderer>().material = bloodMaterial;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Room")
        {
            bloodMaterial.color = bloodColor; // Activate blood color on collision with BloodSource object
        }
    }
}
