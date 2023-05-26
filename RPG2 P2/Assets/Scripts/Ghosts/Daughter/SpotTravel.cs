using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotTravel : MonoBehaviour
{
    private Attack getFloor;
    public float projSpeed;
    private bool reached = false;
    private Animator corrupt;
    public RespectiveFloor findFloor;
    private GameObject realFloor;
    // Start is called before the first frame update
    void Start()
    {
        getFloor = GameObject.Find("Daughter").GetComponent<Attack>();
        corrupt = this.GetComponent<Animator>();
        findFloor = GameObject.Find(getFloor.floorName).GetComponent<RespectiveFloor>();
        realFloor = findFloor.physFloor;
    }

    // Update is called once per frame
    void Update()
    {
        if(reached == false)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, getFloor.floorToKill.position, projSpeed);
        }
        
        if(this.transform.position == getFloor.floorToKill.position)
        {
            reached = true;
            corrupt.SetTrigger("Corrupt");
        }
    }
    void BrokenFloor()
    {
        corrupt.SetTrigger("Corrupted");
        realFloor.SetActive(true);
        StartCoroutine(ReturnToNormal());
    }
    IEnumerator ReturnToNormal()
    {
        yield return new WaitForSeconds(5f);
        corrupt.SetTrigger("Uncorrupt");
    }

    void DestroyThis()
    {
        realFloor.SetActive(false);
        Destroy(gameObject);
    }
}
