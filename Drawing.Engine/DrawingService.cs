using System;
using Drawing.Engine.Invoker;
using Drawing.Engine.Receiver;
using Drawing.Engine.Command;

namespace Drawing.Engine
{
    public class DrawingService : DrawingInvoker
    {
        protected ICommandFactory CmdFactory{get;set;}
        protected ICanvasFactory CanvasFactory { get; set; }

        protected ICanvas Canvas{get;set;}
        public DrawingService()
        {
            CmdFactory = DefaultCommandFactory.Instance;
            CanvasFactory = DefaultCanvasFactory.Instance;
        }

        public DrawingService(ICommandFactory cmdfactory)
            :this(DefaultCanvasFactory.Instance, cmdfactory)
        {
        }

        public DrawingService(ICanvasFactory canvasFactory)
            :this(canvasFactory, DefaultCommandFactory.Instance)
        {
        }

        public DrawingService(ICanvasFactory canvasFactory, ICommandFactory cmdfactory)
        {
            CanvasFactory = canvasFactory;
            CmdFactory = cmdfactory;
        }

        public void CreateCanvas(int width, int height)
        {
            Canvas = CanvasFactory.CreateCanvas(width,height);
            History.Clear();
            OnExecuteSuccess();
        }

        public void CreateLine(int x1, int y1, int x2, int y2, int color)
        {
            if(Canvas == null)
                throw new InvalidOperationException("Canvas is null");

            var cmd = CmdFactory.CreateLine(Canvas, x1, y1, x2, y2, color);

            this.StoreAndExecute(cmd);
        }

        public void CreateRectangle(int x1, int y1, int x2, int y2, int color)
        {
            if(Canvas == null)
                throw new InvalidOperationException("Canvas is null");
                
            var cmd = CmdFactory.CreateRectangle(Canvas, x1, y1, x2, y2, color);

            this.StoreAndExecute(cmd);
        }

        public void BucketFill(int x, int y, int color)
        {
            if(Canvas == null)
                throw new InvalidOperationException("Canvas is null");
            
            var cmd = CmdFactory.CreateBucketFill(Canvas, x, y, color);

            this.StoreAndExecute(cmd);
        }
      
    }
}