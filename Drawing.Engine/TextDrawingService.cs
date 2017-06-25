using System;
using Drawing.Engine.Invoker;
using Drawing.Engine.Receiver;
using Drawing.Engine.Command;
using System.IO;
using System.Collections.Generic;

namespace Drawing.Engine
{
    public class TextDrawingService : DrawingService
    {
        TextReader Input {get;set;}
        TextWriter Output {get;set;}
        TextWriter Error {get;set;}

        Dictionary<string, Func<string [], bool>> TextCmdHandlerDic {get;set;} = new Dictionary<string, Func<string [], bool>> (); 
        public TextDrawingService(TextReader input, TextWriter output, TextWriter error)
        {
            Input = input;
            Output = output;
            Error = error;

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
                    if(TextCmdHandlerDic[key].Invoke(ar))
                    {
                        // success
                        ret = false;
                    }
                }
            }

            return ret;
        }

        protected int GetDefaultColor()
        {
            return (int) 'x';
        }

        protected class ArgumentTuple
        {
            public string Name;
            public string GivenValue;
            public int ParsedValue;
        }

        protected bool ParseArgs(string feature, ref List<ArgumentTuple> ar)
        {
            bool ret = false;
            
            foreach(var i in ar)
            {
                int v;
                if(!int.TryParse(i.GivenValue, out v))
                {
                    //Error.WriteLine($"{i.Name} value ({i.GivenValue}) is not an integer");
                    ret = false; 
                }
                else
                {
                    i.ParsedValue = v;
                    ret = true;
                }
            }

            if(!ret)
            {
                Error.WriteLine($"Feature : [{feature}] requires these arguments in sequence");
                foreach(var i in ar)
                {

                }
            }

            return ret;
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
            for(int i = 0; i < Canvas.Width + 2; i++ )
            {
                Output.Write("-");
            }
            Output.WriteLine();

            for(int i = 0; i < Canvas.Height; i++)
            {
                Output.Write("|");
                for(int j=0; j< Canvas.Width; j++)
                {
                    IPixel pixel = Canvas.GetPixel(j,i);
                    char color = ' ';
                    if(pixel.Color != 0)
                    {
                        color = Convert.ToChar(pixel.Color);
                    }
                    Output.Write(color);
                }
                Output.Write("|");
                Output.WriteLine();
            }

            for(int i = 0; i < Canvas.Width + 2; i++ )
            {
                Output.Write("-");
            }
            Output.WriteLine();
        }
    }
}