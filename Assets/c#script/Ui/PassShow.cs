using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PassShow : MonoBehaviour
{
    public int pass1=1;
    public int Passdir;
    public void Start()
    {
        pass1 = 1;
    }
    public void Update()
    {
        if(Time.timeScale == 0)
        {
            Passdir = 1;
        }
        else
        {
            Passdir=-1;
        }
        Show();
       
    }
    public void Show()
    {
        
        if (pass1 < 60&&pass1>=0) {
        //transform.SetParent(transform.parent);
        
            if ((pass1==1&&Passdir==-1)|| (pass1 == 59 && Passdir == 1))
            {

            }
            else
            {
                    transform.localPosition += new Vector3(Passdir, 0, 0);
                pass1 += Passdir;
            }
        
        }
    }
}
