using Au.Triggers;

partial class Program {
	/// <summary>
	/// When using minimize to tray, force Thunderbird to minimize on close instead of quitting.
	/// </summary>
	void ThunderbirdMinimizeOnClose(MouseTriggers m) {
		Triggers.Of.Window(cn: "MozillawindowClass", of: "thunderbird.exe");
		Triggers.FuncOf.NextTrigger = o => {
			var pos = mouse.xy;
			var win = wnd.fromMouse(WXYFlags.NeedWindow);

			// 8 = min, 9 = max, 20 = close
			var ret = win.Send(0x84, 0, pos.x|(pos.y<<16)); // WM_NCHITTEST
			return ret == 20;
		};
		m[TMClick.Left] = o => {
			o.Window.ShowMinimized();
		};
		Triggers.Of.AllWindows();
	}
}
