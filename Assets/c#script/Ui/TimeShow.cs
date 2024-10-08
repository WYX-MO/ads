using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{
    public float time;
    public TextMeshProUGUI textObject;
    void Start(){

    }
    void Update()
    {
        time = Time.time;
        textObject.text = "Time :" + (int)Time.time;
        PlayerPrefs.SetFloat("MyVariable", time);
        PlayerPrefs.Save();
    }
}