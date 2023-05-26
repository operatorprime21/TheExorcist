using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonMove : MonoBehaviour
{
    private Animator son;
    public float moveSpeed;
    public List<Transform> waypoints = new List<Transform>();
    public Transform nextWP;
    public bool patrolling;
    public int randomWP;
    public int lastWP;
    private bool faceRight;
    // Start is called before the first frame update
    void Start()
    {
        faceRight = true;
        //son = this.GetComponent<Animator>();
        patrolling = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(patrolling == true)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, nextWP.position, moveSpeed);
        }

        if (this.transform.position.x < nextWP.position.x && faceRight == false)
        {
            Flip();
        }
        else if (this.transform.position.x > nextWP.position.x && faceRight == true)
        {
            Flip();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "waypoint")
        {
            Debug.Log("Run Delay");
            //son.SetTrigger("idle");
            lastWP = randomWP;
            StartCoroutine(DelayPatrol());
        }
    }
    void Shuffle()
    {
        randomWP = Random.Range(0, 13);
        nextWP = waypoints[randomWP];
        if (randomWP == lastWP)
        {
            Debug.Log("Reroll");
            StartCoroutine(DelayPatrol());
        }
        else if (randomWP != lastWP)
        {
            Debug.Log("Rolled new");
        }
        patrolling = true;
    }
    IEnumerator DelayPatrol()
    {
        yield return new WaitForSeconds(1f);
        patrolling = false;
        Shuffle();
    }
    void Flip()
    {
        faceRight = !faceRight;
        Vector2 bossScale = this.transform.localScale;
        bossScale.x = bossScale.x * -1;
        this.transform.localScale = bossScale;
    }
}
