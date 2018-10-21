using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaypointHUD : MonoBehaviour {
    private GameObject[] m_waypoints;
    private Camera m_mainCamera;

    [SerializeField]
    public GameObject Rover;

    [SerializeField]
    public float[] ForwardDistances;

    [SerializeField]
    public Vector3[] WTF;

    void OnGUI() {
        ForwardDistances = new float[m_waypoints.Length];
        WTF = new Vector3[m_waypoints.Length];
        int i = 0;
        foreach (GameObject wp in m_waypoints) {
            // Check if dot product of forward vector and vector for camera to way point is negative
            Vector3 cameraToPoint = wp.transform.position.normalized - transform.position.normalized;
            float forwardDotDistance = Vector3.Dot(transform.forward.normalized, wp.transform.position.normalized);
            ForwardDistances[i++] = forwardDotDistance;
            // Check if way point is visible, output > 0; else it's not visible 
            if (forwardDotDistance >= 0) {
                var tmp = wp.transform.position;
                tmp.y = Rover.transform.position.y;
                float distance = Vector3.Distance(Rover.transform.position, tmp);
                Vector3 wpVectorView = m_mainCamera.WorldToScreenPoint(wp.transform.position);
                WTF[i-1] = wpVectorView;
                GUI.color = Color.black;
                GUI.Label(new Rect(wpVectorView.x, 50, 100, 100), distance.ToString("F2") + "m");
            }
        }
    }
	// Use this for initialization
	void Start () {
        m_waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        m_mainCamera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
	}
}
