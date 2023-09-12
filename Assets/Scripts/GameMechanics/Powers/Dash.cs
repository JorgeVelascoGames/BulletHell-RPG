using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : Power
{
	[SerializeField] private float dashSpeedMultiplier = 4f;
	[SerializeField] private float dashDuration = 0.2f;
	[SerializeField] private GameObject lineRenderer;
	private float speed;

	private void Awake()
	{
		lineRenderer.SetActive(false);
	}
	public override void ActivatePower()
	{
		speed = PlayerBrain.Instance.Controller.MoveSpeed;
		PlayerBrain.Instance.Controller.ChangePlayerSpeed(speed * dashSpeedMultiplier);

		lineRenderer.SetActive(true);

		StartCoroutine(FinishDashCorutine());
	}

	private IEnumerator FinishDashCorutine()
	{
		yield return new WaitForSeconds(dashDuration);

		PlayerBrain.Instance.Controller.RestoreBaseSpeed();

		float dashEffectOff = 0.15f;

		yield return new WaitForSeconds(dashEffectOff);

		lineRenderer.SetActive(false);
	}
}
