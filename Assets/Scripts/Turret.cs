using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Turret : MonoBehaviour, IDimensionInteraction
{
    [SerializeField] private GameObject darkBullet;
    [SerializeField] private GameObject lightBullet;
    [SerializeField] private float shootCooldown;
    [SerializeField] private GameObject shootPoint;
    private bool canShoot = true;
    private GameObject activeBullet;
    private Animator animator;

    private void Awake() {
        activeBullet = darkBullet;
        ChangeDimension.OnDimensionChange += DimensionInteraction;
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if(canShoot)
            StartCoroutine(ShootBullet());
    }

    public void DimensionInteraction(bool darken)
    {
        if (darken)
            activeBullet = lightBullet;
        else
            activeBullet = darkBullet;
    }

    private IEnumerator ShootBullet()
    {
        AudioManager.instance.Play("Shoot");
        canShoot = false;
        animator.SetBool("Shooting", true);
        StartCoroutine(ResetAnimation());
        Instantiate(activeBullet, shootPoint.transform.position, shootPoint.transform.rotation);
        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
        
    }
    private IEnumerator ResetAnimation()
    {
        yield return new WaitForSeconds(.5f);
        animator.SetBool("Shooting", false);
    }

}
