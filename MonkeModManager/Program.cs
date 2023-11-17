using System;
using System.Windows.Forms;

namespace MonkeModManager
{
	// Token: 0x02000004 RID: 4
	internal static class Program
	{
		// Token: 0x0600002F RID: 47 RVA: 0x00004C76 File Offset: 0x00002E76
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FormMain());
		}
	}
}
