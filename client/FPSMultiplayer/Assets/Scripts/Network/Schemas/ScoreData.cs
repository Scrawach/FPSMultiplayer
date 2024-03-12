// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 2.0.27
// 

using Colyseus.Schema;
using Action = System.Action;

namespace Network.Schemas {
	public partial class ScoreData : Schema {
		[Type(0, "uint8")]
		public byte kills = default(byte);

		[Type(1, "uint8")]
		public byte deaths = default(byte);

		/*
		 * Support for individual property change callbacks below...
		 */

		protected event PropertyChangeHandler<byte> __killsChange;
		public Action OnKillsChange(PropertyChangeHandler<byte> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.kills));
			__killsChange += __handler;
			if (__immediate && this.kills != default(byte)) { __handler(this.kills, default(byte)); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(kills));
				__killsChange -= __handler;
			};
		}

		protected event PropertyChangeHandler<byte> __deathsChange;
		public Action OnDeathsChange(PropertyChangeHandler<byte> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.deaths));
			__deathsChange += __handler;
			if (__immediate && this.deaths != default(byte)) { __handler(this.deaths, default(byte)); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(deaths));
				__deathsChange -= __handler;
			};
		}

		protected override void TriggerFieldChange(DataChange change) {
			switch (change.Field) {
				case nameof(kills): __killsChange?.Invoke((byte) change.Value, (byte) change.PreviousValue); break;
				case nameof(deaths): __deathsChange?.Invoke((byte) change.Value, (byte) change.PreviousValue); break;
				default: break;
			}
		}
	}
}
