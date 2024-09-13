using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersStat : MonoBehaviour
{
    private Animator animationMonster;

    public int health = 100; 
    public int attackPower = 10; 
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
        Debug.Log(gameObject.name + " is dead!");
        animationMonster.SetTrigger(die);
    }
}
