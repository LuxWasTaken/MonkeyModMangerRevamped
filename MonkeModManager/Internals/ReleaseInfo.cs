using System;
using System.Collections.Generic;
using MonkeModManager.Internals.SimpleJSON;

namespace MonkeModManager.Internals
{
	// Token: 0x02000008 RID: 8
	public class ReleaseInfo
	{
		// Token: 0x0600004A RID: 74 RVA: 0x000051C8 File Offset: 0x000033C8
		public ReleaseInfo(string _name, string _author, string _version, string _group, string _link, string _installLocation, string _gitPath, JSONArray dependencies)
		{
			this.Name = _name;
			this.Author = _author;
			this.Version = _version;
			this.Group = _group;
			this.Link = _link;
			this.GitPath = _gitPath;
			this.InstallLocation = _installLocation;
			this.Group = _group;
			if (dependencies == null)
			{
				return;
			}
			for (int i = 0; i < dependencies.Count; i++)
			{
				this.Dependencies.Add(dependencies[i]);
			}
		}

		// Token: 0x04000038 RID: 56
		public string Version;

		// Token: 0x04000039 RID: 57
		public string Link;

		// Token: 0x0400003A RID: 58
		public string Name;

		// Token: 0x0400003B RID: 59
		public string Author;

		// Token: 0x0400003C RID: 60
		public string GitPath;

		// Token: 0x0400003D RID: 61
		public string Tag;

		// Token: 0x0400003E RID: 62
		public string Group;

		// Token: 0x0400003F RID: 63
		public string InstallLocation;

		// Token: 0x04000040 RID: 64
		public int ReleaseId;

		// Token: 0x04000041 RID: 65
		public bool Install = true;

		// Token: 0x04000042 RID: 66
		public List<string> Dependencies = new List<string>();

		// Token: 0x04000043 RID: 67
		public List<string> Dependents = new List<string>();
	}
}
