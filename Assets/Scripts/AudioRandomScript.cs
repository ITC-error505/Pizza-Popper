using UnityEngine;

public class AudioRandomScript : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] sounds;
    private AudioSource source;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void OnPlay() {
        source.clip = sounds[Random.Range(0, sounds.Length)];
        source.Play();
    }
}
