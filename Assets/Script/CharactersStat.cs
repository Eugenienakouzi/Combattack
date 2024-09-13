using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersStat : MonoBehaviour
{
    private Animator animationMonster;

    public int health = 100; // Points de vie
    public int attackPower = 10; // Force d'attaque
    private const string die = "Die";

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Ajouter ici la logique de mort (désactivation du personnage, animation, etc.)
        Debug.Log(gameObject.name + " is dead!");
        animationMonster.SetTrigger(die);
    }
}
