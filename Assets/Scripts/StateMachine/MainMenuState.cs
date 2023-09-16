using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VelascoGames.StateMachine
{
	public class MainMenuState : State
	{
		public MainMenuState(StateMachine machine, State previousState = null) : base(machine, previousState)
		{
			stateMachine = machine;

			this.previousState = previousState;
		}

		public override void StartState()
		{
			GameManager.Instance.SceneManager.GoToMainMenu();
		}

		public override string GetStateName()
		{
			return "Main Menu State";
		}

		public override void OnClickStartButton()
		{
			GameManager.Instance.SceneManager.GoToGameSceneOne();
		}
		public override void OnClickNextButton()
		{
		}
		public override void OnClickBackButton()
		{
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
		}
		public override void OnClickOptionsButton()
		{
		}
		
	}
}
