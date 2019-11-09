using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraViewCtrl : MonoBehaviour
{
    public static CameraViewCtrl instance;
    public GameObject mainCamera; 
    public GameObject topCamera;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        topCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchCamera()
    {
        mainCamera.SetActive(!mainCamera.activeSelf);
        topCamera.SetActive(!topCamera.activeSelf);
    }
}
