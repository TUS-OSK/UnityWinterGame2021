using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tekazu : MonoBehaviour
{
    public Player player;
    [SerializeField] int point;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void getpoint()
    {
        player.m_life.Value += point;
    }
}
