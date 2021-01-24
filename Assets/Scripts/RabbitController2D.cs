using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitController2D : MonoBehaviour
{
    private Transform target;
    private float speed = 0.02f;
    [SerializeField] int attack = 3;
    public float lineOfSite = 7.0f;
    public GameObject rabbit;
    public GameObject player;
    [SerializeField] Animator animator;
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
            animate();
        }
        if (distanceFromPlayer < 1.0)
        {
            GameManager.instance.healthBar.Subtract(0.5f);
        }
            
    }
    void animate()
    {
        float horizontal = target.position.x - transform.position.x;
        float vertical = target.position.y - transform.position.y;

        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical", vertical);
    }
}