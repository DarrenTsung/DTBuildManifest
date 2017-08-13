using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DTBuildManifest {
	public static class BuildManifestRegistry {
		// PRAGMA MARK - Public Interface
		public static event Action OnManifestRegistered = delegate {};

		public static IEnumerable<KeyValuePair<Type, IBuildManifest>> TypeManifests {
			get { return manifestMap_; }
		}

		public static IEnumerable<IBuildManifest> Manifests {
			get { return manifestMap_.Values; }
		}

		public static IBuildManifest GetManifestOfType<T>() {
			Type type = typeof(T);
			if (!manifestMap_.ContainsKey(type)) {
				return null;
			}

			return manifestMap_[type];
		}

		public static void Register<T>(T manifest) where T : IBuildManifest {
			manifestMap_[typeof(T)] = manifest;
			OnManifestRegistered.Invoke();
		}


		// PRAGMA MARK - Internal
		private static readonly Dictionary<Type, IBuildManifest> manifestMap_ = new Dictionary<Type, IBuildManifest>();
	}
}