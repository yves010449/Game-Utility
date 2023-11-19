using System.Collections;
using UnityEngine;

public class IsometricCameraController : MonoBehaviour {
    public static IsometricCameraController instance;

    private void Awake() {
        instance = this;
    }

    public float angle;
    [SerializeField] float rotationSpeed = 5f;

    public void ChangeCameraAngle(float angle) {
        this.angle = angle;

        // Calculate the target rotation without changing the X rotation
        Quaternion targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, angle, transform.rotation.eulerAngles.z);

        // Use Quaternion.Lerp to smoothly interpolate between the current and target rotation
        StartCoroutine(RotatePivot(targetRotation));
    }

    IEnumerator RotatePivot(Quaternion targetRotation) {
        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.01f) {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            yield return null;
        }

        // Ensure that the final rotation is exactly the target rotation
        transform.rotation = targetRotation;
    }
}
