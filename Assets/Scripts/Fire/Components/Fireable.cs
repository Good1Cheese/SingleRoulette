using System;
using UnityEngine;

[Serializable]
public partial struct Fireable
{
    [SerializeField] private int _delayBeforeFireMilliseconds;
    [SerializeField] private int _delayBeforeNextMoveMilliseconds;

    [SerializeField] private float _rotateSmoothTime;
    [SerializeField] private float _moveSmoothTime;

    [SerializeField] private float _yPosition;
    [SerializeField] private float _positionMultiplier;

    [SerializeField][Range(0, 100)] private float _deathСhance;

    public int DelayBeforeFireMilliseconds => _delayBeforeFireMilliseconds;
    public int DelayBeforeNextMoveMilliseconds => _delayBeforeNextMoveMilliseconds;

    public float RotateSmoothTime => _rotateSmoothTime;
    public float MoveSmoothTime => _moveSmoothTime;

    public float YPosition => _yPosition;
    public float PositionMultiplier => _positionMultiplier;

    public float DeadСhance => _deathСhance;

    public Transform Transform { get; set; }
}