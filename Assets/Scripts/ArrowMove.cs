using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour, IDimensionInteraction
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float maxDistance;
    [SerializeField] private bool upDown;
    [SerializeField] private bool isDark;
    private bool facingForward;
    private Vector2 moveDirection;
    private Vector2 moveVector;
    private bool firstTime = true;
    private bool isSiblingColliding = false;
    private void Awake()
    {
        ChangeDimension.OnDimensionChange += DimensionInteraction;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        if (upDown)
            moveDirection = Vector2.up;
        else
            moveDirection = Vector2.right;
        moveVector = moveDirection * speed;
        if (isDark)
            moveVector *= -1;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "DimensionalElement"){
            isSiblingColliding = true;
        }
    }

    private void FixedUpdate()
    {
        if(isSiblingColliding){
            rb.velocity = new Vector2(0, 0);
        }
        else{
            rb.velocity = moveVector;
        }
    }

    private void OnDestroy() =>
        ChangeDimension.OnDimensionChange -= DimensionInteraction;

    public void DimensionInteraction(bool darken) {
        isSiblingColliding = false;
        //arrow block could've reached it's max distance and stopped so if it did can't just negate velocity
        if (!firstTime)
        {
            moveVector *= -1;
        }
        else{
            firstTime = false;
        }
        rb.velocity = moveVector;
    }
}
