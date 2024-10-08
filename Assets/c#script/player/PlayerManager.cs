using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int heart;
    public AudioClip adc;
    public AudioSource ads;
    public float time;

    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1;
        ads = GetComponent<AudioSource>();
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy")&&time+1<Time.time)
        {
            ads.clip = adc;
            ads.Play();
            time = Time.time;
        }
    }

}
