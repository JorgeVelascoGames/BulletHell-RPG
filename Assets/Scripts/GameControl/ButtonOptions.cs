using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOptions : MonoBehaviour
{
	public static Action OnClickStart;
	public static Action OnClickNext;
	public static Action OnClickBack;
	public static Action OnClickOptions;

	public void OnClickStartButton()
	{
		if (OnClickStart != null)
			OnClickStart();
	}
	public void OnClickNextButton()
	{
		if (OnClickNext != null)
			OnClickNext();
	}
	public void OnClickBackButton()
	{
		if (OnClickBack != null)
			OnClickBack();
	}
	public void OnClickOptionsButton()
	{
		if (OnClickOptions != null)
			OnClickOptions();
	}
}
