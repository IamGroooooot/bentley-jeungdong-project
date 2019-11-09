using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject SettingPanel;
    public GameObject SettingBtn;

    public bool showProjectedAnchor = false;
    public bool ShowCircularRange = false;
    public bool showKg = false;
    public bool enableTopView = false;

    public LayerMask defaultMask;
    public LayerMask kgMask;
    public LayerMask projectedMask;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        SettingPanel = GameObject.FindGameObjectWithTag("Setting");
        SettingPanel.SetActive(false);
        SettingBtn = GameObject.FindGameObjectWithTag("SettingBtn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onSettingBtnClicked()
    {
        if (SettingPanel.activeSelf)
        {
            SettingPanel.SetActive(false);
        }
        else
        {
            SettingPanel.SetActive(true);
        }
    }

    public void onToggleShowProjectedAnchor()
    {
        showProjectedAnchor = !showProjectedAnchor;
        if (showProjectedAnchor)
            CameraViewCtrl.instance.mainCamera.GetComponent<Camera>().cullingMask = projectedMask;
        else
            CameraViewCtrl.instance.mainCamera.GetComponent<Camera>().cullingMask = defaultMask;
        Debug.Log(showProjectedAnchor);
    }

    public void onToggleShowCircularRange()
    {
        ShowCircularRange = !ShowCircularRange;
        if(ShowCircularRange)
            CameraViewCtrl.instance.topCamera.GetComponent<Camera>().cullingMask = kgMask;
        else
            CameraViewCtrl.instance.topCamera.GetComponent<Camera>().cullingMask = defaultMask;
        Debug.Log(ShowCircularRange);
    }

    public void onToggleShowKg()
    {
        showKg = !showKg;
        Debug.Log(showKg);
    }

    public void onToggleTopView()
    {
        CameraViewCtrl.instance.SwitchCamera();
        enableTopView = !enableTopView;
        Debug.Log(enableTopView);
    }
}
