using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name = "Sound 1";
    public AudioClip clip;
    public float volume = 0.7f, pitch = 1f;
    public bool playOnAwake = false;
    public float spatialMultipler = 0;

    internal AudioSource source;
}

public class soundManager : MonoBehaviour
{
    private static soundManager _instance;
    public static soundManager instance
    {
        get
        {
            return _instance;
        }

        set
        {
            _instance = value;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] private Sound[] soundArray;

    private void Start()
    {
        for (int i = 0; i <= soundArray.Length - 1; i++)
        {
            soundArray[i].source = gameObject.AddComponent<AudioSource>();
            soundArray[i].source.playOnAwake = soundArray[i].playOnAwake;
            soundArray[i].source.volume = soundArray[i].volume;
            soundArray[i].source.pitch = soundArray[i].pitch;
            soundArray[i].source.spatialBlend = soundArray[i].spatialMultipler;
        }
    }

    public void PlaySound(string clipName)
    {
        Sound _sound = Array.Find<Sound>(soundArray, s => s.name == clipName);
        _sound.source.clip = _sound.clip;
        _sound.source.Play();
    }
}
