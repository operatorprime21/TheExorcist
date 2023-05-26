using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorMove : MonoBehaviour
{
    public GameObject mainPlayer;
    public GameObject spiritPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spiritPlayer.transform.localPosition = mainPlayer.transform.localPosition;
    }
}
