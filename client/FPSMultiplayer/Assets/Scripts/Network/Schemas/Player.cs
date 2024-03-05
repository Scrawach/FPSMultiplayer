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
		[Type(0, "ref", typeof(Vector3Data))]
		public Vector3Data position = new Vector3Data();

		[Type(1, "ref", typeof(Vector3Data))]
		public Vector3Data velocity = new Vector3Data();

		/*
		 * Support for individual property change callbacks below...
		 */

		protected event PropertyChangeHandler<Vector3Data> __positionChange;
		public Action OnPositionChange(PropertyChangeHandler<Vector3Data> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.position));
			__positionChange += __handler;
			if (__immediate && this.position != null) { __handler(this.position, null); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(position));
				__positionChange -= __handler;
			};
		}

		protected event PropertyChangeHandler<Vector3Data> __velocityChange;
		public Action OnVelocityChange(PropertyChangeHandler<Vector3Data> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.velocity));
			__velocityChange += __handler;
			if (__immediate && this.velocity != null) { __handler(this.velocity, null); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(velocity));
				__velocityChange -= __handler;
			};
		}

		protected override void TriggerFieldChange(DataChange change) {
			switch (change.Field) {
				case nameof(position): __positionChange?.Invoke((Vector3Data) change.Value, (Vector3Data) change.PreviousValue); break;
				case nameof(velocity): __velocityChange?.Invoke((Vector3Data) change.Value, (Vector3Data) change.PreviousValue); break;
				default: break;
			}
		}
	}
}
