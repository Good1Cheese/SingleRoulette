using System;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public struct Rotatable
{
    [SerializeField] private Vector2 _multilier;

    public Transform Head { get; set; }
    public InputAction InputAction { get; set; }
    public Vector2 Multilier => _multilier;
}