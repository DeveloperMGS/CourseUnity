using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputTutorial : MonoBehaviour
{
    private TutorialInpuAction tutorialInpuAction;  
    public void Awake()
    {
        tutorialInpuAction = new TutorialInpuAction();
        tutorialInpuAction.TutorialPlayer.Enable(); // Включаем действия
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = tutorialInpuAction.TutorialPlayer.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        Debug.Log(tutorialInpuAction);
        
        return inputVector;
    }
}
