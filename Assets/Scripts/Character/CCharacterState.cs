using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCharacterState : MonoBehaviour
{

    public Slider hpBar;

    public GameObject dieEft;

    public float maxHealthPoint;

    [SerializeField]
    private float curHealthPoint;

    // 레벨 관련
    private int characterLevel;
    private float nextExpPoint;
    private float curExpPoint;



    private float spd;
    private float def;
    private float atk;

    public float coolTime;

    private float currentCoolTime = 0f;
    private bool isReady = true;

    private void Start()
    {
        curHealthPoint = maxHealthPoint;
        
    }

    private void Update()
    {

        hpBar.value = curHealthPoint / maxHealthPoint;

        if (!isReady)
        {
            currentCoolTime += Time.deltaTime;
            if (currentCoolTime >= coolTime)
            {
                currentCoolTime = 0f;
                isReady = true;
            }
        }
    }


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
        if(isReady)
        {
            curHealthPoint -= damage;
            if (curHealthPoint <= 0f)
            {
                // Die 델리게이트 실행

                this.gameObject.SetActive(false);
                Instantiate(dieEft, transform.position, Quaternion.identity);


            }
            isReady = false;
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
