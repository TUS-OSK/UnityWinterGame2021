using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private int time;
    public int interval;
    public float x_limit;
    public float y_limit;
    public Enemy enemy;


    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time++;
        if (time > interval)
        {
            Instantiate(enemy, RandomPos(), Quaternion.Euler(0, 0, 0));
            time = 0;
        }
    }

    Vector3 RandomPos()
    {
        float u = 2 * Random.value - 1f;
        float v = 2 * Random.value - 1f;
        float x = (u * x_limit + x_limit) / 2f;
        float y = (v * y_limit + y_limit) / 2f;
        return new Vector3(x, y, 0f);
    }
}
