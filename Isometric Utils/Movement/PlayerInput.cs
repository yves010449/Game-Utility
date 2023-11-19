using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] bool debug;

    public event Action<Vector3> OnMove;

    Vector3 _input;

    // Update is called once per frame
    void Update()
    {
        _input = new Vector3( Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical"));


        var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, IsometricCameraController.instance.angle, 0));
        var skewedInput = matrix.MultiplyPoint3x4(_input);

        OnMove?.Invoke(skewedInput);
    }

    private void OnDrawGizmos() {
        if (!debug) return;

        Debug.Log("Input: " + _input);
    }
}
