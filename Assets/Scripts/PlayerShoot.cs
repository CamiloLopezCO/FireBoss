using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    PlayerControls controls;
    public Animator animator;
    public GameObject bullet;
    public Transform bulletHole;
    public float force = 200;

    void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();

        controls.Land.Shoot.performed += ctx => Fire();
    }

    void Fire()
    {
        animator.SetTrigger("shoot");
        GameObject go = Instantiate(bullet, bulletHole.position, bullet.transform.rotation);

        if (GetComponent<PlayerMovement>().isFacingRight)
            go.GetComponent<Rigidbody2D>().AddForce(Vector2.right * force);
        else
            go.GetComponent<Rigidbody2D>().AddForce(Vector2.left * force);
        AudioManager.instance.Play("Shoot");
    }
}
