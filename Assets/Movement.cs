using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {
    [SerializeField]
    float ForwardSpeed = 4.0f;

    [SerializeField]
    float RotationSpeed = 4.0f;

    Rigidbody rb;
    HealthManager m_healthManager;

    // Use this for initialization
    void Start () {
        rb = this.GetComponent<Rigidbody>();
        GameObject[] objs = SceneManager.GetSceneAt(0).GetRootGameObjects();

        foreach (var o in objs)
        {
            if (o.GetComponent<HealthManager>() != null)
            {
                m_healthManager = o.GetComponent<HealthManager>();
                break;
            }
        }        
    }

    // Update is called once per frame
    void Update () {
        if (true) Move();
	}

    void Move() {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * RotationSpeed;
        var z = transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * ForwardSpeed;

        transform.Rotate(0, x, 0);
        transform.position += z;

        m_healthManager.AddDistanceTravelled(z.magnitude);

        //rb.velocity = transform.TransformDirection(5 * Vector3.forward * ForwardSpeed * Input.GetAxis("Vertical"));
    }
}
