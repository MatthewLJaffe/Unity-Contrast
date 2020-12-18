using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DimensionlessBullet : Bullet
{

    public float bulletSpeed;
    private Rigidbody2D rigidBody;
    private float magnitude;


    void OnCollisionEnter2D(Collision2D collision) {
        if(!collision.gameObject.CompareTag("DimensionalElement")){
            if(collision.gameObject.CompareTag("Player")){
            }
            else if(collision.gameObject.CompareTag("Brittle Wall")){
                collision.gameObject.SetActive(false);
                Destroy(this.gameObject);
            }
            else{
                Destroy(this.gameObject);
            }
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        //Debug.Log(rb.velocity.magnitude);
        // calculate angle of bullet
        /*
        if(Mathf.Abs(rb.velocity.x) < Mathf.Abs(rb.velocity.y)){
            float angle = Mathf.Atan(rb.velocity.y/rb.velocity.x);
            //Debug.Log(angle);
            // Set new bullet speed at same outgoing angle
            rb.velocity = new Vector2(magnitude*Mathf.Cos(angle), magnitude*Mathf.Sin(angle));
        }
        else {
            float angle = Mathf.Atan(rb.velocity.x/rb.velocity.y);
            //Debug.Log(angle);
            // Set new bullet speed at same outgoing angle
            rb.velocity = new Vector2(magnitude*Mathf.Sin(angle), magnitude*Mathf.Cos(angle));
        }
        */
        //Debug.Log(rb.velocity);
    }

    public override void DimensionInteraction(bool darken)
    {
        // do nothing lol
    }
}
