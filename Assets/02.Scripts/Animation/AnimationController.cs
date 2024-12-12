using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // 현재 속도는 대략적으로 정의 되어 있음
    public void PlayIdle()
    {
        animator.SetFloat("Speed", 0);
    }

    // 추가 예정
    public void PlayWalk()
    {
        animator.SetFloat("Speed", 0.5f);
    }

    public void PlayRun()
    {
        animator.SetFloat("Speed", 1f);
    }


    // 추가 예정
    public void PlayCombatIdle()
    {
        animator.SetBool("IsInCombat", true);
    }
    // Combat Mode -> Idle
    public void ResetCombatIdle()
    {
        animator.SetBool("IsInCombat", false);
    }

    public void PlayAttack()
    {
        animator.SetTrigger("IsAttack");
    }

    public void PlayHit()
    {
        animator.SetTrigger("IsHit");
    }

    public void PlayDeath()
    {
        animator.SetBool("IsDead", true);
    }
}
