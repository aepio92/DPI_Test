using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick MovementJoysick;
    [SerializeField] private float Speed;
    [SerializeField] private FixedTouchField TouchField;
    [SerializeField] private float TouchSensitivity = 5.0f;

    private float MouseX, MouseY;

    private Vector2 input;
    private Animator PlayerAnimator;

    void Start()
    {
        PlayerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
        RotateCharacter();
    }

    void Movement()
    {
        input.x = MovementJoysick.Horizontal * Speed;
        input.y = MovementJoysick.Vertical * Speed;

        transform.Translate(new Vector3(input.x, 0, input.y));
        PlayerAnimator.SetFloat("Speed", input.magnitude);
    }

    void RotateCharacter()
    {
        MouseX += TouchField.TouchDist.x * TouchSensitivity * Time.deltaTime;
        MouseY -= TouchField.TouchDist.y * TouchSensitivity * Time.deltaTime;
        MouseY = Mathf.Clamp(MouseY, -35, 60);

        transform.rotation = Quaternion.Euler(new Vector3(0, MouseX, 0));
        PlayerAnimator.SetFloat("Pitch", MouseY);
    }
}
