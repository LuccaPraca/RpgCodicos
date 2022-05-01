using UnityEngine;
using System.Collections;

public class SimpleObjectDestructiveBehaviour : DestructiveBase
{

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

		if (Input.GetKeyDown(KeyCode.G))
		{
			ApplyDamage(3);
		}

	}

	public override void OnDestroyed()
	{
		Destroy(gameObject);
	}
}
