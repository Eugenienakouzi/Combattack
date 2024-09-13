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
    void Awake()
    {
        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animation.SetFloat(walk, Input.GetAxis(vertical));
        animation.SetFloat(jump, Input.GetKeyDown(KeyCode.Space) ? 1 : 0);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            animation.SetBool(run, true);
        }
        else
        {
            animation.SetBool(run, false);
        }

    }
}
