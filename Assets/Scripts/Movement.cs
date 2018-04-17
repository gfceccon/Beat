using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Cube))]
public class Movement : MonoBehaviour
{
    private Transform _transform;

    private Cube _cube;
    private bool animating;

    public float speed;

    private void Start()
    {
        _cube = GetComponent<Cube>();
        _transform = GetComponent<Transform>();
        animating = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            StartCoroutine(RotateCube(_transform.position + new Vector3(-0.5f, -0.5f, 0f), Vector3.forward, false));

        if (Input.GetKeyDown(KeyCode.RightArrow))
            StartCoroutine(RotateCube(_transform.position + new Vector3(0.5f, -0.5f, 0f), Vector3.forward, true));

        if (Input.GetKeyDown(KeyCode.DownArrow))
            StartCoroutine(RotateCube(_transform.position + new Vector3(0f, -0.5f, -0.5f), Vector3.right, true));

        if (Input.GetKeyDown(KeyCode.UpArrow))
            StartCoroutine(RotateCube(_transform.position + new Vector3(0f, -0.5f, 0.5f), Vector3.right, false));
    }

    private IEnumerator RotateCube(Vector3 pivot, Vector3 direction, bool clockwise)
    {
        if (animating)
            yield break;
        animating = true;

        float time = 0f;
        float animationTime = 1f / speed;
        float step = 90f / animationTime;


        float delta = 0f;
        while (time < animationTime)
        {
            yield return null;

            time += Time.deltaTime;
            if (time > animationTime)
                delta = time - animationTime;
            else
                delta = Time.deltaTime;
            _transform.RotateAround(pivot, direction, Time.deltaTime * step * (clockwise ? -1f : 1f));
        }

        Fix();

        animating = false;
    }

    private void Fix()
    {
        Vector3 position = _transform.position;
        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);
        position.z = Mathf.Round(position.z);
        _transform.position = position;

        Vector3 rotation = _transform.eulerAngles;
        rotation.x = 90f * Mathf.Round(rotation.x / 90f);
        rotation.y = 90f * Mathf.Round(rotation.y / 90f);
        rotation.z = 90f * Mathf.Round(rotation.z / 90f);
        _transform.eulerAngles = rotation;
    }
}
