using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderTest : MonoBehaviour
{
    Renderer render;

    [Range(0, 1)]
    public float colorAmout;

    void Awake()
    {
        render = GetComponent<Renderer>();
    }

    void Update()
    {
        render.material.SetFloat("_colorAmout", colorAmout);
        //render.material.SetColor("_MainTex", Color.white);
    }
}
