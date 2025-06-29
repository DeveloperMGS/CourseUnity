using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTutorial : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameInputTutorial inputTutorial;
    [SerializeField] private LayerMask interactableLayer;
    private Vector3 lastInteractDir; 
    private bool isWalking;


    private void Start()
    {
        inputTutorial.OnInteractAction += GameInputTutorial_OnInteractAction;
    }

    private void GameInputTutorial_OnInteractAction(object sender,System.EventArgs e)
    {
        Vector2 inputVector = inputTutorial.GetMovementVectorNormalized();
        
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        if (moveDir != Vector3.zero)
        {
            lastInteractDir = moveDir;
        }

        float interacionDistance = 1f;
        if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interacionDistance,interactableLayer))
        {
            if (raycastHit.transform.TryGetComponent(out ClearCounterTutorial clearCounter)) ;
            {
                clearCounter.Interact();
            }
        }
        else
        {
            Debug.Log("-");
        }
    }

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