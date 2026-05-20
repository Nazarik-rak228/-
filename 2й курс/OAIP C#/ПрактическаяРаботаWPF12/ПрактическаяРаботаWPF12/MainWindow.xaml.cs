using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace ПрактическаяРаботаWPF12
{
    public partial class MainWindow : Window
    {
        private FrameworkElement selectedShape = null;


        public MainWindow()
        {
            InitializeComponent();

        }

        private void Shape_Click(object sender, MouseButtonEventArgs e)
        {
            selectedShape = (FrameworkElement)sender;
            this.Title = selectedShape.Name;
        }

        private void Color_Left(object sender, MouseButtonEventArgs e)
        {
            string name = selectedShape.Name;
            if (selectedShape == null) return;

            Button btn = (Button)sender;
            Brush color = btn.Background;

            if (selectedShape is Rectangle rect)
                if (rect.Stroke == color)
                {
                    Sas.Text = "Нельзя ставить один цвет!";
                }
                else
                {
                    rect.Fill = color;
                    Sas.Text = name + " " + rect.Fill;
                }
            else if (selectedShape is Ellipse ellipse)
                if(ellipse.Stroke == color)
                {
                    Sas.Text = "Нельзя ставить один цвет!";
                }
                else
                {
                    ellipse.Fill = color;
                    Sas.Text = name +" "+ ellipse.Fill;
                }

            else if (selectedShape is Border border)
                if(border.BorderBrush == color )
                {
                    Sas.Text = "Нельзя ставить один цвет!";
                }
                else
                {
                    border.Background = color;
                    Sas.Text = name + " " + border.Background;
                }

            

        }

        private void Color_Right(object sender, MouseButtonEventArgs e)
        {
            if (selectedShape == null) return;

            Button btn = (Button)sender;
            Brush color = btn.Background;
            string name = selectedShape.Name;


            if (selectedShape is Rectangle rect)
                if (rect.Fill == color)
                {
                    Sas.Text = "Нельзя ставить один цвет!";
                }
                else
                {
                    rect.Stroke = color;
                    Sas.Text = name + " " + rect.Stroke;
                }

            else if (selectedShape is Ellipse ellipse)
                if (ellipse.Fill == color)
                {
                    Sas.Text = "Нельзя ставить один цвет!";
                }
                else 
                { 
                    ellipse.Stroke = color;
                    Sas.Text = name + " " + ellipse.Stroke;
                }
            else if (selectedShape is Border border)
                if (border.Background == color)
                {
                    Sas.Text = "Нельзя ставить один цвет!";
                }
                else { border.BorderBrush = color;
                    Sas.Text = name + " " + border.BorderBrush; }
            
        }
   
      


       
    }
}