using System.Collections;
using System.Collections.Generic;   
using UnityEngine;

public class ObjectFader : MonoBehaviour
{
    string t = "https://u210399.gluwebsite.nl/api.php";

    public float fadeSpeed = 7.5f;
    public float fadeValue = 0.5f;
    private float _originalValue;

    private MeshRenderer _renderer;
    private Material _material;

    public bool doFade = false;


    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        _material = _renderer.material;
        _originalValue = _material.color.a;
    }

    void Update()
    {
        if (doFade)
        {
            FadeNow();
        }
        else
        {
            ResetFade();
        }
    }

    private void FadeNow()
    {
        Color currentColor = _material.color;
        Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b, Mathf.Lerp(currentColor.a, fadeValue, fadeSpeed * Time.deltaTime));
        _material.color = smoothColor;
    }

    private void ResetFade()
    {
        Color currentColor = _material.color;
        Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b, Mathf.Lerp(currentColor.a, _originalValue, fadeSpeed * Time.deltaTime));
        _material.color = smoothColor;
    }
}
