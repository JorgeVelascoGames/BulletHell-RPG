using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(PlayerPowerManager))]
public class PlayerBrain : MonoBehaviour
{
	private static PlayerBrain instance;
	public static PlayerBrain Instance => instance;

	private PlayerController playerController;
	private PlayerPowerManager playerPowers;

	#region Public properties
	public PlayerController Controller => playerController;
	public PlayerPowerManager PlayerPowers => playerPowers;
	#endregion

	private void Awake()
	{
		instance = this;

		playerController = GetComponent<PlayerController>();
		playerController.SetUpBrain(this);

		playerPowers = GetComponent<PlayerPowerManager>();
		playerPowers.SetUpBrain(this);
	}
}
