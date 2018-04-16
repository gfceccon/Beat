using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Cube))]
public class Movement : MonoBehaviour
{
    private Cube _cube;
    private bool animating;

    public float speed;

    private void Start()
    {
        _cube = GetComponent<Cube>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
        }
    }

    private void RotateSideCW()
    {
        Cube.Vectors sides = _cube.Sides;
        Vector3 up = sides.up;
        RotateTo(up, sides.left, sides.forward, sides.forward);

        sides.up = sides.left;
        sides.left = sides.down;
        sides.down = sides.right;
        sides.right = up;
    }

    private void RotateSideCCW()
    {
        Cube.Vectors sides = _cube.Sides;
        Vector3 up = sides.up;
        RotateTo(up, sides.left, sides.forward, sides.forward);

        sides.up = sides.right;
        sides.right = sides.down;
        sides.down = sides.left;
        sides.left = up;
    }

    private void RotateForwardCW()
    {
        Cube.Vectors sides = _cube.Sides;
        Vector3 up = sides.up;
        RotateTo(up, sides.left, sides.forward, sides.forward);

        sides.up = sides.back;
        sides.back = sides.down;
        sides.down = sides.forward;
        sides.forward = up;
    }

    private void RotateForwardCCW()
    {
        Cube.Vectors sides = _cube.Sides;
        Vector3 up = sides.up;
        RotateTo(up, sides.left, sides.forward, sides.forward);

        sides.up = sides.forward;
        sides.forward = sides.down;
        sides.down = sides.back;
        sides.back = up;
    }

    private IEnumerator RotateTo(Vector3 cUp, Vector3 tUp, Vector3 cForward, Vector3 tForward)
    {
        return null;
    }

}
