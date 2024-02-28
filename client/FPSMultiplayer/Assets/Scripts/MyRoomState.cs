using System;
using Colyseus.Schema;

public partial class MyRoomState : Schema {
    [Colyseus.Schema.Type(0, "string")]
    public string mySynchronizedProperty = default(string);

    /*
     * Support for individual property change callbacks below...
     */

    protected event PropertyChangeHandler<string> __mySynchronizedPropertyChange;
    public Action OnMySynchronizedPropertyChange(PropertyChangeHandler<string> __handler, bool __immediate = true) {
        if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
        __callbacks.AddPropertyCallback(nameof(this.mySynchronizedProperty));
        __mySynchronizedPropertyChange += __handler;
        if (__immediate && this.mySynchronizedProperty != default(string)) { __handler(this.mySynchronizedProperty, default(string)); }
        return () => {
            __callbacks.RemovePropertyCallback(nameof(mySynchronizedProperty));
            __mySynchronizedPropertyChange -= __handler;
        };
    }

    protected override void TriggerFieldChange(DataChange change) {
        switch (change.Field) {
            case nameof(mySynchronizedProperty): __mySynchronizedPropertyChange?.Invoke((string) change.Value, (string) change.PreviousValue); break;
            default: break;
        }
    }
}