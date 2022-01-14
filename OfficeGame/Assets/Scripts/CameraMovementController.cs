using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float movementSpeed;
    Vector3 startMousePosition;
    bool isMouseReleased;

    private void Awake()
    {
        startMousePosition = Vector3.zero;
        isMouseReleased = true;
    }

    void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            if (isMouseReleased)
            {
                isMouseReleased = false;
                startMousePosition = Input.mousePosition;
            }
            CheckMouse();
            CheckKeyboard();
        }

        if (Input.GetMouseButtonUp(1))
            isMouseReleased = true;
    }

    void CheckMouse()
    {
        Vector3 currentMousePosition = Input.mousePosition;
        float deltaX = currentMousePosition.x - startMousePosition.x;
        float deltaY = currentMousePosition.y - startMousePosition.y;
        Vector3 cameraRotation = gameObject.transform.eulerAngles;
        cameraRotation.y += deltaX * Time.deltaTime * Time.deltaTime * rotationSpeed;
        cameraRotation.x -= deltaY * Time.deltaTime * Time.deltaTime * rotationSpeed;
        Quaternion desiredRotation = Quaternion.Euler(cameraRotation.x, cameraRotation.y, 0);
        gameObject.transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, 1f);
    }

    void CheckKeyboard()
    {
        float c = Time.deltaTime * Time.deltaTime * movementSpeed;

        if (Input.GetKey(KeyCode.LeftShift)) c *= 4f;

        Vector3 desiredPosition = gameObject.transform.position;

        if (Input.GetKey(KeyCode.W))
            desiredPosition += gameObject.transform.forward * c;
        if (Input.GetKey(KeyCode.S))
            desiredPosition -= gameObject.transform.forward * c;
        if (Input.GetKey(KeyCode.D))
            desiredPosition += gameObject.transform.right * c / 2;
        if (Input.GetKey(KeyCode.A))
            desiredPosition -= gameObject.transform.right * c / 2;

        transform.position = Vector3.Lerp(gameObject.transform.position, desiredPosition, 3f);
    }
}

