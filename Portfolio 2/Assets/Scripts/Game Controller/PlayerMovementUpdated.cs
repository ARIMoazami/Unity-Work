using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementUpdated : MonoBehaviour
{
    public AudioClip shoutingClip;
    public float speedDampTime = 0.01f;
    public float sensitivityX = 1.0f;
    public Rigidbody rb;

    private Animator anim;
    private HashIDs hash;

    private float elapsedTime = 0;
    private bool noBackMov = true;

    void Awake()
    {
        anim = GetComponent<Animator>();
        anim.SetLayerWeight(1, 1f);
        hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        bool jump = Input.GetButton("Jump");
        bool sprint = Input.GetButton("Sprint");
        float mouseX = Input.GetAxis("Mouse X");

        Rotating(mouseX);
        MovementManager(v, sprint);
        JumpManager(v, h, jump);

        elapsedTime += Time.deltaTime;

        transform.Rotate(0, Input.GetAxis("Horizontal") * 120f * Time.deltaTime, 0);

    }

    void Update()
    {
        bool shout = Input.GetButtonDown("Attract");
        anim.SetBool(hash.shoutingBool, shout);
        AudioManagement(shout);


    }

    void MovementManager(float vertical, bool running)
    {
        anim.SetBool(hash.runningBool, running);

        if (vertical > 0)
        {
            anim.SetFloat(hash.speedFloat, 1.5f, speedDampTime, Time.deltaTime);
            anim.SetBool("Backwards", false);
            noBackMov = true;
        }

        if (vertical < 0)
        {
            if (noBackMov == true)
            {
                elapsedTime = 0;
                noBackMov = false;
            }

            anim.SetFloat(hash.speedFloat, -1.5f, speedDampTime, Time.deltaTime);
            anim.SetBool("Backwards", true);

            Rigidbody ourBody = this.GetComponent<Rigidbody>();
            float movement = Mathf.Lerp(0f, -0.050f, elapsedTime);
            Vector3 moveback = new Vector3(0.0f, 0.0f, movement);
            moveback = ourBody.transform.TransformDirection(moveback);
            ourBody.transform.position += moveback;
        }

        if (vertical == 0)
        {
            anim.SetFloat(hash.speedFloat, 0.01f);
            anim.SetBool(hash.backwardsBool, false);
            noBackMov = true;

        }
    }

    void JumpManager (float vertical, float horizontal, bool jumping)
    {
        
    }

    void Rotating (float mouseXInput)
    {
        //access the player rigidbody
        Rigidbody ourBody = this.GetComponent<Rigidbody>();

        //check to see if rotation data needs to be added
        if (mouseXInput != 0)
        {
            //if we are using mouseX value to make euler angle which provides rotation
            //in the y axis which is then turned to a quaternion
            Quaternion deltaRotation = Quaternion.Euler(0f, mouseXInput * sensitivityX, 0f);

            //applying to turn the avatar via the rigidbody
            ourBody.MoveRotation(ourBody.rotation * deltaRotation);
        }
    }

    void AudioManagement (bool shout)
    {
        if (anim.GetCurrentAnimatorStateInfo (0).IsName("Walk"))
        {
            //if footsteps are not playing
            if (!GetComponent<AudioSource>().isPlaying)
            {
                //play the footsteps
                GetComponent<AudioSource>().pitch = 0.27f;
                GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            GetComponent<AudioSource>().Stop();
        }

        if(shout)
        {
            //3D sound so play the shouting clip where we are
            AudioSource.PlayClipAtPoint(shoutingClip, transform.position);
        }
    }
}
