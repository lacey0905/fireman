using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCharacterController : MonoBehaviour
{

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

    }

    public void Movement(float horizontal, float vertical)
    {
        Vector2 direction = new Vector2(horizontal, vertical);
        Vector2 velocity = direction.normalized * moveSpeed;
        rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);
    }

}
