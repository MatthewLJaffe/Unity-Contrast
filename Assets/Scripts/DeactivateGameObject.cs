using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateGameObject : MonoBehaviour
{
    public float deactivationTime = 100;
    private double initialTime;
    private double currentTime;
    // Start is called before the first frame update
    void Start(){
        initialTime = Time.time;
        currentTime = initialTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= initialTime + deactivationTime){
            this.gameObject.SetActive(false);
        }
    }
}
