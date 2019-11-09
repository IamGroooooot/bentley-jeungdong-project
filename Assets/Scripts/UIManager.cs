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
        Debug.Log(showProjectedAnchor);
    }

    public void onToggleShowCircularRange()
    {
        ShowCircularRange = !ShowCircularRange;
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
