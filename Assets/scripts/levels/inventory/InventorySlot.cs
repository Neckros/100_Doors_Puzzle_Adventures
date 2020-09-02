using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventorySlot : MonoBehaviour
{

	private static int LAYER_DEFAULT = 0;
	private static int LAYER_GUI = 30;
	private float size = 70;
	private Entity entity;
	private bool isActive;
	private Vector3 touchDragStartPos;
	private Vector3 entitySceneScale, entityInvScale;
	private List<GameObject> tempGameObject = new List<GameObject> ();

	void OnTouchDown ()
	{
		if (entity != null) {
			isActive = true;
			GetComponent<AudioSource> ().Play ();
			touchDragStartPos = gameObject.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y));
			if (entity.scaleOnTouchDown) {
				entity.transform.localScale = entitySceneScale;
			}
		}
	}

	void OnTouchDrag (Vector2 pos)
	{ 
		if (entity != null) {
			Vector3 touchPos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y);
			entity.transform.position = Camera.main.ScreenToWorldPoint (touchPos) + touchDragStartPos;

			if (entity.isDragged) {
				GameObject hitObject;

				if (!entity.isDragPosItem) {
					hitObject = ExtraManager.Instance.hitThroughObject (pos, entity.gameObject);
				} else {
					Vector2 dragPos = entity.transform.position;
					dragPos += entity.dragOffset;
					hitObject = ExtraManager.Instance.hitThroughObject (dragPos, entity.gameObject, false);
				}

				if (hitObject) {
					hitObject.SendMessage ("OnInventoryDrag", entity, SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}

	void OnTouchUp (Vector2 pos)
	{
		if (entity != null) {
			if (entity.scaleOnTouchDown) {
				entity.transform.localScale = entityInvScale;
			}

			GameObject hitObject = ExtraManager.Instance.hit (pos);
			
			entity.transform.localPosition = new Vector3 (0, 0, 0);
			
			if (hitObject) {
				if (entity.soundOnAction) {
					if (entity.useCustomSound) {
						if (entity.GetComponent<AudioSource> ())
							entity.GetComponent<AudioSource> ().Play ();
					} else {
						if (GetComponent<AudioSource> ())
							GetComponent<AudioSource> ().Play ();					
					}
				}

				print ("Inventory: Hit - " + hitObject.name);
				hitObject.SendMessage (
					"OnInventoryClick", entity, UnityEngine.SendMessageOptions.DontRequireReceiver);
			} 
			isActive = false;
		}
	}

	void OnTouchClick ()
	{
		if (entity != null) {
			print ("Inventory: click on slot - " + entity.name);			
		}
	}

	public void push (Entity entity)
	{

		//to do:  refactor next line
		entity.transform.localScale = new Vector3 (1, 1, 1);

		entity.gameObject.layer = LAYER_GUI;

		entity.transform.parent = transform;
		this.entity = entity;
		this.entitySceneScale = entity.transform.localScale;

		float width = this.entity.GetComponent<Renderer> ().bounds.size.x * 100;
		float height = this.entity.GetComponent<Renderer> ().bounds.size.y * 100;
		float scale = 0f;
		if (!entity.originalSizeInInventory)
			scale = (width > height) ? size / width : size / height;
		else
			scale = 1;
		entityInvScale = new Vector3 (scale, scale, 1);
		//Debug.Log ("this.entityX="+this.entity.renderer.bounds.size.x*100);
		//Debug.Log ("this.entityY="+this.entity.renderer.bounds.size.y*100);

//		TweenPosition tweenPos = TweenPosition.Begin(entity.gameObject, 0.6f, Vector3.zero);
//		tweenPos.method = UITweener.Method.EaseInOut;
//		tweenPos.delay = 0.2f;
//		TweenScale tweenScaleUp = TweenScale.Begin(entity.gameObject, 0.3f, new Vector3(2, 2, 1));
//		tweenScaleUp.method = UITweener.Method.EaseInOut;
//		TweenScale tweenScaleDown = TweenScale.Begin(entity.gameObject, 0.4f, new Vector3(scale, scale, 1));
//		tweenScaleDown.method = UITweener.Method.EaseInOut;
//		tweenScaleDown.delay = 0.3f;
//		tweenScaleDown.method = UITweener.Method.EaseInOut;
		
		AnimationClip clip = new AnimationClip ();
		clip.legacy = true;
		AnimationCurve curvePosX = AnimationCurve.EaseInOut (.2f, entity.transform.localPosition.x, .6f, 0);
		AnimationCurve curvePosY = AnimationCurve.EaseInOut (.2f, entity.transform.localPosition.y, .6f, 0);
		AnimationCurve curvePosZ = AnimationCurve.EaseInOut (0, entity.transform.localPosition.z, .3f, 0);

		Keyframe[] keyFrames = new Keyframe[] {
			new Keyframe (0, 1),
			new Keyframe (.2f, 2),
			new Keyframe (.3f, 2),
			new Keyframe (.7f, scale)// .5
		};
		AnimationCurve curveScaleX = new AnimationCurve (keyFrames);
		AnimationCurve curveScaleY = new AnimationCurve (keyFrames);
		AnimationCurve curveScaleZ = new AnimationCurve (new Keyframe[]{ new Keyframe (0, 1) });

		clip.SetCurve ("", typeof(Transform), "localPosition.x", curvePosX);
		clip.SetCurve ("", typeof(Transform), "localPosition.y", curvePosY);
		clip.SetCurve ("", typeof(Transform), "localPosition.z", curvePosZ);
		clip.SetCurve ("", typeof(Transform), "localScale.x", curveScaleX);
		clip.SetCurve ("", typeof(Transform), "localScale.y", curveScaleY);
		clip.SetCurve ("", typeof(Transform), "localScale.z", curveScaleZ);
		clip.name = "pushToInventory";
		clip.wrapMode = WrapMode.Once;

		entity.gameObject.AddComponent<Animation> ();
		entity.GetComponent<Animation> ().playAutomatically = false;



		entity.GetComponent<Animation> ().clip = clip;
		entity.GetComponent<Animation> ().AddClip (clip, "pushToInventory");
		entity.GetComponent<Animation> ().Play ("pushToInventory");
	}

	public Entity get ()
	{
		return entity;
	}

	public bool isEmpty ()
	{
		return get () == null;
	}

	public Entity remove ()
	{

		entity.gameObject.layer = LAYER_DEFAULT;

		//print("Innverntory: Remove - " + entity.gameObject.name);
		entity.transform.localScale = entitySceneScale;
		entity.transform.parent = null;
		entity.touchable = true;
		entity.gameObject.SetActive (false);
		Entity returnEntity = entity;
		entity = null;
		return returnEntity;
	}

	public Entity removeWithoutDeleteSprite ()
	{
		tempGameObject.Add (entity.gameObject);
		Entity returnEntity = entity;
		entity = null;
		Invoke ("disableEntity", 0.6f);
		return returnEntity;
	}

	void disableEntity ()
	{
		for (int i = 0; i < tempGameObject.Count; i++) {
			tempGameObject [i].SetActive (false);
		}
	}

	public bool IsActive {
		get {
			return this.isActive;
		}
	}
}
