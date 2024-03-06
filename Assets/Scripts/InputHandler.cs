using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    const string HorizontalAxis = "Horizontal";
    const string JumpButton = "Jump";
    const string AttackButton = "Fire1";

    public delegate void InputEventHandler();
    public static InputEventHandler onJumpButtonPressed;
    public static InputEventHandler onAttackButtonPressed;

    private static float _horAxis;

    public static float Horizontal => _horAxis;

    void Update()
    {
        _horAxis = Input.GetAxis(HorizontalAxis);

        if (Input.GetButtonDown(JumpButton))
            onJumpButtonPressed?.Invoke();
        if (Input.GetButtonDown(AttackButton))
            onAttackButtonPressed?.Invoke();
    }
}
