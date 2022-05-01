using UnityEngine;
using System.Collections;

public enum TypeCharacter
{
	Warrior = 0,
	Wizard = 1,
	Archer = 2
}

public enum PlayerStates
{
	Movement,
	Attack,
}

public class PlayerBehaviour : CharacterBase
{

	private TypeCharacter type;

	private AnimationController animationController;

	//StateMachine
	private PlayerStates currentState = PlayerStates.Movement;
	//

	//Movimentation
	private float speed = 3.0F;
	private float speedSideWalk = 3.0F;
	public float speedRun;
	public float speedWalk;
	public float rotateSpeed = 3.0F;
	public CharacterController controller;
	public Transform focusCamera;
	//

	//Attack
	private int currentAttack = 0;
	public float attackRate;
	public int totalAttackAnimations;
	private float currentAttackRate;
	//

	new protected void Start()
	{
		
		PlayerStatsController.SetTypeCharacter(TypeCharacter.Wizard);
		currentLevel = PlayerStatsController.GetCurrentLevel();
		type = PlayerStatsController.GetTypeCharacter();

		basicStats = PlayerStatsController.intance.GetBasicStats(type);

		animationController = GetComponent<AnimationController>();
		speed = speedWalk;

		controller = GetComponent<CharacterController>();

		base.Start();
	}

        // Update is called once per frame
        new void Update()
	{
		base.Update();

		switch (currentState)
		{
			case PlayerStates.Movement:
				{

					if (Input.GetKey(KeyCode.LeftShift) || Input.GetAxis("Vertical") != 0)
					{
						speed = speedRun;
						animationController.PlayAnimation(AnimationStates.RUN);
					}
					else
					{
						speed = speedWalk;
						if (Input.GetAxis("Vertical") != 0)
							animationController.PlayAnimation(AnimationStates.WALK);
						else if (Input.GetAxis("Horizontal") != 0)
						{
							animationController.PlayAnimation(AnimationStates.SIDE_WALK);
						}
						else
							animationController.PlayAnimation(AnimationStates.IDDLE);
					}


					if (Mathf.Abs(Input.GetAxis("Vertical")) > 0)
					{

						transform.LookAt(new Vector3(focusCamera.position.x, transform.position.y, focusCamera.position.z));
						Vector3 direction = transform.TransformDirection(Vector3.forward);
						float curSpeed = speed * Input.GetAxis("Vertical");
						controller.SimpleMove(direction * curSpeed);
					}

					if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
					{
						transform.LookAt(new Vector3(focusCamera.position.x, transform.position.y, focusCamera.position.z));
						Vector3 direction = transform.TransformDirection(Vector3.right);
						float curSpeed = speedSideWalk * Input.GetAxis("Horizontal");
						controller.SimpleMove(direction * curSpeed);

					}

					//Attack Change State
					if (Input.GetKey(KeyCode.LeftControl))
					{
						currentState = PlayerStates.Attack;
					}

				}
				break;
			case PlayerStates.Attack:
				{
					currentAttackRate += Time.deltaTime;

					if (currentAttackRate > attackRate)
					{
						currentAttackRate = 0;
						animationController.CallAttackAnimation(currentAttack);
						currentAttack++;

						if (currentAttack > totalAttackAnimations)
						{
							currentAttack = 0;
						}
					}

					if (!Input.GetKey(KeyCode.LeftControl))
					{
						currentState = PlayerStates.Movement;
						currentAttackRate = 0;
					}

				}
				break;

		}

	}
}
