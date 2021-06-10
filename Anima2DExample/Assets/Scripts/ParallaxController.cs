using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField]
    List<ParallaxLayer> parallaxLayersList = new List<ParallaxLayer>();
    public ParallaxCamera parallaxCamera;

    // Start is called before the first frame update
    void Start()
    {
        if (parallaxCamera == null)
            parallaxCamera = Camera.main.GetComponent<ParallaxCamera>();
        
        if(parallaxCamera != null)
        {
            parallaxCamera.onCameraTranslateX += MoveX;
            parallaxCamera.onCameraTranslateY += MoveY;
        }

        GetLayers();

    }

    private void MoveX(float delta)
    {
        foreach  (ParallaxLayer layer in parallaxLayersList)
        {
            if (layer != null)
            {
                layer.MoveX(delta);
            }
        }
    }


    private void MoveY(float delta)
    {
        foreach (ParallaxLayer layer in parallaxLayersList)
        {
            if (layer != null)
            {
                layer.MoveY(delta);
            }
        }
    }
    private void GetLayers()
    {
        parallaxLayersList.Clear();
        for(int i = 0; i< transform.childCount; i++)
        {
            ParallaxLayer layer = transform.GetChild(i).GetComponent<ParallaxLayer>();
            if (layer != null)
                parallaxLayersList.Add(layer);
        }
    }
}
