using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReTiaoFollow : MonoBehaviour
{
    public Vector3 Offerst;
    //设置位置偏差
    public GameObject target;
    private Renderer renderer;
    private AudioSource source;
    public AudioClip audioClip;
    //准备接收player
    void Start()
    {
        gameObject.SetActive(false);
        Offerst = new Vector3(0, 0.8f, 0);
        //定义位置偏差
        target = GameObject.FindGameObjectWithTag("Player");
        renderer = target.GetComponent<Renderer>();
        source = target.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = target.transform.position + Offerst;
            //跟随
        }
        if(renderer.isVisible == true)
        {
            source.clip = audioClip;
            source.Play();
        }
    }
   
}
