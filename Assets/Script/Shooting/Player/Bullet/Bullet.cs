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
        transform.position += m_trans;
    }

    void Init(float speed, int power, Vector3 direction, Vector3 position)
    {
        m_trans = speed * direction;
        m_speed = speed;
        m_power = power;
        transform.position = position;
    }

    int getPower()
    {
        return m_power;
    }
}
