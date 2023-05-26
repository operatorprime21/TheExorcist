using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class camSwitch : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;

    public GameObject player1;
    public GameObject player2;
    public GameObject center1;

    private int camState = 0;
    private bool midAnim = false;
    public float x1;
    public float x2;
    public Animator blink;
    public Light2D light1;
    public Light2D light2;
    public Light2D flashlight;
    public float light1Intense;
    public float light2Intense;

    public bool forceCD;
    // Start is called before the first frame update
    void Start()
    {
        cam1.rect = new Rect(-0.5f, 0f, 1f, 1f);
        cam2.rect = new Rect(0.5f, 0f, 1f, 1f);
        camState = 0;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (forceCD == false)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && camState == 0 && midAnim == false)
            {
                ChangeToLeft();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && camState == 0 && midAnim == false)
            {
                x1 = -1f;
                x2 = 0f;
                StartCoroutine(ChangeScreen());
                camState = 1;
                center1.GetComponent<MirrorMove>().enabled = false;
                player1.GetComponent<Movement>().enabled = false;
                player2.GetComponent<SpiritMoveSolo>().enabled = true;
                light1Intense = 0f;
                light2Intense = 1.5f;
                Debug.Log(camState);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && camState < 0 && midAnim == false)
            {
                Debug.Log(camState);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && camState > 0 && midAnim == false)
            {
                Debug.Log(camState);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && camState > 0 && midAnim == false)
            {
                ChangeToMid();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && camState < 0 && midAnim == false)
            {
                ChangeToMid();
            }
        }
    }
    IEnumerator ChangeScreen()
    {
        midAnim = true;
        blink.SetTrigger("Blink");
        yield return new WaitForSeconds(2f);
        blink.SetTrigger("Idle");
        midAnim = false;
    }

    public void ChangeViewpoint()
    {
        cam1.rect = new Rect(x1, 0f, 1f, 1f);
        cam2.rect = new Rect(x2, 0f, 1f, 1f);
        light1.intensity = light1Intense;
        light2.intensity = light2Intense;
    }

    public void ChangeToMid()
    {
        x1 = -0.5f;
        x2 = 0.5f;
        StartCoroutine(ChangeScreen());
        camState = 0;
        center1.GetComponent<MirrorMove>().enabled = true;
        player1.GetComponent<Movement>().enabled = true;
        player2.GetComponent<SpiritMoveSolo>().enabled = false;
        light1Intense = 0.7f;
        light2Intense = 0.7f;
        flashlight.intensity = 0.2f;
        Debug.Log(camState);
    }

    public void ChangeToLeft()
    {
        x1 = 0f;
        x2 = 1f;
        StartCoroutine(ChangeScreen());
        camState = -1;
        center1.GetComponent<MirrorMove>().enabled = true;
        player1.GetComponent<Movement>().enabled = true;
        player2.GetComponent<SpiritMoveSolo>().enabled = false;
        light1Intense = 1.5f;
        light2Intense = 0f;
        flashlight.intensity = 1.5f;
        Debug.Log(camState);
    }
    public void DoCooldown()
    {
        StartCoroutine(SwitchCooldown());
    }
    public IEnumerator SwitchCooldown()
    {
        Debug.Log("Forced out");
        forceCD = true;
        yield return new WaitForSeconds(10f);
        forceCD = false;
    }
}
