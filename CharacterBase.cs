using UnityEngine;
using System.Collections;

[System.Serializable]
public class BasicStats
{
	public float startLife;
	public float startMana;
	public int strenght;
	public int magic;
	public int agillity;
	public int baseDefense;
	public int baseAttack;
}

public abstract class CharacterBase : DestructiveBase
{

	//Basics Atrributes
	public int currentLevel;
	public BasicStats basicStats;





	// Use this for initialization
	protected void Start()
	{
		currentLife = basicStats.startLife;
	}

	// Update is called once per frame
	protected void Update()
	{

	}

	public override void OnDestroyed()
	{
		//
	}

}
