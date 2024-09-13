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
    private bool isAttacking = false; // Nouveau bool�en pour suivre l'�tat de l'attaque

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
                // D�placement du monstre vers la cible
                Vector3 direction = (target.position - transform.position).normalized;
                transform.position += direction * moveSpeed * Time.deltaTime;

                // Faire en sorte que le monstre regarde vers la cible
                transform.LookAt(target);

                // Activer l'animation de course
                if (!animationMonster.GetBool(isRunning))
                {
                    animationMonster.SetTrigger(Run);
                    animationMonster.SetBool(isRunning, true);
                }

                // Assurer que l'animation d'attaque est d�sactiv�e lorsqu'en mouvement
                if (isAttacking)
                {
                    animationMonster.SetFloat(Punch, 0); // R�initialiser le param�tre d'attaque
                    isAttacking = false;
                }
            }
            else
            {
                // Arr�ter l'animation de course et commencer l'attaque si non d�j� en cours
                if (animationMonster.GetBool(isRunning))
                {
                    animationMonster.SetBool(isRunning, false);
                }

                // Commencer l'animation d'attaque si non d�j� en cours
                if (!isAttacking)
                {
                    animationMonster.SetFloat(Punch, 1); // D�clencher l'animation d'attaque
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

            // Commencer la course vers l'ennemi
            if (!animationMonster.GetBool(isRunning))
            {
                animationMonster.SetTrigger(Run);
                animationMonster.SetBool(isRunning, true);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision d�tect�e avec " + collision.gameObject.name);
    }
}
