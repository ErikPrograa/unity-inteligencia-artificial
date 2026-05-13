using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Inputs")]
    [SerializeField] private InputActionProperty moveAction;
    [SerializeField] private InputActionProperty viewAction;

    [Header("References")]
    [SerializeField] private Transform head;

    [Header("Settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float viewSpeed;

    private CharacterController _ch;
    private Vector2 _rotation;
    private Vector3 _gravity;

    private void Awake()
    {
        _ch = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();
        Vector2 viewInput = viewAction.action.ReadValue<Vector2>();

        Vector3 direction = _ch.transform.forward * moveInput.y +
            _ch.transform.right * moveInput.x;
        direction.Normalize();

        _ch.Move(direction * moveSpeed * Time.deltaTime);

        if (!_ch.isGrounded)
            _gravity += -Vector3.up * 9.8f * Time.deltaTime * Time.deltaTime;
        else _gravity = Vector3.zero;
        _ch.Move(_gravity);

        _rotation.y += viewInput.x * viewSpeed;
        _rotation.x -= viewInput.y * viewSpeed;
        _rotation.x = Mathf.Clamp(_rotation.x, -90, 90);

        head.localEulerAngles = new Vector3(_rotation.x, 0, 0);
        _ch.transform.eulerAngles = new Vector3(0, _rotation.y, 0);
    }
}