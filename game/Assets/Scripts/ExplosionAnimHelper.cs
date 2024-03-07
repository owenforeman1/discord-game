using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAnimHelper : MonoBehaviour
{
    public List<string> sounds = new List<string>();

    public void PlaySoundEffect()
    {
        FindObjectOfType<SoundManager>().Play(sounds[Random.Range(0, sounds.Count)]);
    }
}
