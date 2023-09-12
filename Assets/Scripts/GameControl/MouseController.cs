using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
	public static Action<Vector3> MouseClick;


    void Update()
    {
		if (Input.GetMouseButtonDown(0))
		{
			if (MouseClick != null)
				MouseClick(VelascoGames.Utilities.Utilities.GetMousPos());
		}
    }
}
