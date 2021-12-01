using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatRotate : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 0, 0);

    public float floatingSpeed = 0;

    public float floatingAmplitude = 0;

    private float initialY;

    private void Start()
    {
        initialY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
        Vector3 position = transform.position;
        position.y =
            initialY +
            (float) Math.Sin(Time.timeAsDouble * floatingSpeed) *
            floatingAmplitude;
        transform.position = position;
    }
}
