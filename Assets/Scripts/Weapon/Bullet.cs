using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject eftPrefab;

    Rigidbody2D rigidbody;

    public float damage;
    public float moveSpeed;
    Vector2 direction;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 velocity = direction.normalized * moveSpeed;
        rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Monster")
        {
            GameObject eft = Instantiate(eftPrefab, collision.transform.position, Quaternion.identity);
            eft.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y, -2f);
            eft.transform.parent = collision.transform;
            collision.GetComponent<Monster>().Damage(damage);
            Destroy(this.gameObject);
        }
    }

}
