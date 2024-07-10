using Au.Triggers;

partial class Program {
	/// <summary>
	/// Convenient text replacements for commonly used symbols. Postfix is disabled so replacements are immediate.
	/// </summary>
	void TextReplacements(AutotextTriggers tt) {
		tt.DefaultPostfixType = TAPostfix.None;

		var tr = tt.SimpleReplace;

		tr[";giggle"] = "🤭";

		tr[";zettel"] = DateTime.Now.ToString("yyyyMMddHHmmss");
		tr[";date"] = DateTime.Now.ToString("yyyy-MM-dd");
		tr[";time"] = DateTime.Now.ToString("HH:mm:ss");

		tr[";en"] = "–";
		tr[";em"] = "—";

		tr[";guid"] = Guid.NewGuid().ToString();
	}
}
