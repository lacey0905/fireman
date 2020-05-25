using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultMissile : MonoBehaviour
{

    public Bullet bullet;

    public float coolTime;

    private float currentCoolTime = 0f;
    private bool isReady = true;

    float maxDistance = 1.09f;
    public float radius = 0.16f;

    private void Update()
    {
        
        if(isReady)
        {
            int layerMask = 1 << LayerMask.NameToLayer("Monster");
            RaycastHit2D hit = Physics2D.CircleCast(transform.position, radius, Vector2.up, maxDistance, layerMask);

            if(hit)
            {

                Vector2 targetDir = hit.transform.position - transform.position;

                Bullet _bullet = Instantiate(bullet, transform.position, Quaternion.identity) as Bullet;
                _bullet.SetDirection(targetDir.normalized);

                isReady = false;
            }

        }
        else {
            currentCoolTime += Time.deltaTime;
            if(currentCoolTime >= coolTime)
            {
                currentCoolTime = 0f;
                isReady = true;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
