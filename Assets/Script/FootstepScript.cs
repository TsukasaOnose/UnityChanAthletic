using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FootstepScript : MonoBehaviour
{
    //オーディオクリップを入れる
    [SerializeField] AudioClip[] clip;
    [SerializeField] bool randomizePitch = true;
    [SerializeField] float pitchRange = 0.1f;

    protected AudioSource source;

    private void Awake()
    {
        source = GetComponents<AudioSource>()[0];
    }

    public void PlayFootstepSE()
    {
        if (randomizePitch)
        {
            source.pitch = 1.0f + Random.Range(-pitchRange, pitchRange);
        }
        source.PlayOneShot(clip[Random.Range(0, clip.Length)]);
    }
}
