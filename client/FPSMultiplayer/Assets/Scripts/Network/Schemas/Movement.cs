// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 2.0.27
// 

using Colyseus.Schema;
using Action = System.Action;

namespace Network.Schemas {
	public partial class Movement : Schema {
		[Type(0, "ref", typeof(Vector3Data))]
		public Vector3Data position = new Vector3Data();

		[Type(1, "ref", typeof(Vector3Data))]
		public Vector3Data velocity = new Vector3Data();

		[Type(2, "ref", typeof(Vector2Data))]
		public Vector2Data rotation = new Vector2Data();

		[Type(3, "ref", typeof(Vector2Data))]
		public Vector2Data angles = new Vector2Data();

		[Type(4, "boolean")]
		public bool isSitting = default(bool);

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

		protected event PropertyChangeHandler<Vector2Data> __rotationChange;
		public Action OnRotationChange(PropertyChangeHandler<Vector2Data> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.rotation));
			__rotationChange += __handler;
			if (__immediate && this.rotation != null) { __handler(this.rotation, null); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(rotation));
				__rotationChange -= __handler;
			};
		}

		protected event PropertyChangeHandler<Vector2Data> __anglesChange;
		public Action OnAnglesChange(PropertyChangeHandler<Vector2Data> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.angles));
			__anglesChange += __handler;
			if (__immediate && this.angles != null) { __handler(this.angles, null); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(angles));
				__anglesChange -= __handler;
			};
		}

		protected event PropertyChangeHandler<bool> __isSittingChange;
		public Action OnIsSittingChange(PropertyChangeHandler<bool> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.isSitting));
			__isSittingChange += __handler;
			if (__immediate && this.isSitting != default(bool)) { __handler(this.isSitting, default(bool)); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(isSitting));
				__isSittingChange -= __handler;
			};
		}

		protected override void TriggerFieldChange(DataChange change) {
			switch (change.Field) {
				case nameof(position): __positionChange?.Invoke((Vector3Data) change.Value, (Vector3Data) change.PreviousValue); break;
				case nameof(velocity): __velocityChange?.Invoke((Vector3Data) change.Value, (Vector3Data) change.PreviousValue); break;
				case nameof(rotation): __rotationChange?.Invoke((Vector2Data) change.Value, (Vector2Data) change.PreviousValue); break;
				case nameof(angles): __anglesChange?.Invoke((Vector2Data) change.Value, (Vector2Data) change.PreviousValue); break;
				case nameof(isSitting): __isSittingChange?.Invoke((bool) change.Value, (bool) change.PreviousValue); break;
				default: break;
			}
		}
	}
}
