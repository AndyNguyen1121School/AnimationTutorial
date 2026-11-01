using UnityEngine;

public class ResetPlayerState : StateMachineBehaviour
{
    public bool isPerformingAction;

    public bool canJump;

    public bool resetComboCountIndex;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerManager playerManager = animator.GetComponent<PlayerManager>();
        if (playerManager != null)
        {
            playerManager.isPerformingAction = isPerformingAction;
            playerManager.canJump = canJump;

            if (resetComboCountIndex)
            {
                playerManager.currentComboAttackIndex = 0;
            }
        }
    }

   
}
