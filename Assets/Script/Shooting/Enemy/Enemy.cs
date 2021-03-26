using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Enemy : MonoBehaviour
{
    private ReactiveProperty<int> m_life;
    public EnemyBullet m_bullet;
    public hpitem item;
    public int shotcount;
    public int life;

    private int time;
    void Start()
    {
        m_life = new ReactiveProperty<int>(life);
        m_life.Subscribe(x => ManageHP());
        time = 0;
    }

    void Update()
    {
        ++time;

        if (time > shotcount)
        {
            Shot();
            time = 0;
        }
    }
    void ManageHP()
    {
        if (m_life.Value <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(item, transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            m_life.Value -= 10;
        }
        else if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().Damage(10);
        }
    }

    private void Shot()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(m_bullet, transform.position, transform.rotation * Quaternion.Euler(0, 0, i * 360 / 30));
        }
    }
}
