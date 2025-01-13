using UnityEngine;

namespace TalesEngine
{
	public interface ITimeObserver
	{
		public void OnTimePassed(float deltaTime);
	}
}
