using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiDamageTest : MonoBehaviour
{

    public GameObject effect;

    public float coolTime;

    private float currentCoolTime = 0f;
    private bool isReady = false;

    private void Update()
    {

        if (isReady)
        {
            GameObject eft = Instantiate(effect, transform.position, Quaternion.identity) as GameObject;
            eft.transform.parent = GameObject.Find("Fireman").transform.parent;
            isReady = false;
        }
        else
        {
            currentCoolTime += Time.deltaTime;
            if (currentCoolTime >= coolTime)
            {
                currentCoolTime = 0f;
                isReady = true;
            }
        }
    }

}
