using System;
using Drawing.Engine.Command;
using System.Collections.Generic;

namespace Drawing.Engine.Invoker
{
    public class DrawingInvoker : IDrawingInvoker
    {
        protected List<ICanvasCommand> History {get;set;} = new List<ICanvasCommand>();
        public  void StoreAndExecute(ICanvasCommand command)
        {
            try{
                command.Execute();
                History.Add(command);
                OnExecuteSuccess();
            }
            catch(Exception e)
            {
                OnExcuteException(e);
            }
        }

        protected virtual void OnExcuteException(Exception e)
        {

        }
        protected virtual void OnExecuteSuccess()
        {
            
        }
    }
}