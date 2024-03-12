// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 2.0.27
// 

using Colyseus.Schema;
using Action = System.Action;

namespace Network.Schemas {
	public partial class Player : Schema {
		[Type(0, "ref", typeof(Movement))]
		public Movement movement = new Movement();

		[Type(1, "ref", typeof(CharacterStatsData))]
		public CharacterStatsData settings = new CharacterStatsData();

		/*
		 * Support for individual property change callbacks below...
		 */

		protected event PropertyChangeHandler<Movement> __movementChange;
		public Action OnMovementChange(PropertyChangeHandler<Movement> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.movement));
			__movementChange += __handler;
			if (__immediate && this.movement != null) { __handler(this.movement, null); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(movement));
				__movementChange -= __handler;
			};
		}

		protected event PropertyChangeHandler<CharacterStatsData> __settingsChange;
		public Action OnSettingsChange(PropertyChangeHandler<CharacterStatsData> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.settings));
			__settingsChange += __handler;
			if (__immediate && this.settings != null) { __handler(this.settings, null); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(settings));
				__settingsChange -= __handler;
			};
		}

		protected override void TriggerFieldChange(DataChange change) {
			switch (change.Field) {
				case nameof(movement): __movementChange?.Invoke((Movement) change.Value, (Movement) change.PreviousValue); break;
				case nameof(settings): __settingsChange?.Invoke((CharacterStatsData) change.Value, (CharacterStatsData) change.PreviousValue); break;
				default: break;
			}
		}
	}
}
