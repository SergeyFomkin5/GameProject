using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private Transform CameraAxisTransform;

    [SerializeField] private float minAngle;
    [SerializeField] private float maxAngle;
    [SerializeField] private float rotationSpeed;
    void Update()
    {
        var newAngleY = transform.localEulerAngles.y + Time.deltaTime * rotationSpeed * Input.GetAxis("Mouse X");
        transform.localEulerAngles = new Vector3(0, newAngleY, 0);

        var newAngleX = CameraAxisTransform.localEulerAngles.x - Time.deltaTime * rotationSpeed * Input.GetAxis("Mouse Y");
        if (newAngleX > 180) newAngleX -= 360;

        newAngleX = Mathf.Clamp(newAngleX, minAngle, maxAngle);
        CameraAxisTransform.localEulerAngles = new Vector3(newAngleX, 0, 0);
    }
}
