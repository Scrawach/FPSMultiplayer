// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 2.0.27
// 

using Colyseus.Schema;
using Action = System.Action;

namespace Network.Schemas {
	public partial class HealthData : Schema {
		[Type(0, "uint8")]
		public byte current = default(byte);

		[Type(1, "uint8")]
		public byte total = default(byte);

		/*
		 * Support for individual property change callbacks below...
		 */

		protected event PropertyChangeHandler<byte> __currentChange;
		public Action OnCurrentChange(PropertyChangeHandler<byte> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.current));
			__currentChange += __handler;
			if (__immediate && this.current != default(byte)) { __handler(this.current, default(byte)); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(current));
				__currentChange -= __handler;
			};
		}

		protected event PropertyChangeHandler<byte> __totalChange;
		public Action OnTotalChange(PropertyChangeHandler<byte> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.total));
			__totalChange += __handler;
			if (__immediate && this.total != default(byte)) { __handler(this.total, default(byte)); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(total));
				__totalChange -= __handler;
			};
		}

		protected override void TriggerFieldChange(DataChange change) {
			switch (change.Field) {
				case nameof(current): __currentChange?.Invoke((byte) change.Value, (byte) change.PreviousValue); break;
				case nameof(total): __totalChange?.Invoke((byte) change.Value, (byte) change.PreviousValue); break;
				default: break;
			}
		}
	}
}
