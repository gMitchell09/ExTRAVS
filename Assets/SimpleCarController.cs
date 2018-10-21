using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimpleCarController : MonoBehaviour {
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have

    private Vector3 m_lastPos;
    private HealthManager m_healthManager;

    void Start() {
        m_lastPos = transform.position;
        m_healthManager = FindObjectOfType<HealthManager>();
    }

    public void FixedUpdate() {
        float motor = maxMotorTorque * Input.GetAxis("VerticalKey");
        float steering = maxSteeringAngle * Input.GetAxis("HorizontalKey");

        foreach (AxleInfo axleInfo in axleInfos) {
            if (axleInfo.steering) {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor) {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
        }

        if (Input.GetKeyDown("space")) {
            Quaternion rot = transform.rotation;
            rot.eulerAngles.Set(rot.x, rot.y, 0);
            transform.rotation = rot;
        }

        m_healthManager.AddDistanceTravelled(Mathf.Abs((transform.position - m_lastPos).magnitude));
        m_lastPos = transform.position;
    }
}

[System.Serializable]
public class AxleInfo {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}
