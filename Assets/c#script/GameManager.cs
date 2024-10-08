using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float time;
    public GameObject SM;
    void Start()
    {
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > time + 200f)
        {
            SM.GetComponent<SenceManager>().LoadWin();
        }
    }
}
