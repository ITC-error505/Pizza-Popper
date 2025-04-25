using UnityEngine;

public class AudioMuffleScript : MonoBehaviour
{
    private AudioLowPassFilter filter;
    private AudioSource source;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        filter = GetComponent<AudioLowPassFilter>();
        source = GetComponent<AudioSource>();
    }

    public void OnGamePause() {
        // filter.cutoffFrequency = 420f; 
        source.volume = 0.1f;
    }

    public void OnGameUnpause() {
        // filter.cutoffFrequency = 12000f; 
        source.volume = 0.724f;
    }
}
