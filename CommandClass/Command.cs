using SeleniumAPI;
using System;
using System.Globalization;

namespace CommandClass
{
    public class Command
    {
        private string _filename;
        private string _step;
        private string _type;
        private string _id;
        private string _message = "";
        private double _number;
        private static Browser _browser;

        public string Step
        {
            get
            {
                return _step;
            }

            set
            {
                _step = value;
            }
        }

        public string Filename
        {
            get
            {
                return _filename;
            }

            set
            {
                _filename = value;
            }
        }

        public string Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }

        public string Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Message
        {
            get
            {
                return _message;
            }

            set
            {
                _message = value;
            }
        }

        public double Number
        {
            get
            {
                return _number;
            }

            set
            {
                _number = value;
            }
        }

        public static Browser Browser
        {
            get
            {
                return _browser;
            }

            set
            {
                _browser = value;
            }
        }


        /// <summary>
        /// The constructor for text type commands.
        /// </summary>
        /// <param name="f"></param>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <param name="i"></param>
        /// <param name="m"></param>
        /// <param name="n"></param>
        public Command(string f, string s, string t, string i, string m, double n)
        {
            Filename = f;
            Step = s;
            Type = t;
            Id = i;
            Message = m;
            Number = n;


        }

        /// <summary>
        /// Constructor that makes a browser object, necessary for functioning.  Probably should go somewhere else.
        /// </summary>
        public Command()
        {
        }

        /// <summary>
        /// Prints each of the fields in the command object.  Useful for debugging.
        /// </summary>
        public void PrintContents()
        {
            Console.Write(Filename);
            Console.Write(Step);
            Console.Write(Type);
            Console.Write(Id);
            Console.Write(Message);
        }

        /// <summary>
        /// Makes browser calls according to the type of command. When the action is successful it returns true, else it returns false.
        /// </summary>
        public bool Execute(Command step)
        {

            bool testStatus = true;

            ///System.Threading.Thread.Sleep(3000);
            Console.WriteLine("Executing");

            if (step.Type == "Button")
            {
                if (Browser.ClickButton(Id) == false)
                { testStatus = false; }
            }
            else if (Type == "Xpath")
            {
                if (Browser.ClickButtonWithXPath(Id) == false)
                { testStatus = false; }
            }
            else if (Type == "Text")
            {
                if (Browser.InputTextToBox(Id, Message) == false)
                { testStatus = false; }
            }
            else if (Type == "Wait")
            {
                System.Threading.Thread.Sleep(Convert.ToInt32((step.Number)));
            }
            else if (Type == "Assert")
            {
                testStatus = Browser.HasText(Id);
            }
            else if (Type == "Navigate")
            {
                Browser = new Browser(step.Id, step.Message);
            }
            else if (Type == "Number")
            {
                if (Browser.InputTextToBox(Id, Number.ToString(CultureInfo.InvariantCulture)) == false)
                { testStatus = false; }
            }




            return testStatus;
        }

        /// <summary>
        /// Refreshes the browser, if it is instantiated.
        /// </summary>
        public void Reset()
        {
            Browser?.Refresh();
        }
    }



}


