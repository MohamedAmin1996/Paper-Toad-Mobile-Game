using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SimplePlayer : MonoBehaviour
{
    private MasterControls masterControls;
    [SerializeField] private float speed = 5;

    private void Awake()
    {
        masterControls = new MasterControls();
        masterControls.Player.Enable();

        masterControls.Player.Jump.performed += Jump; // Buttons inputs
    }
    private void Update()
    {
        Movement();
    }
    private void Movement()
    {
        Vector2 input = masterControls.Player.Movement.ReadValue<Vector2>().normalized;
        transform.position += new Vector3(input.x, 0, input.y) * Time.deltaTime * speed;
    }
    private void Jump(InputAction.CallbackContext ctx)
    {

    }
}
