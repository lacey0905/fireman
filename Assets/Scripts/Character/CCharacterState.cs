using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCharacterState : MonoBehaviour
{

    private float maxHealthPoint;
    private float curHealthPoint;

    // 레벨 관련
    private int characterLevel;
    private float nextExpPoint;
    private float curExpPoint;



    private float spd;
    private float def;
    private float atk;


    //public float HealthPoint { get; }
    //public float ExpPoint { get; }

    public void AddHealth(float heal)
    {
        curHealthPoint += heal;
        if(curHealthPoint >= maxHealthPoint)
        {
            curHealthPoint = maxHealthPoint;
        }
    }

    public void Damage(float damage)
    {
        curHealthPoint -= damage;
        if(curHealthPoint <= 0f)
        {
            // Die 델리게이트 실행
        }
    }

    public void AddExp(float exp)
    {
        curExpPoint += exp;
        if(curExpPoint >= nextExpPoint)
        {
            // Level Up 델리게이트 실행
        }
    }



}
