using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;


public class Player : MonoBehaviour
{
    //HP初期値
    [SerializeField] private int m_hpin = 10;
    //HP上限の初期値
    [SerializeField] private int m_hpmaxin = 10;
    [SerializeField] private float m_speed;
    [SerializeField] private float m_bulletspeed;
    [SerializeField] private int m_bulletnumber;
    [SerializeField] private int m_bulletpower;
    public GameObject m_bullet;

    //現在HP
    [HideInInspector] public ReactiveProperty<int> m_life;
    //現在HP上限
    [HideInInspector] public ReactiveProperty<int> m_lifemax;
    //パズル用の手数
    [HideInInspector] public ReactiveProperty<int> m_count;

    public KeyPad keyPad;

    private ReactiveProperty<Vector2> m_trans;
    private Bulletstatus m_bulletstatus;

    private Shotinterface m_shot;


    // Start is called before the first frame update
    void Start()
    {
        m_life = new ReactiveProperty<int>(m_hpin);
        m_lifemax = new ReactiveProperty<int>(m_hpmaxin);
        m_count = new ReactiveProperty<int>(0);
        m_bulletstatus.bulletpower = m_bulletpower;
        m_bulletstatus.bulletspeed = m_bulletspeed;
        m_bulletstatus.bulletnumber = m_bulletnumber;
        m_bulletstatus.bullet = m_bullet;
        m_life.Subscribe(x => GaugeHP());
        m_lifemax.Subscribe(x => GaugeMaxHP());
        m_trans = keyPad.InputVector();

        m_shot = new MaltipleShot();
        keyPad.LeftClick().Subscribe(x => m_shot.shot(m_bulletstatus, transform.position, transform.rotation));

    }


    // Update is called once per frame
    void Update()
    {
        transform.position += m_speed * new Vector3(m_trans.Value.x, m_trans.Value.y, 0);
    }

    //HPゲージの管理
    void GaugeHP()
    {

    }

    //HP上限ゲージの管理
    void GaugeMaxHP()
    {

    }



}
