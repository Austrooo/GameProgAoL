using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Audio
{
    public string name;
    [Range(0f, 1f)]
    public float volume;
    public AudioClip clip;
    public bool loop;
}
public class AudioManager : MonoBehaviour
{
    [SerializeField] private Audio[] audioList;
    public static AudioManager instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Play("background");
    }

    public void Play(string name)
    {
        Audio audio = System.Array.Find(audioList, a => a.name == name);
        if (audio != null)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = audio.clip;
            audioSource.volume = audio.volume;
            audioSource.loop = audio.loop;
            audioSource.Play();
            if(!audio.loop)
            {
                Destroy(audioSource, audio.clip.length);
            }
        }
        else
        {
            Debug.LogWarning("Audio not found: " + name);
        }
    }

    public void StopAudio()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.Stop();
            Destroy(audioSource);
        }
    }
}
