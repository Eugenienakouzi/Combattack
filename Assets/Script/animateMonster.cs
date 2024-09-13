using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animateMonster : MonoBehaviour
{
    private Animator animationMonster;
    private const string Run = "Run";
    private const string isRunning = "isRunning";
    private const string ennemy = "ennemy";
    private const string Punch = "Punch";
    public float stopDistance = 1f;
    public float moveSpeed = 3f;

    private Transform target;
    private bool isAttacking = false; 

    void Awake()
    {
        animationMonster = GetComponent<Animator>();
    }

    void Update()
    {
        if (target != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            if (distanceToTarget > stopDistance)
            {
                Vector3 direction = (target.position - transform.position).normalized;
                transform.position += direction * moveSpeed * Time.deltaTime;

                transform.LookAt(target);

                if (!animationMonster.GetBool(isRunning))
                {
                    animationMonster.SetTrigger(Run);
                    animationMonster.SetBool(isRunning, true);
                }

                if (isAttacking)
                {
                    animationMonster.SetFloat(Punch, 0); 
                    isAttacking = false;
                }
            }
            else
            {
                if (animationMonster.GetBool(isRunning))
                {
                    animationMonster.SetBool(isRunning, false);
                }

                if (!isAttacking)
                {
                    animationMonster.SetFloat(Punch, 1); 
                    isAttacking = true;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(ennemy))
        {
            target = other.transform;

            if (!animationMonster.GetBool(isRunning))
            {
                animationMonster.SetTrigger(Run);
                animationMonster.SetBool(isRunning, true);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision détectée avec " + collision.gameObject.name);
    }
}
