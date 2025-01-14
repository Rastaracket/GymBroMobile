using UnityEngine;

public class HorizontalRotation : MonoBehaviour
{
    public float rotationSpeed = 100f; // Geschwindigkeit der Drehung

    void Update()
    {
        // Maussteuerung
    {
        if (Input.GetMouseButton(0)) // Bei Mausklick oder Touch
        {
            float horizontalInput = Input.GetAxis("Mouse X"); // Bewegung entlang der X-Achse
            transform.Rotate(Vector3.up, -horizontalInput * rotationSpeed * Time.deltaTime, Space.World);
        }
    }

        // Touchsteuerung
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            float touchX = Input.GetTouch(0).deltaPosition.x; // Bewegung des Fingers auf der X-Achse
            RotateModel(-touchX);
        }
    }

void RotateModel(float input)
{
    // Aktuelle Rotation abrufen
    Vector3 currentRotation = transform.rotation.eulerAngles;

    // Drehung anwenden (nur Y-Achse)
    float newYRotation = currentRotation.y + input * rotationSpeed * Time.deltaTime;

    // Begrenzung der Y-Rotation (z. B. zwischen 0° und 180°)
    newYRotation = Mathf.Clamp(newYRotation, 0f, 180f);

    // Rotation anwenden
    transform.rotation = Quaternion.Euler(currentRotation.x, newYRotation, currentRotation.z);
}
}