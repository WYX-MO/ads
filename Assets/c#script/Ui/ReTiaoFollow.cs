using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReTiaoFollow : MonoBehaviour
{
    public Vector3 Offerst;
    //����λ��ƫ��
    public GameObject target;
    private Renderer renderer;
    private AudioSource source;
    public AudioClip audioClip;
    //׼������player
    void Start()
    {
        gameObject.SetActive(false);
        Offerst = new Vector3(0, 0.8f, 0);
        //����λ��ƫ��
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
            //����
        }
        if(renderer.isVisible == true)
        {
            source.clip = audioClip;
            source.Play();
        }
    }
   
}
