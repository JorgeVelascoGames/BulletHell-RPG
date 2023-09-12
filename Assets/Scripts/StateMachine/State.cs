using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VelascoGames.StateMachine
{
	public abstract class State
	{
		public State(StateMachine machine, State previousState = null)
		{
			stateMachine = machine;

			this.previousState = previousState;
		}

		protected StateMachine stateMachine;
		protected State previousState;

		#region Public properties
		public StateMachine Machine => stateMachine;
		public State PreviousState => previousState;
		#endregion


		public abstract string GetStateName();

		#region Unity methods
		public virtual void StartState()
		{

		}
		public virtual void UpdateState()
		{

		}
		public virtual void FixedUpdateState()
		{

		}
		public virtual void LateUpdateState()
		{

		}
		public virtual void EndState()
		{

		}
		#endregion

		#region Menu
		public virtual void OnClickStartButton()
		{

		}
		public virtual void OnClickNextButton()
		{

		}
		public virtual void OnClickBackButton()
		{

		}
		public virtual void OnClickOptionsButton()
		{

		}
		#endregion
	}
}
