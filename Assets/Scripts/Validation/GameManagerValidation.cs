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
			SceneManager.LoadScene("Init");

	}
}
