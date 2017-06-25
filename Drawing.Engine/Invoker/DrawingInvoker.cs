using System;
using Drawing.Engine.Command;
using System.Collections.Generic;

namespace Drawing.Engine.Invoker
{
    public class DrawingInvoker : IDrawingInvoker
    {
        List<ICanvasCommand> History {get;set;} = new List<ICanvasCommand>();
        public  void StoreAndExecute(ICanvasCommand command)
        {
            History.Add(command);
            command.Execute();
        }
    }
}