using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceOrb : MonoBehaviour
{
    private int experienceValue;
    private AudioSource ad;
    public AudioClip object1SoundClip;
    public AudioClip object2SoundClip;
    private void Start()
    {
       ad = GetComponent<AudioSource>();
       ad .clip = object1SoundClip;
       ad.Play();
    }

    public void SetExperienceValue(int value)
    {
        experienceValue = value;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ad.clip = object2SoundClip;
            ad.Play();
            Debug.Log("x");
            PlayerInput player = other.GetComponent<PlayerInput>();
            if (player != null)
            {
                
                player.AddExperience(experienceValue);
                Destroy(gameObject);
            }
        }
    }
}