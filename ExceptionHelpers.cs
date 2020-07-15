using System;
using System.Threading;
using CodeHelpers.DebugHelpers;
using CodeHelpers.ThreadHelpers;
using UnityEngine.Networking;

namespace CodeHelpers
{
	public static class ExceptionHelper
	{
		public static Exception NotPossible => new Exception("The impossible happened!");
		public static Exception NotConvertible => new Exception("Not convertible");
		public static Exception FoundNon => new Exception("Found non");
		public static Exception PlayerObjectNotExist => new Exception("The player object does not exist");

		public static Exception Invalid(string memberName, InvalidType type) => GetException(memberName, GetInvalidMessage(type));
		public static Exception Invalid(string memberName, object argumentValue, InvalidType type) => GetException(memberName, argumentValue, GetInvalidMessage(type));

		public static Exception Invalid(string memberName, string customMessage) => GetException(memberName, customMessage);
		public static Exception Invalid(string memberName, object argumentValue, string customMessage) => GetException(memberName, argumentValue, customMessage);

		static Exception GetException(string name, string message) => new Exception($"The member named \"{name}\" is invalid because it {message}");
		static Exception GetException(string name, object value, string message) => new Exception($"The member named \"{name}\" with a value of {DebugHelper.ToString(value)} is invalid because it {message}");

		public static NotSupportedException UseNewMember(string newMemberName, string oldMemberName = null)
		{
			if (oldMemberName == null) return new NotSupportedException($"Use the new member, {newMemberName}, instead.");
			return new NotSupportedException($"Old member, {oldMemberName}, should not be used for this type. Use the new member, {newMemberName}, instead.");
		}

		public static void InvalidIfNotMainThread()
		{
			if (ThreadHelper.IsOnMainThread) return;
			throw new Exception("This code can only be executed in the main thread.");
		}

		static string GetInvalidMessage(InvalidType type)
		{
			switch (type)
			{
				case InvalidType.isNull:                   return "is null.";
				case InvalidType.unexpected:               return "is unexpected.";
				case InvalidType.outOfBounds:              return "is out of bounds.";
				case InvalidType.minLargerThanMax:         return "is larger than max.";
				case InvalidType.collectionCountIs0:       return "has a count/length of 0, which is unexpected.";
				case InvalidType.unexpectedIdentification: return "is an unexpected identification.";
				case InvalidType.indistinctiveCollection:  return "is a collection with items that are not distinctive.";
				case InvalidType.foundDuplicate:           return "is already present and a duplicate of a current object.";
				case InvalidType.semiReadonlyAssignment:   return "is semi-readonly (can only be assigned once).";
				case InvalidType.semiReadonlyNoData:       return "is semi-readonly and needs an assignment before accessing.";
				case InvalidType.alreadySealed:            return "is already sealed.";
			}

			throw NotPossible;
		}
	}

	public enum InvalidType
	{
		isNull,
		unexpected,
		outOfBounds,
		minLargerThanMax,
		collectionCountIs0,
		unexpectedIdentification,
		indistinctiveCollection,
		foundDuplicate,
		semiReadonlyAssignment,
		semiReadonlyNoData,
		alreadySealed
	}
}