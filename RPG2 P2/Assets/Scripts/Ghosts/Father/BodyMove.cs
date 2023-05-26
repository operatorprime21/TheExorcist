using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMove : MonoBehaviour
{
    public Transform player;
    public Transform hoverHeight;
    private Vector3 hoverPos;
    private float playerX;
    private float hoverX;
    public float flySpeed;
    public float dropSpeed;
    private bool following;
    private HeadMove touch;
    private bool faceRight;
    public AudioClip thud;
    // Start is called before the first frame update
    void Start()
    {
        faceRight = false;
        following = true;
        touch = GameObject.Find("Head").GetComponent<HeadMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (following == true)
        {
            hoverPos.y = hoverHeight.position.y;
            hoverPos.x = player.position.x;
        }
        this.transform.position = Vector3.MoveTowards(this.transform.position, hoverPos, flySpeed);
        if (this.transform.position == hoverPos && following == true)
        {
            StartCoroutine(DropDown());
            touch.StopMove();
        }
        if (this.transform.position.x < hoverPos.x && faceRight == false)
        {
            Flip();
        }
        else if (this.transform.position.x > hoverPos.x && faceRight == true)
        {
            Flip();
        }

    }
    IEnumerator DropDown()
    {
        following = false;
        hoverPos.y = player.position.y + 1f;
        flySpeed = flySpeed * 10f;
        yield return new WaitForSeconds(1f);
        AudioSource.PlayClipAtPoint(thud, this.transform.position);
        yield return new WaitForSeconds(1f);
        
        hoverPos.y = hoverHeight.position.y;
        yield return new WaitForSeconds(0.5f);
        flySpeed = flySpeed / 10f;
        following = true;
    }

    void Flip()
    {
        faceRight = !faceRight;
        Vector2 bossScale = this.transform.localScale;
        bossScale.x = bossScale.x * -1;
        this.transform.localScale = bossScale;
    }
}
