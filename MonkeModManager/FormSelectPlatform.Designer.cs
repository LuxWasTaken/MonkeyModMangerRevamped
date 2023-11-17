namespace MonkeModManager
{
	// Token: 0x02000003 RID: 3
	public partial class FormSelectPlatform : global::System.Windows.Forms.Form
	{
		// Token: 0x0600002D RID: 45 RVA: 0x000049E8 File Offset: 0x00002BE8
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00004A08 File Offset: 0x00002C08
		private void InitializeComponent()
		{
			this.radioButtonSteam = new global::System.Windows.Forms.RadioButton();
			this.radioButtonOculus = new global::System.Windows.Forms.RadioButton();
			this.buttonConfirm = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.radioButtonSteam.AutoSize = true;
			this.radioButtonSteam.Location = new global::System.Drawing.Point(53, 12);
			this.radioButtonSteam.Name = "radioButtonSteam";
			this.radioButtonSteam.Size = new global::System.Drawing.Size(187, 17);
			this.radioButtonSteam.TabIndex = 0;
			this.radioButtonSteam.TabStop = true;
			this.radioButtonSteam.Text = "I purchased the game on Steam";
			this.radioButtonSteam.UseVisualStyleBackColor = true;
			this.radioButtonOculus.AutoSize = true;
			this.radioButtonOculus.Location = new global::System.Drawing.Point(25, 35);
			this.radioButtonOculus.Name = "radioButtonOculus";
			this.radioButtonOculus.Size = new global::System.Drawing.Size(242, 17);
			this.radioButtonOculus.TabIndex = 1;
			this.radioButtonOculus.TabStop = true;
			this.radioButtonOculus.Text = "I purchased the game on the Oculus Store";
			this.radioButtonOculus.UseVisualStyleBackColor = true;
			this.buttonConfirm.Location = new global::System.Drawing.Point(109, 60);
			this.buttonConfirm.Name = "buttonConfirm";
			this.buttonConfirm.Size = new global::System.Drawing.Size(75, 23);
			this.buttonConfirm.TabIndex = 2;
			this.buttonConfirm.Text = "Confirm";
			this.buttonConfirm.UseVisualStyleBackColor = true;
			this.buttonConfirm.Click += new global::System.EventHandler(this.buttonConfirm_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(292, 95);
			base.Controls.Add(this.buttonConfirm);
			base.Controls.Add(this.radioButtonOculus);
			base.Controls.Add(this.radioButtonSteam);
			this.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FormSelectPlatform";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Please select your platform";
			base.TopMost = true;
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000029 RID: 41
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400002A RID: 42
		private global::System.Windows.Forms.RadioButton radioButtonSteam;

		// Token: 0x0400002B RID: 43
		private global::System.Windows.Forms.RadioButton radioButtonOculus;

		// Token: 0x0400002C RID: 44
		private global::System.Windows.Forms.Button buttonConfirm;
	}
}
