using System;
using UnityEngine;
using System.Collections.Generic;
using Sunshine.Metric;
using Voidforge;
using LocalizationCustomSystem;
using Sunshine.Views;

namespace DiscoElysium.Trainer
{
	public class TrainerBehaviour : MonoBehaviour
	{

		private readonly Dictionary<KeyCode, Action> _actions = new Dictionary<KeyCode, Action>();

		void Start()
		{
			_actions.Clear();

			_actions.Add(KeyCode.KeypadDivide, () => UpdatePlayerCharacter(p => p.Money -= 10000));
			_actions.Add(KeyCode.KeypadMultiply, () => UpdatePlayerCharacter(p => p.Money += 10000));
			_actions.Add(KeyCode.Keypad8, () => UpdatePlayerCharacter(p => p.SkillPoints -= 1));
			_actions.Add(KeyCode.Keypad9, () => UpdatePlayerCharacter(p => p.SkillPoints += 1));
			_actions.Add(KeyCode.Keypad5, () => UpdatePlayerCharacter(p => p.XpAmount -= 10));
			_actions.Add(KeyCode.Keypad6, () => UpdatePlayerCharacter(p => p.XpAmount += 10));
			_actions.Add(KeyCode.Keypad2, () => UpdateAbilities(-1));
			_actions.Add(KeyCode.Keypad3, () => UpdateAbilities(1));
		}

		private void UpdateAbilities(int value)
		{
			var characterSheet = SingletonComponent<CharsheetView>.Singleton.character;

			foreach (var abilityType in new[] { AbilityType.FYS, AbilityType.INT, AbilityType.MOT, AbilityType.PSY })
			{
				var ability = characterSheet.GetAbility(abilityType);
				var modifier = ability.GetModifierOfType(ModifierType.INITIAL_DICE);
				if (modifier == null)
				{
					modifier = new Modifier(ModifierType.INITIAL_DICE, 1, () => LocalizationManager.GetLocalizedTerm("BASE_ABILITY_LABEL"));
					ability.Add(modifier);
				}
				modifier.Amount += value;
				characterSheet.Recalc();

				if (ViewController.Current == ViewType.CHARACTERSHEET)
					SingletonComponent<CharsheetView>.Singleton.NotifyActivation();
			}
		}

		void UpdatePlayerCharacter(Action<PlayerCharacter> action)
		{
			var playerCharacter = LiteSingleton<PlayerCharacter>.Singleton;
			action(playerCharacter);

			if (ViewController.Current == ViewType.CHARACTERSHEET)
				SingletonComponent<CharsheetView>.Singleton.NotifyActivation();
		}

		void Update()
		{
			foreach (var keyCode in _actions.Keys)
			{
				if (Input.GetKeyDown(keyCode))
					_actions[keyCode]();
			}
		}
	}
}
