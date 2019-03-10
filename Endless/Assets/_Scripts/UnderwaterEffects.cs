﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode , ImageEffectAllowedInSceneView]
public class UnderwaterEffects : MonoBehaviour
    
{
    public Material _mat;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source , destination , _mat);
    }
}
