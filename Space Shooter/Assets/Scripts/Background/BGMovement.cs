using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMovement : MonoBehaviour
{
    public float scrollSpeed = 0.12f;
    private MeshRenderer meshRenderer;
    private string MainTexture = "_MainTex";
    // Start is called before the first frame update
    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        Vector2 offset = meshRenderer.sharedMaterial.GetTextureOffset(MainTexture);
        offset.y -= Time.deltaTime * scrollSpeed;
        meshRenderer.sharedMaterial.SetTextureOffset(MainTexture,offset);
    }
}
