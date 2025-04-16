using UnityEngine;
using UnityEngine.InputSystem;
public class TouchManagerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private PlayerInput playerInput;

    private InputAction touchPositionAction;
    private InputAction touchPressAction;

    private void Awake() {
        playerInput = GetComponent<PlayerInput>();
        touchPressAction = playerInput.actions["TouchPress"];
        touchPositionAction = playerInput.actions["TouchPosition"];
    }

    private void OnEnable() {
        touchPressAction.performed += TouchPressed; //sub to event
    }
    
    private void OnDisable() {
        touchPressAction.performed -= TouchPressed; //unsub from event
    }

    private void TouchPressed(InputAction.CallbackContext context) {
        Vector3 position = Camera.main.ScreenToWorldPoint(touchPositionAction.ReadValue<Vector2>());
        position.z = player.transform.position.z;
        player.transform.position = position;
    }
}
