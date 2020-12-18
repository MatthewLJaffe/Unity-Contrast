using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IDimensionInteraction
{
    [SerializeField] private float liveTime;
    [SerializeField] private float speed;
    [SerializeField] private bool isDark;
    protected Rigidbody2D rb;
    private Vector2 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ChangeDimension.OnDimensionChange += DimensionInteraction;
    }
    private void OnDestroy()
    {
        ChangeDimension.OnDimensionChange -= DimensionInteraction;
    }
    private void Start() {
        float zRot = transform.rotation.eulerAngles.z;
        //Debug.Log(zRot);
        if (zRot <= 45)
            moveDirection = Vector2.left;
        else if (zRot > 45 && zRot < 135)
            moveDirection = Vector2.up;
        else if (Mathf.Abs(zRot) > 135 && Mathf.Abs(zRot) < 225)
            moveDirection = Vector2.right;
        else
            moveDirection = Vector2.down;


        StartCoroutine(KillBullet());
        rb.velocity = moveDirection * speed;
    }

    private IEnumerator KillBullet() {
        yield return new WaitForSeconds(liveTime);
        Destroy(gameObject);
    }

    public virtual void DimensionInteraction(bool darken) {
        if (isDark == darken)
            Destroy(gameObject);
    }
}
