using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In meters per seconds")][SerializeField] float speed = 10f;

    [Header("Screen-position related")]
    [SerializeField] float xPositionLimit = 4.5f;
    [SerializeField] float yPositionLimit = 2.5f;

    [Header("Ship movement rotation related")]
    [SerializeField] float positionPitchFactor = -5.6f;
    [SerializeField] float positionYawFactor = 4.5f;
    [SerializeField] float throwTilt = 15f;

    bool disableInput = false;

    // Update is called once per frame
    void Update()
    {
        if(!disableInput)
        {
            float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
            float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
            ProcessTranslation(xThrow, yThrow);
            ProcessRotation(xThrow, yThrow);
        }
    }

    private void ProcessRotation(float xThrow, float yThrow)
    {
        float pitch = (transform.localPosition.y * positionPitchFactor) - (yThrow * throwTilt);
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = -xThrow * throwTilt;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation(float xThrow, float yThrow)
    {
        float[] positionOffset = { xThrow * speed * Time.deltaTime, yThrow * speed * Time.deltaTime };
        float[] rawPosition = { transform.localPosition.x + positionOffset[0], transform.localPosition.y + positionOffset[1] };
        float[] clampedPosition = { Mathf.Clamp(rawPosition[0], xPositionLimit * -1f, xPositionLimit), Mathf.Clamp(rawPosition[1], yPositionLimit * -1f, yPositionLimit) };

        // can go from -3.5 to 3.5 in x offset
        transform.localPosition = new Vector3(clampedPosition[0], clampedPosition[1], transform.localPosition.z);
    }
    void OnPlayerDeath() // Called by string reference
    {
        disableInput = true;
    }
}
