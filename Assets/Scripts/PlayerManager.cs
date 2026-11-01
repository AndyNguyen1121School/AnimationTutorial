using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public bool canJump = true;
    public bool isPerformingAction = false;
    public int currentComboAttackIndex;
    
    [SerializeField] private List<string> comboStringNames = new();
    [SerializeField] private Animator animator;
    
    void Update()
    {
        // Jump if player is not currently performing an action
        if (Keyboard.current.spaceKey.wasPressedThisFrame && canJump && !isPerformingAction)
        {
            isPerformingAction = true;
            canJump = false;
            
            animator.CrossFade("Jump", 0.1f);
            currentComboAttackIndex = 0;
        }

        // Attack if player is not currently performing an action
        if (Mouse.current.leftButton.wasPressedThisFrame && !isPerformingAction)
        {
           isPerformingAction = true;
           PlayComboAttack();
           ++currentComboAttackIndex;
        }
    }

    void PlayComboAttack()
    {
        string currentAnimToPlay = comboStringNames[currentComboAttackIndex % comboStringNames.Count];
        animator.CrossFade(currentAnimToPlay, 0.1f);
    }
    
    // This is used as an animation event
    public void ResetIsPerformingAction()
    {
        isPerformingAction = false;
    }
}
