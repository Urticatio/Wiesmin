using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitController2D : MonoBehaviour
{
    private Transform target;
    public float highSpeed = 0.05f;
    public float lowSpeed = 0.025f;
    private float speed = 0.05f;
    [SerializeField] int attack = 3;
    public float lineOfSite = 7.0f;
    public GameObject rabbit;
    public GameObject player;
    void Start()
    {
        target = player.transform;
    }
    void Update()
    {
        if (rabbit.activeInHierarchy)
        {
            GetPos();
        }        
    }
    void GetPos()
    {
        target = player.transform;
        float distanceFromPlayer = Vector3.Distance(target.position, transform.position);
        if (distanceFromPlayer > lineOfSite) //jeśli jest za daleko od postaci
        {
            return; //przerywa funkcję
        }
        if (distanceFromPlayer < lineOfSite)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
        }
        if (distanceFromPlayer < 0.5)
        {
            //speed = lowSpeed;
            GameManager.instance.healthBar.Subtract(1);
        }
        //else speed = highSpeed;
            
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