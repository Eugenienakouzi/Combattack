using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animate : MonoBehaviour
{
    Animator animation;

    private const string vertical = "Vertical";
    private const string run = "run";
    private const string walk = "walk";
    private const string jump = "jump";
    private const string attack = "attack";
    private const string die = "die";
    void Awake()
    {
        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animation.SetFloat(walk, Input.GetAxis(vertical));
        animation.SetFloat(jump, Input.GetKeyDown(KeyCode.Space) ? 1 : 0);
        animation.SetFloat(attack, Input.GetMouseButtonDown(0) ? 1 : 0);
        animation.SetFloat(run, Input.GetKey(KeyCode.LeftShift) ? 1 : 0);
        animation.SetFloat(die, Input.GetKeyDown(KeyCode.K) ? 1 : 0);


    }
}
