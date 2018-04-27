using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityUtility;

public class GlobalSettings : MonoBehaviour
{
	static GlobalSettings _instance;
	static GlobalSettings Instance
	{
		get
		{
			if (_instance) return _instance;

			_instance = GlobalObject.GetOrAddComponent<GlobalSettings>();
			return _instance;
		}
	}

	[SerializeField]
	private float mouseSensitiveness;
	public static float MouseSensitiveness
	{
		get { return Instance.mouseSensitiveness; }
		set { Instance.mouseSensitiveness = value; }
	}

	[SerializeField]
	private bool gotFirstLevelKey;
	public static bool GotFirstLevelKey
	{
		get { return Instance.gotFirstLevelKey; }
		set { Instance.gotFirstLevelKey = value; }
	}

	[SerializeField]
	private bool gotThirdLevelKey;
	public static bool GotThirdLevelKey
	{
		get { return Instance.gotThirdLevelKey; }
		set { Instance.gotThirdLevelKey = value; }
	}

	public static void Gameover()
	{
		print("Gameover");
		GlobalObject.GetOrAddComponent<SwitchLevel>().Reload();
	}

}
