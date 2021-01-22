using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitController2D : MonoBehaviour
{
    private Transform target;
    [SerializeField] float speed = 2f;
    [SerializeField] int attack = 3;
    public float lineOfSite;
    void Start()
    {
        target = GameObject.FindWithTag("MainCamera").transform;
    }
    void Update()
    {
        getPos();
    }
    void getPos()
    {
        float distanceFromPlayer = Vector2.Distance(target.position, transform.position);
        if(lineOfSite > distanceFromPlayer)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);
        }
        if(distanceFromPlayer < 0.3)
            GameManager.instance.healthBar.Subtract(1);
    }
    /*
    Vector2 motionVector;
    public Vector2 lastMotionVector;
    
    Animator animator;
    public bool moving;
    //Vector2 characterPosiiton = transform.position;
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        motionVector = new Vector2(
            horizontal,
            vertical
            );
        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical", vertical);


        moving = horizontal != 0 || vertical != 0;
        animator.SetBool("moving", moving);

        if (horizontal != 0 || vertical != 0)
        {
            lastMotionVector = new Vector2(
                horizontal,
                vertical
                ).normalized;
            animator.SetFloat("lastHorizontal", horizontal);
            animator.SetFloat("lastVertical", vertical);
        }

    }

    void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        rigidbody2d.velocity = motionVector * speed;

    }
    */
}