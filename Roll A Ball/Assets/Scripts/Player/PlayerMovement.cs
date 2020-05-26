using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody rb;

    public float speed = 10;

    private int score;

    public TextMeshProUGUI text;


    void Start()
    {
        text = FindObjectOfType<TextMeshProUGUI>();
        rb = GetComponent<Rigidbody>();
      
      //  Debug.Log("Starting Pos");
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        UserInput();

        if (score >= 3)
        {

            text.SetText("You Win!"); 
        }

    }
    public void UserInput()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    public void Movement()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        Vector3 forceVector = new Vector3(horizontalAxis * speed, 0, verticalAxis * speed);
        rb.AddForce(forceVector);

        //Debug.Log("Current pos" + transform.position);


    }

    public void Jump()
    {

        Vector3 jumpVector = new Vector3(0, 200, 0);
        rb.AddForce(jumpVector);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "pickup")
        {

            score++;
            Debug.Log("Score is:" + score);

            Destroy(other.gameObject);

        }
    }

 

      

       
   
}
