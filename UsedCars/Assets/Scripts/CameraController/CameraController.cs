using UnityEngine;
public class CameraController : MonoBehaviour
{
#if UNITY_IOS || UNITY_ANDROID


    [SerializeField] private Camera _camera;
    [SerializeField] private Plane _plane;
    private Vector3 touchDirection;
    private Vector2 touchStartPosition;
    private float maxX = 40;
    private float minX = -400;
    private float maxY = 160;
    private float minY = 50;
    private float minZ = -80;
    private float maxZ = 180;
    private float speedCamera = 35f;
    private float inertiaTime = 0;
    private float inertiaSpeed = 0;
    private float touchSTartTime;

    private Vector3 newPosition;
    private Vector3 newDirection;
    private Vector3 mathfClamp;

    private bool isTouchPhasaseEnded;
    private bool isMoving;

    private void Awake()
    {
        if (_camera == null)
        {
            _camera = Camera.main;
        }
    }

    private void LateUpdate()
    {
        if (Input.touchCount >= 1)
            _plane.SetNormalAndPosition(transform.up, transform.position);
        var DeltaOne = Vector3.zero;
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            DeltaOne = PlanePositionDelta(Input.GetTouch(0));
            if (touch.phase == TouchPhase.Began)
            {
                isTouchPhasaseEnded = false;
                touchStartPosition = touch.position;
                touchSTartTime = Time.time;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                _camera.transform.position += DeltaOne * speedCamera * Time.deltaTime; 
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                Vector2 touchEndPosition = touch.position;
                touchDirection = (touchEndPosition - touchStartPosition).normalized;
                newDirection = new Vector3(touchDirection.x, 0, touchDirection.y);
                newPosition = newDirection;

                float touchEndTime = Time.time;
                float touchDuration = touchEndTime - touchSTartTime;
                inertiaSpeed = newDirection.magnitude / touchDuration;
                inertiaTime = 0.7f;
                Vector2 dragSize = touchStartPosition - touchEndPosition;
                float magnitude = dragSize.magnitude;
                if (magnitude > 150)
                {
                    isTouchPhasaseEnded = true;

                }
            }
        }
        inertiaTime -= Time.deltaTime;
        if (isTouchPhasaseEnded)
        {
            

            if (inertiaTime > 0)
                _camera.transform.position += newDirection * inertiaTime * inertiaSpeed * 10 * Time.deltaTime;
            else
                isTouchPhasaseEnded = false;
        }

        //Pinch
        if (Input.touchCount == 2)
        {
            mathfClamp = _camera.transform.position;
            mathfClamp.x = Mathf.Clamp(mathfClamp.x, minX, maxX);
            mathfClamp.z = Mathf.Clamp(mathfClamp.z, minZ, maxZ);
            Vector3 pos1 = PlanePosition(Input.GetTouch(0).position);
            Vector3 pos2 = PlanePosition(Input.GetTouch(1).position);
            Vector3 pos1b = PlanePosition((Input.GetTouch(0).position) - Input.GetTouch(0).deltaPosition);
            Vector3 pos2b = PlanePosition((Input.GetTouch(1).position) - Input.GetTouch(1).deltaPosition);
            var zoom = Vector3.Distance(pos1, pos2) / Vector3.Distance(pos1b, pos2b);
            if (zoom == 1 || zoom > 10)
                return;
            _camera.transform.position = Vector3.LerpUnclamped(pos1, _camera.transform.position, 1 / zoom);
            if (_camera.transform.position.x >= maxX)
                _camera.transform.position = mathfClamp;
            if (_camera.transform.position.z >= maxZ)
                _camera.transform.position = mathfClamp;
            if (_camera.transform.position.z <= minZ)
                _camera.transform.position = mathfClamp;
            if (_camera.transform.position.x <= minX)
                _camera.transform.position = mathfClamp;
            Vector3 limitPinch;
            limitPinch = _camera.transform.position;
            limitPinch.y = Mathf.Clamp(limitPinch.y, minY, maxY);
            _camera.transform.position = limitPinch;
        }
    }
    public Vector3 PlanePositionDelta(Touch touch)
    {
        if (touch.phase != TouchPhase.Moved)
            return Vector3.zero;


        var rayBefore = _camera.ScreenPointToRay(touch.position - touch.deltaPosition);
        var rayNow = _camera.ScreenPointToRay(touch.position);
        if (_plane.Raycast(rayBefore, out var enterBefore) && _plane.Raycast(rayNow, out var enterNow))
            return rayBefore.GetPoint(enterBefore) - rayNow.GetPoint(enterNow);


        return Vector3.zero;
    }

    public Vector3 PlanePosition(Vector2 screenPos)
    {
        var rayNow = _camera.ScreenPointToRay(screenPos);
        if (_plane.Raycast(rayNow, out var enterNow))
            return rayNow.GetPoint(enterNow);


        return Vector3.zero;
    }


#endif
}
