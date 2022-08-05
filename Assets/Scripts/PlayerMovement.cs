using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public GameManager gm;
    public Rigidbody rb;

    public AudioSource sourceSound;
    public AudioClip crashSound;

    public AudioSource engineSource;
    public AudioSource fireSource;

    public float runSpeed;
    public float strefeSpeed;
    public float jumpForce;
    private float maxSpeed = 90f;

    protected bool doJump = false;


    void Start()
    {

        Time.timeScale = 1;
        StartCoroutine(SpeedIncrease());
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            gm.EndGame();
            sourceSound.PlayOneShot(crashSound);
            engineSource.Stop();
            fireSource.Stop();
        }
    }


    void Update()
    {

        if (Input.GetKey("space"))
        {
            doJump = true;
        }

        //Fall
        if (transform.position.y < -20)
        {
            gm.EndGame();
            engineSource.Stop();
            fireSource.Stop();
        }


        //Rotate
        if (transform.position.y > 1)
        {
            var z = UnityEditor.TransformUtils.GetInspectorRotation(rb.transform).z;
            if (z > 100 || z < -100)
            {
                gm.EndGame();
            }
        }
    }
    

    

    void FixedUpdate()
    {

        //rb.MovePosition(transform.position + Vector3.forward * runSpeed * Time.deltaTime);

        //rb.AddForce(0, 0, runSpeed * Time.deltaTime, ForceMode.VelocityChange);

        transform.Translate(Vector3.forward * Time.deltaTime * runSpeed);

        if (doJump)
        {

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            doJump = false;

        }
    }

    private IEnumerator SpeedIncrease()
    {
        yield return new WaitForSeconds(6);
        if (runSpeed < maxSpeed)
        {
            runSpeed += 3;
            StartCoroutine(SpeedIncrease());
        }
    }
}
