using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject dieEft;

    Rigidbody2D rigidbody;

    public float moveSpeed;
    Vector2 direction;

    public float hp;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {

        Vector2 targetPos = GameObject.Find("Fireman").transform.position;
        direction = targetPos - rigidbody.position;
        direction = direction.normalized;
        Vector2 velocity = direction.normalized * moveSpeed;
        float distance = Vector2.Distance(targetPos, rigidbody.position);

        if(distance > 1.0f)
        {
            rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);
        }
        
    }

    public void Damage(float _damage)
    {
        hp -= _damage;
        if(hp <= 0)
        {
            Instantiate(dieEft, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

}
