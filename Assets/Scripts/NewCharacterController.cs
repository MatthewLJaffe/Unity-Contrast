using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCharacterController : MonoBehaviour
{

    public int playerSpeed = 1;
    public int playerAcceleration = 1;
    public float playerJumpSpeed = 1;
    [SerializeField] private float fallJumpMultiplier = 2.5f;
    [SerializeField] private float lowJumpMultiplier = 2;
    private SpriteRenderer sprite;
    public Animator animator;

    protected Rigidbody2D playerRigidBody;
    private Collider2D[] colliders;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        colliders = gameObject.GetComponents<Collider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //collisionCount = 0;
        //ContactPoint2D[] cont;
        bool grounded = colliders[1].IsTouchingLayers(Physics2D.AllLayers);

        if (colliders[1].IsTouchingLayers(Physics2D.AllLayers) && Input.GetKeyDown(KeyCode.Space)) {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, playerJumpSpeed);
            AudioManager.instance.Play("Jump");
        }
        animator.SetBool("IsJumping", !grounded);
        if (playerRigidBody.velocity.y < 0)
        {
            playerRigidBody.velocity += Vector2.up * Physics2D.gravity.y * (fallJumpMultiplier - 1) * Time.deltaTime;
        }
        else if(playerRigidBody.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) {
            playerRigidBody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A)){
            //this.gameObject.transform.Translate(-1 * playerSpeed * Time.deltaTime, 0, 0);
            //if(playerRigidBody.velocity.x >= -1 * playerSpeed){
                playerRigidBody.velocity = new Vector2(playerSpeed * Input.GetAxis("Horizontal"), playerRigidBody.velocity.y);
            animator.SetFloat("Speed", 1);
            sprite.flipX = true;
            
            //}
        }
        else if(Input.GetKey(KeyCode.D)){
            //this.gameObject.transform.Translate(playerSpeed * Time.deltaTime, 0, 0);
            //if(playerRigidBody.velocity.x <= playerSpeed){
                playerRigidBody.velocity = new Vector2(playerSpeed * Input.GetAxis("Horizontal"), playerRigidBody.velocity.y);
            animator.SetFloat("Speed", 1);
            sprite.flipX = false;
            //}
        }
        else{
            playerRigidBody.velocity = new Vector2(playerSpeed * Input.GetAxis("Horizontal"), playerRigidBody.velocity.y);
            animator.SetFloat("Speed", 0);
        }

    }
}
