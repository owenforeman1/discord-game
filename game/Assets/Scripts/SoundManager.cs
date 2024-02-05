using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public List<AudioClip> audioClips = new List<AudioClip>();
    [Range(0f, 1f)]
    public List<float> volumes = new List<float>();

    Dictionary<string, AudioSource> AudioSources = new Dictionary<string, AudioSource>();

    // Start is called before the first frame update
    void Start()
    {
        int index = 0;
        foreach (AudioClip clip in audioClips)
        {
            AudioSource newAudioSource = gameObject.AddComponent<AudioSource>();
            newAudioSource.clip = clip;
            newAudioSource.playOnAwake = false;
            newAudioSource.volume = volumes[index];

            AudioSources.Add(clip.name, newAudioSource);
            index += 1;
        }
    }

    public void Play(string soundName)
    {
        AudioSources[soundName].Play();
    }
}
