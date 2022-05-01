using UnityEngine;
using System.Collections;

public enum AnimationStates
{
	WALK,
	SIDE_WALK,
	RUN,
	IDDLE,
	ATTACK_MELEE1,
	ATTACK_MELEE2,
	ATTACK_MELEE3,
}

public class AnimationController : MonoBehaviour
{

	public Animator animator;

	public void PlayAnimation(AnimationStates stateAnimation)
	{

		switch (stateAnimation)
		{
			case AnimationStates.IDDLE:
				{
					StopAnimations();
					animator.SetBool("inIddle", true);
				}
				break;
			case AnimationStates.WALK:
				{
					StopAnimations();
					animator.SetBool("inWalk", true);
				}
				break;
			case AnimationStates.SIDE_WALK:
				{
					StopAnimations();
					animator.SetBool("sideWalk", true);
				}
				break;
			case AnimationStates.RUN:
				{
					StopAnimations();
					animator.SetBool("inRun", true);
				}
				break;
			case AnimationStates.ATTACK_MELEE1:
				{
					StopAnimations();
					animator.SetBool("inAttack", true);
				}
				break;
			case AnimationStates.ATTACK_MELEE2:
				{
					StopAnimations();
					animator.SetBool("inAttack", true);
				}
				break;
			case AnimationStates.ATTACK_MELEE3:
				{
					StopAnimations();
					animator.SetBool("inAttack", true);
				}
				break;
		}

	}


	public void CallAttackAnimation(int indiceAnimation)
	{
		if (indiceAnimation == 0)
			PlayAnimation(AnimationStates.ATTACK_MELEE1);
		else if (indiceAnimation == 1)
			PlayAnimation(AnimationStates.ATTACK_MELEE2);
		else if (indiceAnimation == 2)
			PlayAnimation(AnimationStates.ATTACK_MELEE3);

		animator.SetInteger("CurrentAttack", indiceAnimation);
	}


	void StopAnimations()
	{
		animator.SetBool("inRun", false);
		animator.SetBool("inWalk", false);
		animator.SetBool("inIddle", false);
		animator.SetBool("inAttack", false);
		animator.SetBool("sideWalk", false);

	}
}
