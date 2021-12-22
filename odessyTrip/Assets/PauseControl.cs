using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public GameObject pauseManagement;

    public Canvas pauseCanvas;
    void Start()
    {
        pauseManagement.SetActive(false);
        pauseCanvas.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftAlt)||Input.GetKeyDown(KeyCode.RightAlt))
        {
            pauseManagement.SetActive(true);
             pauseCanvas.enabled=true;
        }
    }
}
