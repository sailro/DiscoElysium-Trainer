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
				return result != null ? result : new GameObject();
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
			var trainer = Trainer;
			if (trainer != null)
				Object.DestroyImmediate(trainer);
		}
	}
}
