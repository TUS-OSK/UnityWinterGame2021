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
    //現在HP
    [HideInInspector] public ReactiveProperty<int> m_life;
    //現在HP上限
    [HideInInspector] public ReactiveProperty<int> m_lifemax;


    // Start is called before the first frame update
    void Start()
    {
        m_life = new ReactiveProperty<int>(m_hpin);
        m_lifemax = new ReactiveProperty<int>(m_hpmaxin);

        m_life.Subscribe(x => GaugeHP());
        m_lifemax.Subscribe(x => GaugeMaxHP());
    }


    // Update is called once per frame
    void Update()
    {

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
