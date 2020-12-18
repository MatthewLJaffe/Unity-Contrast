using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public int playerSpeed = 1;
    public int playerAcceleration = 1;
    public int playerJumpForce = 1;

    protected Rigidbody2D playerRigidBody;
    private Collider2D[] colliders;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = this.gameObject.GetComponent<Rigidbody2D>();
        colliders = gameObject.GetComponents<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
//collisionCount = 0;
        //ContactPoint2D[] cont;


        if(colliders[1].IsTouchingLayers(Physics2D.AllLayers) && Input.GetKeyDown(KeyCode.Space)){
            playerRigidBody.AddForce(Vector2.up * playerJumpForce);
        }

        if(Input.GetKey(KeyCode.A)){
            //this.gameObject.transform.Translate(-1 * playerSpeed * Time.deltaTime, 0, 0);
            //if(playerRigidBody.velocity.x >= -1 * playerSpeed){
                playerRigidBody.velocity = new Vector2(playerSpeed * Input.GetAxis("Horizontal"), playerRigidBody.velocity.y);
            //}
        }
        else if(Input.GetKey(KeyCode.D)){
            //this.gameObject.transform.Translate(playerSpeed * Time.deltaTime, 0, 0);
            //if(playerRigidBody.velocity.x <= playerSpeed){
                playerRigidBody.velocity = new Vector2(playerSpeed * Input.GetAxis("Horizontal"), playerRigidBody.velocity.y);
            //}
        }
        else{
            //playerRigidBody.velocity = new Vector2(playerSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, playerRigidBody.velocity.y);
        }

    }
}
