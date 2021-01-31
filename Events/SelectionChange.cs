using System;

namespace CodeHelpers.Events
{
	public readonly struct SelectionChange : IEquatable<SelectionChange>
	{
		public SelectionChange(int? currentIndex, int? previousIndex)
		{
			this.currentIndex = currentIndex ?? -1;
			this.previousIndex = previousIndex ?? -1;
		}

		readonly int currentIndex;
		readonly int previousIndex;

		public int? CurrentIndex => currentIndex < 0 ? (int?)null : currentIndex;
		public int? PreviousIndex => previousIndex < 0 ? (int?)null : previousIndex;

		public bool Equals(SelectionChange other) => currentIndex == other.currentIndex && previousIndex == other.previousIndex;
		public override bool Equals(object obj) => obj is SelectionChange other && Equals(other);

		public override int GetHashCode()
		{
			unchecked
			{
				return (currentIndex * 397) ^ previousIndex;
			}
		}

		public override string ToString() => $"{nameof(CurrentIndex)}: {CurrentIndex}, {nameof(PreviousIndex)}: {PreviousIndex}";
	}
}