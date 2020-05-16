using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// TODO: rename this to PlayerMovementController
public class MovementController : MonoBehaviour
{
    public enum MovementState { moving, dashing, none };
    private MovementState movementState;

    [SerializeField] private Ease easeType;

    private float inputXAxis;
    private float inputYAxis;
    private Vector2 moveVelocity;   // velocity after manipulation for movement

    private Vector3 dashVelocity;

    [Range(0, 3)]
    [SerializeField] private float moveDuration;
    
    [SerializeField] private float moveMultiplier;
    [SerializeField] private float dashMultiplier;

    void Awake()
    {
        movementState = MovementState.none;
        inputXAxis = 0f;
        inputYAxis = 0f;

        moveVelocity = Vector2.zero;
        dashVelocity = Vector2.zero;
    }

    void Update()
    {
        switch (movementState)
        {
            case MovementState.moving:
                Move();
                break;
            case MovementState.dashing:
                Dash();
                break;
            default:
                Move();
                break;
        }
    }

    public void SetInputVelocity(float x, float y)
    {
        inputXAxis = x;
        inputYAxis = y;
    }

    public void ResetInputVelocity()
    {
        inputXAxis = 0f;
        inputYAxis = 0f;
    }

    private void Move()
    {
        moveVelocity.x = inputXAxis;
        transform.DOMoveX(moveVelocity.x * moveMultiplier, moveDuration, false).SetEase(easeType);
    }

    private void Dash()
    {
        print("dashing!");
        dashVelocity = new Vector3(inputXAxis, inputYAxis, 0f) * dashMultiplier;
        print(dashVelocity);
        transform.DOMove(transform.position + dashVelocity, moveDuration).SetEase(easeType);
    }

    public void SetState(MovementState state)
    {
        movementState = state;
    }
}
