using System;

namespace CodeHelpers.Files
{
	public interface ITypeSerializer
	{
		void Write(DataWriter writer, Type type);
		Type Read(DataReader reader);
	}
}