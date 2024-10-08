using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 Offerst;
    //设置位置偏差
    public GameObject target;
    //准备接收player
    public List<GameObject> createPoints = new List<GameObject> ();
    public GameObject monsterPrefab;
    float LastTime;
    void Start()
    {
        Offerst = new Vector3(0, 0, 0);
        //定义位置偏差
        target = GameObject.FindGameObjectWithTag("Player");
        LastTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = target.transform.position + Offerst;
            //跟随
        }
        if(Time.time > LastTime+0.8f)
        {
           SpawnMonster();
            LastTime = Time.time;
        }
    }
    private void SpawnMonster()
    {
        Vector3 spawnPosition = createPoints[Random.Range(0,9)].transform.position;
        Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);
    }
}
