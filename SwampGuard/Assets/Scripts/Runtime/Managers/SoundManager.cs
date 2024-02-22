using System.Collections.Generic;
using Runtime.Extentions;
using UnityEngine;

namespace Runtime.Managers
{

    public enum GunSoundEffectsEnum
    {
        ShotSound,
        ReloadSound,
        LoadSound,
        EmptyShotSound
    }
    
    public class SoundManager : MonoSingelton<SoundManager>
    {
        [SerializeField] private List<AudioClip> audioClips;
        private AudioSource _audioSource;
        private void Awake()
        {
            SingeltonThisGameObject(this);
            _audioSource = GetComponent<AudioSource>();
        }
        
        internal void PlayOneShot(int index)
        {
            _audioSource.PlayOneShot(audioClips[index]);
        }

    }
}
