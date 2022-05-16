using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource bgm;

    public void StartBackgroundMusic()
    {
        bgm.Play();
    }
}
