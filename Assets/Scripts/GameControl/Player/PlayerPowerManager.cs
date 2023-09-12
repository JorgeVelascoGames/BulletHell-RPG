using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerManager : PlayerComponent
{
	private Power[] powers;

	private Power activePower;

	public Power[] PowerList => powers;
	public Power ActivePower => activePower;

	private void Awake()
	{
		powers = GetComponentsInChildren<Power>();
		activePower = powers[0];
	}

	public void UseActivePower()
	{
		activePower.ActivatePower();
	}
}
