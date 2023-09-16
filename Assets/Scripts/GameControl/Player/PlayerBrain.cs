using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(PlayerPowerManager))]
public class PlayerBrain : Singleton<PlayerBrain>
{
	private PlayerController playerController;
	private PlayerPowerManager playerPowers;

	#region Public properties
	public PlayerController Controller => playerController;
	public PlayerPowerManager PlayerPowers => playerPowers;
	#endregion

	protected override void Awake()
	{
		base.Awake();

		playerController = GetComponent<PlayerController>();
		playerController.SetUpBrain(this);

		playerPowers = GetComponent<PlayerPowerManager>();
		playerPowers.SetUpBrain(this);
	}
}
