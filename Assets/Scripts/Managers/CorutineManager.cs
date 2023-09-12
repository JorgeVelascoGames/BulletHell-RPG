using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorutineManager : MonoBehaviour
{
	public Coroutine StartManagedCoroutine(IEnumerator coroutine)
	{
		return StartCoroutine(coroutine);
	}

	public void StopManagedCoroutine(Coroutine coroutine)
	{
		StopCoroutine(coroutine);
	}
}
