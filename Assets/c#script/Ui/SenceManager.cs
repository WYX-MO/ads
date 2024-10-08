using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SenceManager : MonoBehaviour
    
{
    public AudioClip object1SoundClip;
    public AudioClip object2SoundClip;
    public AudioClip object3SoundClip;
    private AudioSource ad;
    // Start is called before the first frame update
    void Start()
    {
        ad = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
   public void LoadNewScene()
{
   ad.clip = object1SoundClip;
    ad.Play();
    SceneManager.LoadScene("Gaming");
        
    
}
    public void LoadEnd()
    {
   
        SceneManager.LoadScene("End");
    }
    public void LoadWin()
    {

        SceneManager.LoadScene("Win");
    }
}
