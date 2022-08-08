using System;
using UnityEngine;

[Serializable]
public struct Fireable
{
    [SerializeField] private AudioClip _fireSound;
    [SerializeField] private AudioClip _clickSound;

    [SerializeField] private int _delayBeforeFireMilliseconds;

    [SerializeField] private float _rotateSmoothTime;
    [SerializeField] private float _rotateTime;
    [SerializeField][Range(0, 100)] private float _deathСhance;

    public AudioClip FireSound => _fireSound;
    public AudioClip ClickSound => _clickSound;

    public int DelayBeforeFireMilliseconds => _delayBeforeFireMilliseconds;

    public float RotateSmoothTime => _rotateSmoothTime;
    public float RotateTime => _rotateTime;
    public float DeadСhance => _deathСhance;

    public AudioSource AudioSource { get; set; }
    public Transform Transform { get; set; }
    public Rigidbody Rigidbody { get; set; }
}