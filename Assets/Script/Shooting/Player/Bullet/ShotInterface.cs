using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Bulletstatus
{
    public int bulletpower;
    public float bulletspeed;
    public GameObject bullet;
};
public interface Shotinterface
{
    void shot(Bulletstatus bullet, Vector3 position, Quaternion rotation);
}

public class NormalShot : Shotinterface
{
    public void shot(Bulletstatus bullet, Vector3 position, Quaternion rotation)
    {
        var bulletshot = GameObject.Instantiate(bullet.bullet, position, rotation);
        var v = bulletshot.GetComponent<Bullet>();
        v.Init(bullet.bulletspeed, bullet.bulletpower);
    }
}

public class MaltipleShot : Shotinterface
{
    public void shot(Bulletstatus bullet, Vector3 position, Quaternion rotation)
    {

    }
}




