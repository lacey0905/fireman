using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject target;
    public float distance;

    public Monster monster;

    //public float spanwDistance = 
    public float coolTime;

    private float currentCoolTime = 0f;
    private bool isReady = true;

    private void Update()
    {

        if (isReady)
        {

            Quaternion newRot = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
            transform.rotation = newRot;

            Vector2 newSpawnPos = target.transform.position + transform.up * distance;

            Instantiate(monster, newSpawnPos, Quaternion.identity);

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
