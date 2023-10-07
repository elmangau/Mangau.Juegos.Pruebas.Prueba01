using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private float _scrollX;

    public float ScrollSpeed = 0.1f;

    void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        _scrollX = Time.time * ScrollSpeed;
        var offset = new Vector2(_scrollX, 0f);
        _meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
