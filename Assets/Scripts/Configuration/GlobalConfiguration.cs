using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalConfiguration : MonoBehaviour
{
	[BoxGroup("CardMatch")]
	[SerializeField] private float startMatchDelay;
	[BoxGroup("CardMatch")]
	[SerializeField] private float spawnMapDelay;
	[BoxGroup("CardMatch")]
	[SerializeField] private float startPlayingDelay;
	[BoxGroup("CardMatch")]
	[SerializeField] private int cardsOnFirstHand;
	[BoxGroup("CardMatch")]
	[SerializeField] private int cardsToDrawAtStartRound;
	[BoxGroup("CardMatch")]
	[SerializeField] private float summonDelay;
	[BoxGroup("CardMatch")]
	[SerializeField] private float combatStartDelay;
	[BoxGroup("CardMatch")]
	[SerializeField] private float betweenFightDelay;
	[BoxGroup("CardMatch")]
	[SerializeField] private int roundsPerCycle;
	[BoxGroup("CardMatch")]
	[SerializeField] private float resetCycleTimer;
	[BoxGroup("CardMatch")]
	[SerializeField] private float drawPauseTimer;

	[BoxGroup("Combat")]
	[SerializeField] private float skillTimer;


	[BoxGroup("Board")]
	[SerializeField] private int minCellsBetweenObjectives;


	#region Public properties
	/// <summary>
	/// Small dellay when we load a match
	/// </summary>
	public float StartMatchDelay => startMatchDelay;
	/// <summary>
	/// Delay for the spawning animation to play
	/// </summary>
	public float SpawnMapDelay => spawnMapDelay;
	/// <summary>
	/// Delay to start being able to use cards
	/// </summary>
	public float StartPlayingDelay => startPlayingDelay;
	/// <summary>
	/// Amount of cards you might have in your first hand
	/// </summary>
	public int CardsOnFirstHand => cardsOnFirstHand;
	/// <summary>
	/// Amount of cards to draw at the beggining of each round
	/// </summary>
	public int CardsToDrawAtStartRound => cardsToDrawAtStartRound;
	/// <summary>
	/// Delay for the unit to appear
	/// </summary>
	public float SummonDelay => summonDelay;
	/// <summary>
	/// Small dellay between fights (a fight is a cicle of 4 abilities use by one unit
	/// </summary>
	public float BetweenFightDelay => betweenFightDelay;
	/// <summary>
	/// Delay for the combat to start 
	/// </summary>
	public float CombatStartDelay => combatStartDelay;
	/// <summary>
	/// Min amount of cells between objectives. IE: if the number is 2, there must be at least 2 cells between objectives
	/// </summary>
	public int MinCellsBetweenObjectives => minCellsBetweenObjectives;
	/// <summary>
	/// Amount of rounds per cycle
	/// </summary>
	public int RoundsPerCycle => roundsPerCycle;
	/// <summary>
	/// This is the time that the game pauses between cycles
	/// </summary>
	public float ResetCycleTimer => resetCycleTimer;
	/// <summary>
	/// The amount of time for a skill to play
	/// </summary>
	public float SkillTimer => skillTimer;
	/// <summary>
	/// The amount of time for a skill to play
	/// </summary>
	public float DrawPauseTimer => drawPauseTimer;
	#endregion
}
