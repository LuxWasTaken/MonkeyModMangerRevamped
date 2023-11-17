using System;
using System.Text;

namespace MonkeModManager.Internals.SimpleJSON
{
	// Token: 0x02000011 RID: 17
	public class JSONNull : JSONNode
	{
		// Token: 0x060000D0 RID: 208 RVA: 0x000062D3 File Offset: 0x000044D3
		public static JSONNull CreateOrGet()
		{
			if (JSONNull.reuseSameInstance)
			{
				return JSONNull.m_StaticInstance;
			}
			return new JSONNull();
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x000062E7 File Offset: 0x000044E7
		private JSONNull()
		{
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000D2 RID: 210 RVA: 0x000062EF File Offset: 0x000044EF
		public override JSONNodeType Tag
		{
			get
			{
				return JSONNodeType.NullValue;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000D3 RID: 211 RVA: 0x00005AC1 File Offset: 0x00003CC1
		public override bool IsNull
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x000062F4 File Offset: 0x000044F4
		public override JSONNode.Enumerator GetEnumerator()
		{
			return default(JSONNode.Enumerator);
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000D5 RID: 213 RVA: 0x0000630A File Offset: 0x0000450A
		// (set) Token: 0x060000D6 RID: 214 RVA: 0x0000526D File Offset: 0x0000346D
		public override string Value
		{
			get
			{
				return "null";
			}
			set
			{
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000D7 RID: 215 RVA: 0x00005276 File Offset: 0x00003476
		// (set) Token: 0x060000D8 RID: 216 RVA: 0x0000526D File Offset: 0x0000346D
		public override bool AsBool
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00006311 File Offset: 0x00004511
		public override bool Equals(object obj)
		{
			return this == obj || obj is JSONNull;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00005276 File Offset: 0x00003476
		public override int GetHashCode()
		{
			return 0;
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00006322 File Offset: 0x00004522
		internal override void WriteToStringBuilder(StringBuilder aSB, int aIndent, int aIndentInc, JSONTextMode aMode)
		{
			aSB.Append("null");
		}

		// Token: 0x0400005A RID: 90
		private static JSONNull m_StaticInstance = new JSONNull();

		// Token: 0x0400005B RID: 91
		public static bool reuseSameInstance = true;
	}
}
