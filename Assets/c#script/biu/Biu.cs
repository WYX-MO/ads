using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class Biu : MonoBehaviour
{
    public float biuSpeed = 100f;
    public Vector3 dir;
    public float Starttime;
    // Start is called before the first frame update
    void Start()
    {
        biuSpeed = 75f;
        Vector3 MymousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dir = (MymousePosition - transform.position).normalized;
        dir.z = 1;
        Starttime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.SetActive(true);
        transform.position += dir * biuSpeed * Time.deltaTime;
        if (Time.time > Starttime + 1f)
        {
            Destroy(gameObject);
        }
    }
    
            

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {
            Enemy player = other.GetComponent<Enemy>();
            if (player != null)
            {
             player.Die();
             Debug.Log("7");
            Destroy(gameObject);
            }
        }
    }
}
