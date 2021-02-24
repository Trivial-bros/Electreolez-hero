
using UnityEngine;

public class seamlessfollow : MonoBehaviour
{
    public Transform cameraobject;
    public Vector3 offset;


    // Update is called once per frame
    void Update()
    {
        transform.position = cameraobject.position + offset;
    }
}
