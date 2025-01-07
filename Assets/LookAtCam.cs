using UnityEngine;

public class LookAtCam : MonoBehaviour
{
    public Camera targetCamera; // Assign your camera in the Inspector
    void Start()
    {
        if (targetCamera == null)
        {
            targetCamera = Camera.main;
        }
    }

    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - targetCamera.transform.position);
    }
}
