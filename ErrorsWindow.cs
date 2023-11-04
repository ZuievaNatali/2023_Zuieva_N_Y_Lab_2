using Gtk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class ErrorsWindow : TextView
    {
        private Window window;
        public ErrorsWindow(Window window) : base()
        {
            this.Buffer = new TextBuffer(new TextTagTable());
            this.HexpandSet = false;
            this.VexpandSet = false;
            this.window = window;
        }

        public void Report(string message)
        {
            TextIter iter = this.Buffer.EndIter;
            this.Buffer.Insert(ref iter, message + "\n");
            Console.WriteLine(message);
            MessageDialog errorDialog = new MessageDialog(
                this.window,
                DialogFlags.Modal,
                MessageType.Error,
                ButtonsType.Ok,
                message
            );

            errorDialog.Title = "Сталася Помилка";
            errorDialog.Run();
            errorDialog.Destroy();
        }
    }
}
