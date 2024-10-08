using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBlock : MonoBehaviour
{
    public List<GameObject> objList = new List<GameObject>();
    //需要复制的物体列表
    public List<Transform> obsPointList = new List<Transform>(); 
    //地点列表（几个空物体）
    // Start is called before the first frame update
    void Start()
    {
        Initd();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Initd()
    {
        for (int i = 0; i < obsPointList.Count; i++)//循环 地点数 次
        {
            GameObject temp = objList[Random.Range(0,objList.Count)];
            //令temp为随机的一个预设
            GameObject go = GameObject.Instantiate(temp);
            //实例化一个go
            go.transform.parent = obsPointList[i].transform;
            //go的父地址设为第i个地点
            go.transform.localPosition = Vector3.zero;
            //偏差，以后可随机
            go.SetActive(true);
        }
    }
    
}
