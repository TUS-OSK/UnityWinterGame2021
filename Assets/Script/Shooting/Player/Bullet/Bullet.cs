using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float m_speed;
    private int m_power;
    private Vector3 m_trans;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * m_speed);
    }

    public void Init(float speed, int power)
    {
        m_speed = speed;
        m_power = power;
        Destroy(this.gameObject, 2);
    }

    int getPower()
    {
        return m_power;
    }
}
