using System;
using System.Text;

namespace MonkeModManager.Internals.SimpleJSON
{
	// Token: 0x02000010 RID: 16
	public class JSONBool : JSONNode
	{
		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000C4 RID: 196 RVA: 0x00006225 File Offset: 0x00004425
		public override JSONNodeType Tag
		{
			get
			{
				return JSONNodeType.Boolean;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000C5 RID: 197 RVA: 0x00005AC1 File Offset: 0x00003CC1
		public override bool IsBoolean
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00006228 File Offset: 0x00004428
		public override JSONNode.Enumerator GetEnumerator()
		{
			return default(JSONNode.Enumerator);
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000C7 RID: 199 RVA: 0x0000623E File Offset: 0x0000443E
		// (set) Token: 0x060000C8 RID: 200 RVA: 0x0000624C File Offset: 0x0000444C
		public override string Value
		{
			get
			{
				return this.m_Data.ToString();
			}
			set
			{
				bool flag;
				if (bool.TryParse(value, out flag))
				{
					this.m_Data = flag;
				}
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x0000626A File Offset: 0x0000446A
		// (set) Token: 0x060000CA RID: 202 RVA: 0x00006272 File Offset: 0x00004472
		public override bool AsBool
		{
			get
			{
				return this.m_Data;
			}
			set
			{
				this.m_Data = value;
			}
		}

		// Token: 0x060000CB RID: 203 RVA: 0x0000627B File Offset: 0x0000447B
		public JSONBool(bool aData)
		{
			this.m_Data = aData;
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0000613B File Offset: 0x0000433B
		public JSONBool(string aData)
		{
			this.Value = aData;
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0000628A File Offset: 0x0000448A
		internal override void WriteToStringBuilder(StringBuilder aSB, int aIndent, int aIndentInc, JSONTextMode aMode)
		{
			aSB.Append(this.m_Data ? "true" : "false");
		}

		// Token: 0x060000CE RID: 206 RVA: 0x000062A7 File Offset: 0x000044A7
		public override bool Equals(object obj)
		{
			return obj != null && obj is bool && this.m_Data == (bool)obj;
		}

		// Token: 0x060000CF RID: 207 RVA: 0x000062C6 File Offset: 0x000044C6
		public override int GetHashCode()
		{
			return this.m_Data.GetHashCode();
		}

		// Token: 0x04000059 RID: 89
		private bool m_Data;
	}
}
