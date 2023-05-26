using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMove : MonoBehaviour
{
    public Transform player2;

    public float flySpeed;
    private bool tracking;
    private bool faceRight;
    // Start is called before the first frame update
    void Start()
    {
        faceRight = false;
        tracking = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (tracking == true)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, player2.position, flySpeed);
        }
        if (this.transform.position.x < player2.position.x && faceRight == false)
        {
            Flip();
        }
        else if (this.transform.position.x > player2.position.x && faceRight == true)
        {
            Flip();
        }
    }
    IEnumerator Stop()
    {
        tracking = false;
        yield return new WaitForSeconds(2.5f);
        tracking = true;
    }

    public void StopMove()
    {
        StartCoroutine(Stop());
    }

    void Flip()
    {
        faceRight = !faceRight;
        Vector2 bossScale = this.transform.localScale;
        bossScale.x = bossScale.x * -1;
        this.transform.localScale = bossScale;
    }

}
