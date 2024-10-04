using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player2_controller : MonoBehaviour
{
    private Vector2 movementVector;
    private Rigidbody2D rb;

    [SerializeField] int speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = movementVector;

        // rb.velocity = new Vector2(speed * movementVector.x, rb.velocity.y);
    }

    void OnMove(InputValue value){

        movementVector = value.Get<Vector2>()*10;

        Debug.Log(movementVector);
    }

    void OnCollisionEnter2D(Collision2D collision){
        rb.AddForce(new Vector2(0, 0));

        if(collision.gameObject.CompareTag("Ground")){
            Debug.Log("IsGround");
        }
    }

}
