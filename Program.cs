using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
//MacOS ,VScode

namespace assignment_03_19404086
{    class Program
    {
        static void Main(string[] args)
        {
            bool showTheMenu = true;   // menu control
            // around the menu item functions
            Canvas canvas = new Canvas();
           // Shape shape = new Shape();
            //Main terminal menu each time the new terminal executes
            Console.WriteLine("***********************");
            Console.WriteLine("SVG CANVAS Created\n");
            Console.WriteLine("Abderahman Haouit, 19404086");
            Console.WriteLine("***********************\n");
            //Dispaly the menu contents
            message();
            //UNTIL INPUT SATISFIED KEEP PROOMTING FOR CORRECT INPUT WITH THE MENU
            while (showTheMenu)
            {
                showTheMenu = MainMenu(canvas);
            }
            Console.Clear();// Clear terminal for tidiness 
        }
        //
        // This section contains the application MENU
        //
        static void message()
            {
            Console.Write("\rCommands: \n");
            Console.WriteLine("H: Help - displays this message");
            Console.WriteLine("A: <Shape> Add <shape to canvas");
            Console.WriteLine("U: Undo last operation");
            Console.WriteLine("R: Redo last operation");
            Console.WriteLine("C: Clear canvas");
            Console.WriteLine("S: Save in the 'shape2.svg' file");
            Console.WriteLine("D: Dispaly canvas to the console");
            Console.WriteLine("Q: Quit application \n");
            }
        //
        // This section contains the application CASES
        //
        public static bool MainMenu(Canvas canvas)
        {
            User user=new User();
            string input;
            Console.Write("> ");
            switch (Console.ReadKey().KeyChar)
            {
                case 'H':
                    message();                           //printing out the message method
                    return true;
                case 'A': 
                    input = Console.ReadLine();         //Read the shape entered by the user
                    checkShape(input,canvas,user);           //put the shape and canvas in method
                    return true;
                case 'U':
                    user.Undo();
                    user.Action(new DeleteShapeCommand(canvas));
                    //UndoShape(canvas);
                    return true;
                case 'R':
                    user.Redo();
                    //user.Action(new AddShapeCommand(s,canvas));
                    return true;    
                case 'C':
                    clear(canvas);                  //putting canvas into the delete shape method
                    MenuItemClear();              //promting user to enter space bar to continu                            
                    message();                  //printing out the message method
                    return true;   
                case 'S':                 
                    DisplayCanvas(canvas);   //putting canvas into the display method
                    return true;            //This will exit terminal and run new T as we are finished with canvas (created)
                case 'D':
                    DisplayCanvas1(canvas);     //putting canvas into the display1 method
                    return true;  
                case 'Q':
                case 'q':
                    return false;
                default:
                    Console.Clear();
                    Console.WriteLine("Please Enter one of the command keys!\n");//if input is not met keep prompting for correct input
                    message();
                return true;
            }
        }
        //
        // This section contains the menu item functions
        //
        private static void MenuItemClear()
        {
            // menu header output
            do{
                Console.WriteLine("\nPlease enter Space Bar to Continue !");
            }while(Console.ReadKey(true).Key != ConsoleKey.Spacebar); 
        }
        public static void checkShape(string input, Canvas canvas,User user)
    {
        if(input==" circle"){
            CreateRandomCircle(canvas,user); 
        }
        else if(input==" rectangle"){
            CreateRandomRectangle(canvas,user);
        }
        else if(input==" ellipse"){
            CreateRandomEllipse(canvas,user); 
        }
        else if(input==" line"){
            CreateRandomLine(canvas,user); 
        }
        else if(input==" polyline"){
            CreateRandomPolyLine(canvas,user); 
        }
        else if(input==" polygon"){
            CreateRandomPolygon(canvas,user);
        }
        else if(input==" path"){
            CreateRandomPath(canvas,user);
        }
        else{
            Console.WriteLine("\nPlease enter a shape example from assingment 2!");
            message();
        }
    }    
        private static void CreateRandomCircle(Canvas canvas,User user) 
        {
            // menu header output
            // create the random circle
            Random rnd = new Random(); // random number generator
            int rnd1=rnd.Next(100, 200);
            int rnd2=rnd.Next(100, 200);
            int rnd3=rnd.Next(100, 200);

            Circle c = new Circle("C"+rnd.Next(1, 50),rnd1, rnd2, rnd3);
            Console.WriteLine("Circle (R="+rnd1+",X="+rnd2+",Y="+rnd3+") added to canvas.");
            user.Action(new AddShapeCommand(c,canvas));
            // add the circle to the canvas - at the end of the list
            //canvas.Add(c);
            // write the circle details
        }
        private static void CreateRandomRectangle(Canvas canvas,User user)
        {
            // create the random Rectangle
            Random rnd = new Random(); // random number generator
            int rnd1=rnd.Next(100, 200);
            int rnd2=rnd.Next(100, 200);
            int rnd3=rnd.Next(1, 100);
            int rnd4=rnd.Next(1, 100);

            Rectangle r = new Rectangle("R"+rnd.Next(1, 50),rnd1, rnd2, rnd3, rnd4);
            //Print to user what they created
            Console.WriteLine("Rectangle (X="+rnd1+",Y="+rnd2+",Width="+rnd3+",Height="+rnd4+") added to canvas.");
            user.Action(new AddShapeCommand(r,canvas));
            // add the Rectangle to the canvas - at the end of the list
            //canvas.Add(r);
        }

        private static void CreateRandomEllipse(Canvas canvas,User user)
        {
            // create the random Ellipse
            Random rnd = new Random(); // random number generator
            int rnd1=rnd.Next(100, 200);
            int rnd2=rnd.Next(100, 200);
            int rnd3=rnd.Next(1, 100);
            int rnd4=rnd.Next(1, 100);

            Ellipse e = new Ellipse("E"+rnd.Next(1, 50),rnd1, rnd2, rnd3, rnd4);
            //Print to user what they created
            Console.WriteLine("Ellipse (XR="+rnd1+",YR="+rnd2+",CX="+rnd3+",CY="+rnd4+") added to canvas.");
            user.Action(new AddShapeCommand(e,canvas));
            // add the Ellipse to the canvas - at the end of the list
            //canvas.Add(e);
        }
        private static void CreateRandomLine(Canvas canvas,User user)
        {
            // create the random Line
            Random rnd = new Random(); // random number generator
            int rnd1=rnd.Next(100, 200);
            int rnd2=rnd.Next(100, 200);
            int rnd3=rnd.Next(1, 100);
            int rnd4=rnd.Next(1, 100);

            Line l = new Line("L"+rnd.Next(1, 50),rnd1, rnd2, rnd3, rnd4);
            //Print to user what they created
            Console.WriteLine("Line (X1"+rnd1+",Y1="+rnd2+",X2="+rnd3+",Y2="+rnd4+") added to canvas.");
            user.Action(new AddShapeCommand(l,canvas));
            // add the Line to the canvas - at the end of the list
            //canvas.Add(l);
        }
        private static void CreateRandomPolyLine(Canvas canvas,User user)
        {
            // create the random PolyLine
            Random rnd = new Random(); // random number generator
            int rnd1=rnd.Next(1, 100),rnd2=rnd.Next(100, 200),rnd3=rnd.Next(1, 100),rnd4=rnd.Next(100, 200),rnd5=rnd.Next(1, 100),
                rnd6=rnd.Next(100, 200),rnd7=rnd.Next(1, 100),rnd8=rnd.Next(100, 200),rnd9=rnd.Next(1, 100),rnd10=rnd.Next(100, 200),rnd11=rnd.Next(1, 100),rnd12=rnd.Next(100, 200),
                rnd13=rnd.Next(1, 100),rnd14=rnd.Next(100, 200),rnd15=rnd.Next(1, 100),rnd16=rnd.Next(100, 200),rnd17=rnd.Next(1, 100),rnd18=rnd.Next(100, 200);

            PolyLine p = new PolyLine("P"+rnd.Next(1, 50),rnd1+" "+rnd2+" "+rnd3+" "+rnd4+" "+rnd5+" "+rnd6+" "+rnd7+" "+rnd8+" "+rnd9+" "+rnd10+" "+rnd11+" "+rnd12+" "+rnd13+" "+rnd14+" "+rnd15+" "+rnd16+" "+rnd17+" "+rnd18+" ");
            //Print to user what they created
            Console.WriteLine("Polyline (Points "+rnd1+","+rnd2+","+rnd3+","+rnd4+","+rnd5+","+rnd6+","+rnd7+","+rnd8+","+rnd9+","+rnd10+","+rnd11+","+rnd12+","+rnd13+","+rnd14+","+rnd15+","+rnd16+rnd17+","+rnd18+") added to canvas.");
            user.Action(new AddShapeCommand(p,canvas));
            // add the PolyLine to the canvas - at the end of the list
            //canvas.Add(p);
        }
        private static void CreateRandomPolygon(Canvas canvas,User user)
        {
            // create the random Polygon
            Random rnd = new Random(); // random number generator
            int rnd1=rnd.Next(1, 100),rnd2=rnd.Next(100, 200),rnd3=rnd.Next(1, 100),rnd4=rnd.Next(100, 200),rnd5=rnd.Next(1, 100),
                rnd6=rnd.Next(100, 200),rnd7=rnd.Next(1, 100),rnd8=rnd.Next(100, 200),rnd9=rnd.Next(1, 100),rnd10=rnd.Next(100, 200),rnd11=rnd.Next(1, 100),rnd12=rnd.Next(100, 200),
                rnd13=rnd.Next(1, 100),rnd14=rnd.Next(100, 200),rnd15=rnd.Next(1, 100),rnd16=rnd.Next(100, 200),rnd17=rnd.Next(1, 100),rnd18=rnd.Next(100, 200),
                rnd19=rnd.Next(1, 100),rnd20=rnd.Next(100, 200);

            Polygon pg = new Polygon("PG"+rnd.Next(1, 50),rnd1+" "+rnd2+" "+rnd3+" "+rnd4+" "+rnd5+" "+rnd6+" "+rnd7+" "+rnd8+" "+rnd9+" "+rnd10+" "+rnd11+" "+rnd12+" "+rnd13+" "+rnd14+" "+rnd15+" "+rnd16+" "+rnd17+" "+rnd18+" "+rnd19+" "+rnd20+" ");
            //Print to user what they created
            Console.WriteLine("Polygon (Points "+rnd1+","+rnd2+","+rnd3+","+rnd4+","+rnd5+","+rnd6+","+rnd7+","+rnd8+","+rnd9+","+rnd10+","+rnd11+","+rnd12+","+rnd13+","+rnd14+","+rnd15+","+rnd16+","+rnd17+","+rnd18+","+rnd19+","+rnd20+") added to canvas.");
            user.Action(new AddShapeCommand(pg,canvas));
            // add the Polygon to the canvas - at the end of the list
            //canvas.Add(pg);
        }
        private static void CreateRandomPath(Canvas canvas,User user)
        {
            // create the random Path
            Random rnd = new Random(); // random number generator
            int rnd1=rnd.Next(1, 100),rnd2=rnd.Next(200, 250),rnd3=rnd.Next(1, 100),rnd4=rnd.Next(200, 250),rnd5=rnd.Next(1, 100),
                rnd6=rnd.Next(200, 250),rnd7=rnd.Next(1, 100),rnd8=rnd.Next(200, 250);

            Path pt = new Path("Path"+rnd.Next(1, 50),"M"+rnd1+","+rnd2+" "+"Q"+rnd3+","+rnd4+" "+rnd5+","+rnd6+" "+"T"+rnd7+","+rnd8);
            //Print to user what they created
            Console.WriteLine("Path (Points "+"M"+rnd1+","+rnd2+" "+"Q"+rnd3+","+rnd4+" "+rnd5+","+rnd6+" "+"T"+rnd7+","+rnd8+") added to canvas.");
            user.Action(new AddShapeCommand(pt,canvas));
            // add the Polygon to the canvas - at the end of the list
            //canvas.Add(pt);
        }
        private static void DisplayCanvas(Canvas canvas)
        {
            // menu header output
            Console.WriteLine("\nDrawing Canvas (as SVG), check the 'shape2.svg' file");
            canvas.DisplayCanvas();
        }
        private static void DisplayCanvas1(Canvas canvas)
        {
            // menu header output 
            Console.WriteLine("\nDrawing Canvas (as SVG), in the Console\n");
            canvas.DisplayCanvas1();
        }
        private static void clear(Canvas canvas)
        {
            // menu header output 
            Console.WriteLine("\nCleared the Canvas!");
            canvas.clear();
        }    
        //
        // This section contains the classes used by the application
        // to create canvas, shapes, etc.
        //
        public class Canvas
        {
            private Stack<Shape> canvas = new Stack<Shape>(); // using list to store shapes
            //private Stack<Shape> undo = new Stack<Shape>();
            //private Stack<Shape> redo = new Stack<Shape>();
            public void Add(Shape s)
            {
                canvas.Push(s);
            }
            public Shape Remove()
            {
                Shape s = canvas.Pop();
                //Console.WriteLine("Removed Shape from canvas: {0}" + Environment.NewLine, s);
                return s;
            }
            public Canvas () { }
            public void DisplayCanvas () {
                // create the opening and closing tags for the svg canvas
                string svgOpen = @"<svg height=""500"" width=""500"" xmlns=""http://www.w3.org/2000/svg"">";
                string svgClose = @"</svg>";
                //draw the canvas (write to the display)
                string svg = @"./shape2.svg";
                using (StreamWriter sw = File.CreateText(svg))
                {
                    sw.WriteLine(svgOpen);
                    foreach (var shape in canvas) sw.WriteLine("".PadLeft(3, ' ') + shape.ToSVGElement());
                    sw.WriteLine(svgClose+"\n");
                }
            }
            public void DisplayCanvas1 () {
                // create the opening and closing tags for the svg canvas
                string svgOpen = @"<svg height=""500"" width=""500"" xmlns=""http://www.w3.org/2000/svg"">";
                string svgClose = @"./shape2.svg";

                // draw the canvas (write to the display)
                Console.WriteLine(svgOpen);
                // iterate over all circles in the list
                foreach (var shape in canvas) Console.WriteLine("".PadLeft(3, ' ') + shape.ToSVGElement());
                Console.WriteLine(svgClose);
            }
            public void clear() 
            {
                canvas.Clear();//Clears all the shapes in the canvas
            }
        } 
        public abstract class Shape {
            public string ID { get; set; }            // shapes have an ID
            public abstract string ToSVGElement();    // shapes must implement to SVG method
        }

        public class Circle : Shape
        {
            public int X { get; set; }        // circle centre x-coordinate
            public int Y { get; set; }        // circle centre y-coordinate
            public int R { get; set; }        // circle radius

            public Circle() { ID="C100"; X = 100; Y = 100; R = 100; }
            public Circle(string id, int x, int y, int r) { ID = id; X = x; Y = y; R = r; }

            public override string ToString()
            {
                // convert the Object to a string
                string dispXYR = String.Format("Circle ({3}) at ({0},{1}) R={2}.", X, Y, R, ID);
                // return the convered string
                return dispXYR;
            }

            public override string ToSVGElement()
            {
                // convert the object to an SVG element descriptor string for circle
                string dispSVG = String.Format(@"<circle id=""{3}"" cx=""{0}"" cy=""{1}"" r=""{2}"" stroke=""black"" stroke-width=""5"" fill=""yellow"" />", X, Y, R, ID);
                return dispSVG;
            }
        }
        public class Rectangle : Shape
        {
            public int X { get; set; }        // Rectangle centre x-coordinate
            public int Y { get; set; }        // Rectangle centre y-coordinate
            public int W { get; set; }        // Rectangle width
            public int H { get; set; }        // Rectangle height

            public Rectangle() { ID="R100"; X = 100; Y = 100; W = 100; H = 100;}

            public Rectangle(string id, int x, int y, int w, int h) { ID = id; X = x; Y = y; W = w; H = h;}

            public override string ToString()
            {
                // convert the Object to a string
                string dispXYR = String.Format("Rectangle ({4}) at ({0},{0}) W={1} H={1}.", X, Y, W, H, ID);
                // return the convered string
                return dispXYR;
            }
            public override string ToSVGElement()
            {
                // convert the object to an SVG element descriptor string for circle
                string dispSVG = String.Format(@"<rect id=""{4}"" x=""{0}"" y=""{0}"" width=""{1}"" height=""{1}"" stroke=""black"" stroke-width=""5"" fill=""purple"" />", X, Y, W, H, ID);
                return dispSVG;
            }

        }
        public class Ellipse : Shape
        {
            public int X { get; set; }        // Ellipse centre x-coordinate
            public int Y { get; set; }        // Ellipse centre y-coordinate
            public int RX { get; set; }       // Ellipse radius x
            public int RY { get; set; }       // Ellipse radius y

            public Ellipse() { ID="E100"; X = 100; Y = 100; RX = 100; RY = 100;}

            public Ellipse(string id, int x, int y, int rx, int ry) { ID = id; X = x; Y = y; RX = rx; RY = ry;}

            public override string ToString()
            {
                // convert the Object to a string
                string dispXYR = String.Format("Ellipse ({4}) at ({0},{0}) RX={2} RY={1}.", X, Y, RX, RY, ID);
                // return the convered string
                return dispXYR;
            }
            public override string ToSVGElement()
            {
                // convert the object to an SVG element descriptor string for circle
                string dispSVG = String.Format(@"<ellipse id=""{4}"" cx=""{0}"" cy=""{0}"" rx=""{2}"" ry=""{1}"" stroke=""black"" stroke-width=""5"" fill=""red"" />", X, Y, RX, RY, ID);
                return dispSVG;
            }
        }

        public class Line : Shape
        {
            public int X1 { get; set; }        // Line centre x1-coordinate
            public int Y1 { get; set; }        // Line centre y1-coordinate
            public int X2 { get; set; }        // Line  x2-coordinate
            public int Y2 { get; set; }        // Line  y2-coordinate

            public Line() { ID="L100"; X1 = 100; Y1 = 100; X2 = 100; Y2 = 100;}
            public Line(string id, int x1, int y1, int x2, int y2) { ID = id; X1 = x1; Y1 = y1; X2 = x2; Y2 = y2;}

            public override string ToString()
            {
                // convert the Object to a string
                string dispXYR = String.Format("Line ({4}) at ({0},{1}) X2={2} Y2={3}.", X1, Y1, X2, Y2, ID);
                // return the convered string
                return dispXYR;
            }
            public override string ToSVGElement()
            {
                // convert the object to an SVG element descriptor string for circle
                string dispSVG = String.Format(@"<line id=""{4}"" x1=""{0}"" y1=""{1}"" x2=""{2}"" y2=""{3}"" stroke=""black"" stroke-width=""5"" fill=""orange"" />", X1, Y1, X2, Y2, ID);
                return dispSVG;
            }
        }

        public class PolyLine : Shape
        {
            public string P {get; set;} //String P(points) for the polyline

            public PolyLine() { ID="P100"; P = "60 110 65 120 70 115 75 130 80 125 85 140 90 135 95 150 100 145";}
            public PolyLine(string id, string p) { ID = id; P = p;}

            public override string ToString()
            {
                // convert the Object to a string
                string dispXYR = String.Format("PolyLine ({1}) at ({0}).", P, ID);
                // return the convered string
                return dispXYR;
            }
            public override string ToSVGElement()
            {
                // convert the object to an SVG element descriptor string for circle
                string dispSVG = String.Format(@"<polyline id=""{1}"" points=""{0}"" stroke=""green"" stroke-width=""5"" fill=""none"" />", P, ID);
                return dispSVG; 
            }    
        }
         private class Polygon : Shape
        {
            public string PG {get; set;}    //String PG(points) for the polygon

            public Polygon() { ID="PG100"; PG = "50 160 55 180 70 180 60 190 65 205 50 195 35 205 40 190 30 180 45 180";}
            public Polygon(string id, string pg) { ID = id; PG = pg;}

            public override string ToString()
            {
                // convert the Object to a string
                string dispXYR = String.Format("Polygon ({1}) at ({0})", PG, ID);
                // return the convered string
                return dispXYR;
            }
            public override string ToSVGElement()
            {
                // convert the object to an SVG element descriptor string for circle
                string dispSVG = String.Format(@"<polygon id=""{1}"" points=""{0}"" stroke=""black"" stroke-width=""5"" fill=""blue"" />", PG, ID);
                return dispSVG; 
            }    
        }
         private class Path : Shape
        {
            public string PT {get; set;}    //String Path(points) for the Path

            public Path() { ID="PT100"; PT = "M20,230 Q40,205 50,230 T90,230";}

            public Path(string id, string pt) { ID = id; PT = pt;}

            public override string ToString()
            {
                // convert the Object to a string
                string dispXYR = String.Format("Path ({1}) at ({0})", PT, ID);
                // return the convered string
                return dispXYR;
            }
            public override string ToSVGElement()
            {
                // convert the object to an SVG element descriptor string for circle
                string dispSVG = String.Format(@"<path id=""{1}"" d=""{0}"" stroke=""brown"" stroke-width=""5"" fill=""none"" />", PT, ID);
                return dispSVG; 
            }    
        }
        public class User
        {
            private Stack<Command> undo;
            private Stack<Command> redo;

            public int UndoCount { get => undo.Count; }
            public int RedoCount { get => undo.Count; }
            public User(){
                Reset();
            }
            public void Reset()
            {
                undo = new Stack<Command>();
                redo = new Stack<Command>();
            }

            public void Action(Command command)
            {
                // first update the undo - redo stacks
                undo.Push(command);  // save the command to the undo command
                redo.Clear();        // once a new command is issued, the redo stack clears

                // next determine  action from the Command object type
                // this is going to be AddShapeCommand or DeleteShapeCommand
                Type t = command.GetType();
                if (t.Equals(typeof(AddShapeCommand)))
                {
                    //Console.WriteLine("Command Received: Add new Shape!" + Environment.NewLine);
                    command.Do();
                }
                if (t.Equals(typeof(DeleteShapeCommand)))
                {
                    //Console.WriteLine("Command Received: Delete last Shape!" + Environment.NewLine);
                    command.Do();
                }
            }
            // Undo
            public void Undo()
            {
                Console.WriteLine("\nShape removed from canvas.");
                if (undo.Count > 0)
                {
                    Command c = undo.Pop(); c.Undo(); redo.Push(c);
                }
            }
            // Redo
            public void Redo()
            {
                Console.WriteLine("\nShape added back to canvas.");
                if (redo.Count > 0)
                {
                    Command c = redo.Pop(); c.Do(); undo.Push(c);
                }
            }
        }
        // Abstract Command (Command) class - commands can do something and also undo
        public abstract class Command
        {
            public abstract void Do();     // what happens when we execute (do)
            public abstract void Undo();   // what happens when we unexecute (undo)
        }
        // Add Shape Command - it is a ConcreteCommand Class (extends Command)
        // This adds a Shape (Circle) to the Canvas as the "Do" action
        public class AddShapeCommand : Command
        {
            Shape shape;
            Canvas canvas;

            public AddShapeCommand(Shape s, Canvas c)
            {
                shape = s;
                canvas = c;
            }

            // Adds a shape to the canvas as "Do" action
            public override void Do()
            {
                canvas.Add(shape);
            }
            // Removes a shape from the canvas as "Undo" action
            public override void Undo()
            {
                shape = canvas.Remove();
            }

        }
        // Delete Shape Command - it is a ConcreteCommand Class (extends Command)
        // This deletes a Shape (Circle) from the Canvas as the "Do" action
        public  class DeleteShapeCommand : Command
        {

            Shape shape;
            Canvas canvas;

            public  DeleteShapeCommand(Canvas c)
            {
                canvas = c;
            }
            // Removes a shape from the canvas as "Do" action
            public override void Do()
            {
                shape = canvas.Remove();
            }
            // Restores a shape to the canvas a an "Undo" action
            public override void Undo()
            {
                canvas.Add(shape);
            }
        }

    }
}


