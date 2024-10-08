using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBlock : MonoBehaviour
{
    public List<GameObject> objList = new List<GameObject>();
    //��Ҫ���Ƶ������б�
    public List<Transform> obsPointList = new List<Transform>(); 
    //�ص��б����������壩
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
        for (int i = 0; i < obsPointList.Count; i++)//ѭ�� �ص��� ��
        {
            GameObject temp = objList[Random.Range(0,objList.Count)];
            //��tempΪ�����һ��Ԥ��
            GameObject go = GameObject.Instantiate(temp);
            //ʵ����һ��go
            go.transform.parent = obsPointList[i].transform;
            //go�ĸ���ַ��Ϊ��i���ص�
            go.transform.localPosition = Vector3.zero;
            //ƫ��Ժ�����
            go.SetActive(true);
        }
    }
    
}
