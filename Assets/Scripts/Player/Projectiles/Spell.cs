﻿using UnityEditor;
using UnityEngine;


public abstract class Spell : MonoBehaviour
{
    [SerializeField]
    public GameObject ProjectilePrefab;
    public abstract void Fire();
}