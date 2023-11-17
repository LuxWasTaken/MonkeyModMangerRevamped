using System;
using System.Text;

namespace MonkeModManager.Internals.SimpleJSON
{
	// Token: 0x0200000E RID: 14
	public class JSONString : JSONNode
	{
		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000AC RID: 172 RVA: 0x00005FF7 File Offset: 0x000041F7
		public override JSONNodeType Tag
		{
			get
			{
				return JSONNodeType.String;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000AD RID: 173 RVA: 0x00005AC1 File Offset: 0x00003CC1
		public override bool IsString
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00005FFC File Offset: 0x000041FC
		public override JSONNode.Enumerator GetEnumerator()
		{
			return default(JSONNode.Enumerator);
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000AF RID: 175 RVA: 0x00006012 File Offset: 0x00004212
		// (set) Token: 0x060000B0 RID: 176 RVA: 0x0000601A File Offset: 0x0000421A
		public override string Value
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

		// Token: 0x060000B1 RID: 177 RVA: 0x00006023 File Offset: 0x00004223
		public JSONString(string aData)
		{
			this.m_Data = aData;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00006032 File Offset: 0x00004232
		internal override void WriteToStringBuilder(StringBuilder aSB, int aIndent, int aIndentInc, JSONTextMode aMode)
		{
			aSB.Append('"').Append(JSONNode.Escape(this.m_Data)).Append('"');
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00006054 File Offset: 0x00004254
		public override bool Equals(object obj)
		{
			if (base.Equals(obj))
			{
				return true;
			}
			string text = obj as string;
			if (text != null)
			{
				return this.m_Data == text;
			}
			JSONString jsonstring = obj as JSONString;
			return jsonstring != null && this.m_Data == jsonstring.m_Data;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x000060A6 File Offset: 0x000042A6
		public override int GetHashCode()
		{
			return this.m_Data.GetHashCode();
		}

		// Token: 0x04000057 RID: 87
		private string m_Data;
	}
}
