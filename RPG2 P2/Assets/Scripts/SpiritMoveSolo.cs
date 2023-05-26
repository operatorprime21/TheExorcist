using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritMoveSolo : MonoBehaviour
{

    public float moveSpeed;
    public Animator p2;
    public string facing;
    public bool moving;
    private bool facingRight;
    public GameObject projectile;
    public GameObject player1;
    private camSwitch returnToReal;
    void Awake()
    {
        facing = "front";
        moving = false;
        facingRight = true;
        returnToReal = GameObject.Find("Canvas/RawImage").GetComponent<camSwitch>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        PlayAnimation();
        if(Input.GetKeyDown(KeyCode.Mouse0) && (facing == "right" || facing == "left"))
        {
            GameObject proj = Instantiate(projectile, new Vector2(this.transform.position.x + 0.3f, this.transform.position.y + 0.3f), this.transform.rotation);
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && (facing == "front") && facingRight == true)
        {
            GameObject proj = Instantiate(projectile, new Vector2(this.transform.position.x -0.2f, this.transform.position.y + 0.12f), Quaternion.Euler(0f, 0f, 270f));
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && (facing == "front") && facingRight == false)
        {
            GameObject proj = Instantiate(projectile, new Vector2(this.transform.position.x + 0.2f, this.transform.position.y + 0.12f), Quaternion.Euler(0f, 0f, 90f));
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && (facing == "back") && facingRight == true)
        {
            GameObject proj = Instantiate(projectile, new Vector2(this.transform.position.x + 0.2f, this.transform.position.y + 0.12f), Quaternion.Euler(0f, 0f, -270f));
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && (facing == "back") && facingRight == false)
        {
            GameObject proj = Instantiate(projectile, new Vector2(this.transform.position.x - 0.2f, this.transform.position.y + 0.12f), Quaternion.Euler(0f, 0f, -90f));
        }

        float distanceX = this.transform.localPosition.x - player1.transform.localPosition.x;
        float distanceY = this.transform.localPosition.y - player1.transform.localPosition.y;
        float distance = Mathf.Sqrt(distanceX * distanceX + distanceY + distanceY);
        if(distance > 5f)
        {
            returnToReal.ChangeToLeft();
            returnToReal.DoCooldown();
        }
    }

    public void Move()
    {
        Vector3 playerPos = this.transform.position;

        if (Input.GetKey(KeyCode.W))
        {
            playerPos.y = playerPos.y + moveSpeed;
            this.transform.position = playerPos;
            facing = "back";
            moving = true;
            p2.SetTrigger("WalkBack");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            playerPos.y = playerPos.y - moveSpeed;
            this.transform.position = playerPos;
            facing = "front";
            moving = true;
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
            p2.SetTrigger("WalkSide");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            playerPos.x = playerPos.x - moveSpeed;
            this.transform.position = playerPos;
            facing = "left";
            moving = true;
            if (facingRight == true)
            {
                Flip();
            }
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
            p2.SetTrigger("idleFront");
        }
        else if (moving == false && facing == "back")
        {
            p2.SetTrigger("idleBack");
        }
        else if (moving == false && facing == "right")
        {
            p2.SetTrigger("idleSide");
        }
        else if (moving == false && facing == "left")
        {
            p2.SetTrigger("idleSide");
        }

    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector2 playerScale = this.transform.localScale;
        playerScale.x = playerScale.x * -1;
        this.transform.localScale = playerScale;
    }
}
