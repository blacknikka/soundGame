using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesMove : MonoBehaviour {

	[SerializeField, Range(0, 10)]
	float time = 1;

	[SerializeField]
	Vector3	endPosition;

	//[SerializeField]
	//AnimationCurve curve;

	private float startTime;
	private Vector3 startPosition;

	void OnEnable ()
	{
		// 生成時の情報を保存しておく
		startTime = Time.timeSinceLevelLoad;
		startPosition = transform.position;
	}

	// 目的地の情報をセットする関数
	public void SetMoveInf(Vector3 end, float t)
	{
		endPosition = end;
		time = t;
	}
	
	void Update ()
	{
		var diff = Time.timeSinceLevelLoad - startTime;
		if (diff > time) {
			transform.position = endPosition;
			enabled = false;

			// 目的地に到着したら消去する
			Destroy(gameObject);
		}

		var rate = diff / time;
		//var pos = curve.Evaluate(rate);
		
		transform.position = Vector3.Lerp (startPosition, endPosition, rate);
		//transform.position = Vector3.Lerp (startPosition, endPosition, pos);
	}

	void OnDrawGizmosSelected ()
	{
#if UNITY_EDITOR

		if( !UnityEditor.EditorApplication.isPlaying || enabled == false ){
			startPosition = transform.position;
		}

		UnityEditor.Handles.Label(endPosition, endPosition.ToString());
		UnityEditor.Handles.Label(startPosition, startPosition.ToString());
#endif
		Gizmos.DrawSphere (endPosition, 0.1f);
		Gizmos.DrawSphere (startPosition, 0.1f);

		Gizmos.DrawLine (startPosition, endPosition);
	}
}
