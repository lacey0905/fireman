using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stome : MonoBehaviour
{
    float maxDistance = 1.09f;
    public float radius = 0.16f;
    public float Damage;

    public float life;
    float currentLife;

    public float delay = 1.0f;
    float currentDelay = 0f;

    public GameObject hitEft;

    private void Update()
    {
        currentLife += Time.deltaTime;

        if (currentLife >= life)
        {
            Destroy(this.gameObject);
        }

        if (currentDelay >= delay)
        {
            int layerMask = 1 << LayerMask.NameToLayer("Monster");
            RaycastHit2D[] hit = Physics2D.CircleCastAll(transform.position, radius, Vector2.up, maxDistance, layerMask);

            for (int i = 0; i < hit.Length; i++)
            {
                hit[i].transform.GetComponent<Monster>().Damage(Damage);
                Vector3 spawnPos = new Vector3(hit[i].transform.position.x, hit[i].transform.position.y, -2f);
                GameObject eft = Instantiate(hitEft, spawnPos, Quaternion.identity) as GameObject;
                eft.transform.parent = hit[i].transform;
            }

            currentDelay = 0f;
        }
        else
        {
            currentDelay += Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
