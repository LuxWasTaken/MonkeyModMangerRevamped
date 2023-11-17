using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using MonkeModManager.Internals;
using MonkeModManager.Internals.SimpleJSON;

namespace MonkeModManager
{
	// Token: 0x02000002 RID: 2
	public partial class FormMain : Form
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public FormMain()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000002 RID: 2 RVA: 0x0000207C File Offset: 0x0000027C
		private void FormMain_Load(object sender, EventArgs e)
		{
			this.LocationHandler();
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			this.releases = new List<ReleaseInfo>();
			string text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
			this.labelVersion.Text = "Monke Mod Manager v" + text.Substring(0, text.Length - 2);
			if (!File.Exists(Path.Combine(this.InstallDirectory, "winhttp.dll")))
			{
				if (File.Exists(Path.Combine(this.InstallDirectory, "mods.disable")))
				{
					this.buttonToggleMods.Text = "Enable Mods";
					this.modsDisabled = true;
					this.buttonToggleMods.BackColor = Color.IndianRed;
					this.buttonToggleMods.Enabled = true;
				}
				else
				{
					this.buttonToggleMods.Enabled = false;
				}
			}
			else
			{
				this.buttonToggleMods.Enabled = true;
			}
			new Thread(delegate
			{
				this.LoadRequiredPlugins();
			}).Start();
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002170 File Offset: 0x00000370
		private void LoadReleases()
		{
			JSONNode jsonnode = JSON.Parse(this.DownloadSite("https://raw.githubusercontent.com/DeadlyKitten/MonkeModInfo/master/modinfo.json"));
			JSONNode jsonnode2 = JSON.Parse(this.DownloadSite("https://raw.githubusercontent.com/DeadlyKitten/MonkeModInfo/master/groupinfo.json"));
			JSONArray asArray = jsonnode.AsArray;
			JSONArray asArray2 = jsonnode2.AsArray;
			for (int i = 0; i < asArray.Count; i++)
			{
				JSONNode jsonnode3 = asArray[i];
				ReleaseInfo releaseInfo = new ReleaseInfo(jsonnode3["name"], jsonnode3["author"], jsonnode3["version"], jsonnode3["group"], jsonnode3["download_url"], jsonnode3["install_location"], jsonnode3["git_path"], jsonnode3["dependencies"].AsArray);
				this.releases.Add(releaseInfo);
			}
			asArray2.Linq.OrderBy((KeyValuePair<string, JSONNode> x) => x.Value["rank"]);
			for (int j = 0; j < asArray2.Count; j++)
			{
				JSONNode current = asArray2[j];
				if (this.releases.Any((ReleaseInfo x) => x.Group == current["name"]))
				{
					this.groups.Add(current["name"], this.groups.Count<KeyValuePair<string, int>>());
				}
			}
			this.groups.Add("Uncategorized", this.groups.Count<KeyValuePair<string, int>>());
			foreach (ReleaseInfo releaseInfo2 in this.releases)
			{
				using (List<string>.Enumerator enumerator2 = releaseInfo2.Dependencies.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						string dep = enumerator2.Current;
						ReleaseInfo releaseInfo3 = this.releases.Where((ReleaseInfo x) => x.Name == dep).FirstOrDefault<ReleaseInfo>();
						if (releaseInfo3 != null)
						{
							releaseInfo3.Dependents.Add(releaseInfo2.Name);
						}
					}
				}
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000023E0 File Offset: 0x000005E0
		private void LoadRequiredPlugins()
		{
			this.CheckVersion();
			this.UpdateStatus("Getting latest version info...");
			this.LoadReleases();
			base.Invoke(new MethodInvoker(delegate
			{
				new Dictionary<string, int>();
				int i;
				int j;
				for (i = 0; i < this.groups.Count<KeyValuePair<string, int>>(); i = j + 1)
				{
					string key = this.groups.First((KeyValuePair<string, int> x) => x.Value == i).Key;
					int num = this.listViewMods.Groups.Add(new ListViewGroup(key, HorizontalAlignment.Left));
					this.groups[key] = num;
					j = i;
				}
				foreach (ReleaseInfo releaseInfo in this.releases)
				{
					ListViewItem listViewItem = new ListViewItem();
					listViewItem.Text = releaseInfo.Name;
					if (!string.IsNullOrEmpty(releaseInfo.Version))
					{
						listViewItem.Text = releaseInfo.Name + " - " + releaseInfo.Version;
					}
					if (!string.IsNullOrEmpty(releaseInfo.Tag))
					{
						listViewItem.Text = string.Format("{0} - ({1})", releaseInfo.Name, releaseInfo.Tag);
					}
					listViewItem.SubItems.Add(releaseInfo.Author);
					listViewItem.Tag = releaseInfo;
					if (releaseInfo.Install)
					{
						this.listViewMods.Items.Add(listViewItem);
					}
					this.CheckDefaultMod(releaseInfo, listViewItem);
					if (releaseInfo.Group == null || !this.groups.ContainsKey(releaseInfo.Group))
					{
						listViewItem.Group = this.listViewMods.Groups[this.groups["Uncategorized"]];
					}
					else if (this.groups.ContainsKey(releaseInfo.Group))
					{
						int num2 = this.groups[releaseInfo.Group];
						listViewItem.Group = this.listViewMods.Groups[num2];
					}
				}
				this.tabControlMain.Enabled = true;
				this.buttonInstall.Enabled = true;
			}));
			this.UpdateStatus("Release info updated!");
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002418 File Offset: 0x00000618
		private void UpdateReleaseInfo(ref ReleaseInfo release)
		{
			Thread.Sleep(100);
			string text = "https://api.github.com/repos/" + release.GitPath + "/releases";
			JSONNode jsonnode = JSON.Parse(this.DownloadSite(text))[0];
			release.Version = jsonnode["tag_name"];
			JSONNode jsonnode2 = jsonnode["assets"][release.ReleaseId];
			release.Link = jsonnode2["browser_download_url"];
			JSONNode jsonnode3 = jsonnode2["uploader"];
			if (release.Author.Equals(string.Empty))
			{
				release.Author = jsonnode3["login"];
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000024D4 File Offset: 0x000006D4
		private void Install()
		{
			this.ChangeInstallButtonState(false);
			this.UpdateStatus("Starting install sequence...");
			foreach (ReleaseInfo releaseInfo in this.releases)
			{
				if (releaseInfo.Install)
				{
					this.UpdateStatus(string.Format("Downloading...{0}", releaseInfo.Name));
					byte[] array = this.DownloadFile(releaseInfo.Link);
					this.UpdateStatus(string.Format("Installing...{0}", releaseInfo.Name));
					string fileName = Path.GetFileName(releaseInfo.Link);
					if (Path.GetExtension(fileName).Equals(".dll"))
					{
						string text;
						if (releaseInfo.InstallLocation == null)
						{
							text = Path.Combine(this.InstallDirectory, "BepInEx\\plugins", Regex.Replace(releaseInfo.Name, "\\s+", string.Empty));
							if (!Directory.Exists(text))
							{
								Directory.CreateDirectory(text);
							}
						}
						else
						{
							text = Path.Combine(this.InstallDirectory, releaseInfo.InstallLocation);
						}
						File.WriteAllBytes(Path.Combine(text, fileName), array);
						string text2 = Path.Combine(this.InstallDirectory, "BepInEx\\plugins", fileName);
						if (File.Exists(text2))
						{
							File.Delete(text2);
						}
					}
					else
					{
						this.UnzipFile(array, (releaseInfo.InstallLocation != null) ? Path.Combine(this.InstallDirectory, releaseInfo.InstallLocation) : this.InstallDirectory);
					}
					this.UpdateStatus(string.Format("Installed {0}!", releaseInfo.Name));
				}
			}
			this.UpdateStatus("Install complete!");
			this.ChangeInstallButtonState(true);
			base.Invoke(new MethodInvoker(delegate
			{
				this.buttonToggleMods.Enabled = true;
			}));
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002694 File Offset: 0x00000894
		private void buttonInstall_Click(object sender, EventArgs e)
		{
			new Thread(delegate
			{
				this.Install();
			}).Start();
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000026AC File Offset: 0x000008AC
		private void buttonFolderBrowser_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.FileName = "Gorilla Tag.exe";
				openFileDialog.Filter = "Exe Files (.exe)|*.exe|All Files (*.*)|*.*";
				openFileDialog.FilterIndex = 1;
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					string fileName = openFileDialog.FileName;
					if (Path.GetFileName(fileName).Equals("Gorilla Tag.exe"))
					{
						this.InstallDirectory = Path.GetDirectoryName(fileName);
						this.textBoxDirectory.Text = this.InstallDirectory;
					}
					else
					{
						MessageBox.Show("That's not Gorilla Tag.exe! please try again!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
			}
		}

		// Token: 0x06000009 RID: 9 RVA: 0x0000274C File Offset: 0x0000094C
		private void listViewMods_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			ReleaseInfo release = (ReleaseInfo)e.Item.Tag;
			if (release.Dependencies.Count > 0)
			{
				foreach (object obj in this.listViewMods.Items)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					ReleaseInfo plugin = (ReleaseInfo)listViewItem.Tag;
					if (!(plugin.Name == release.Name) && release.Dependencies.Contains(plugin.Name))
					{
						if (e.Item.Checked)
						{
							listViewItem.Checked = true;
							listViewItem.ForeColor = Color.DimGray;
						}
						else
						{
							release.Install = false;
							if (this.releases.Count((ReleaseInfo x) => plugin.Dependents.Contains(x.Name) && x.Install) <= 1)
							{
								listViewItem.Checked = false;
								listViewItem.ForeColor = Color.Black;
							}
						}
					}
				}
			}
			if (release.Dependents.Count > 0 && this.releases.Count((ReleaseInfo x) => release.Dependents.Contains(x.Name) && x.Install) > 0)
			{
				e.Item.Checked = true;
			}
			if (release.Name.Contains("BepInEx"))
			{
				e.Item.Checked = true;
			}
			release.Install = e.Item.Checked;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000028FC File Offset: 0x00000AFC
		private void listViewMods_DoubleClick(object sender, EventArgs e)
		{
			this.OpenLinkFromRelease();
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000028FC File Offset: 0x00000AFC
		private void buttonModInfo_Click(object sender, EventArgs e)
		{
			this.OpenLinkFromRelease();
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000028FC File Offset: 0x00000AFC
		private void viewInfoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.OpenLinkFromRelease();
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002904 File Offset: 0x00000B04
		private void listViewMods_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if (this.listViewMods.SelectedItems.Count > 0)
			{
				this.buttonModInfo.Enabled = true;
				return;
			}
			this.buttonModInfo.Enabled = false;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002934 File Offset: 0x00000B34
		private void buttonUninstallAll_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("You are about to delete all your mods (including hats and materials). This cannot be undone!\n\nAre you sure you wish to continue?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				this.UpdateStatus("Uninstalling all mods");
				string text = Path.Combine(this.InstallDirectory, "BepInEx\\plugins");
				try
				{
					string[] array = Directory.GetDirectories(text);
					for (int i = 0; i < array.Length; i++)
					{
						Directory.Delete(array[i], true);
					}
					array = Directory.GetFiles(text);
					for (int i = 0; i < array.Length; i++)
					{
						File.Delete(array[i]);
					}
				}
				catch (Exception)
				{
					MessageBox.Show("Something went wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					this.UpdateStatus("Failed to uninstall mods.");
					return;
				}
				this.UpdateStatus("All mods uninstalled successfully!");
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000029EC File Offset: 0x00000BEC
		private void buttonBackupMods_Click(object sender, EventArgs e)
		{
			string text = Path.Combine(this.InstallDirectory, "BepInEx\\plugins");
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				InitialDirectory = this.InstallDirectory,
				FileName = "Mod Backup",
				Filter = "ZIP Folder (.zip)|*.zip",
				Title = "Save Mod Backup"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK && saveFileDialog.FileName != "")
			{
				this.UpdateStatus("Backing up mods...");
				try
				{
					if (File.Exists(saveFileDialog.FileName))
					{
						File.Delete(saveFileDialog.FileName);
					}
					ZipFile.CreateFromDirectory(text, saveFileDialog.FileName);
				}
				catch (Exception)
				{
					MessageBox.Show("Something went wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					this.UpdateStatus("Failed to back up mods.");
					return;
				}
				this.UpdateStatus("Successfully backed up mods!");
			}
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002AC8 File Offset: 0x00000CC8
		private void buttonBackupCosmetics_Click(object sender, EventArgs e)
		{
			string text = Path.Combine(this.InstallDirectory, "BepInEx\\plugins");
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				InitialDirectory = this.InstallDirectory,
				FileName = "Cosmetics Backup",
				Filter = "ZIP Folder (.zip)|*.zip",
				Title = "Save Cosmetics Backup"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK && saveFileDialog.FileName != "")
			{
				this.UpdateStatus("Backing up cosmetics...");
				if (File.Exists(saveFileDialog.FileName))
				{
					File.Delete(saveFileDialog.FileName);
				}
				try
				{
					ZipFile.CreateFromDirectory(Path.Combine(text, "GorillaCosmetics\\Hats"), saveFileDialog.FileName, CompressionLevel.Optimal, true);
					using (ZipArchive zipArchive = ZipFile.Open(saveFileDialog.FileName, ZipArchiveMode.Update))
					{
						foreach (string text2 in Directory.GetFiles(Path.Combine(text, "GorillaCosmetics\\Materials")))
						{
							zipArchive.CreateEntryFromFile(text2, Path.Combine("Materials", Path.GetFileName(text2)) ?? "");
						}
					}
				}
				catch (Exception)
				{
					MessageBox.Show("Something went wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					this.UpdateStatus("Failed to restore cosmetics.");
					return;
				}
				this.UpdateStatus("Backed up cosmetics!");
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002C28 File Offset: 0x00000E28
		private void buttonRestoreMods_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.InitialDirectory = this.InstallDirectory;
				openFileDialog.FileName = "Mod Backup.zip";
				openFileDialog.Filter = "ZIP Folder (.zip)|*.zip";
				openFileDialog.FilterIndex = 1;
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					if (!Path.GetExtension(openFileDialog.FileName).Equals(".zip", StringComparison.InvariantCultureIgnoreCase))
					{
						MessageBox.Show("Invalid file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						this.UpdateStatus("Failed to restore mods.");
					}
					else
					{
						string text = Path.Combine(this.InstallDirectory, "BepInEx\\plugins");
						try
						{
							this.UpdateStatus("Restoring mods...");
							using (ZipArchive zipArchive = ZipFile.OpenRead(openFileDialog.FileName))
							{
								foreach (ZipArchiveEntry zipArchiveEntry in zipArchive.Entries)
								{
									string text2 = Path.Combine(this.InstallDirectory, "BepInEx\\plugins", Path.GetDirectoryName(zipArchiveEntry.FullName));
									if (!Directory.Exists(text2))
									{
										Directory.CreateDirectory(text2);
									}
									zipArchiveEntry.ExtractToFile(Path.Combine(text, zipArchiveEntry.FullName), true);
								}
							}
							this.UpdateStatus("Successfully restored mods!");
						}
						catch (Exception)
						{
							MessageBox.Show("Something went wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							this.UpdateStatus("Failed to restore mods.");
						}
					}
				}
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002DEC File Offset: 0x00000FEC
		private void buttonRestoreCosmetics_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.InitialDirectory = this.InstallDirectory;
				openFileDialog.FileName = "Cosmetics Backup.zip";
				openFileDialog.Filter = "ZIP Folder (.zip)|*.zip";
				openFileDialog.FilterIndex = 1;
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					if (!Path.GetExtension(openFileDialog.FileName).Equals(".zip", StringComparison.InvariantCultureIgnoreCase))
					{
						MessageBox.Show("Invalid file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						this.UpdateStatus("Failed to restore co0smetics.");
					}
					else
					{
						string text = Path.Combine(this.InstallDirectory, "BepInEx\\plugins\\GorillaCosmetics");
						try
						{
							this.UpdateStatus("Restoring cosmetics...");
							using (ZipArchive zipArchive = ZipFile.OpenRead(openFileDialog.FileName))
							{
								foreach (ZipArchiveEntry zipArchiveEntry in zipArchive.Entries)
								{
									string text2 = Path.Combine(this.InstallDirectory, "BepInEx\\plugins\\GorillaCosmetics", Path.GetDirectoryName(zipArchiveEntry.FullName));
									if (!Directory.Exists(text2))
									{
										Directory.CreateDirectory(text2);
									}
									zipArchiveEntry.ExtractToFile(Path.Combine(text, zipArchiveEntry.FullName), true);
								}
							}
							this.UpdateStatus("Successfully restored cosmetics!");
						}
						catch
						{
							MessageBox.Show("Something went wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							this.UpdateStatus("Failed to restore cosmetics.");
						}
					}
				}
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002FB0 File Offset: 0x000011B0
		private void buttonOpenGameFolder_Click(object sender, EventArgs e)
		{
			if (Directory.Exists(this.InstallDirectory))
			{
				Process.Start(this.InstallDirectory);
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002FCC File Offset: 0x000011CC
		private void buttonOpenConfigFolder_Click(object sender, EventArgs e)
		{
			string text = Path.Combine(this.InstallDirectory, "BepInEx\\config");
			if (Directory.Exists(text))
			{
				Process.Start(text);
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002FFC File Offset: 0x000011FC
		private void buttonOpenBepInExFolder_Click(object sender, EventArgs e)
		{
			string text = Path.Combine(this.InstallDirectory, "BepInEx");
			if (Directory.Exists(text))
			{
				Process.Start(text);
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00003029 File Offset: 0x00001229
		private void buttonOpenWiki_Click(object sender, EventArgs e)
		{
			Process.Start("https://gorillatagmodding.burrito.software/");
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00003036 File Offset: 0x00001236
		private void buttonDiscordLink_Click(object sender, EventArgs e)
		{
			Process.Start("https://discord.gg/monkemod");
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00003044 File Offset: 0x00001244
		private string DownloadSite(string URL)
		{
			string text2;
			try
			{
				if (this.PermCookie == null)
				{
					this.PermCookie = new CookieContainer();
				}
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);
				httpWebRequest.Method = "GET";
				httpWebRequest.KeepAlive = true;
				httpWebRequest.CookieContainer = this.PermCookie;
				httpWebRequest.ContentType = "application/x-www-form-urlencoded";
				httpWebRequest.Referer = "";
				httpWebRequest.UserAgent = "Monke-Mod-Manager";
				httpWebRequest.Proxy = null;
				StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
				string text = streamReader.ReadToEnd();
				streamReader.Close();
				text2 = text;
			}
			catch (Exception ex)
			{
				if (ex.Message.Contains("403"))
				{
					MessageBox.Show("Failed to update version info, GitHub has rate limited you, please check back in 15 - 30 minutes", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					MessageBox.Show("Failed to update version info, please check your internet connection", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				Process.GetCurrentProcess().Kill();
				text2 = null;
			}
			return text2;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00003134 File Offset: 0x00001334
		private void UnzipFile(byte[] data, string directory)
		{
			using (MemoryStream memoryStream = new MemoryStream(data))
			{
				using (Unzip unzip = new Unzip(memoryStream))
				{
					unzip.ExtractToDirectory(directory);
				}
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00003188 File Offset: 0x00001388
		private byte[] DownloadFile(string url)
		{
			return new WebClient
			{
				Proxy = null
			}.DownloadData(url);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x0000319C File Offset: 0x0000139C
		private void UpdateStatus(string status)
		{
			string formattedText = string.Format("Status: {0}", status);
			base.Invoke(new MethodInvoker(delegate
			{
				this.labelStatus.Text = formattedText;
			}));
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000031DC File Offset: 0x000013DC
		private void NotFoundHandler()
		{
			bool flag = false;
			while (!flag)
			{
				using (OpenFileDialog openFileDialog = new OpenFileDialog())
				{
					openFileDialog.FileName = "Gorilla Tag.exe";
					openFileDialog.Filter = "Exe Files (.exe)|*.exe|All Files (*.*)|*.*";
					openFileDialog.FilterIndex = 1;
					if (openFileDialog.ShowDialog() == DialogResult.OK)
					{
						string fileName = openFileDialog.FileName;
						if (Path.GetFileName(fileName).Equals("Gorilla Tag.exe"))
						{
							this.InstallDirectory = Path.GetDirectoryName(fileName);
							this.textBoxDirectory.Text = this.InstallDirectory;
							flag = true;
						}
						else
						{
							MessageBox.Show("That's not Gorilla Tag.exe! please try again!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					else
					{
						Process.GetCurrentProcess().Kill();
					}
				}
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00003298 File Offset: 0x00001498
		private void CheckVersion()
		{
			this.UpdateStatus("Checking for updates...");
			if (Convert.ToInt16(this.DownloadSite("https://raw.githubusercontent.com/DeadlyKitten/MonkeModManager/master/update.txt")) > 7)
			{
				base.Invoke(new MethodInvoker(delegate
				{
					MessageBox.Show("Your version of the mod installer is outdated! Please download the new one!", "Update available!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					Process.Start("https://github.com/DeadlyKitten/MonkeModManager/releases/latest");
					Process.GetCurrentProcess().Kill();
					Environment.Exit(0);
				}));
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000032EC File Offset: 0x000014EC
		private void ChangeInstallButtonState(bool enabled)
		{
			base.Invoke(new MethodInvoker(delegate
			{
				this.buttonInstall.Enabled = enabled;
			}));
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00003320 File Offset: 0x00001520
		private void OpenLinkFromRelease()
		{
			if (this.listViewMods.SelectedItems.Count > 0)
			{
				ReleaseInfo releaseInfo = (ReleaseInfo)this.listViewMods.SelectedItems[0].Tag;
				this.UpdateStatus("Opening GitHub page for " + releaseInfo.Name);
				Process.Start(string.Format("https://github.com/{0}", releaseInfo.GitPath));
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00003388 File Offset: 0x00001588
		private void LocationHandler()
		{
			string steamLocation = this.GetSteamLocation();
			if (steamLocation != null && Directory.Exists(steamLocation) && File.Exists(steamLocation + "\\Gorilla Tag.exe"))
			{
				this.textBoxDirectory.Text = steamLocation;
				this.InstallDirectory = steamLocation;
				this.platformDetected = true;
				return;
			}
			this.ShowErrorFindingDirectoryMessage();
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000033DA File Offset: 0x000015DA
		private void ShowErrorFindingDirectoryMessage()
		{
			MessageBox.Show("We couldn't seem to find your Gorilla Tag installation, please press \"OK\" and point us to it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			this.NotFoundHandler();
			base.TopMost = true;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000033FC File Offset: 0x000015FC
		private string GetSteamLocation()
		{
			string text = FormMain.RegistryWOW6432.GetRegKey64(FormMain.RegHive.HKEY_LOCAL_MACHINE, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Steam App 1533390", "InstallLocation");
			if (text != null)
			{
				text += "\\";
			}
			return text;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x0000342E File Offset: 0x0000162E
		private void CheckDefaultMod(ReleaseInfo release, ListViewItem item)
		{
			if (release.Name.Contains("BepInEx"))
			{
				item.Checked = true;
				item.ForeColor = Color.DimGray;
				return;
			}
			release.Install = false;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x0000345C File Offset: 0x0000165C
		private void buttonToggleMods_Click(object sender, EventArgs e)
		{
			if (this.modsDisabled)
			{
				if (File.Exists(Path.Combine(this.InstallDirectory, "mods.disable")))
				{
					File.Move(Path.Combine(this.InstallDirectory, "mods.disable"), Path.Combine(this.InstallDirectory, "winhttp.dll"));
					this.buttonToggleMods.Text = "Disable Mods";
					this.buttonToggleMods.BackColor = Color.Transparent;
					this.modsDisabled = false;
					this.UpdateStatus("Enabled mods!");
					return;
				}
			}
			else if (File.Exists(Path.Combine(this.InstallDirectory, "winhttp.dll")))
			{
				File.Move(Path.Combine(this.InstallDirectory, "winhttp.dll"), Path.Combine(this.InstallDirectory, "mods.disable"));
				this.buttonToggleMods.Text = "Enable Mods";
				this.buttonToggleMods.BackColor = Color.IndianRed;
				this.modsDisabled = true;
				this.UpdateStatus("Disabled mods!");
			}
		}

		// Token: 0x04000001 RID: 1
		private const string BaseEndpoint = "https://api.github.com/repos/";

		// Token: 0x04000002 RID: 2
		private const short CurrentVersion = 7;

		// Token: 0x04000003 RID: 3
		private List<ReleaseInfo> releases;

		// Token: 0x04000004 RID: 4
		private Dictionary<string, int> groups = new Dictionary<string, int>();

		// Token: 0x04000005 RID: 5
		private string InstallDirectory = "";

		// Token: 0x04000006 RID: 6
		private bool modsDisabled;

		// Token: 0x04000007 RID: 7
		public bool isSteam = true;

		// Token: 0x04000008 RID: 8
		public bool platformDetected;

		// Token: 0x04000009 RID: 9
		private CookieContainer PermCookie;

		// Token: 0x02000015 RID: 21
		private enum RegSAM
		{
			// Token: 0x04000060 RID: 96
			QueryValue = 1,
			// Token: 0x04000061 RID: 97
			SetValue,
			// Token: 0x04000062 RID: 98
			CreateSubKey = 4,
			// Token: 0x04000063 RID: 99
			EnumerateSubKeys = 8,
			// Token: 0x04000064 RID: 100
			Notify = 16,
			// Token: 0x04000065 RID: 101
			CreateLink = 32,
			// Token: 0x04000066 RID: 102
			WOW64_32Key = 512,
			// Token: 0x04000067 RID: 103
			WOW64_64Key = 256,
			// Token: 0x04000068 RID: 104
			WOW64_Res = 768,
			// Token: 0x04000069 RID: 105
			Read = 131097,
			// Token: 0x0400006A RID: 106
			Write = 131078,
			// Token: 0x0400006B RID: 107
			Execute = 131097,
			// Token: 0x0400006C RID: 108
			AllAccess = 983103
		}

		// Token: 0x02000016 RID: 22
		private static class RegHive
		{
			// Token: 0x0400006D RID: 109
			public static UIntPtr HKEY_LOCAL_MACHINE = new UIntPtr(2147483650U);

			// Token: 0x0400006E RID: 110
			public static UIntPtr HKEY_CURRENT_USER = new UIntPtr(2147483649U);
		}

		// Token: 0x02000017 RID: 23
		private static class RegistryWOW6432
		{
			// Token: 0x060000FB RID: 251
			[DllImport("Advapi32.dll")]
			private static extern uint RegOpenKeyEx(UIntPtr hKey, string lpSubKey, uint ulOptions, int samDesired, out int phkResult);

			// Token: 0x060000FC RID: 252
			[DllImport("Advapi32.dll")]
			private static extern uint RegCloseKey(int hKey);

			// Token: 0x060000FD RID: 253
			[DllImport("advapi32.dll")]
			public static extern int RegQueryValueEx(int hKey, string lpValueName, int lpReserved, ref uint lpType, StringBuilder lpData, ref uint lpcbData);

			// Token: 0x060000FE RID: 254 RVA: 0x00006552 File Offset: 0x00004752
			public static string GetRegKey64(UIntPtr inHive, string inKeyName, string inPropertyName)
			{
				return FormMain.RegistryWOW6432.GetRegKey64(inHive, inKeyName, FormMain.RegSAM.WOW64_64Key, inPropertyName);
			}

			// Token: 0x060000FF RID: 255 RVA: 0x00006561 File Offset: 0x00004761
			public static string GetRegKey32(UIntPtr inHive, string inKeyName, string inPropertyName)
			{
				return FormMain.RegistryWOW6432.GetRegKey64(inHive, inKeyName, FormMain.RegSAM.WOW64_32Key, inPropertyName);
			}

			// Token: 0x06000100 RID: 256 RVA: 0x00006570 File Offset: 0x00004770
			public static string GetRegKey64(UIntPtr inHive, string inKeyName, FormMain.RegSAM in32or64key, string inPropertyName)
			{
				int num = 0;
				string text;
				try
				{
					uint num2 = FormMain.RegistryWOW6432.RegOpenKeyEx(FormMain.RegHive.HKEY_LOCAL_MACHINE, inKeyName, 0U, (int)(FormMain.RegSAM.QueryValue | in32or64key), out num);
					if (num2 != 0U)
					{
						text = null;
					}
					else
					{
						uint num3 = 0U;
						uint num4 = 1024U;
						StringBuilder stringBuilder = new StringBuilder(1024);
						FormMain.RegistryWOW6432.RegQueryValueEx(num, inPropertyName, 0, ref num3, stringBuilder, ref num4);
						text = stringBuilder.ToString();
					}
				}
				finally
				{
					if (num != 0)
					{
						FormMain.RegistryWOW6432.RegCloseKey(num);
					}
				}
				return text;
			}
		}
	}
}
