using UnityEngine;

public class PlayerAttackStateBehavior : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.transform.root.TryGetComponent(out PlayerAttacker attacker))
            attacker.StopAttack();
    }
}
