using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SP_hw_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Thread thread = new Thread(ReadFile);
            thread.Start();
          
        }

        public string path = "result.txt"; 
        
        public ConcurrentBag<string> pointList = new ConcurrentBag<string>(); 
        Point position = new Point();

        //List<string> listik = new List<string>();

       

        private void Window__MouseMove(object sender, MouseEventArgs e)
        {          
            position = Mouse.GetPosition(this);
            pointList.Add($"X: {(int)position.X} Y: {(int)position.Y}  {DateTime.Now.ToString("HH:mm:ss:ff")}\n");
            tb.Text = "X: " + (int)position.X + " " + "Y: " + (int)position.Y + " " + DateTime.Now.ToString("HH:mm:ss:ff");
            
            //listik.Add($"X: {(int)position.X} Y: {(int)position.Y}  {DateTime.Now.ToString("HH:mm:ss:ff")}\n");            
        }

        private void ReadFile()
        {
            if (!File.Exists(path))
            {
                File.Create(path);                
            }

            File.WriteAllLines(path, pointList/*pointList.ToString()*/);

            //foreach (var item in listik)
            //{
            //    File.WriteAllLines(path, listik);
            //}

           /* using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(listik.Count);
                
            }*/
        }

        
    }
}
