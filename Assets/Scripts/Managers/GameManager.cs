using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VelascoGames.StateMachine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance => instance;
	private static GameManager instance;

	private StateMachine generalStateMachine;

	#region Sub managers
	[SerializeField][HideIf("gameSceneManager")] private GameSceneManager gameSceneManager;
	[SerializeField][HideIf("corutineManager")] private CorutineManager corutineManager;
	[SerializeField][HideIf("globalConfiguration")] private GlobalConfiguration globalConfiguration;
	[SerializeField][HideIf("objectReferences")] private ReferenceManager objectReferences;
	[SerializeField][HideIf("cameraController")] private CameraController cameraController;
	#endregion

	#region Public properties
	public StateMachine GeneralStateMachine => generalStateMachine;
	public GameSceneManager SceneManager => gameSceneManager;
	public CorutineManager CorutineManager => corutineManager;
	public GlobalConfiguration Configuration => globalConfiguration;
	public ReferenceManager ObjectReferences => objectReferences;
	public CameraController CameraController => cameraController;
	#endregion

	#region Unity methods
	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}

		generalStateMachine = new StateMachine(new EmptyState(generalStateMachine));
		//Actions
		ButtonOptions.OnClickStart += generalStateMachine.OnClickStartButton;
		ButtonOptions.OnClickNext += generalStateMachine.OnClickNextButton;
		ButtonOptions.OnClickBack += generalStateMachine.OnClickBackButton;
		ButtonOptions.OnClickOptions += generalStateMachine.OnClickOptionsButton;

		//Dont destroy on load
		DontDestroyOnLoad(gameObject);

		generalStateMachine.StartNewState(new MainMenuState(generalStateMachine));
	}

	private void Update()
	{
		if (generalStateMachine != null)
			generalStateMachine.Update();
	}
	private void FixedUpdate()
	{
		if (generalStateMachine != null)
			generalStateMachine.FixedUpdate();
	}
	private void LateUpdate()
	{
		if (generalStateMachine != null)
			generalStateMachine.LateUpdate();
	}
	#endregion

}
