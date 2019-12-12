using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject box_prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void spawnbox()
    {
        GameObject box_obj = Instantiate(box_prefab);
        Vector3 temp = transform.position;
        temp.z = 0.0f;
        box_obj.transform.position = temp;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
