// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 2.0.27
// 

using Colyseus.Schema;
using Action = System.Action;

namespace Network.Schemas {
	public partial class PlayerSettings : Schema {
		[Type(0, "uint8")]
		public byte speed = default(byte);

		[Type(1, "uint8")]
		public byte totalHealth = default(byte);

		[Type(2, "uint8")]
		public byte jumpHeight = default(byte);

		/*
		 * Support for individual property change callbacks below...
		 */

		protected event PropertyChangeHandler<byte> __speedChange;
		public Action OnSpeedChange(PropertyChangeHandler<byte> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.speed));
			__speedChange += __handler;
			if (__immediate && this.speed != default(byte)) { __handler(this.speed, default(byte)); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(speed));
				__speedChange -= __handler;
			};
		}

		protected event PropertyChangeHandler<byte> __totalHealthChange;
		public Action OnTotalHealthChange(PropertyChangeHandler<byte> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.totalHealth));
			__totalHealthChange += __handler;
			if (__immediate && this.totalHealth != default(byte)) { __handler(this.totalHealth, default(byte)); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(totalHealth));
				__totalHealthChange -= __handler;
			};
		}

		protected event PropertyChangeHandler<byte> __jumpHeightChange;
		public Action OnJumpHeightChange(PropertyChangeHandler<byte> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.jumpHeight));
			__jumpHeightChange += __handler;
			if (__immediate && this.jumpHeight != default(byte)) { __handler(this.jumpHeight, default(byte)); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(jumpHeight));
				__jumpHeightChange -= __handler;
			};
		}

		protected override void TriggerFieldChange(DataChange change) {
			switch (change.Field) {
				case nameof(speed): __speedChange?.Invoke((byte) change.Value, (byte) change.PreviousValue); break;
				case nameof(totalHealth): __totalHealthChange?.Invoke((byte) change.Value, (byte) change.PreviousValue); break;
				case nameof(jumpHeight): __jumpHeightChange?.Invoke((byte) change.Value, (byte) change.PreviousValue); break;
				default: break;
			}
		}
	}
}
