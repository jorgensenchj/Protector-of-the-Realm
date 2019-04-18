using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed = 6f;
    public float v;
    Vector3 movement;                  
    public Animator anim;                    
    Rigidbody playerRigidbody;
    public bool Running;
    public float Lookspeed;
    public bool WeaponInHand;

    //Test

    // Use this for initialization
    void Start ()
    {
        //change

        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    void FixedUpdate()

    {
        WeaponInHand = GetComponent<PlayerAttack>().armed;
        // Generate a plane that intersects the transform's position with an upwards normal.
        Plane playerPlane = new Plane(Vector3.up, transform.position);

        // Generate a ray from the cursor position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Determine the point where the cursor ray intersects the plane.
        // This will be the point that the object must look towards to be looking at the mouse.
        // Raycasting to a Plane object only gives us a distance, so we'll have to take the distance,
        //   then find the point along that ray that meets that distance.  This will be the point
        //   to look at.
        float hitdist = 0.0f;
        // If the ray is parallel to the plane, Raycast will return false.
        if (playerPlane.Raycast(ray, out hitdist))
        {
            // Get the point along the ray that hits the calculated distance.
            Vector3 targetPoint = ray.GetPoint(hitdist);

            // Determine the target rotation.  This is the rotation if the transform looks at the target point.
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Lookspeed * Time.deltaTime);
        }
    }


    void Update ()
    {
     


        Moveing();
        if (v > 0)
        {
            Running = true;
        }
        else
        if (v <= 0)
        {
            Running = false;
        }
        if (WeaponInHand == true)
        {


            if (Input.GetMouseButtonDown(0) && Running == false)
            {
                Attack();

            }

            if (Input.GetMouseButtonDown(1) && Running == false)
            {
                AttackTwo();

            }
        }
      
    }

    private void Moveing()
    {
        float h = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        v = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, 0, 0);
        transform.Translate(0, 0, v);
        
        Animating(h, v);
       
    }

    void Animating(float h, float v)
    {
        // Create a boolean that is true if either of the input axes is non-zero.
        bool Running = h != 0f || v != 0f;

        // Tell the animator whether or not the player is walking.
        anim.SetBool("Running", Running);
    }
    void Attack()
    {
        if (Running == false)
        {
            anim.SetTrigger("Attack");
            
        }

    }
    void AttackTwo()
    {
        if (Running == false)
        {
            anim.SetTrigger("Attack2");
            
        }


    }
}
