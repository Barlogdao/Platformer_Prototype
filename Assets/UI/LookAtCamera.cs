using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void LateUpdate()
    {
        transform.rotation = _camera.transform.rotation;
    }
}
