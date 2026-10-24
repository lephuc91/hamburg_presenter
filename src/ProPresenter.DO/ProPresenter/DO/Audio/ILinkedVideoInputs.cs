using System;
using System.Collections.Generic;
using ProPresenter.DO.LiveVideo;

namespace ProPresenter.DO.Audio;

public interface ILinkedVideoInputs
{
	bool this[int index] { get; set; }

	bool this[LiveVideoInput videoInput] { get; set; }

	int Count { get; }

	event Action DataModified;

	void Clear();

	void Deserialize(IEnumerable<int> inputs);

	bool IsLinked(int index);

	bool IsLinked(LiveVideoInput videoInput);

	void Link(int index);

	void Link(LiveVideoInput videoInput);

	IEnumerable<uint> Serialize();

	void ToggleLink(int index);

	void ToggleLink(LiveVideoInput videoInput);

	void Unlink(int index);

	void Unlink(LiveVideoInput videoInput);
}
