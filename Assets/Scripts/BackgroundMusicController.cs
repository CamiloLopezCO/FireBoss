using UnityEngine;

public class BackgroundMusicController : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
    public void PauseMusic()
    {
        audioSource.Pause();
    }
    public void StopMusic()
    {
        audioSource.Stop();
    }
    public void ResumeMusic()
    {
        audioSource.UnPause();
    }
    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
