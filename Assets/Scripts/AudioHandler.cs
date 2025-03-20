using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioHandler : MonoBehaviour
{
    public AudioSource AudioSource { get; private set; }
    [field: SerializeField]
    public AudioClip[] AudioClips { get; private set; }

    private void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    public void Play(int audioIndex)
    {
        AudioSource.PlayOneShot(AudioClips[audioIndex]);
    }
}
