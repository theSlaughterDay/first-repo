using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SetRenderMode
{
     public static void SetOpaque(Item item)
    {
        SetMaterialRenderingMode(item.gameObject.GetComponent<Renderer>().material,
          RenderingMode.Opaque);
    }
     public static void SetTrans(Item item)
    {
        SetMaterialRenderingMode(item.gameObject.GetComponent<Renderer>().material,
            RenderingMode.Transparent);

    }
    public static void SetOpaque(GameObject obj)
    {
        SetMaterialRenderingMode(obj.gameObject.GetComponent<Renderer>().material,
          RenderingMode.Opaque);
    }
    public static void SetTrans(GameObject obj)
    {
        SetMaterialRenderingMode(obj.gameObject.GetComponent<Renderer>().material,
            RenderingMode.Transparent);

    }
    public enum RenderingMode
     {
         Opaque,
         Cutout,
         Fade,
         Transparent,
     }

     private static void SetMaterialRenderingMode(Material material, RenderingMode renderingMode)
     {
         switch (renderingMode)
         {
             case RenderingMode.Opaque:
                 material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                 material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                 material.SetInt("_ZWrite", 1);
                 material.DisableKeyword("_ALPHATEST_ON");
                 material.DisableKeyword("_ALPHABLEND_ON");
                 material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                 material.renderQueue = -1;
                 break;
             case RenderingMode.Cutout:
                 material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                 material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                 material.SetInt("_ZWrite", 1);
                 material.EnableKeyword("_ALPHATEST_ON");
                 material.DisableKeyword("_ALPHABLEND_ON");
                 material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                 material.renderQueue = 2450;
                 break;
             case RenderingMode.Fade:
                 material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                 material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                 material.SetInt("_ZWrite", 0);
                 material.DisableKeyword("_ALPHATEST_ON");
                 material.EnableKeyword("_ALPHABLEND_ON");
                 material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                 material.renderQueue = 3000;
                 break;
             case RenderingMode.Transparent:
                 material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                 material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                 material.SetInt("_ZWrite", 0);
                 material.DisableKeyword("_ALPHATEST_ON");
                 material.DisableKeyword("_ALPHABLEND_ON");
                 material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
                 material.renderQueue = 3000;
                 break;
         }
     }

 
}
