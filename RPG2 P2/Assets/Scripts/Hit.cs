using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hit : MonoBehaviour
{
    public float Health;
    private string objectName;
    public AudioClip grunts;
    private void Start()
    {
        objectName = this.gameObject.name;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.tag == "damageSource")
        {
            Health--;
            Debug.Log(name + " hit, remaining health: " + Health);
            if (objectName == "Player1")
            {
                AudioSource.PlayClipAtPoint(grunts, this.transform.position);
            }
        }
    }

    private void Update()
    {
        if(objectName != "Player1" && Health <= 0)
        {
            SceneManager.LoadScene(7);
        }
        else if (objectName == "Player1" && Health <= 0)
        {
            SceneManager.LoadScene(8);
        }
    }
}
