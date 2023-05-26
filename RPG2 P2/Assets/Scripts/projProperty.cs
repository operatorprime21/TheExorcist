using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projProperty : MonoBehaviour
{
    public GameObject player;
    public float direction;
    private float speed;
    private SpiritMoveSolo direc;
    private string projDirec;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.1f;
        direc = player.GetComponent<SpiritMoveSolo>();
        direction = player.transform.localScale.x;
        this.transform.localScale = player.transform.localScale;
        projDirec = direc.facing;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 projectilePos = this.transform.position;
        
        if (projDirec == "left" || projDirec == "right")
        {
            projectilePos.x = projectilePos.x + speed * direction;
            this.transform.position = projectilePos;
        }
        else if (projDirec == "front")
        {
            projectilePos.y = projectilePos.y - speed;
            this.transform.position = projectilePos;
        }
        else if (projDirec == "back")
        {
            projectilePos.y = projectilePos.y + speed; 
            this.transform.position = projectilePos;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Player")
        {
            Destroy(gameObject);
        }
        
    }
}
