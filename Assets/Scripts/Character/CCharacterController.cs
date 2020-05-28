using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCharacterController : MonoBehaviour
{

    public delegate void dieHandler();
    public static event dieHandler OnplayerDie;
    
    public float hp = 100f;

    Rigidbody2D rigidbody;

    public float moveSpeed;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");


        if (h != 0f || v != 0f)
        {
            Movement(h, v);
        }
        else
        {
            rigidbody.velocity = Vector2.zero;
        }

        if (Input.GetMouseButtonDown(0))
        {

        }

        if (hp <= 0)
        {
            if (OnplayerDie != null)
            {
                OnplayerDie();
            }
        }

    }


    //public void Damage(float _damage)
    //{
    //    hp -= _damage;
        
    //}

    public void Movement(float horizontal, float vertical)
    {
        Vector2 direction = new Vector2(horizontal, vertical);
        Vector2 velocity = direction.normalized * moveSpeed;
        //rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);
        //rigidbody.velocity = velocity;
        transform.Translate(velocity * Time.deltaTime);
    }

}
