using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static float movementSpeed = 5;
    public float maxSpeed = 15;


    public float leftRightSpeed = 4;
    private int desiredLane = 1; //0= left, 1= center, 2= right
    public float laneDistance = 4f; //distance between lanes in game



    public GameObject playerAnim;
    public Rigidbody rbody;
    [SerializeField] private float jumpingPower = 6f;
    static public bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
         
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed, Space.World); //translates the character to forward according to movement speed



        //increase speed over time
        if (movementSpeed < maxSpeed)
            movementSpeed += 0.1f * Time.deltaTime;




        
        

            if (SwipeManager.swipeRight)
            {
                if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
                {
                    desiredLane++;
                    if (desiredLane == 3)
                    {
                        desiredLane = 2;
                    }
                }
            }
            else if (SwipeManager.swipeLeft)
            {
                if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
                {
                    desiredLane--;
                    if (desiredLane == -1)
                    {
                        desiredLane = 0;
                    }
                }
            }
            if (SwipeManager.swipeUp && isGrounded)
            {
                
                rbody.velocity = Vector3.zero;
                rbody.velocity = Vector3.up * jumpingPower;
                Debug.Log("Jumping worked...");
                playerAnim.GetComponent<Animator>().Play("Jump");
                isGrounded = false;


            }
        

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, leftRightSpeed * Time.deltaTime);
    }
}