using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneCtrl : MonoBehaviour
{
    private Transform crane; //used in moving front and back
    private GameObject upPivot; //used in moving right and left
    private GameObject pickerPivot; // used in moving picker  - spin down
    private GameObject picker;
    private Transform btmMovable;
    private Transform pickerPosition;

    private float anchor = 10f;

    public bool turnRight = false;
    public bool turnLeft = false;

    public bool pickerDown = false;
    public bool pickerUp = false;

    public bool anchorUp = false;
    public bool anchorDown = false;

    public float turnSpeed = 50f;
    public float spinSpeed = 20f;
    public float anchorSpeed = 10f;



    // Use this for initialization
    private void Start()
    {
        crane = transform;
        upPivot = transform.GetChild(1).gameObject;
        //upPivot = GameObject.FindGameObjectWithTag("UpPivot");
        pickerPivot = upPivot.transform.GetChild(0).gameObject;
        //pickerPivot = GameObject.FindGameObjectWithTag("PickerPivot");
        picker = pickerPivot.transform.GetChild(0).gameObject;
        //picker = GameObject.FindGameObjectWithTag("Picker");
        pickerPosition = pickerPivot.transform.GetChild(1);
        //pickerPosition = GameObject.FindGameObjectWithTag("PickerPosition").transform;
        btmMovable = transform.GetChild(0);
        //btmMovable = GameObject.FindGameObjectWithTag("BottomMovable").transform;

    }

    // Update is called once per frame
    private void Update()
    {
        TurnCtrl();
        PickerRotationCtrl();
        AnchorCtrl();



    }

    void TurnCtrl()
    {
        if (turnRight || Input.GetKey(KeyCode.RightArrow))
        {
            turnLeft = false;
            upPivot.transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
        }

        if (turnLeft || Input.GetKey(KeyCode.LeftArrow))
        {
            turnRight = false;
            upPivot.transform.Rotate(Vector3.up * -turnSpeed * Time.deltaTime);
        }
    }

    void PickerRotationCtrl()
    {
        // get rotation vector
        Vector3 dirVector = Vector3.Cross(Vector3.up, (btmMovable.transform.localPosition - picker.transform.localPosition)).normalized;

        if (pickerDown || Input.GetKey(KeyCode.UpArrow))
        {
            pickerUp = false;
            pickerPivot.transform.Rotate(dirVector * -spinSpeed * Time.deltaTime);

        }
        if (pickerUp || Input.GetKey(KeyCode.DownArrow))
        {
            pickerDown = false;
            pickerPivot.transform.Rotate(dirVector * spinSpeed * Time.deltaTime);
        }
    }

    void AnchorCtrl()
    {
        // look down
        //picker.transform.rotation = Quaternion.LookRotation(Vector3.left, Vector3.right);
        if (anchorUp || Input.GetKey(KeyCode.F1))
        {
            anchor -= anchorSpeed * Time.deltaTime;
        }
        if (anchorDown || Input.GetKey(KeyCode.F2))
        {
            anchor += anchorSpeed * Time.deltaTime;
        }

        // fix pos
        picker.transform.position = new Vector3(pickerPosition.position.x, pickerPosition.position.y - anchor, pickerPosition.position.z);

    }
}




//transform.Rotate(Vector3.right * Time.deltaTime);
//transform.RotateAround(target.position, Vector3.up, currentYaw);
//transform.LookAt(target.position + Vector3.up * pitch);
