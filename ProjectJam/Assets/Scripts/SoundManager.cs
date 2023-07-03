using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
   public static SoundManager instance;
   public AudioSource audiosource;
   public AudioClip coinSound;
   public AudioClip runSound;
   public AudioClip blastSound;
   public AudioClip rocketSound;
   public AudioClip mobdieSound;

   public void Awake() 
   {
      instance = this;
   }
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
