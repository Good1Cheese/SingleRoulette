using System;
using UnityEngine;

public partial struct Fireable
{
    [Serializable]
    public struct Sounds
    {
        [SerializeField] private AudioClip _fireSound;
        [SerializeField] private AudioClip _clickSound;
        [SerializeField] private AudioClip _spinSound;

        public AudioSource AudioSource { get; set; }

        public AudioClip FireSound => _fireSound;
        public AudioClip ClickSound => _clickSound;
        public AudioClip SpinSound => _spinSound;
    }
}