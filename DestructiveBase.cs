using UnityEngine;
using System.Collections;

public abstract class DestructiveBase : MonoBehaviour
{

	public float currentLife;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void ApplyDamage(int damage)
	{
		currentLife -= damage;

		if (currentLife <= 0)
		{
			OnDestroyed();
		}
	}

	public abstract void OnDestroyed();
}
