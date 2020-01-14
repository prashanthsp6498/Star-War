using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float xSpeed = 20f;
    [SerializeField] float ySpeed = 20f;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float positionYawFactor = -5f;
    [SerializeField] float controlYawFactor = -10f;
    [SerializeField] float controlRollFactor = -10f;
    [SerializeField] float controlrollFactor = -10f;

    bool isControlEnabled = true;
    float xThrow, yThrow;
    
    void Update()
    {
        if (isControlEnabled)
        {
            HorizontalControl();
            VerticalControl();
            RotationControl();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            isControlEnabled = true;
        }
    }

    void FreezeControl()
    {
        isControlEnabled = false;
        print("freezing controling");
    }

    private void RotationControl()
    {
        float pitch = positionPitchFactor * transform.localPosition.y + yThrow + controlPitchFactor;
        float roll = xThrow * controlrollFactor;
        float yaw = positionYawFactor * transform.localRotation.x;
        transform.localRotation = Quaternion.Euler(-pitch, yaw, roll);
    }

    private void HorizontalControl()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffsetOfThisFrame = xThrow * xSpeed * Time.deltaTime;
        float xRawPosition = transform.localPosition.x + xOffsetOfThisFrame;
        float clampedXPosition = Mathf.Clamp(xRawPosition, -20f, 20f);
        transform.localPosition = new Vector3(clampedXPosition, transform.localPosition.y, transform.localPosition.z);
    }

    private void VerticalControl()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffsetOfThisFrame = yThrow * ySpeed * Time.deltaTime;
        float yRawPosition = transform.localPosition.y + yOffsetOfThisFrame;
        float clampedYPosition = Mathf.Clamp(yRawPosition, -7f, 7f);
        transform.localPosition = new Vector3(transform.localPosition.x, clampedYPosition, transform.localPosition.z);
    }
}