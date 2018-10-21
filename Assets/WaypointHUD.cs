using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaypointHUD : MonoBehaviour {
    private GameObject[] m_waypoints;
    private Camera m_mainCamera;

    void OnGUI() {
        foreach (GameObject wp in m_waypoints) {
            float distance = Vector3.Distance(transform.position, wp.transform.position);
            GUI.Label(new Rect(Camera.main.WorldToViewportPoint(wp.transform.position).x, 101, 100, 20), distance.ToString() + "m");
        }
    }
	// Use this for initialization
	void Start () {
        m_waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        m_mainCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
