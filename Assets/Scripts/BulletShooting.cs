using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject firePoint;

    Animator animator;

    public bool fireForward = true;
    public float bulletForce = 1500.0f;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput > 0)
        {
            fireForward = true;
        }
        else if (horizontalInput < 0)
        {
            fireForward = false;
        }

        if (Input.GetButton("Fire1"))
        {
            animator.SetTrigger("IsAttack");
            FireBullet();
        }
    }
    void FireBullet()
    {
        // Bullet instantiate at the position of GameObject
        GameObject newBullet = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation) as GameObject;

        // get Rigidbody2D component of instantiated Bullet and control
        Rigidbody2D tempRigidBody = newBullet.GetComponent<Rigidbody2D>();

        // push the Bullet forward by amount bulletForce
        if (fireForward)
        {
            // fireForward is fire to the right
            tempRigidBody.AddForce(transform.right * bulletForce);
        }
        else
        {
            // fire left, a.k.a. "negative right"
            tempRigidBody.AddForce(-transform.right * bulletForce);
        }

        // basic Clean Up, set Bullets to self destruct after 5 seconds
        Destroy(newBullet, 5.0f);
    }
}
