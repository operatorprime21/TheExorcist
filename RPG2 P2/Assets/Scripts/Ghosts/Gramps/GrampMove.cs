using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrampMove : MonoBehaviour
{
    private Animator gramps;
    public float moveSpeed;
    public float speedMultiplier;
    public List<Transform> waypoints = new List<Transform>();
    public Transform nextWP;
    public bool patrolling;
    public int randomWP;
    public int lastWP;
    private bool needToReroll;
    private bool inCooldown;
    private bool faceRight;
    public GameObject puddle;
    // Start is called before the first frame update
    void Start()
    {
        //gramps = this.GetComponent<Animator>();
        patrolling = true;
        needToReroll = false;
        inCooldown = false;
        faceRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (patrolling == true)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, nextWP.position, moveSpeed);
        }

        if(needToReroll == true)
        {
            Shuffle();
        }

        if (inCooldown == false)
        {
            StartCoroutine(Attack());
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
        if (other.tag == "waypoint" && needToReroll == false)
        { 
            lastWP = randomWP;
            Shuffle();
        }
    }
    void Shuffle()
    {
        randomWP = Random.Range(0, 8);
        nextWP = waypoints[randomWP];
        if (randomWP == lastWP)
        {
            Debug.Log("Reroll");
            needToReroll = true;
        }
        else if (randomWP != lastWP)
        {
            Debug.Log("Rolled new");
            needToReroll = false;
        }
    }

    IEnumerator Attack()
    {
        inCooldown = true;
        for(int i = 0; i < 10; i++)
        {
            GameObject trap = Instantiate(puddle, this.transform.position, this.transform.rotation);
            Debug.Log(i);
            yield return new WaitForSeconds(1f);
            if(i == 9)
            {
                yield return new WaitForSeconds(10f);
                inCooldown = false;
            }
        }
    }

    void Flip()
    {
        faceRight = !faceRight;
        Vector2 bossScale = this.transform.localScale;
        bossScale.x = bossScale.x * -1;
        this.transform.localScale = bossScale;
    }
}
