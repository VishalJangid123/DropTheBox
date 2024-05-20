using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] private GameObject box_prefab;
  
    public void Spawnbox()
    {
        GameObject box_obj = Instantiate(box_prefab);
        Vector3 temp = transform.position;
        temp.z = 0.0f;
        box_obj.transform.position = temp;
    }
}
