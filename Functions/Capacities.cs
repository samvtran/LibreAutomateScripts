using Au.Triggers;

partial class Program {
	/// <summary>
	/// Custom shortcuts for the Capacities PKM app.
	/// </summary>
	void CapacitiesShortcuts(HotkeyTriggers hk) {
		Triggers.Of.Window("Capacities");
		
		// Select the add/new button since the regular Ctrl+N shortcut is for creating any object not just the one focused.
		hk["Ctrl+Shift+N"] = o => {
			var w = wnd.active;
			var button = w.Elm["web:BUTTON", also: o => o.Name == "Add" || o.Name == "New"];
			
			if (!button.Exists()) return;
			
			button.Find(1).Invoke();
		};
		
		Triggers.Of.AllWindows();
	}
}
