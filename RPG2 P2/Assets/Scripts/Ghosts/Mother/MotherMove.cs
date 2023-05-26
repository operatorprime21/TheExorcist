using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherMove : MonoBehaviour
{
    public Transform player2;
    public float flySpeed;
    public List<Transform> waypoints = new List<Transform>();
    private bool inCooldown;
    private int randomLoc;
    private Transform location;
    // Start is called before the first frame update
    void Start()
    {
        inCooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inCooldown == false)
        {
            Teleport();
        }
        this.transform.position = location.position;
    }

    void Teleport()
    {
        inCooldown = true;
        randomLoc = Random.Range(0, 5);
        location = waypoints[randomLoc];
        StartCoroutine(CooldownTime());
    }
    IEnumerator CooldownTime()
    {
        yield return new WaitForSeconds(10f);
        inCooldown = false;
    }
}
