using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VCamCollider : MonoBehaviour
{
    public int a;
    public int b;
    public CameraHandler cameraHandler;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //cameraHandler.SwitchPriority(a, b);
            cameraHandler.SetPriority(a);
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        cameraHandler.SwitchPriority(a, b);
    //    }
    //}

   
}
