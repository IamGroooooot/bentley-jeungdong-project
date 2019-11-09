using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchorControl : MonoBehaviour
{
    GameObject myTarget;
    // Start is called before the first frame update
    void Start()
    {

    }
    bool once = true;

    // Update is called once per frame
    void Update()
    {
        if (myTarget != null && once)
        {
            myTarget.transform.SetParent(transform);
            once = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("target"))
        {
            myTarget = other.transform.parent.gameObject;

            Debug.Log("catched " + myTarget.name);
            other.GetComponent<Collider>().enabled = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        OnTriggerEnter(other);
    }
}
