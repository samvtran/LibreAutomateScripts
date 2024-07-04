using Au.Triggers;

partial class Program {
	/// <summary>
	/// Some convenient autotext triggers for OneNote. Some functionality currently uses the OneMore plugin.
	/// </summary>
	void OneNoteTextReplacements(AutotextTriggers tt) {
		Triggers.Of.Window(of: "onenote.exe");
		
		// Code block via OneMore
		tt[";c"] = o => {
			o.Replace("");
			keys.send("F6");
		};
		
		// Normal text
		tt[";n"] = o => {
			o.Replace("");
			keys.send("Ctrl+Shift+N");
		};
		
		// Headers 1-6
		foreach (var i in Enumerable.Range(1, 6)) {
			tt[$";{i}"] = o => {
				o.Replace("");
				keys.send($"Ctrl+Alt+{i}");
			};
		}
		
		// Math equation block
		tt[";m"] = o => {
			o.Replace("");
			keys.send("Alt+=");
		};
		
		Triggers.Of.AllWindows();
	}
}
