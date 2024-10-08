using System;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public Image[] starImages;
   
    public int heart;
    public GameObject SM;
   

    private void Start()
    {
        
    }
    void Update()
    {
        for (int i = 0; i < starImages.Length; i++)
        {
            if (i < heart)
            {
                starImages[i].enabled = true;
            }
            else
            {
                starImages[i].enabled = false;
            }
        }
        if(heart <= 0)
        {
            Debug.Log("die");
            
            SM.GetComponent<SenceManager>().LoadEnd();
            
        }
    }
}