using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculateCraneLimit : MonoBehaviour
{
    float radius;
    float limit;
    float movableLoad = 7;
    public GameObject crane;
    public Text childText;

    public Vector3 a, b;
    // Start is called before the first frame update
    void Start()
    {
        crane = GameObject.FindGameObjectWithTag("CircularRange");
        a = new Vector3();
        b = new Vector3();
        childText = transform.GetChild(0).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ShootRay.instance != null)
        {
            a = crane.transform.position;
            b = ShootRay.instance.projectedPosition;
            a.y = 0;
            b.y = 0;
            radius = Vector3.Distance(a, b) * 6 / 500.0f;
            Debug.Log(radius);

            // 작업 반경에 따른 인양 가능 하중
            // y = 471.58*x^(-1.316)
            limit = 471.58f * Mathf.Pow(radius, -1.316f);

            childText.text = "인양 가능 하중 (T): " + limit.ToString() +
                             "\n" + "적재 하중 (T): " +movableLoad.ToString();
            if(limit < movableLoad)
            {
                childText.color = Color.red;
            }
            else
            {
                childText.color = Color.blue;
            }
        }
    }
}

