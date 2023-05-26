using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject player2;
    public GameObject flashLight;
    public float moveSpeed = 0.2f;
    public Animator p1;
    public Animator p2;
    private string facing;
    public bool moving;
    private bool facingRight;
    public AudioClip footstep;

    void Start()
    {
        facing = "front";
        moving = false;
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        PlayAnimation();
        
    }

    void PlayFootstep()
    {
        AudioSource.PlayClipAtPoint(footstep, this.transform.position);
    }
    public void Move()
    {
        Vector3 playerPos = this.transform.position;
        
        if (facing == "left")
        {
            
            Quaternion rotation = Quaternion.Euler(0, 0, 90);
            flashLight.transform.rotation = rotation;
            flashLight.transform.localPosition = new Vector3(0.2671f, 0.268f, 0f);
        }
        else if (facing == "front")
        {
            Quaternion rotation = Quaternion.Euler(0, 0, 180);
            flashLight.transform.rotation = rotation;
            flashLight.transform.localPosition = new Vector3(-0.1996f, 0.2092f, 0f);
        }
        else if (facing == "back")
        {
            Quaternion rotation = Quaternion.Euler(0, 0, 0);
            flashLight.transform.rotation = rotation;
            flashLight.transform.localPosition = new Vector3(0.256f, 0.19f, 0f);
        }
        else if (facing == "right")
        {
            Quaternion rotation = Quaternion.Euler(0, 0, 270);
            flashLight.transform.rotation = rotation;
            flashLight.transform.localPosition = new Vector3(0.2671f, 0.268f, 0f);
        }




        if (Input.GetKey(KeyCode.W))
        {
            playerPos.y = playerPos.y + moveSpeed;
            this.transform.position = playerPos;
            facing = "back";
            moving = true;
            p1.SetTrigger("WalkBack");
            p2.SetTrigger("WalkBack");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            playerPos.y = playerPos.y - moveSpeed;
            this.transform.position = playerPos;
            facing = "front";
            moving = true;
            p1.SetTrigger("WalkFront");
            p2.SetTrigger("WalkFront");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerPos.x = playerPos.x + moveSpeed;
            this.transform.position = playerPos;
            facing = "right";
            moving = true;
            if (facingRight == false)
            {
                Flip();
            }
            p1.SetTrigger("WalkSide");
            p2.SetTrigger("WalkSide");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            playerPos.x = playerPos.x - moveSpeed;
            this.transform.position = playerPos;
            facing = "left";
            moving = true;
            if(facingRight == true)
            {
                Flip();
            }    
            p1.SetTrigger("WalkSide");
            p2.SetTrigger("WalkSide");
        }
        else
        {
            moving = false;
        }
           
    }

    void PlayAnimation()
    {
        if (moving == false && facing == "front")
        {
            p1.SetTrigger("idleFront");
            p2.SetTrigger("idleFront");
        }
        else if (moving == false && facing == "back")
        {
            p1.SetTrigger("idleBack");
            p2.SetTrigger("idleBack");
        }
        else if (moving == false && facing == "right")
        {
            p1.SetTrigger("idleSide");
            p2.SetTrigger("idleSide");
        }
        else if (moving == false && facing == "left")
        {
            p1.SetTrigger("idleSide");
            p2.SetTrigger("idleSide");
        }

    }
    void Flip()
    {
       facingRight =! facingRight;
       Vector2 playerScale = this.transform.localScale;
       Vector2 player2Face = this.transform.localScale;
       playerScale.x = playerScale.x * -1;
       player2Face.x = player2Face.x * -1;
       this.transform.localScale = playerScale;
       player2.transform.localScale = player2Face; 
    }

}
