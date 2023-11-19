using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricTrigger : MonoBehaviour {

    [SerializeField]
    float angle = 45;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            IsometricCameraController.instance.ChangeCameraAngle(angle);
        }
    }
}
