using System;
using System.Collections;
using UnityEngine;

namespace DTBuildManifest.UnityCloudBuild {
	[Serializable]
	public class UnityCloudBuildManifest : IBuildManifest {
		// PRAGMA MARK - Static
		[RuntimeInitializeOnLoadMethod]
		private static void Initialize() {
			var manifest = Load();
			if (manifest == null) {
				return;
			}

			BuildManifestRegistry.Register<UnityCloudBuildManifest>(manifest);
		}

		private static UnityCloudBuildManifest Load() {
			var manifestJson = (TextAsset)Resources.Load("UnityCloudBuildManifest.json");
			if (manifestJson == null) {
				return null;
			}

			return JsonUtility.FromJson<UnityCloudBuildManifest>(manifestJson.text);
		}


		// PRAGMA MARK - IBuildManifest Implementation
		string IBuildManifest.ToString() {
			return string.Format("Commit Id: {0}\nBranch: {1}\nBuild Number: {2}\nBuild Start Time: {3}\nProject Id: {4}\nBundle Id: {5}\nUnity Version: {6}\nXCode Version: {7}\nCloud Build Target Name: {8}", this.scmCommitId.Substring(startIndex: 0, length: 7), this.scmBranch, this.buildNumber, this.buildStartTime, this.projectId, this.bundleId, this.unityVersion, this.xcodeVersion, this.cloudBuildTargetName);
		}


		// PRAGMA MARK - Public Interface
		public string scmCommitId;
		public string scmBranch;
		public string buildNumber;
		public string buildStartTime;
		public string projectId;
		public string bundleId;
		public string unityVersion;
		public string xcodeVersion;
		public string cloudBuildTargetName;
	}
}