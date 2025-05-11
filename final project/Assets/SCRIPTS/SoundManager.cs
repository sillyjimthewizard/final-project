using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    private Transform SoundTrash;
    [SerializeField] 
    private AudioClip music;
    private AudioClip collision;
    
    
    private void Awake() {
        SoundTrash = GameObject.Find("SoundTrash").transform;
    }
    
    private void Start() {
        PlayMusic();
    }
    
 
    public void PlaySound(AudioClip audioClip)
    {
        GameObject newSoundObject = new GameObject("SFX"); //Creates a new object in the heirachy
        newSoundObject.transform.SetParent(SoundTrash); //Moves object into the trash folder
        AudioSource audioSource = newSoundObject.AddComponent<AudioSource>(); //adds an audio source
        audioSource.clip = audioClip; //assigns the audio clip from the argument
        //audioSource.clip = collision; //assigns the audio clip from the argument
        audioSource.Play(); //Plays the sound
        Destroy(newSoundObject, audioClip.length); //Destroys the object after the sound completes playing    
              
    }
    
    
    public void PlaySoundAltered(AudioClip audioClip, float volume)
    {
        GameObject newSoundObject = new GameObject("SFX"); //Creates a new object in the heirachy
        newSoundObject.transform.SetParent(SoundTrash); //Moves object into the trash folder
        AudioSource audioSource = newSoundObject.AddComponent<AudioSource>(); //adds an audio source
        audioSource.clip = audioClip; //assigns the audio clip from the argument
        //Change stuff here
        audioSource.volume = volume;                   
        audioSource.Play(); //Plays the sound
        Destroy(newSoundObject, audioClip.length + 10.0f); //Destroys the object after the sound completes playing        
    }  
    
    
     public void PlayMusic()
    {
        GameObject newSoundObject = new GameObject("Music"); //Creates a new object in the heirachy
        newSoundObject.transform.SetParent(SoundTrash); //Moves object into the trash folder
        AudioSource audioSource = newSoundObject.AddComponent<AudioSource>(); //adds an audio source
        audioSource.clip = music; //assigns the audio clip from the argument
        audioSource.loop = true;
        audioSource.volume = 0.3f;  
        audioSource.Play(); //Plays the sound

    }   
    
    
    
    
    

}
