using System;
using UnityEngine;

[Serializable]
public struct Rotatable
{
    [SerializeField] private Vector2 _multilier;

    public Transform Head { get; set; }
    public Vector2 Multilier => _multilier;
}