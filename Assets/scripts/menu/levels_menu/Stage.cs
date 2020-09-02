using UnityEngine;
using System.Collections;

public class Stage : MonoBehaviour
{
		public LevelButton[] arrButtons;

	public void setStageNumber (int stageNumber)
	{
		for (int i = 0; i < arrButtons.Length; i++) {
			arrButtons [i].resetButtonNameState (stageNumber, i);
		}
	}

}
