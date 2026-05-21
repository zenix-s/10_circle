using System;

namespace CircleGame.Core;

public class TickManager
{
	public event Action Tick;

	public float TickRate = 1f;
	private float _accumulator = 0f;

	public void ProcessTime(double delta)
	{
		_accumulator += (float)delta;
		while (_accumulator >= TickRate)
		{
			_accumulator -= TickRate;
			Tick?.Invoke();
		}
	}
}
