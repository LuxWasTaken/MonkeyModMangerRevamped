using System;
using System.Text;

namespace MonkeModManager.Internals.SimpleJSON
{
	// Token: 0x02000012 RID: 18
	internal class JSONLazyCreator : JSONNode
	{
		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000DD RID: 221 RVA: 0x00006342 File Offset: 0x00004542
		public override JSONNodeType Tag
		{
			get
			{
				return JSONNodeType.None;
			}
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00006348 File Offset: 0x00004548
		public override JSONNode.Enumerator GetEnumerator()
		{
			return default(JSONNode.Enumerator);
		}

		// Token: 0x060000DF RID: 223 RVA: 0x0000635E File Offset: 0x0000455E
		public JSONLazyCreator(JSONNode aNode)
		{
			this.m_Node = aNode;
			this.m_Key = null;
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00006374 File Offset: 0x00004574
		public JSONLazyCreator(JSONNode aNode, string aKey)
		{
			this.m_Node = aNode;
			this.m_Key = aKey;
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x0000638A File Offset: 0x0000458A
		private T Set<T>(T aVal) where T : JSONNode
		{
			if (this.m_Key == null)
			{
				this.m_Node.Add(aVal);
			}
			else
			{
				this.m_Node.Add(this.m_Key, aVal);
			}
			this.m_Node = null;
			return aVal;
		}

		// Token: 0x17000040 RID: 64
		public override JSONNode this[int aIndex]
		{
			get
			{
				return new JSONLazyCreator(this);
			}
			set
			{
				this.Set<JSONArray>(new JSONArray()).Add(value);
			}
		}

		// Token: 0x17000041 RID: 65
		public override JSONNode this[string aKey]
		{
			get
			{
				return new JSONLazyCreator(this, aKey);
			}
			set
			{
				this.Set<JSONObject>(new JSONObject()).Add(aKey, value);
			}
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x000063F6 File Offset: 0x000045F6
		public override void Add(JSONNode aItem)
		{
			this.Set<JSONArray>(new JSONArray()).Add(aItem);
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x000063E2 File Offset: 0x000045E2
		public override void Add(string aKey, JSONNode aItem)
		{
			this.Set<JSONObject>(new JSONObject()).Add(aKey, aItem);
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00006409 File Offset: 0x00004609
		public static bool operator ==(JSONLazyCreator a, object b)
		{
			return b == null || a == b;
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00006414 File Offset: 0x00004614
		public static bool operator !=(JSONLazyCreator a, object b)
		{
			return !(a == b);
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00006409 File Offset: 0x00004609
		public override bool Equals(object obj)
		{
			return obj == null || this == obj;
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00005276 File Offset: 0x00003476
		public override int GetHashCode()
		{
			return 0;
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000EC RID: 236 RVA: 0x00006420 File Offset: 0x00004620
		// (set) Token: 0x060000ED RID: 237 RVA: 0x00006438 File Offset: 0x00004638
		public override int AsInt
		{
			get
			{
				this.Set<JSONNumber>(new JSONNumber(0.0));
				return 0;
			}
			set
			{
				this.Set<JSONNumber>(new JSONNumber((double)value));
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000EE RID: 238 RVA: 0x00006448 File Offset: 0x00004648
		// (set) Token: 0x060000EF RID: 239 RVA: 0x00006438 File Offset: 0x00004638
		public override float AsFloat
		{
			get
			{
				this.Set<JSONNumber>(new JSONNumber(0.0));
				return 0f;
			}
			set
			{
				this.Set<JSONNumber>(new JSONNumber((double)value));
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000F0 RID: 240 RVA: 0x00006464 File Offset: 0x00004664
		// (set) Token: 0x060000F1 RID: 241 RVA: 0x00006484 File Offset: 0x00004684
		public override double AsDouble
		{
			get
			{
				this.Set<JSONNumber>(new JSONNumber(0.0));
				return 0.0;
			}
			set
			{
				this.Set<JSONNumber>(new JSONNumber(value));
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060000F2 RID: 242 RVA: 0x00006493 File Offset: 0x00004693
		// (set) Token: 0x060000F3 RID: 243 RVA: 0x000064C6 File Offset: 0x000046C6
		public override long AsLong
		{
			get
			{
				if (JSONNode.longAsString)
				{
					this.Set<JSONString>(new JSONString("0"));
				}
				else
				{
					this.Set<JSONNumber>(new JSONNumber(0.0));
				}
				return 0L;
			}
			set
			{
				if (JSONNode.longAsString)
				{
					this.Set<JSONString>(new JSONString(value.ToString()));
					return;
				}
				this.Set<JSONNumber>(new JSONNumber((double)value));
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060000F4 RID: 244 RVA: 0x000064F1 File Offset: 0x000046F1
		// (set) Token: 0x060000F5 RID: 245 RVA: 0x00006501 File Offset: 0x00004701
		public override bool AsBool
		{
			get
			{
				this.Set<JSONBool>(new JSONBool(false));
				return false;
			}
			set
			{
				this.Set<JSONBool>(new JSONBool(value));
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060000F6 RID: 246 RVA: 0x00006510 File Offset: 0x00004710
		public override JSONArray AsArray
		{
			get
			{
				return this.Set<JSONArray>(new JSONArray());
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060000F7 RID: 247 RVA: 0x0000651D File Offset: 0x0000471D
		public override JSONObject AsObject
		{
			get
			{
				return this.Set<JSONObject>(new JSONObject());
			}
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00006322 File Offset: 0x00004522
		internal override void WriteToStringBuilder(StringBuilder aSB, int aIndent, int aIndentInc, JSONTextMode aMode)
		{
			aSB.Append("null");
		}

		// Token: 0x0400005C RID: 92
		private JSONNode m_Node;

		// Token: 0x0400005D RID: 93
		private string m_Key;
	}
}
