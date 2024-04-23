using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private void LateUpdate() {
        transform.LookAt(_camera.transform.position);
    }
}
