using System;
using System.Globalization;
using System.Text;

namespace MonkeModManager.Internals.SimpleJSON
{
	// Token: 0x0200000F RID: 15
	public class JSONNumber : JSONNode
	{
		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000B5 RID: 181 RVA: 0x000060B3 File Offset: 0x000042B3
		public override JSONNodeType Tag
		{
			get
			{
				return JSONNodeType.Number;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000B6 RID: 182 RVA: 0x00005AC1 File Offset: 0x00003CC1
		public override bool IsNumber
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x000060B8 File Offset: 0x000042B8
		public override JSONNode.Enumerator GetEnumerator()
		{
			return default(JSONNode.Enumerator);
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060000B8 RID: 184 RVA: 0x000060CE File Offset: 0x000042CE
		// (set) Token: 0x060000B9 RID: 185 RVA: 0x000060E0 File Offset: 0x000042E0
		public override string Value
		{
			get
			{
				return this.m_Data.ToString(CultureInfo.InvariantCulture);
			}
			set
			{
				double num;
				if (double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out num))
				{
					this.m_Data = num;
				}
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000BA RID: 186 RVA: 0x00006108 File Offset: 0x00004308
		// (set) Token: 0x060000BB RID: 187 RVA: 0x00006110 File Offset: 0x00004310
		public override double AsDouble
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

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000BC RID: 188 RVA: 0x00006119 File Offset: 0x00004319
		// (set) Token: 0x060000BD RID: 189 RVA: 0x00006122 File Offset: 0x00004322
		public override long AsLong
		{
			get
			{
				return (long)this.m_Data;
			}
			set
			{
				this.m_Data = (double)value;
			}
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000612C File Offset: 0x0000432C
		public JSONNumber(double aData)
		{
			this.m_Data = aData;
		}

		// Token: 0x060000BF RID: 191 RVA: 0x0000613B File Offset: 0x0000433B
		public JSONNumber(string aData)
		{
			this.Value = aData;
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000614A File Offset: 0x0000434A
		internal override void WriteToStringBuilder(StringBuilder aSB, int aIndent, int aIndentInc, JSONTextMode aMode)
		{
			aSB.Append(this.Value);
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x0000615C File Offset: 0x0000435C
		private static bool IsNumeric(object value)
		{
			return value is int || value is uint || value is float || value is double || value is decimal || value is long || value is ulong || value is short || value is ushort || value is sbyte || value is byte;
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x000061C4 File Offset: 0x000043C4
		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (base.Equals(obj))
			{
				return true;
			}
			JSONNumber jsonnumber = obj as JSONNumber;
			if (jsonnumber != null)
			{
				return this.m_Data == jsonnumber.m_Data;
			}
			return JSONNumber.IsNumeric(obj) && Convert.ToDouble(obj) == this.m_Data;
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00006218 File Offset: 0x00004418
		public override int GetHashCode()
		{
			return this.m_Data.GetHashCode();
		}

		// Token: 0x04000058 RID: 88
		private double m_Data;
	}
}
