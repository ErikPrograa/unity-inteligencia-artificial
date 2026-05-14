using UnityEngine;
using UnityEngine.InputSystem;


public class FirearmTesting : MonoBehaviour
{
    [SerializeField] private MonoBehaviour firearm;
    [SerializeField] private int ammoInventory;

    private IFirearm _firearm;

    private void Awake()
    {
        _firearm = firearm.GetComponent<IFirearm>();
    }

    private void Update()
    {
        if(Keyboard.current.rKey.wasPressedThisFrame)
        {
            ammoInventory = _firearm.Reload(ammoInventory);
            return;
        }

        if (!Mouse.current.leftButton.isPressed)
            return;

        _firearm.Shoot();
    }
}