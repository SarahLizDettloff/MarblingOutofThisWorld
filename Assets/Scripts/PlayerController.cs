using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour {
    public float speed;
    public float maxSpeed;
    public float acceleration;
    public float deceleration;
    private Rigidbody rb;
    private int count;
    public Text countText;
    public Text winText;
    public MoonScript attractorMoon;
    private Transform playerTransform;
    public AudioSource audioPickup;
    public AudioSource audioSuccess;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        winText.text = "";

        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        playerTransform = transform;
    }
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(moveHorizontal, 0, moveVertical).normalized;

    }

    void FixedUpdate ()
    {

        if (attractorMoon)
        {
            attractorMoon.Attract(playerTransform);
        }

        if ((Input.GetKey("left") || Input.GetKey("right") || Input.GetKey("up") || Input.GetKey("down")) && (speed < maxSpeed))
        {
            speed = speed + acceleration * Time.deltaTime;
        }
        else
        {
            if (speed > deceleration * Time.deltaTime)
            {
                speed = speed - deceleration * Time.deltaTime;
            }
            else if (speed < -deceleration * Time.deltaTime)
            {
                speed = speed + deceleration * Time.deltaTime;
            }
            else
            {
                speed = 0;
            }
        }

        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        rb.MovePosition(rb.position + transform.TransformDirection(movement) * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("PickUp"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            
            SetCountText();
            audioPickup.Play();
        }
    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
        if (count >= 101)
        {
            winText.text = "Whoa! You won!";
            audioSuccess.Play();
        }
    }
}
