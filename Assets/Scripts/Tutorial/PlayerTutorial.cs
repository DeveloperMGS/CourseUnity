using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTutorial : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameInputTutorial inputTutorial;
    private bool isWalking;

    public void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        Vector2 inputVector = inputTutorial.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
      
        CollisionDetection(moveDir);
        isWalking = moveDir != Vector3.zero; // Устанавливаем isWalking на основе движения
        
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, rotateSpeed * Time.deltaTime);
    }

    private void CollisionDetection(Vector3 moveDir)
    {
        float moveDistance = moveSpeed * Time.deltaTime;
        float playerHeight = 2f;
        float playerRadius = 0.7f;
        // Обновляем isWalking на основе проверки столкновения
        isWalking = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight,playerRadius,moveDir.normalized,moveDistance);
        
        if (isWalking)
        {
            transform.position += moveDir * moveSpeed * Time.deltaTime;
        }
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}