using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passFollow : MonoBehaviour
{
    public Vector3 Offerst;
    //设置位置偏差
    public GameObject target;
    //准备接收player
    void Start()
    {
        Offerst = new Vector3(-60, 0, 0);
        //定义位置偏差
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = target.transform.position + Offerst;
            //跟随
        }
    }
}
