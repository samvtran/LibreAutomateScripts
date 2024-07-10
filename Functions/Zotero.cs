using Au.Triggers;

partial class Program {
	/// <summary>
	/// Ctrl+H from anywhere to go back to the main library and focus the first item.
	///
	/// WARNING: This is currently set up to work with Zotero 7 beta. It has already broken once between betas.
	/// </summary>
	void ZoteroGoToHome(HotkeyTriggers hk) {
		Triggers.Of.Window(of: "zotero.exe");

		// Focus on My Library contents
		hk["Ctrl+H"] = o => {
			var w = wnd.active;
			// First click into the library tab
			w.Elm["div", prop: "@class=tab-name"].Find(1).Invoke();
			//First click into the My Library collection
			w.Elm["TREEITEM", "My Library"].Find(1).Invoke();
			// Then focus the first item in the list
			w.Elm["TREE", "Items"]["TREEITEM"].Find(1).Invoke();
		};
	}
}
