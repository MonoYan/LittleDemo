using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class ButtonStart : MonoBehaviour
{
    public GameObject mainCamera, cameraMoveTarget, firstLaunchCanvas, dialogSystem;
    [HideInInspector] public bool isClick, firstLaunch;

    void Start()
    {
        
    }
    void Update()
    {
        FirstLunch();
    }

    public void Click_Start() {
        isClick = true;
    }

    public void Click_Quit() {
        Application.Quit();
    }

    void FirstLunch() {
        if (isClick)
        {
            Time.timeScale = 1;
            dialogSystem.SetActive(true);
            mainCamera.GetComponent<CinemachineVirtualCamera>().Follow = cameraMoveTarget.transform;
            firstLaunchCanvas.SetActive(false);
            firstLaunch = true;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
}
