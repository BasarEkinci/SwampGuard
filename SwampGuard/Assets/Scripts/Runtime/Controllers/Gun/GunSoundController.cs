using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Controllers
{
    public class GunSoundController : MonoBehaviour
    {
        [SerializeField] private AudioClip shotSound;
        [SerializeField] private AudioClip reloadSound;
        [SerializeField] private AudioClip emptyShotSound;
        [SerializeField] private AudioClip loadSound;
        
        private AudioSource _audioSource;
        
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }
        
        internal void PlayReloadSound()
        {
            _audioSource.PlayOneShot(reloadSound);
        }
        internal void PlayShotSound()
        {
            _audioSource.PlayOneShot(shotSound);
        }
        
        internal void PlayEmptyShotSound()
        {
            _audioSource.PlayOneShot(emptyShotSound);
        }
        
        internal void PlayLoadSound()
        {
            _audioSource.PlayOneShot(loadSound);
        }
    }    
}


