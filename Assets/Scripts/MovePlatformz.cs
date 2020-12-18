using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformz : MonoBehaviour
{

    public enum Direction {Horizontal, Vertical};

    public Direction direction;
    public float speed;
    public float distance;
    public float interval;

    private float currentDistance;

    private float initialPosition;
    private float currentPosition;

    private double initialTime;
    private double currentTime;

    // Start is called before the first frame update
    void Start()
    {
        if(direction == Direction.Horizontal){
            initialPosition = this.transform.position.x;
            currentPosition = initialPosition;
        }
        else{
            initialPosition = this.transform.position.y;
            currentPosition = initialPosition;
        }
        initialTime = Time.time;
        currentTime = Time.time;

        currentDistance = distance;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime - initialTime >= interval){
            if(currentPosition < initialPosition + currentDistance){
                
                if(direction == Direction.Horizontal){
                    this.transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
                    currentPosition = this.transform.position.x;
                }
                else if(direction == Direction.Vertical){
                    this.transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
                    currentPosition = this.transform.position.y;
                }

                if(currentPosition >= initialPosition + currentDistance){
                    initialTime = currentTime;
                    //initialPosition = currentPosition;
                    currentDistance = 0;
                }

            }
            else if(currentPosition > initialPosition){

                if(direction == Direction.Horizontal){
                    this.transform.position -= new Vector3(1, 0, 0) * speed * Time.deltaTime;
                    currentPosition = this.transform.position.x;
                }
                else if(direction == Direction.Vertical){
                    this.transform.position -= new Vector3(0, 1, 0) * speed * Time.deltaTime;
                    currentPosition = this.transform.position.y;
                }

                if(currentPosition <= initialPosition){
                    initialTime = currentTime;
                    currentDistance = distance;
                }

            }

        }
    }
}
