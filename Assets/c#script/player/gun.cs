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
    // 计算从枪到鼠标位置的方向
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector3 direction = (mousePosition - player.transform.position).normalized;

        // 计算枪的旋转角度
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 设置枪的位置为玩家的右上角（可根据实际需求调整偏移量）
        transform.position = player.transform.position + new Vector3(0.5f, 0, 0);

        // 设置枪的旋转
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

