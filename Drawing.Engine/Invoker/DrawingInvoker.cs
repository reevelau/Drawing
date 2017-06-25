using System;
using Drawing.Engine.Command;
using System.Collections.Generic;

namespace Drawing.Engine.Invoker
{
    public class DrawingInvoker : IDrawingInvoker
    {
        public  void StoreAndExecute(ICanvasCommand command)
        {
            try{
                command.Execute();
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