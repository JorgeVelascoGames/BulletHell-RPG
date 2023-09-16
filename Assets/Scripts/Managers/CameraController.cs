using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
	private CinemachineVirtualCamera cinemachineVC;

    public void SetPlayerCameraFollow()
	{
		cinemachineVC = FindObjectOfType<CinemachineVirtualCamera>();
		cinemachineVC.Follow = PlayerBrain.Instance.transform;
	}
}
