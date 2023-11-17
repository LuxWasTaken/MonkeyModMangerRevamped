using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MonkeModManager.Internals.SimpleJSON
{
	// Token: 0x0200000B RID: 11
	public abstract class JSONNode
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600004B RID: 75
		public abstract JSONNodeType Tag { get; }

		// Token: 0x17000009 RID: 9
		public virtual JSONNode this[int aIndex]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		// Token: 0x1700000A RID: 10
		public virtual JSONNode this[string aKey]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000050 RID: 80 RVA: 0x0000526F File Offset: 0x0000346F
		// (set) Token: 0x06000051 RID: 81 RVA: 0x0000526D File Offset: 0x0000346D
		public virtual string Value
		{
			get
			{
				return "";
			}
			set
			{
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000052 RID: 82 RVA: 0x00005276 File Offset: 0x00003476
		public virtual int Count
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000053 RID: 83 RVA: 0x00005276 File Offset: 0x00003476
		public virtual bool IsNumber
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000054 RID: 84 RVA: 0x00005276 File Offset: 0x00003476
		public virtual bool IsString
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000055 RID: 85 RVA: 0x00005276 File Offset: 0x00003476
		public virtual bool IsBoolean
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000056 RID: 86 RVA: 0x00005276 File Offset: 0x00003476
		public virtual bool IsNull
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000057 RID: 87 RVA: 0x00005276 File Offset: 0x00003476
		public virtual bool IsArray
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000058 RID: 88 RVA: 0x00005276 File Offset: 0x00003476
		public virtual bool IsObject
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000059 RID: 89 RVA: 0x00005276 File Offset: 0x00003476
		// (set) Token: 0x0600005A RID: 90 RVA: 0x0000526D File Offset: 0x0000346D
		public virtual bool Inline
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		// Token: 0x0600005B RID: 91 RVA: 0x0000526D File Offset: 0x0000346D
		public virtual void Add(string aKey, JSONNode aItem)
		{
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00005279 File Offset: 0x00003479
		public virtual void Add(JSONNode aItem)
		{
			this.Add("", aItem);
		}

		// Token: 0x0600005D RID: 93 RVA: 0x0000526A File Offset: 0x0000346A
		public virtual JSONNode Remove(string aKey)
		{
			return null;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x0000526A File Offset: 0x0000346A
		public virtual JSONNode Remove(int aIndex)
		{
			return null;
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00005287 File Offset: 0x00003487
		public virtual JSONNode Remove(JSONNode aNode)
		{
			return aNode;
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000060 RID: 96 RVA: 0x0000528A File Offset: 0x0000348A
		public virtual IEnumerable<JSONNode> Children
		{
			get
			{
				yield break;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000061 RID: 97 RVA: 0x00005293 File Offset: 0x00003493
		public IEnumerable<JSONNode> DeepChildren
		{
			get
			{
				foreach (JSONNode jsonnode in this.Children)
				{
					foreach (JSONNode jsonnode2 in jsonnode.DeepChildren)
					{
						yield return jsonnode2;
					}
					IEnumerator<JSONNode> enumerator2 = null;
				}
				IEnumerator<JSONNode> enumerator = null;
				yield break;
				yield break;
			}
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000052A4 File Offset: 0x000034A4
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			this.WriteToStringBuilder(stringBuilder, 0, 0, JSONTextMode.Compact);
			return stringBuilder.ToString();
		}

		// Token: 0x06000063 RID: 99 RVA: 0x000052C8 File Offset: 0x000034C8
		public virtual string ToString(int aIndent)
		{
			StringBuilder stringBuilder = new StringBuilder();
			this.WriteToStringBuilder(stringBuilder, 0, aIndent, JSONTextMode.Indent);
			return stringBuilder.ToString();
		}

		// Token: 0x06000064 RID: 100
		internal abstract void WriteToStringBuilder(StringBuilder aSB, int aIndent, int aIndentInc, JSONTextMode aMode);

		// Token: 0x06000065 RID: 101
		public abstract JSONNode.Enumerator GetEnumerator();

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000066 RID: 102 RVA: 0x000052EB File Offset: 0x000034EB
		public IEnumerable<KeyValuePair<string, JSONNode>> Linq
		{
			get
			{
				return new JSONNode.LinqEnumerator(this);
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000067 RID: 103 RVA: 0x000052F3 File Offset: 0x000034F3
		public JSONNode.KeyEnumerator Keys
		{
			get
			{
				return new JSONNode.KeyEnumerator(this.GetEnumerator());
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000068 RID: 104 RVA: 0x00005300 File Offset: 0x00003500
		public JSONNode.ValueEnumerator Values
		{
			get
			{
				return new JSONNode.ValueEnumerator(this.GetEnumerator());
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000069 RID: 105 RVA: 0x00005310 File Offset: 0x00003510
		// (set) Token: 0x0600006A RID: 106 RVA: 0x0000534B File Offset: 0x0000354B
		public virtual double AsDouble
		{
			get
			{
				double num = 0.0;
				if (double.TryParse(this.Value, NumberStyles.Float, CultureInfo.InvariantCulture, out num))
				{
					return num;
				}
				return 0.0;
			}
			set
			{
				this.Value = value.ToString(CultureInfo.InvariantCulture);
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600006B RID: 107 RVA: 0x0000535F File Offset: 0x0000355F
		// (set) Token: 0x0600006C RID: 108 RVA: 0x00005368 File Offset: 0x00003568
		public virtual int AsInt
		{
			get
			{
				return (int)this.AsDouble;
			}
			set
			{
				this.AsDouble = (double)value;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600006D RID: 109 RVA: 0x00005372 File Offset: 0x00003572
		// (set) Token: 0x0600006E RID: 110 RVA: 0x00005368 File Offset: 0x00003568
		public virtual float AsFloat
		{
			get
			{
				return (float)this.AsDouble;
			}
			set
			{
				this.AsDouble = (double)value;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600006F RID: 111 RVA: 0x0000537C File Offset: 0x0000357C
		// (set) Token: 0x06000070 RID: 112 RVA: 0x000053AA File Offset: 0x000035AA
		public virtual bool AsBool
		{
			get
			{
				bool flag = false;
				if (bool.TryParse(this.Value, out flag))
				{
					return flag;
				}
				return !string.IsNullOrEmpty(this.Value);
			}
			set
			{
				this.Value = (value ? "true" : "false");
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000071 RID: 113 RVA: 0x000053C4 File Offset: 0x000035C4
		// (set) Token: 0x06000072 RID: 114 RVA: 0x000053E7 File Offset: 0x000035E7
		public virtual long AsLong
		{
			get
			{
				long num = 0L;
				if (long.TryParse(this.Value, out num))
				{
					return num;
				}
				return 0L;
			}
			set
			{
				this.Value = value.ToString();
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000073 RID: 115 RVA: 0x000053F6 File Offset: 0x000035F6
		public virtual JSONArray AsArray
		{
			get
			{
				return this as JSONArray;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000074 RID: 116 RVA: 0x000053FE File Offset: 0x000035FE
		public virtual JSONObject AsObject
		{
			get
			{
				return this as JSONObject;
			}
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00005406 File Offset: 0x00003606
		public static implicit operator JSONNode(string s)
		{
			return new JSONString(s);
		}

		// Token: 0x06000076 RID: 118 RVA: 0x0000540E File Offset: 0x0000360E
		public static implicit operator string(JSONNode d)
		{
			if (!(d == null))
			{
				return d.Value;
			}
			return null;
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00005421 File Offset: 0x00003621
		public static implicit operator JSONNode(double n)
		{
			return new JSONNumber(n);
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00005429 File Offset: 0x00003629
		public static implicit operator double(JSONNode d)
		{
			if (!(d == null))
			{
				return d.AsDouble;
			}
			return 0.0;
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00005444 File Offset: 0x00003644
		public static implicit operator JSONNode(float n)
		{
			return new JSONNumber((double)n);
		}

		// Token: 0x0600007A RID: 122 RVA: 0x0000544D File Offset: 0x0000364D
		public static implicit operator float(JSONNode d)
		{
			if (!(d == null))
			{
				return d.AsFloat;
			}
			return 0f;
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00005444 File Offset: 0x00003644
		public static implicit operator JSONNode(int n)
		{
			return new JSONNumber((double)n);
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00005464 File Offset: 0x00003664
		public static implicit operator int(JSONNode d)
		{
			if (!(d == null))
			{
				return d.AsInt;
			}
			return 0;
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00005477 File Offset: 0x00003677
		public static implicit operator JSONNode(long n)
		{
			if (JSONNode.longAsString)
			{
				return new JSONString(n.ToString());
			}
			return new JSONNumber((double)n);
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00005494 File Offset: 0x00003694
		public static implicit operator long(JSONNode d)
		{
			if (!(d == null))
			{
				return d.AsLong;
			}
			return 0L;
		}

		// Token: 0x0600007F RID: 127 RVA: 0x000054A8 File Offset: 0x000036A8
		public static implicit operator JSONNode(bool b)
		{
			return new JSONBool(b);
		}

		// Token: 0x06000080 RID: 128 RVA: 0x000054B0 File Offset: 0x000036B0
		public static implicit operator bool(JSONNode d)
		{
			return !(d == null) && d.AsBool;
		}

		// Token: 0x06000081 RID: 129 RVA: 0x000054C3 File Offset: 0x000036C3
		public static implicit operator JSONNode(KeyValuePair<string, JSONNode> aKeyValue)
		{
			return aKeyValue.Value;
		}

		// Token: 0x06000082 RID: 130 RVA: 0x000054CC File Offset: 0x000036CC
		public static bool operator ==(JSONNode a, object b)
		{
			if (a == b)
			{
				return true;
			}
			bool flag = a is JSONNull || a == null || a is JSONLazyCreator;
			bool flag2 = b is JSONNull || b == null || b is JSONLazyCreator;
			return (flag && flag2) || (!flag && a.Equals(b));
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00005522 File Offset: 0x00003722
		public static bool operator !=(JSONNode a, object b)
		{
			return !(a == b);
		}

		// Token: 0x06000084 RID: 132 RVA: 0x0000552E File Offset: 0x0000372E
		public override bool Equals(object obj)
		{
			return this == obj;
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00005534 File Offset: 0x00003734
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000086 RID: 134 RVA: 0x0000553C File Offset: 0x0000373C
		internal static StringBuilder EscapeBuilder
		{
			get
			{
				if (JSONNode.m_EscapeBuilder == null)
				{
					JSONNode.m_EscapeBuilder = new StringBuilder();
				}
				return JSONNode.m_EscapeBuilder;
			}
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00005554 File Offset: 0x00003754
		internal static string Escape(string aText)
		{
			StringBuilder escapeBuilder = JSONNode.EscapeBuilder;
			escapeBuilder.Length = 0;
			if (escapeBuilder.Capacity < aText.Length + aText.Length / 10)
			{
				escapeBuilder.Capacity = aText.Length + aText.Length / 10;
			}
			int i = 0;
			while (i < aText.Length)
			{
				char c = aText[i];
				switch (c)
				{
				case '\b':
					escapeBuilder.Append("\\b");
					break;
				case '\t':
					escapeBuilder.Append("\\t");
					break;
				case '\n':
					escapeBuilder.Append("\\n");
					break;
				case '\v':
					goto IL_E2;
				case '\f':
					escapeBuilder.Append("\\f");
					break;
				case '\r':
					escapeBuilder.Append("\\r");
					break;
				default:
					if (c != '"')
					{
						if (c != '\\')
						{
							goto IL_E2;
						}
						escapeBuilder.Append("\\\\");
					}
					else
					{
						escapeBuilder.Append("\\\"");
					}
					break;
				}
				IL_121:
				i++;
				continue;
				IL_E2:
				if (c < ' ' || (JSONNode.forceASCII && c > '\u007f'))
				{
					ushort num = (ushort)c;
					escapeBuilder.Append("\\u").Append(num.ToString("X4"));
					goto IL_121;
				}
				escapeBuilder.Append(c);
				goto IL_121;
			}
			string text = escapeBuilder.ToString();
			escapeBuilder.Length = 0;
			return text;
		}

		// Token: 0x06000088 RID: 136 RVA: 0x000056A4 File Offset: 0x000038A4
		private static JSONNode ParseElement(string token, bool quoted)
		{
			if (quoted)
			{
				return token;
			}
			string text = token.ToLower();
			if (text == "false" || text == "true")
			{
				return text == "true";
			}
			if (text == "null")
			{
				return JSONNull.CreateOrGet();
			}
			double num;
			if (double.TryParse(token, NumberStyles.Float, CultureInfo.InvariantCulture, out num))
			{
				return num;
			}
			return token;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00005724 File Offset: 0x00003924
		public static JSONNode Parse(string aJSON)
		{
			Stack<JSONNode> stack = new Stack<JSONNode>();
			JSONNode jsonnode = null;
			int i = 0;
			StringBuilder stringBuilder = new StringBuilder();
			string text = "";
			bool flag = false;
			bool flag2 = false;
			while (i < aJSON.Length)
			{
				char c = aJSON[i];
				if (c <= ',')
				{
					if (c <= ' ')
					{
						switch (c)
						{
						case '\t':
							break;
						case '\n':
						case '\r':
							goto IL_348;
						case '\v':
						case '\f':
							goto IL_33A;
						default:
							if (c != ' ')
							{
								goto IL_33A;
							}
							break;
						}
						if (flag)
						{
							stringBuilder.Append(aJSON[i]);
						}
					}
					else if (c != '"')
					{
						if (c != ',')
						{
							goto IL_33A;
						}
						if (flag)
						{
							stringBuilder.Append(aJSON[i]);
						}
						else
						{
							if (stringBuilder.Length > 0 || flag2)
							{
								jsonnode.Add(text, JSONNode.ParseElement(stringBuilder.ToString(), flag2));
							}
							text = "";
							stringBuilder.Length = 0;
							flag2 = false;
						}
					}
					else
					{
						flag = !flag;
						flag2 = flag2 || flag;
					}
				}
				else
				{
					if (c <= ']')
					{
						if (c != ':')
						{
							switch (c)
							{
							case '[':
								if (flag)
								{
									stringBuilder.Append(aJSON[i]);
									goto IL_348;
								}
								stack.Push(new JSONArray());
								if (jsonnode != null)
								{
									jsonnode.Add(text, stack.Peek());
								}
								text = "";
								stringBuilder.Length = 0;
								jsonnode = stack.Peek();
								goto IL_348;
							case '\\':
								i++;
								if (flag)
								{
									char c2 = aJSON[i];
									if (c2 <= 'f')
									{
										if (c2 == 'b')
										{
											stringBuilder.Append('\b');
											goto IL_348;
										}
										if (c2 == 'f')
										{
											stringBuilder.Append('\f');
											goto IL_348;
										}
									}
									else
									{
										if (c2 == 'n')
										{
											stringBuilder.Append('\n');
											goto IL_348;
										}
										switch (c2)
										{
										case 'r':
											stringBuilder.Append('\r');
											goto IL_348;
										case 't':
											stringBuilder.Append('\t');
											goto IL_348;
										case 'u':
										{
											string text2 = aJSON.Substring(i + 1, 4);
											stringBuilder.Append((char)int.Parse(text2, NumberStyles.AllowHexSpecifier));
											i += 4;
											goto IL_348;
										}
										}
									}
									stringBuilder.Append(c2);
									goto IL_348;
								}
								goto IL_348;
							case ']':
								break;
							default:
								goto IL_33A;
							}
						}
						else
						{
							if (flag)
							{
								stringBuilder.Append(aJSON[i]);
								goto IL_348;
							}
							text = stringBuilder.ToString();
							stringBuilder.Length = 0;
							flag2 = false;
							goto IL_348;
						}
					}
					else if (c != '{')
					{
						if (c != '}')
						{
							goto IL_33A;
						}
					}
					else
					{
						if (flag)
						{
							stringBuilder.Append(aJSON[i]);
							goto IL_348;
						}
						stack.Push(new JSONObject());
						if (jsonnode != null)
						{
							jsonnode.Add(text, stack.Peek());
						}
						text = "";
						stringBuilder.Length = 0;
						jsonnode = stack.Peek();
						goto IL_348;
					}
					if (flag)
					{
						stringBuilder.Append(aJSON[i]);
					}
					else
					{
						if (stack.Count == 0)
						{
							throw new Exception("JSON Parse: Too many closing brackets");
						}
						stack.Pop();
						if (stringBuilder.Length > 0 || flag2)
						{
							jsonnode.Add(text, JSONNode.ParseElement(stringBuilder.ToString(), flag2));
						}
						flag2 = false;
						text = "";
						stringBuilder.Length = 0;
						if (stack.Count > 0)
						{
							jsonnode = stack.Peek();
						}
					}
				}
				IL_348:
				i++;
				continue;
				IL_33A:
				stringBuilder.Append(aJSON[i]);
				goto IL_348;
			}
			if (flag)
			{
				throw new Exception("JSON Parse: Quotation marks seems to be messed up.");
			}
			if (jsonnode == null)
			{
				return JSONNode.ParseElement(stringBuilder.ToString(), flag2);
			}
			return jsonnode;
		}

		// Token: 0x04000050 RID: 80
		public static bool forceASCII;

		// Token: 0x04000051 RID: 81
		public static bool longAsString;

		// Token: 0x04000052 RID: 82
		[ThreadStatic]
		private static StringBuilder m_EscapeBuilder;

		// Token: 0x02000026 RID: 38
		public struct Enumerator
		{
			// Token: 0x1700005A RID: 90
			// (get) Token: 0x06000142 RID: 322 RVA: 0x00006BB7 File Offset: 0x00004DB7
			public bool IsValid
			{
				get
				{
					return this.type > JSONNode.Enumerator.Type.None;
				}
			}

			// Token: 0x06000143 RID: 323 RVA: 0x00006BC2 File Offset: 0x00004DC2
			public Enumerator(List<JSONNode>.Enumerator aArrayEnum)
			{
				this.type = JSONNode.Enumerator.Type.Array;
				this.m_Object = default(Dictionary<string, JSONNode>.Enumerator);
				this.m_Array = aArrayEnum;
			}

			// Token: 0x06000144 RID: 324 RVA: 0x00006BDE File Offset: 0x00004DDE
			public Enumerator(Dictionary<string, JSONNode>.Enumerator aDictEnum)
			{
				this.type = JSONNode.Enumerator.Type.Object;
				this.m_Object = aDictEnum;
				this.m_Array = default(List<JSONNode>.Enumerator);
			}

			// Token: 0x1700005B RID: 91
			// (get) Token: 0x06000145 RID: 325 RVA: 0x00006BFC File Offset: 0x00004DFC
			public KeyValuePair<string, JSONNode> Current
			{
				get
				{
					if (this.type == JSONNode.Enumerator.Type.Array)
					{
						return new KeyValuePair<string, JSONNode>(string.Empty, this.m_Array.Current);
					}
					if (this.type == JSONNode.Enumerator.Type.Object)
					{
						return this.m_Object.Current;
					}
					return new KeyValuePair<string, JSONNode>(string.Empty, null);
				}
			}

			// Token: 0x06000146 RID: 326 RVA: 0x00006C48 File Offset: 0x00004E48
			public bool MoveNext()
			{
				if (this.type == JSONNode.Enumerator.Type.Array)
				{
					return this.m_Array.MoveNext();
				}
				return this.type == JSONNode.Enumerator.Type.Object && this.m_Object.MoveNext();
			}

			// Token: 0x04000094 RID: 148
			private JSONNode.Enumerator.Type type;

			// Token: 0x04000095 RID: 149
			private Dictionary<string, JSONNode>.Enumerator m_Object;

			// Token: 0x04000096 RID: 150
			private List<JSONNode>.Enumerator m_Array;

			// Token: 0x02000030 RID: 48
			private enum Type
			{
				// Token: 0x040000B0 RID: 176
				None,
				// Token: 0x040000B1 RID: 177
				Array,
				// Token: 0x040000B2 RID: 178
				Object
			}
		}

		// Token: 0x02000027 RID: 39
		public struct ValueEnumerator
		{
			// Token: 0x06000147 RID: 327 RVA: 0x00006C75 File Offset: 0x00004E75
			public ValueEnumerator(List<JSONNode>.Enumerator aArrayEnum)
			{
				this = new JSONNode.ValueEnumerator(new JSONNode.Enumerator(aArrayEnum));
			}

			// Token: 0x06000148 RID: 328 RVA: 0x00006C83 File Offset: 0x00004E83
			public ValueEnumerator(Dictionary<string, JSONNode>.Enumerator aDictEnum)
			{
				this = new JSONNode.ValueEnumerator(new JSONNode.Enumerator(aDictEnum));
			}

			// Token: 0x06000149 RID: 329 RVA: 0x00006C91 File Offset: 0x00004E91
			public ValueEnumerator(JSONNode.Enumerator aEnumerator)
			{
				this.m_Enumerator = aEnumerator;
			}

			// Token: 0x1700005C RID: 92
			// (get) Token: 0x0600014A RID: 330 RVA: 0x00006C9C File Offset: 0x00004E9C
			public JSONNode Current
			{
				get
				{
					KeyValuePair<string, JSONNode> keyValuePair = this.m_Enumerator.Current;
					return keyValuePair.Value;
				}
			}

			// Token: 0x0600014B RID: 331 RVA: 0x00006CBC File Offset: 0x00004EBC
			public bool MoveNext()
			{
				return this.m_Enumerator.MoveNext();
			}

			// Token: 0x0600014C RID: 332 RVA: 0x00006CC9 File Offset: 0x00004EC9
			public JSONNode.ValueEnumerator GetEnumerator()
			{
				return this;
			}

			// Token: 0x04000097 RID: 151
			private JSONNode.Enumerator m_Enumerator;
		}

		// Token: 0x02000028 RID: 40
		public struct KeyEnumerator
		{
			// Token: 0x0600014D RID: 333 RVA: 0x00006CD1 File Offset: 0x00004ED1
			public KeyEnumerator(List<JSONNode>.Enumerator aArrayEnum)
			{
				this = new JSONNode.KeyEnumerator(new JSONNode.Enumerator(aArrayEnum));
			}

			// Token: 0x0600014E RID: 334 RVA: 0x00006CDF File Offset: 0x00004EDF
			public KeyEnumerator(Dictionary<string, JSONNode>.Enumerator aDictEnum)
			{
				this = new JSONNode.KeyEnumerator(new JSONNode.Enumerator(aDictEnum));
			}

			// Token: 0x0600014F RID: 335 RVA: 0x00006CED File Offset: 0x00004EED
			public KeyEnumerator(JSONNode.Enumerator aEnumerator)
			{
				this.m_Enumerator = aEnumerator;
			}

			// Token: 0x1700005D RID: 93
			// (get) Token: 0x06000150 RID: 336 RVA: 0x00006CF8 File Offset: 0x00004EF8
			public JSONNode Current
			{
				get
				{
					KeyValuePair<string, JSONNode> keyValuePair = this.m_Enumerator.Current;
					return keyValuePair.Key;
				}
			}

			// Token: 0x06000151 RID: 337 RVA: 0x00006D1D File Offset: 0x00004F1D
			public bool MoveNext()
			{
				return this.m_Enumerator.MoveNext();
			}

			// Token: 0x06000152 RID: 338 RVA: 0x00006D2A File Offset: 0x00004F2A
			public JSONNode.KeyEnumerator GetEnumerator()
			{
				return this;
			}

			// Token: 0x04000098 RID: 152
			private JSONNode.Enumerator m_Enumerator;
		}

		// Token: 0x02000029 RID: 41
		public class LinqEnumerator : IEnumerator<KeyValuePair<string, JSONNode>>, IDisposable, IEnumerator, IEnumerable<KeyValuePair<string, JSONNode>>, IEnumerable
		{
			// Token: 0x06000153 RID: 339 RVA: 0x00006D32 File Offset: 0x00004F32
			internal LinqEnumerator(JSONNode aNode)
			{
				this.m_Node = aNode;
				if (this.m_Node != null)
				{
					this.m_Enumerator = this.m_Node.GetEnumerator();
				}
			}

			// Token: 0x1700005E RID: 94
			// (get) Token: 0x06000154 RID: 340 RVA: 0x00006D60 File Offset: 0x00004F60
			public KeyValuePair<string, JSONNode> Current
			{
				get
				{
					return this.m_Enumerator.Current;
				}
			}

			// Token: 0x1700005F RID: 95
			// (get) Token: 0x06000155 RID: 341 RVA: 0x00006D6D File Offset: 0x00004F6D
			object IEnumerator.Current
			{
				get
				{
					return this.m_Enumerator.Current;
				}
			}

			// Token: 0x06000156 RID: 342 RVA: 0x00006D7F File Offset: 0x00004F7F
			public bool MoveNext()
			{
				return this.m_Enumerator.MoveNext();
			}

			// Token: 0x06000157 RID: 343 RVA: 0x00006D8C File Offset: 0x00004F8C
			public void Dispose()
			{
				this.m_Node = null;
				this.m_Enumerator = default(JSONNode.Enumerator);
			}

			// Token: 0x06000158 RID: 344 RVA: 0x00006DA1 File Offset: 0x00004FA1
			public IEnumerator<KeyValuePair<string, JSONNode>> GetEnumerator()
			{
				return new JSONNode.LinqEnumerator(this.m_Node);
			}

			// Token: 0x06000159 RID: 345 RVA: 0x00006DAE File Offset: 0x00004FAE
			public void Reset()
			{
				if (this.m_Node != null)
				{
					this.m_Enumerator = this.m_Node.GetEnumerator();
				}
			}

			// Token: 0x0600015A RID: 346 RVA: 0x00006DA1 File Offset: 0x00004FA1
			IEnumerator IEnumerable.GetEnumerator()
			{
				return new JSONNode.LinqEnumerator(this.m_Node);
			}

			// Token: 0x04000099 RID: 153
			private JSONNode m_Node;

			// Token: 0x0400009A RID: 154
			private JSONNode.Enumerator m_Enumerator;
		}
	}
}
