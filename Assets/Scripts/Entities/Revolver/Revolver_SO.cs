﻿using UnityEngine;

[CreateAssetMenu(fileName = "new Revolver_SO", menuName = "Entities/Revolver")]
public class Revolver_SO : Entity_SO
{
    public Fireable fireable;
    public Fireable.Explosion fireableExplosion;
    public Fireable.Sounds fireableSounds;
}