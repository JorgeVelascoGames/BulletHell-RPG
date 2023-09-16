using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaExit : MonoBehaviour
{
	[SerializeField] private string sceneToLoad;
	[SerializeField] private string sceneTransitionName;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.GetComponent<PlayerComponent>())
		{
			GameManager.Instance.SceneManager.SetTransitionName(sceneTransitionName);
			GameManager.Instance.SceneManager.GoToSceneByName(sceneToLoad);
		}
	}
}
