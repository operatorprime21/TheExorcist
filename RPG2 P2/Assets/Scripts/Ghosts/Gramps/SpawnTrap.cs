using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrap : MonoBehaviour
{
    public GameObject grampsHead;

    void Start()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
        GameObject gramps = Instantiate(grampsHead, new Vector3(this.transform.position.x - 40f, this.transform.position.y, this.transform.position.z), this.transform.rotation);
    }
}
