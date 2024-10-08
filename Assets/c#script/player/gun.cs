using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class gun : MonoBehaviour
{
    public GameObject player;
    public Camera mainCamera;
    public float time;
    public int IsReloading;
    public GameObject LoadingTiao;

    void Update()
    {
        spin();
        Mirror();
        StartRe();
        if (IsReloading == 0)
        {
            LoadingTiao.SetActive(false);
        }
        else if (IsReloading == 1)
        {

            LoadingTiao.SetActive(true);
        }
    }
    public void spin()
    {
    // �����ǹ�����λ�õķ���
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector3 direction = (mousePosition - player.transform.position).normalized;

        // ����ǹ����ת�Ƕ�
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // ����ǹ��λ��Ϊ��ҵ����Ͻǣ��ɸ���ʵ���������ƫ������
        transform.position = player.transform.position + new Vector3(0.5f, 0, 0);

        // ����ǹ����ת
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    public void Mirror()
    {
        Vector3 scale = transform.localScale;
        if (mainCamera.ScreenToWorldPoint(Input.mousePosition).x<transform.position.x)
        {
            scale.y= - 10;
            
        }
        else
        {
            scale.y= 10;
            
        }
        scale.x= 10;
        transform.localScale = scale;
    }
    public void ReLoading()
    {
        IsReloading = 1;
        //Loadingtiao.show
        time = Time.time;
    }
    public void StartRe()
    {

        if (IsReloading == 1&&time+1<Time.time)
        {
            player.GetComponent<PlayerInput>().biuNum = 8;
            //loding.hide
            IsReloading=0;
            
        }
    }
}

