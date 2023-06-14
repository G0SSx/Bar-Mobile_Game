using System;
using System.Collections;
using _Code.Infrastructure;
using UnityEngine;

namespace _Code.Logic
{
    public class GameTimer
    {
        public Timer Timer { get; private set; } = new();

        private readonly ICoroutineRunner _coroutineRunner;

        private Coroutine _current;

        public GameTimer(ICoroutineRunner coroutineRunner) =>
            _coroutineRunner = coroutineRunner;

        public void Start(Action onFinish, float finishTime)
        {
            StopTimerIfActive();

            Timer.SetFinishTime(finishTime);
            _current = _coroutineRunner.StartCoroutine(StartTimer(onFinish));
        }

        public void RenewTimer(Action onFinish)
        {
            StopTimerIfActive();
            _current = _coroutineRunner.StartCoroutine(StartTimer(onFinish));
        }

        public void Stop() => 
            _coroutineRunner.StopCoroutine(_current);

        private void StopTimerIfActive()
        {
            if (_current != null)
                Stop();
        }

        private IEnumerator StartTimer(Action onFinish)
        {
            Debug.Log("Timer started");

            while (true)
            {
                yield return null;
                Timer.SubtractFrameTime();

                if (Timer.TimeLeft < 0)
                {
                    onFinish?.Invoke();
                    Debug.Log("Timer finished");
                    yield break;
                }
            }

        }
    }
}