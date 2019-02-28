using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCamera : MonoBehaviour
{

	[SerializeField] Transform m_target;
	[SerializeField] Vector3 m_offset;
	[SerializeField] float m_followSmoothing = 0.1f;
	[SerializeField] float m_lookSmoothing = 0.1f;

	void LookAtTarget()
	{
		Vector3 lookDir = m_target.position - transform.position;
		Quaternion rot = Quaternion.LookRotation(lookDir, Vector3.up);
		transform.rotation = Quaternion.Lerp(transform.rotation, rot, m_lookSmoothing);
	}

	void MoveToTarget()
	{
		Vector3 targetPos = m_target.position +
							m_target.transform.forward * m_offset.z +
							m_target.transform.right * m_offset.x +
							m_target.transform.up * m_offset.y;
		transform.position = Vector3.Lerp(transform.position, targetPos, m_followSmoothing);
	}

    void FixedUpdate()
    {
		LookAtTarget();
		MoveToTarget();
    }
}
