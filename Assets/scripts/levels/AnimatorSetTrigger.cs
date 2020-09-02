using UnityEngine;
using System.Collections;

public class AnimatorSetTrigger : MonoBehaviour {
	public Animator animator;
	public string trigger;

	public void setTrigger() {
		animator.SetTrigger(trigger);
	}
}
