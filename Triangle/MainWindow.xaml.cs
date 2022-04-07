using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using static System.Convert;
using static System.Math;

namespace Triangle
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            Figure.Children.Clear();
            double ab = 0, bc = 0, ca = 0;
            double a = 0, b = 0, c = 0;
            double width = Figure.ActualWidth - 400;
            Line abLine = new Line();
            Line bcLine = new Line();
            Line caLine = new Line();
            abLine.Stroke = (Brush)TryFindResource("ThrushEggSolidColor");
            abLine.StrokeThickness = 3;
            bcLine.Stroke = (Brush)TryFindResource("ThrushEggSolidColor");
            bcLine.StrokeThickness = 3;
            caLine.Stroke = (Brush)TryFindResource("ThrushEggSolidColor");
            caLine.StrokeThickness = 3;
            try
            {
                ab = ToDouble(AB.Text);
                bc = ToDouble(BC.Text);
                ca = ToDouble(CA.Text);
                a = Acos((Pow(ab, 2) + Pow(ca, 2) - Pow(bc, 2)) / (2 * ab * ca)) * 180 / PI;
                b = Acos((Pow(ab, 2) + Pow(bc, 2) - Pow(ca, 2)) / (2 * ab * bc)) * 180 / PI;
                c = Acos((Pow(bc, 2) + Pow(ca, 2) - Pow(ab, 2)) / (2 * bc * ca)) * 180 / PI;
            }
            catch (FormatException) { }
            if (ab != 0 & bc != 0 & ca != 0 & ab + bc > ca & bc + ca > ab & ca + ab > bc)
            {
                try
                {
                    A.Text = Round(a, 3).ToString();
                    B.Text = Round(b, 3).ToString();
                    C.Text = Round(c, 3).ToString();
                }
                catch (DivideByZeroException) { }
                if (ab == bc & bc == ca)
                {
                    Side.Text = "Равносторонний";
                    SideCause.Text = "AB = BC = CA";
                }
                else if (ab == bc & bc != ca)
                {
                    Side.Text = "Равнобедренный";
                    SideCause.Text = "AB = BC и BC ≠ CA";
                }
                else if (bc == ca & ab != bc)
                {
                    Side.Text = "Равнобедренный";
                    SideCause.Text = "BC = CA и AB ≠ BC";
                }
                else if (ab == ca & bc != ca)
                {
                    Side.Text = "Равнобедренный";
                    SideCause.Text = "AB = CA и AB ≠ BC";
                }
                else
                {
                    Side.Text = "Разносторонний";
                    SideCause.Text = "AB ≠ BC ≠ CA";
                }
                if (ToDouble(A.Text) < 90 & ToDouble(B.Text) < 90 & ToDouble(C.Text) < 90)
                {
                    Angle.Text = "Остроугольный";
                    AngleCause.Text = "∠A < 90° и ∠B < 90° и ∠C < 90°";
                }
                else if (ToDouble(A.Text) == 90)
                {
                    Angle.Text = "Прямоугольный";
                    AngleCause.Text = "∠A = 90°";
                }
                else if (ToDouble(B.Text) == 90)
                {
                    Angle.Text = "Прямоугольный";
                    AngleCause.Text = "∠B = 90°";
                }
                else if (ToDouble(C.Text) == 90)
                {
                    Angle.Text = "Прямоугольный";
                    AngleCause.Text = "∠C = 90°";
                }
                else if (ToDouble(A.Text) > 90)
                {
                    Angle.Text = "Тупоугольный";
                    AngleCause.Text = "∠A > 90°";
                }
                else if (ToDouble(B.Text) > 90)
                {
                    Angle.Text = "Тупоугольный";
                    AngleCause.Text = "∠B > 90°";
                }
                else if (ToDouble(C.Text) > 90)
                {
                    Angle.Text = "Тупоугольный";
                    AngleCause.Text = "∠C > 90°";
                }
                try
                {
                    double step = 0;
                    double X1 = 0, X2 = 0, X3 = 0, Y1 = 0, Y2 = 0, Y3 = 0;
                    if (ab > bc & ab > ca)
                    {
                        step = width / ab;
                        ab *= step;
                        bc *= step;
                        X1 = 200;
                        Y1 = 200;
                        X2 = X1 + ab;
                        Y2 = Y1;
                        Y3 = Y1 + ab * (Sin(a * PI / 180) * Sin(b * PI / 180) / Sin((a + b) * PI / 180));
                        X3 = X2 - Sqrt(Pow(bc, 2) - Pow(Y3 - Y1, 2));
                    }
                    else if (bc > ab & bc > ca)
                    {
                        step = width / bc;
                        bc *= step;
                        ca *= step;
                        X1 = 200;
                        Y1 = 200;
                        X2 = X1 + bc;
                        Y2 = Y1;
                        Y3 = Y1 + bc * (Sin(b * PI / 180) * Sin(c * PI / 180) / Sin((b + c) * PI / 180));
                        X3 = X2 - Sqrt(Pow(ca, 2) - Pow(Y3 - Y1, 2));
                    }
                    else if (ca > ab & ca > bc)
                    {
                        step = width / ca;
                        ca *= step;
                        ab *= step;
                        X1 = 200;
                        Y1 = 200;
                        X2 = X1 + ca;
                        Y2 = Y1;
                        Y3 = Y1 + ca * (Sin(c * PI / 180) * Sin(a * PI / 180) / Sin((c + a) * PI / 180));
                        X3 = X2 - Sqrt(Pow(ab, 2) - Pow(Y3 - Y1, 2));
                    }
                    else
                    {
                        step = width / ab;
                        ab *= step;
                        bc *= step;
                        X1 = 200;
                        Y1 = 200;
                        X2 = X1 + ab;
                        Y2 = Y1;
                        Y3 = Y1 + ab * (Sin(a * PI / 180) * Sin(b * PI / 180) / Sin((a + b) * PI / 180));
                        X3 = X2 - Sqrt(Pow(bc, 2) - Pow(Y3 - Y1, 2));
                    }
                    abLine.X1 = X1;
                    abLine.Y1 = Y1;
                    abLine.X2 = X2;
                    abLine.Y2 = Y2;
                    bcLine.X1 = X2;
                    bcLine.Y1 = Y2;
                    bcLine.Y2 = Y3;
                    bcLine.X2 = X3;
                    caLine.X1 = X1;
                    caLine.Y1 = Y1;
                    caLine.X2 = X3;
                    caLine.Y2 = Y3;
                    Figure.Children.Add(abLine);
                    Figure.Children.Add(bcLine);
                    Figure.Children.Add(caLine);
                }
                catch (ArgumentException) { }
            }
            else
            {
                A.Text = "";
                B.Text = "";
                C.Text = "";
                Side.Text = "";
                SideCause.Text = "";
                Angle.Text = "";
                AngleCause.Text = "";
                Figure.Children.Clear();
            }
        }
    }
}
