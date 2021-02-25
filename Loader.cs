using UnityEngine;
using Voidforge;

namespace DiscoElysium.Trainer
{
	public class Loader
	{

		public static GameObject HookObject
		{
			get
			{
				var result = SingletonComponent<World>.Singleton.gameObject;
				if (result != null) 
					return result;

				result = GameObject.Find(typeof(Loader).FullName);
				if (result != null) 
					return result;

				result = new GameObject(typeof(Loader).FullName);
				Object.DontDestroyOnLoad(result);

				return result;
			}
		}

		public static TrainerBehaviour Trainer
		{
			get
			{
				return HookObject.GetComponent<TrainerBehaviour>();
			}
		}

		public static void Load()
		{
			HookObject.AddComponent<TrainerBehaviour>();
		}

		public static void Unload()
		{
			Object.DestroyImmediate(Trainer);
			Object.DestroyImmediate(HookObject);
		}
	}
}
