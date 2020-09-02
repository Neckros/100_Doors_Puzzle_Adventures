using UnityEngine;
using System.Collections;

public class SwipeListener : EventListener
{

	public enum Direction
	{
		LEFT,
		RIGHT,
		UP,
		DOWN
	}

	public Direction direction;
	private Vector2 swipeStartPos;

	void OnTouchDown (Vector2 pos)
	{
		swipeStartPos = pos;
	}

	void OnTouchUp (Vector2 pos)
	{
		Vector2 swipeDiffPos = pos - swipeStartPos;
		float distance = Vector2.Distance (pos, swipeStartPos);
		float angle = Vector2.Angle (swipeDiffPos, new Vector2 (0, 1));
		if (pos.x < swipeStartPos.x) {
			angle = 360 - angle;
		}

		if (distance > 50f &&
		    ((angle <= 135 && angle > 45 && direction == Direction.RIGHT) ||
		    (angle <= 225 && angle > 135 && direction == Direction.DOWN) ||
		    (angle <= 315 && angle > 225 && direction == Direction.LEFT) ||
		    (((angle <= 360 && angle > 315) || (angle <= 45 && angle > 0)) && direction == Direction.UP))) {
			gameObject.SendMessage ("OnShake", SendMessageOptions.DontRequireReceiver);		
			executeEvents ();
		}
	}

}
