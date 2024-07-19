using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraFollow : MonoBehaviour
{
	public float followSpeed = 2f;
	public Transform target;
	
	private Transform camTransform;
	
	public float shakeDuration = 0f;
	
	public float shakeAmount = 0.1f;
	public float decreaseFactor = 1.0f;

	private Vector3 _originalPos;

	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}

	void OnEnable()
	{
		_originalPos = camTransform.localPosition;
	}

	private void Update()
	{
		Vector3 newPosition = target.position;
		newPosition.z = -10;
		transform.position = Vector3.Slerp(transform.position, newPosition, followSpeed * Time.deltaTime);

		if (shakeDuration > 0)
		{
			camTransform.localPosition = _originalPos + Random.insideUnitSphere * shakeAmount;

			shakeDuration -= Time.deltaTime * decreaseFactor;
		}
	}

	public void ShakeCamera()
	{
		_originalPos = camTransform.localPosition;
		shakeDuration = 0.2f;
	}
}
