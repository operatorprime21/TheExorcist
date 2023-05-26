using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool rest;
    private int floor;
    public List<Transform> floors = new List<Transform>();
    public Transform floorToKill;
    public GameObject darkSpot;
    public string floorName;
    private Animator safe;
    public GameObject flashlight1;
    public GameObject flashlight2;
    // Start is called before the first frame update
    void Start()
    {
        rest = true;
        safe = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rest == true)
        {
            StartCoroutine(RestPeriod());
        }
    }
    IEnumerator RestPeriod()
    {
        rest = false;
        yield return new WaitForSeconds(10f);
        flashlight1.SetActive(false);
        flashlight2.SetActive(false);
        safe.SetTrigger("attacking");
        rest = true;
        yield return new WaitForSeconds(3f);
        safe.SetTrigger("closing");
        yield return new WaitForSeconds(1f);
        flashlight1.SetActive(true);
        flashlight2.SetActive(true);
    }

    public void Pick()
    {
        safe.SetTrigger("opened");
        floor = Random.Range(0, 9);
        floorToKill = floors[floor];
        floorName = floorToKill.name;
        GameObject CorruptBullet = Instantiate(darkSpot, this.transform.position, this.transform.rotation);
    }

    public void CloseSafe()
    {
        safe.SetTrigger("idle");
    }

}
