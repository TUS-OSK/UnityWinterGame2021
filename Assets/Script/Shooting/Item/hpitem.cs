using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpitem : MonoBehaviour
{
    private Vector3 vec;
    private Vector3 gravity;
    public float grav = -0.1f;
    public float v = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        vec = new Vector3(0, v, 0);
        gravity = new Vector3(0, grav, 0);
    }

    // Update is called once per frame
    void Update()
    {
        vec += gravity;
        transform.position += vec;
    }

    public void getpoint()
    {

    }

}
