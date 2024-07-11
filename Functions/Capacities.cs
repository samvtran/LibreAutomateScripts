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

		// Activate the block-level color picker
		hk["Ctrl+Alt+Shift+H"] = o => {
			var w = wnd.active;
			// Trigger the block-level editor panel
			keys.send("Ctrl+Shift+E");

			var blockButton = w.Elm["web:GROUPING", "Turn blocks into"];
			if (!blockButton.Exists()) return;

			var colorButton = blockButton.Find(2).Navigate("parent previous first");
			if (colorButton == null) return;

			colorButton.MouseClick();
		};

		Triggers.Of.AllWindows();
	}
}
