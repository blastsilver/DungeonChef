using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class GlitchPostRender : MonoBehaviour
{
    public Material _material;
    [Range(0, 0.1f)]
    public float offset = 0.005f;

    public void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        //    // TV noise
        //    _material.SetFloat("_OffsetNoiseX", Random.Range(0f, 0.6f));
        //    float offsetNoise = _material.GetFloat("_OffsetNoiseY");
        //    _material.SetFloat("_OffsetNoiseY", offsetNoise + Random.Range(-0.03f, 0.03f));

        //    // Vertical shift
        //    float offsetPosY = _material.GetFloat("_OffsetPosY");
        //    if (offsetPosY > 0.0f)
        //    {
        //        _material.SetFloat("_OffsetPosY", offsetPosY - Random.Range(0f, offsetPosY));
        //    }
        //    else if (offsetPosY < 0.0f)
        //    {
        //        _material.SetFloat("_OffsetPosY", offsetPosY + Random.Range(0f, -offsetPosY));
        //    }
        //    else if (Random.Range(0, 150) == 1)
        //    {
        //        _material.SetFloat("_OffsetPosY", Random.Range(-0.5f, 0.5f));
        //    }

        //    // Channel color shift
        //    float offsetColor = _material.GetFloat("_OffsetColor");
        //    if (offsetColor > 0.003f)
        //    {
        //        _material.SetFloat("_OffsetColor", offsetColor - 0.001f);
        //    }
        //    else if (Random.Range(0, 400) == 1)
        //    {
        //        _material.SetFloat("_OffsetColor", Random.Range(0.003f, 0.1f));
        //    }

        //    // Distortion
        //    if (Random.Range(0, 15) == 1)
        //    {
        //        _material.SetFloat("_OffsetDistortion", Random.Range(1f, 480f));
        //    }
        //    else
        //    {
        //        _material.SetFloat("_OffsetDistortion", 480f);
        //    }
        float xRandom = Random.Range(-offset, offset);
        float yRandom = Random.Range(-offset, offset);

        _material.SetFloat("_RedX", xRandom);
        _material.SetFloat("_BlueX", yRandom);
        _material.SetFloat("_GreenX", -xRandom);

        _material.SetFloat("_RedY", yRandom);
        _material.SetFloat("_BlueY", -xRandom);
        _material.SetFloat("_GreenY", -yRandom);


        Graphics.Blit(source, destination, _material);
    }
}