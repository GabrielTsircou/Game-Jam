using UnityEngine;

public class Audio: MonoBehaviour
{
    [Header("Audio Clip")]
    [SerializeField] AudioSource musicSource;

    [Header("Audio Clip")]
    public AudioClip Ambient; 
    public AudioClip Banshee;
    public AudioClip Bomb;
    public AudioClip Equip;
    public AudioClip PickUp;
    public AudioClip Hurt;
    public AudioClip Tierd;

    private void Start()
    {
        musicSource.clip = Ambient;
        musicSource.Play();
    }


}
