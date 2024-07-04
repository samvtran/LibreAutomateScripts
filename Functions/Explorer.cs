using Au.Triggers;

partial class Program {
	/// <summary>
	/// Triggers PowerToys Peek on space like macOS' QuickLook and other Windows QuickLook-like plugins.
	/// Ignores space while focused on other Explorer UI elements or when editing filenames.
	///
	/// NOTE: I don't use this as Peek doesn't currently work with my main file manager, Directory Opus :(
	/// </summary>
	void ExplorerQuicklook(HotkeyTriggers hk) {
		Triggers.Of.Window(of: "explorer.exe");
		Triggers.FuncOf.NextTrigger = o => {
			var w = elm.fromWindow(wnd.active);
			var maybeShellFolderView = w.Elm["WINDOW", "Shell Folder View"].Find();

			if (maybeShellFolderView == null) {
				Console.WriteLine("No shell folder view");
				return false;
			}

			var listItem = w.Elm["LISTITEM", prop: "state=SELECTED, FOCUSED"].In(maybeShellFolderView).Find();

			if (listItem == null) {
				Console.WriteLine("no list item selected");
				return false;
			}

			return true;
		};

		hk["Space"] = o => {
			keys.send("Ctrl+Shift+Space");
		};

		Triggers.Of.AllWindows();
	}
}
