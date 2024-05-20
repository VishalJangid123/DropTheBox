﻿using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [HideInInspector]
    public Vector3 targetPos;

    private float smoothMove = 1f;
    public bool inc_size = false, viewfull_btn = false;
   

    void Start()
    {
        targetPos = transform.position;
        Debug.Log("Screen" + Screen.width + " " + Screen.height);
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothMove * Time.deltaTime);
        
         /*if (inc_size)
        {
            float temp = Camera.main.orthographicSize;
            Camera.main.orthographicSize = Mathf.Lerp(temp, temp + 0.4f, smoothMove * Time.deltaTime);
            inc_size = false;
        }*/


    }
    public void CameraSizeInc()
    {
        inc_size = true;
       
    }
  
}
