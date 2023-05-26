using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public GameObject hitbox;
    public Animator attack;
    private bool cd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cd == true)
        {
            StartCoroutine(Countdown());
        }
    }
    IEnumerator DoDamage()
    {
        hitbox.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        hitbox.SetActive(false);
        cd = true;
    }
    IEnumerator Countdown()
    {
        cd = false;
        yield return new WaitForSeconds(10f);
        attack.SetTrigger("bite");
    }
    void SetIdle()
    {
        attack.SetTrigger("idle");
    }
}
