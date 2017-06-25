using System;
using Drawing.Engine.Invoker;
using Drawing.Engine.Receiver;
using Drawing.Engine.Command;
using System.IO;
using System.Collections.Generic;
using Drawing.Engine.Utility; 

namespace Drawing.Engine.Text
{
    public class DrawingService : DrawingServiceBase
    {
        TextReader Input {get;set;}
        TextWriter Output {get;set;}
        TextWriter Error {get;set;}

        ICanvasPrinter Printer{get;set;}

        Dictionary<string, Func<string [], bool>> TextCmdHandlerDic {get;set;} = new Dictionary<string, Func<string [], bool>> ();
        public DrawingService(TextReader input, TextWriter output, TextWriter error)
            : this(input , output, error, new CanvasPrinter(output))
        {

        } 
        public DrawingService(TextReader input, TextWriter output, TextWriter error, ICanvasPrinter printer)
        {
            Input = input;
            Output = output;
            Error = error;
            Printer = printer;

            TextCmdHandlerDic["C"] = this.Cmd_C;
            TextCmdHandlerDic["L"] = this.Cmd_L;
            TextCmdHandlerDic["R"] = this.Cmd_R;
            TextCmdHandlerDic["B"] = this.Cmd_B;
        }

        public void Start()
        {
            string line = null;

            do
            {
                Output.Write("enter command: ");
                line = Input.ReadLine();
            }
            while(!IsProcessDone(line));
        }

        protected bool IsProcessDone(string line)
        {
            bool ret = false;

            if(line.ToUpper() == "Q")
            {
                ret = true;
            }
            else{
                string [] ar = line.Split(' ');
                string key = ar[0].ToUpper();
                if(TextCmdHandlerDic.ContainsKey(key))
                {
                    try
                    {
                        TextCmdHandlerDic[key].Invoke(ar);
                    }
                    catch(Exception e)
                    {
                        OnExcuteException(e);
                    }
                }
                else
                {
                    Error.WriteLine($"Unknown Command {line}");
                }
            }
            return ret;
        }

        protected int GetDefaultColor()
        {
            return (int) 'x';
        }

        protected bool ParseIntField(string name, string input, out int reseult)
        {
            if(!int.TryParse(input, out reseult))
            {
                Error.WriteLine($"{name} value ({input}) is not an integer");
                return false;
            }
            return true;
        }

        protected bool ParseCharField(string name, string input, out char reseult)
        {
            if(!char.TryParse(input, out reseult))
            {
                Error.WriteLine($"{name} value ({input}) is not a char");
                return false;
            }
            return true;
        }

        protected bool Cmd_C(string [] cmd)
        {
            if(cmd[0].ToUpper() != "C")
                return false;
            
            int width = 0, height = 0;
            if(!ParseIntField("Width", cmd[1], out width)) 
                return false;
            
            if(!ParseIntField("Height", cmd[2], out height))
                return false;

            this.CreateCanvas(width, height);
            return true;
        }

        protected bool Cmd_L(string [] cmd)
        {
            if(cmd[0].ToUpper() != "L")
                return false;
            
            int x1, y1, x2, y2;

            if(!ParseIntField("x1", cmd[1], out x1)) 
                return false;
            
            if(!ParseIntField("y1", cmd[2], out y1)) 
                return false;
            
            if(!ParseIntField("x2", cmd[3], out x2)) 
                return false;
            
            if(!ParseIntField("y2", cmd[4], out y2)) 
                return false;
            
            this.CreateLine(x1-1, y1-1, x2-1, y2-1, GetDefaultColor());
            return true;
        }

        protected bool Cmd_R(string [] cmd)
        {
            if(cmd[0].ToUpper() != "R")
                return false;
            
            int x1, y1, x2, y2;

            if(!ParseIntField("x1", cmd[1], out x1)) 
                return false;
            
            if(!ParseIntField("y1", cmd[2], out y1)) 
                return false;
            
            if(!ParseIntField("x2", cmd[3], out x2)) 
                return false;
            
            if(!ParseIntField("y2", cmd[4], out y2)) 
                return false;
            
            this.CreateRectangle(x1-1, y1-1, x2-1, y2-1, GetDefaultColor());
            return true;
        }

        protected bool Cmd_B(string [] cmd)
        {
            if(cmd[0].ToUpper() != "B")
                return false;
            
            int x, y;
            char c; 

            if(!ParseIntField("x", cmd[1], out x)) 
                return false;
            
            if(!ParseIntField("y", cmd[2], out y)) 
                return false;
                
            if(!ParseCharField("c", cmd[3], out c)) 
                return false;
            
            this.BucketFill(x -1, y -1,  (int)c);
            return true;
        }

        protected override void OnExecuteSuccess()
        {
            Printer.Print(this.Canvas);
        }

        protected override void OnExcuteException(Exception e)
        {
            Error.WriteLine();
            Error.WriteLine("Runtime exception:");

            if(e is IncorrectCoordianteException)
            {
                var cast = e as IncorrectCoordianteException;
                Error.WriteLine($"\tCoordinate ({cast.X+1},{cast.Y+1}) is incorrect in current Canvas.");
            }
            else
            {
                Error.WriteLine($"\t{e.Message}");
            }
        }
    }
}