using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Vrlife.Core
{
    public class ActorManager : CommandBufferManager
    {
        public static readonly string ScreenPlaysName = nameof(screenPlays);
        
        public DialogLineEventHandler onLineComplete;

        public ActorManagerEventsHandler onCommandsBuffered;

        [SerializeField] private ScreenPlaysPlaceholder[] screenPlays;

        private ActorScreenPlayLine _currentLine;

        public void PlayScreenLine(string screenPlayName, string lineId)
        {
            var screenPlay = screenPlays.FirstOrDefault(x => x.screenPlay.Id == screenPlayName);

            _currentLine = screenPlay.lines.FirstOrDefault(x => x.Id == lineId);

            _currentLine.onLineExecute?.Invoke(_currentLine);

            var commandList = new List<Command>();

            if (!string.IsNullOrEmpty(_currentLine.text))
            {
                commandList.Add(new SpeechCommand {Text = _currentLine.text, Lifetime = 30 });
            }

            if (_currentLine.walkTo)
            {
                commandList.Add(new WalkCommand {Target = _currentLine.walkTo, Lifetime = 30 });
            }

            if (_currentLine.watchAnimationExit.Length > 0)
            {
                commandList.Add(new AnimationCommand(_currentLine.watchAnimationExit){ Lifetime = 30 });
            }

            var commands = commandList.ToArray();
        
            BufferCommands(commands);
        
            onCommandsBuffered?.Invoke(commands);
        }

        private void Update()
        {
            UpdateCommandBuffer();
        }

        protected override void OnBufferCompleted()
        {
            onLineComplete?.Invoke(_currentLine);
        }
    }
}