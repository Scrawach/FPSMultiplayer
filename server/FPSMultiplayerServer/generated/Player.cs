// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 2.0.27
// 

using Colyseus.Schema;
using Action = System.Action;

public partial class Player : Schema {
	[Type(0, "ref", typeof(Position))]
	public Position position = new Position();

	/*
	 * Support for individual property change callbacks below...
	 */

	protected event PropertyChangeHandler<Position> __positionChange;
	public Action OnPositionChange(PropertyChangeHandler<Position> __handler, bool __immediate = true) {
		if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
		__callbacks.AddPropertyCallback(nameof(this.position));
		__positionChange += __handler;
		if (__immediate && this.position != null) { __handler(this.position, null); }
		return () => {
			__callbacks.RemovePropertyCallback(nameof(position));
			__positionChange -= __handler;
		};
	}

	protected override void TriggerFieldChange(DataChange change) {
		switch (change.Field) {
			case nameof(position): __positionChange?.Invoke((Position) change.Value, (Position) change.PreviousValue); break;
			default: break;
		}
	}
}

