using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerValidation : MonoBehaviour
{
	private void Start()
	{
		Invoke("GameManagerValidate", 1f);
	}

	private void GameManagerValidate()
	{
		if (GameManager.Instance == null)
		{
			if (PlayerBrain.Instance != null)
				Destroy(PlayerBrain.Instance.gameObject);

			SceneManager.LoadScene("Init");
		}

	}
}
