
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip[] _clips;

    public void ChangeCurrentMusic()
    {
        _source.Stop();
        _source.PlayOneShot(_clips[Random.Range(0, _clips.Length)]);
    }

    public void LateUpdate() 
    {
        if(!_source.isPlaying)
        {
            ChangeCurrentMusic();
        }
    }
}
