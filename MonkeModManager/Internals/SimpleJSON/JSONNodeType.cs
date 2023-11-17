using System;

namespace MonkeModManager.Internals.SimpleJSON
{
	// Token: 0x02000009 RID: 9
	public enum JSONNodeType
	{
		// Token: 0x04000045 RID: 69
		Array = 1,
		// Token: 0x04000046 RID: 70
		Object,
		// Token: 0x04000047 RID: 71
		String,
		// Token: 0x04000048 RID: 72
		Number,
		// Token: 0x04000049 RID: 73
		NullValue,
		// Token: 0x0400004A RID: 74
		Boolean,
		// Token: 0x0400004B RID: 75
		None,
		// Token: 0x0400004C RID: 76
		Custom = 255
	}
}
