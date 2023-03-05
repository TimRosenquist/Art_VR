using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using Unity.Collections;

public class TexturePainter : MonoBehaviour
{
    public GameObject targetObject;
    public float brushSize = 0.1f;
    public Color brushColor = Color.white;
    public bool paintOnCollision = true;

    private Renderer targetRenderer;
    private Texture2D targetTexture;
    private NativeArray<Color32> targetTextureData;

    private void Start()
    {
        targetRenderer = targetObject.GetComponent<Renderer>();
        targetTexture = (Texture2D)targetRenderer.material.mainTexture;
        targetTextureData = targetTexture.GetRawTextureData<Color32>();
    }


    private void PaintOnTargetTexture(Vector3 worldPosition)
    {
        // Convert world position to texture space
        Vector2 pixelUV = targetTexture.InverseTransformPoint(worldPosition);
        pixelUV.x *= targetTexture.width;
        pixelUV.y *= targetTexture.height;

        // Sample color from source texture
        Color sourceColor = sourceTexture.GetPixelBilinear(brushPosition.x / brushTexture.width,
                                                           brushPosition.y / brushTexture.height);

        // Apply color to target texture at the specified position
        int pixelIndex = Mathf.FloorToInt(pixelUV.y) * targetTexture.width + Mathf.FloorToInt(pixelUV.x);
        if (pixelIndex >= 0 && pixelIndex < targetTexture.width * targetTexture.height)
        {
            Color32[] colors = targetTexture.GetPixels32();
            colors[pixelIndex] = sourceColor;
            targetTexture.SetPixels32(colors);
            targetTexture.Apply();
        }
    }

}

// Create a new texture with RGBA32 format
Texture2D newTargetTexture = new Texture2D(targetTexture.width, targetTexture.height, TextureFormat.RGBA32, false);
        newTargetTexture.SetPixels32(targetTexture.GetPixels32());

        // Paint on the new texture
        Color32[] pixelData = new Color32[targetTextureData.Length];
        for (int i = 0; i < targetTextureData.Length; i++)
        {
            pixelData[i] = targetTextureData[i];
        }
        newTargetTexture.SetPixels32(pixelData);
        newTargetTexture.Apply();

        // Replace the old texture with the new one
        targetRenderer.material.mainTexture = newTargetTexture;
        targetTexture = newTargetTexture;



    }



    private void OnCollisionStay(Collision collision)
    {
        if (paintOnCollision)
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                PaintOnTargetTexture(contact.point);
            }
        }
    }
}
