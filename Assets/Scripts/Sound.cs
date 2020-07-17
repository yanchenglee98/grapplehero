using UnityEngine.Audio;
using UnityEngine;

[System.Serializable] // so class will appear in inspector
public class Sound {

	public string name;

	public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;

    [Range(.1f, 3f)]
    public float pitch;

	public bool loop = false;

	[HideInInspector]
	public AudioSource source;

}
