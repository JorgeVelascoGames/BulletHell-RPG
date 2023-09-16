using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VelascoGames.StateMachine
{
	public class StateMachine
	{
		private State currentState;
		
		public StateMachine(State initState)
		{
			currentState = initState;
		}

		#region Public properties
		public State CurrentState => currentState;
		#endregion

		public void StartNewState(State newState)
		{
			if(currentState != null)
				currentState.EndState();

			currentState = newState;
			currentState.StartState();
		}

		public void Update()
		{
			if (currentState != null)
			{
				currentState.UpdateState();
			}
		}

		public void FixedUpdate()
		{
			if (currentState != null)
			{
				currentState.FixedUpdateState();
			}
		}

		public void LateUpdate()
		{
			if (currentState != null)
			{
				currentState.LateUpdateState();
			}
		}

		#region Menu
		public void OnClickStartButton()
		{
			currentState.OnClickStartButton();
		}
		public void OnClickNextButton()
		{
			currentState.OnClickNextButton();
		}
		public void OnClickBackButton()
		{
			currentState.OnClickBackButton();
		}
		public void OnClickOptionsButton()
		{
			currentState.OnClickOptionsButton();
		}
		#endregion
	}
}
