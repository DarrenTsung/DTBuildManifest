#if DT_DEBUG_MENU
using System;
using System.Collections;
using UnityEngine;

using DTDebugMenu;

namespace DTBuildManifest.DebugMenu {
	public static class BuildManifestDebugMenuItem {
		// PRAGMA MARK - Static
		[RuntimeInitializeOnLoadMethod]
		private static void Initialize() {
			RefreshManifests();
			BuildManifestRegistry.OnManifestRegistered += HandleManifestRegistered;
		}

		private static void HandleManifestRegistered() {
			RefreshManifests();
		}

		private static void RefreshManifests() {
			var inspector = GenericInspectorRegistry.Get("Build Manifests");
			inspector.ResetFields();

			foreach (var kvp in BuildManifestRegistry.TypeManifests) {
				Type type = kvp.Key;
				IBuildManifest manifest = kvp.Value;

				inspector.RegisterHeader(type.Name);
				inspector.RegisterLabel(manifest.ToString());
			}
		}
	}
}
#endif