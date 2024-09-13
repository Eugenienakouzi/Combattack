using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody playerRigidBody;

    public bool onGround = false;

    public int jumpForce = 5;

    private const string SOL = "Sol";
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis(HORIZONTAL); 
        float moveVertical = Input.GetAxis(VERTICAL);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        transform.Translate(movement * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && onGround == true)
        {
            playerRigidBody.velocity = Vector3.zero;
            playerRigidBody.AddForce(new Vector3(0f, 1f, 0f) * jumpForce);
            onGround = false; 
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == SOL)
        {
            onGround = true;
        }
    }
}



