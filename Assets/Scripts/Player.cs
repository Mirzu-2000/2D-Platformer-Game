using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   
    Rigidbody2D rb;
    Animator animator;

    float horizontalValue;
    [SerializeField] float speed = 3.0f;

  
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    
    void Update()
    {
       horizontalValue = Input.GetAxisRaw("Horizontal");


    }

     void FixedUpdate()
    {
        Move(horizontalValue);
        
    }


    void Move(float dir)
    {
        //
        float xVal = dir * speed * 100 * Time.deltaTime;
        Vector2 targetVelocity = new Vector2(xVal, rb.velocity.y);
        rb.velocity = targetVelocity;

        Vector3 scale = transform.localScale;
        if (horizontalValue < 0)
        {
            //Facing Left
            scale.x = -1f * Mathf.Abs(scale.x);

        }
        else if (horizontalValue > 0)
        {
            //Facing Right
            scale.x = Mathf.Abs(scale.x);

        }
        transform.localScale = scale;

        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));


    }

}
