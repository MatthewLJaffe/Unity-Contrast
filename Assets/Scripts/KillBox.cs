using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : ResetLevel
{
      
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("collision");
        if (collision.gameObject.CompareTag("Player"))
            Restart();
    }
}
