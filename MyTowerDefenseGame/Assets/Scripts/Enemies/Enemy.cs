using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public float MoveSpeed;

    public Transform target;

    void Start()
    {
        target = GetComponent<Transform>();
        target.position = transform.position;
    }
}
