#if CODEHELPERS_UNITY

using UnityEngine;
using ILogger = CodeHelpers.Diagnostics.ILogger;

namespace CodeHelpers.Unity.Diagnostics
{
	public class UnityLogger : ILogger
	{
		public void Write(string text) => Debug.Log(text);
		public void WriteWarning(string text) => Debug.LogWarning(text);
		public void WriteError(string text) => Debug.LogError(text);
	}
}

#endif