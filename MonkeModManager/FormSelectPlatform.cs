using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MonkeModManager
{
	// Token: 0x02000003 RID: 3
	public partial class FormSelectPlatform : Form
	{
		// Token: 0x0600002B RID: 43 RVA: 0x000049A6 File Offset: 0x00002BA6
		public FormSelectPlatform(FormMain parent)
		{
			this.InitializeComponent();
			this.Parent = parent;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000049BB File Offset: 0x00002BBB
		private void buttonConfirm_Click(object sender, EventArgs e)
		{
			this.Parent.platformDetected = true;
			if (this.radioButtonOculus.Checked)
			{
				this.Parent.isSteam = false;
			}
			base.Close();
		}

		// Token: 0x04000028 RID: 40
		private new readonly FormMain Parent;
	}
}
