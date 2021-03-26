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
        m_count.Subscribe(x => Counter());
        m_trans = keyPad.InputVector();

        m_shot = new NormalShot();
        keyPad.LeftClick().Subscribe(x => m_shot.shot(m_bulletstatus, transform.position, transform.rotation));

    }


    // Update is called once per frame
    void Update()
    {
        var screenPos = Camera.main.WorldToScreenPoint(transform.position);
        var direction = Input.mousePosition - screenPos;
        var angle = Units.getAngle(Vector3.zero, direction);
        var angles = transform.localEulerAngles;
        angles.z = angle;

        transform.localEulerAngles = angles;
        transform.position += m_speed * new Vector3(m_trans.Value.x, m_trans.Value.y, 0);
    }

    //HPゲージの管理
    void GaugeHP()
    {
        //UIのHPゲージの処理
        if (m_life.Value <= 0)
        {
            //gameover処理
            Destroy(this.gameObject);
        }
    }

    //HP上限ゲージの管理
    void GaugeMaxHP()
    {

    }
    void Counter()
    {

    }

    public void Damage(int damage)
    {
        m_life.Value -= damage;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "TekazuItem")
        {
            other.gameObject.GetComponent<tekazu>().getpoint();
        }
        else if (other.tag == "HpItem")
        {
            other.gameObject.GetComponent<hpitem>().getpoint();
        }
    }

}
