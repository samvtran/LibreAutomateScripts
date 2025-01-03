using Au.Triggers;

partial class Program
{
    /// <summary>
    /// Custom shortcuts for the Capacities PKM app.
    /// </summary>
    void CapacitiesShortcuts(HotkeyTriggers hk)
    {
        Triggers.Of.Window("Capacities");

        // Select the add/new button since the regular Ctrl+N shortcut is for creating any object not just the one focused.
        hk["Ctrl+Shift+N"] = o =>
        {
            var w = wnd.active;
            var button = w.Elm["BUTTON", also: o => o.Name == "Add" || o.Name == "New"];

            if (!button.Exists()) return;

            button.Find(1).Invoke();
        };

        // Activate the block-level color picker
        hk["Ctrl+Alt+Shift+H"] = o =>
        {
            var w = wnd.active;
            // Trigger the block-level editor panel
            keys.send("Ctrl+Shift+E");

            var blockButton = w.Elm["web:GROUPING", "Turn blocks into"];
            if (!blockButton.Exists(2)) return;

            var colorButton = blockButton.Find().Navigate("parent previous first");
            if (colorButton == null) return;

            colorButton.MouseClick();
        };

        // Alt+1-4 for h1-h4
        foreach (var i in Enumerable.Range(1, 4))
        {
            hk[$"Alt+{i}"] = o =>
            {
                var hashes = new string('#', i);
                keys.send("Home", $"!{hashes}", "Space", "End");
            };
        }

        Triggers.Of.AllWindows();
    }
}
