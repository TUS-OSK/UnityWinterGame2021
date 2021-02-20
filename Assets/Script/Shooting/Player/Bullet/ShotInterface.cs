using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Bulletstatus
{
    public int bulletpower;
    public int bulletnumber;
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
        Vector3 way = new Vector3(0, 0, 30.0f);

        for (int i = 0; i < bullet.bulletnumber; ++i)
        {
            var bulletshot = GameObject.Instantiate(bullet.bullet, position, Quaternion.Euler(way));
            var v = bulletshot.GetComponent<Bullet>();
            v.Init(bullet.bulletspeed, bullet.bulletpower);
        }
    }
}




