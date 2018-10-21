using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockSkyAxis : MonoBehaviour {

    private Camera m_camera;

    void Start()
    {
        m_camera = GetComponent<Camera>();
    }
    void LateUpdate()
    {
        Vector3 pos = transform.position;
        pos.y = 29.0f;
        transform.SetPositionAndRotation(pos, transform.rotation);
    }
}
