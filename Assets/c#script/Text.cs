using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Text : MonoBehaviour
{
    public TextMeshProUGUI textObject;
    int t;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t = (int)PlayerPrefs.GetFloat("MyVariable");
        textObject.text = "Survive: " + t+"s";
    }
}
