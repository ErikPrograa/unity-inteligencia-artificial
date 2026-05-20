using UnityEngine;
using UnityEngine.InputSystem;


public class PointingTesting : MonoBehaviour
{
    [SerializeField] private new Camera camera;

    private IPointable _current;

    private void Update()
    {
        Vector2 cursor = Mouse.current.position.ReadValue();
        Ray ray = camera.ScreenPointToRay(cursor);

        if(Physics.Raycast(ray, out var hit))
        {
            IPointable pointable = hit.collider.GetComponent<IPointable>();
            if(pointable == null)
            {
                _current?.Ignore(camera.transform.position, hit.point);
                _current = null;
                return;
            }

            if(_current != pointable)
            {
                _current?.Ignore(camera.transform.position, hit.point);
                _current = pointable;
            }

            _current?.Point(camera.transform.position, hit.point);
            return;
        }

        _current?.Ignore(camera.transform.position,
            camera.transform.position);
        _current = null;
    }
}