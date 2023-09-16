using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
	[SerializeField] private string transitionName;

	private void Start()
	{
		if (PlayerBrain.Instance != null && GameManager.Instance.SceneManager.SceneTransitionName == transitionName)
		{
			PlayerBrain.Instance.transform.position = transform.position;
			GameManager.Instance.CameraController.SetPlayerCameraFollow();
		}
	}
}
