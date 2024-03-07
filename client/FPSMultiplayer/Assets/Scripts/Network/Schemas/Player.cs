// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 2.0.27
// 

using System;
using Colyseus.Schema;
using Action = System.Action;

namespace Network.Schemas {
	public partial class Player : Schema {
		[Colyseus.Schema.Type(0, "ref", typeof(Movement))]
		public Movement movement = new Movement();

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

		protected override void TriggerFieldChange(DataChange change) {
			switch (change.Field) {
				case nameof(movement): __movementChange?.Invoke((Movement) change.Value, (Movement) change.PreviousValue); break;
				default: break;
			}
		}
	}
}
