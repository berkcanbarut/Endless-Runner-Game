using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject targetObject;
    public Vector3 cameraOffset;
    // Update is called once per frame


    void LateUpdate()
    {
        
        //transform.position = targetObject.transform.position + cameraOffset;
        Vector3 pos = targetObject.transform.position + cameraOffset;
        transform.position = new Vector3(pos.x, transform.position.y, pos.z);
    }

}
