using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    public Transform spawner;
    public Rigidbody2D ball;
    public float forceX;
    public float forceY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "son")
        {
            Rigidbody2D newBall = Instantiate(ball, spawner.position, spawner.rotation);
            newBall.AddRelativeForce(new Vector2(forceX, forceY));
        }
        
    }
}
