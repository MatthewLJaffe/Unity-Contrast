using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDestroy : MonoBehaviour
{
    [SerializeField] private GameObject destroy;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(destroy);
    }
}
