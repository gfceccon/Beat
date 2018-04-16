using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System;
using System.Collections;
using System.Collections.Generic;

public class Cube : MonoBehaviour
{
    public class Vectors
    {
        public Vector3 up;
        public Vector3 down;
        public Vector3 left;
        public Vector3 right;
        public Vector3 forward;
        public Vector3 back;
    }

    private Vectors _sides;
    public Vectors Sides { get { return _sides; } }

    private void Start()
    {
        _sides = new Vectors();
        _sides.up = Vector3.up;
        _sides.down = Vector3.down;
        _sides.left = Vector3.left;
        _sides.right = Vector3.right;
        _sides.forward = Vector3.forward;
        _sides.back = Vector3.back;

    }
}
