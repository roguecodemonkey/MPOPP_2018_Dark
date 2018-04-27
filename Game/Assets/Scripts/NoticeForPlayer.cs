using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class OnTriggerEnterEvent : UnityEvent<Collider> { }

public class NoticeForPlayer : MonoBehaviour
{
	[SerializeField]
	bool shown;

	[SerializeField]
	OnTriggerEnterEvent OnTouch;

	[SerializeField]
	UnityEvent OnQuit;

	void OnTriggerEnter(Collider collider)
	{
		if (shown) return;

		Time.timeScale = 0;
		shown = true;

		if (OnTouch != null)
			OnTouch.Invoke(collider);
	}

	public void TriggerNotice()
	{
		if (shown) return;
		StartCoroutine(DelayTrigger());
	}

	void Update()
	{
		if (shown && Input.anyKeyDown)
		{
			Time.timeScale = 1;
            this.enabled = false;

			if (OnQuit != null)
				OnQuit.Invoke();
		}
	}

	IEnumerator DelayTrigger()
	{
		yield return null;

		Time.timeScale = 0;
		shown = true;

		if (OnTouch != null)
			OnTouch.Invoke(null);
	}
}
