using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInputTutorial : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    private TutorialInpuAction tutorialInpuAction;  
    public void Awake()
    {
        tutorialInpuAction = new TutorialInpuAction();
        tutorialInpuAction.TutorialPlayer.Enable(); // Включаем действия
        tutorialInpuAction.TutorialPlayer.Interact.performed += Interact_Perfomed;
    }

    private void Interact_Perfomed(InputAction.CallbackContext obj)
    {
    if (OnInteractAction != null)
        OnInteractAction(this, EventArgs.Empty);;
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = tutorialInpuAction.TutorialPlayer.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        Debug.Log(tutorialInpuAction);
        
        return inputVector;
    }

    public void JumpJump()
    {
     
    }
}
