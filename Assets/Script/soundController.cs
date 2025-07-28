using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class soundController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<AudioClip> ListSound;
    public AudioSource BackgroundSound;
    public AudioSource FireSound;
    public AudioSource GetScoreSound;
    public static soundController Instance;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        BackgroundSound = gameObject.AddComponent<AudioSource>();
        FireSound = gameObject.AddComponent<AudioSource>();
        GetScoreSound = gameObject.AddComponent<AudioSource>();
        PlayeAuditoSound();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  public   void PlayFireSound()
    {
        FireSound.clip = ListSound[1];
        FireSound.Play();
    }
    void PlayeAuditoSound()
    {
        BackgroundSound.clip = ListSound[0];
        BackgroundSound.loop = true;
        BackgroundSound.Play();
    

    }
    public void PlaySoundGetScore()
    {
        GetScoreSound.clip = ListSound[2];
        GetScoreSound.Play();
    }
}
