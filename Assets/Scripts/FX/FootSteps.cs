using UnityEngine;

public class FootSteps : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] stoneClips;
    // [SerializeField]
    // private AudioClip[] mudClips;
    // [SerializeField]
    // private AudioClip[] grassClips;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Step()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomClip()
    {


            return stoneClips[UnityEngine.Random.Range(0, stoneClips.Length)];

        
        
    }
}