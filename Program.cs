global using Au;
global using Au.Types;
global using System;
global using System.Linq;

using Au.Triggers;

/// <summary>
/// A dumping ground for any LibreAutomate globals and Program properties used by functions.
/// </summary>
partial class Program {
    ActionTriggers Triggers { get; } = new();
}
