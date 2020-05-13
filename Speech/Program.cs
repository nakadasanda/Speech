using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Threading;

namespace Speech
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*  Application.EnableVisualStyles();
              Application.SetCompatibleTextRenderingDefault(false);
              Application.Run(new Form1());
            */

            SpeechRecognitionEngine engine = new SpeechRecognitionEngine();
            engine.LoadGrammar(new DictationGrammar());
            engine.SetInputToDefaultAudioDevice();
            engine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Program_SpeechRecognized);
            while(true)
            {
                engine.Recognize();
            }
        }

        static void Program_SpeechRecognized(object sender,SpeechRecognizedEventArgs eventArgs)
        {
            Console.WriteLine(eventArgs.Result.Text);
        }
    }
}
