using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Rigidbody2D rb;
    public float movementSpeed;
    private Vector2 moveDirection;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        processInput();
    }

    private void FixedUpdate() {
        Move();
    }

    private void processInput(){
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(x, y).normalized;
    }

    private void Move(){
        float x = moveDirection.x * movementSpeed * Time.deltaTime;
        float y = moveDirection.y * movementSpeed * Time.deltaTime;
        rb.velocity = new Vector2(x, y);
    }
}
