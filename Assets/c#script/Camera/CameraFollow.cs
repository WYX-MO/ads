using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 Offerst;
    //����λ��ƫ��
    public GameObject target;
    //׼������player
    void Start()
    {
        Offerst = new Vector3(0, 2, -10);
        //����λ��ƫ��
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = target.transform.position + Offerst;
            //����
        }
    }
}
