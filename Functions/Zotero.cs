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
			w.Elm["div", prop: "@class=tab-name"].Find(1).MouseClick();
			//First click into the My Library collection
			w.Elm["TREEITEM", "My Library"].Find(1).MouseClick();
			// Then focus the first item in the list
			w.Elm["TREE", "Items"]["TREEITEM"].Find(1)/*image:WkJNG7UIAMT//3F1Z7xipf6sK5Q2AUqQqhSiVOHO083/zrv+1muLWd5tEYRvwqjE7xP4Fm2iJowCTCDA5gPBB75AbqK63VIkI/wQMETGr+sx/DrgCengWyughsrNXmxZu76ZqrR4Xs1DXYgVNL6NKFm7x/HrG/r7O6HWR8ElZxyHdR54up5HlJEKM89v8Gw4xXScAm9vb+D5fwackfGjYl66UiPNisMLJAyfR0oQlxglPMvGOHgzbfNnB0YUsjGiFFDOV2hLTRYoUhbXI4UbAfPNCxz+TL1vc8KMrkvbvDb5+zaSFExKZWPcPNaI0xIpK5ZL1ZDiXYCC5I8wKE0QpMDaqp/tXcWHolLGzd9kVBdWOPCBICOinH92NC/wlcMv246rqoorHGjDgQ3FHSJbhKxiO9F4gCWmbcNzKpQLsvFMbxSUHWG84BK83Hx74QORyTy7AA==*/.MouseClick();
		};
	}
}
