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
		public CharacterStatsData stats = new CharacterStatsData();

		[Type(2, "ref", typeof(ScoreData))]
		public ScoreData score = new ScoreData();

		[Type(3, "ref", typeof(HealthData))]
		public HealthData health = new HealthData();

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

		protected event PropertyChangeHandler<CharacterStatsData> __statsChange;
		public Action OnStatsChange(PropertyChangeHandler<CharacterStatsData> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.stats));
			__statsChange += __handler;
			if (__immediate && this.stats != null) { __handler(this.stats, null); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(stats));
				__statsChange -= __handler;
			};
		}

		protected event PropertyChangeHandler<ScoreData> __scoreChange;
		public Action OnScoreChange(PropertyChangeHandler<ScoreData> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.score));
			__scoreChange += __handler;
			if (__immediate && this.score != null) { __handler(this.score, null); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(score));
				__scoreChange -= __handler;
			};
		}

		protected event PropertyChangeHandler<HealthData> __healthChange;
		public Action OnHealthChange(PropertyChangeHandler<HealthData> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.health));
			__healthChange += __handler;
			if (__immediate && this.health != null) { __handler(this.health, null); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(health));
				__healthChange -= __handler;
			};
		}

		protected override void TriggerFieldChange(DataChange change) {
			switch (change.Field) {
				case nameof(movement): __movementChange?.Invoke((Movement) change.Value, (Movement) change.PreviousValue); break;
				case nameof(stats): __statsChange?.Invoke((CharacterStatsData) change.Value, (CharacterStatsData) change.PreviousValue); break;
				case nameof(score): __scoreChange?.Invoke((ScoreData) change.Value, (ScoreData) change.PreviousValue); break;
				case nameof(health): __healthChange?.Invoke((HealthData) change.Value, (HealthData) change.PreviousValue); break;
				default: break;
			}
		}
	}
}
