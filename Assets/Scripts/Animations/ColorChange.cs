using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ColorChange : MonoBehaviour
{
    public float duration = 2f;
    public MeshRenderer meshRenderer;

    public Color startColor = Color.white;

    private Color _correctcolor;
    
    private void OnValidate() { 
        meshRenderer = GetComponent<MeshRenderer>();
    }


    
    private void Start()
    {
        _correctcolor = meshRenderer.materials[0].GetColor("_Color");
        LerpColor();

    }


    private void LerpColor()
    {
        meshRenderer.materials[0].SetColor("_Color", startColor);
        meshRenderer.materials[0].DOColor(_correctcolor, duration).SetDelay(1f);

    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            LerpColor();
        }
    }
}
