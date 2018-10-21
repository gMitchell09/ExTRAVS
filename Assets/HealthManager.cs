using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {
    [SerializeField]
    public int StartHealth = 10;

    [SerializeField]
    public float DistanceCostPerUnitHealth = 100.0f;

    private float m_currentHealth;
    private float m_distanceTravelled = 0;

    private GameObject[] m_images;

    void Start()
    {
        m_currentHealth = StartHealth;

        m_images = GameObject.FindGameObjectsWithTag("HealthBar");
        
        foreach (var img in m_images)
        {

            if (img.GetComponent<HBConstant>().Value > m_currentHealth)
            {
                img.gameObject.SetActive(true);
            }
        }
    }

    public float GetHealth() { return m_currentHealth; }

    public void AddDistanceTravelled(float dp)
    {
        m_distanceTravelled += dp;
        if (m_distanceTravelled > DistanceCostPerUnitHealth)
        {

            m_distanceTravelled = 0;
            m_currentHealth--;
            if (m_currentHealth < 0) {  // bad
            }

            foreach (var img in m_images)
            {
                if (img.GetComponent<HBConstant>().Value > m_currentHealth)
                {
                    img.gameObject.SetActive(false);
                    Debug.LogWarning("Hiding: " + m_currentHealth);

                }
            }
        }
    }
}
