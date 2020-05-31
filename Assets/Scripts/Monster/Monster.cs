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
    public float damage;

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

        rigidbody.velocity = velocity;

        //if(distance > 1.0f)
        //{
        //    rigidbody.velocity = velocity;
        //    //transform.Translate(velocity * Time.deltaTime);
        //    //rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);
        //}
        ////else
        ////{
        ////    rigidbody.velocity = Vector2.zero;
        ////}

        //transform.rotation = new Quaternion(0f, 0f, 0f, 0f);

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


    //public void DamageEft()
    //{
    //    StartCoroutine(ResetColor());
    //}

    //IEnumerator ResetColor()
    //{
    //    GetComponentInChildren<SpriteRenderer>().color = new Color(0, 255, 255);
    //    yield return new WaitForSeconds(0.1f);
    //    GetComponentInChildren<SpriteRenderer>().color = new Color(255, 255, 255);
    //}


    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Debug.Log(collision);
            CCharacterState player = collision.gameObject.GetComponent<CCharacterState>();
            player.Damage(damage);
        }
    }

}
