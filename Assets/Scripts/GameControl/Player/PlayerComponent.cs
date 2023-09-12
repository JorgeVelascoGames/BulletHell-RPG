using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerComponent : MonoBehaviour
{
	private PlayerBrain brain;

	public PlayerBrain Brain => brain;

	public void SetUpBrain(PlayerBrain brain)
	{
		this.brain = brain;
	}
}
