using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    public float Speed = 1;
    private RawImage _rawImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rawImage = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        Rect rect = _rawImage.uvRect;
        rect.y += Speed * Time.deltaTime;
        _rawImage.uvRect = rect;
    }
}


