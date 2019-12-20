using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovementController : MonoBehaviour
{
    private float inputXAxis;  // velocity based on user input
    private Vector2 moveVelocity;   // velocity after manipulation for movement

    [Range(0, 1)]
    [SerializeField] private float moveDuration;

    void Awake()
    {
        inputXAxis = 0f;
        moveVelocity = Vector2.zero;
    }

    void Update()
    {
        Move();
    }

    public void SetInputVelocity(float vel)
    {
        inputXAxis = vel;
    }

    public void ResetInputVelocity()
    {
        inputXAxis = 0f;
    }

    private void Move()
    {
        moveVelocity.x = inputXAxis;
        transform.DOMoveX(moveVelocity.x, moveDuration);
    }
}
