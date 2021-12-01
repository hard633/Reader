﻿using System;
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
using System.IO;
using Microsoft.Win32;

namespace reader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///

    public partial class MainWindow : Window
    {
        static bool isDark = false;
        public MainWindow()
        {
            string txtContent;

            InitializeComponent();
            Title = "Reader";
            Uri iconUri = new Uri(@"..\..\..\icons\mainWindowIcon.ico", UriKind.RelativeOrAbsolute);
            Icon = BitmapFrame.Create(iconUri);

            StreamReader reader = new StreamReader(@"..\..\..\books\book1.txt");
            txtContent = reader.ReadToEnd();
            myParagraph.Inlines.Add(txtContent);
        }
        private void DotsClick(object sender, RoutedEventArgs e)
        {
            HideButtons();
        }

        private void FontClick(object sender, RoutedEventArgs e)
        {
            FontDialogWindow newWindow = new FontDialogWindow(myParagraph);
            TextProperties newStyle;

            newWindow.ShowDialog();
            newStyle = new TextProperties(newWindow.exampleText);
            newStyle.SetParagraphStyle(myParagraph);

            HideButtons();

        }

        private void ThemeClick(object sender, RoutedEventArgs e)
        {
            if (isDark == false)
            {
                mainFlowDoc.Foreground = Brushes.White;
                Background = (Brush)new BrushConverter().ConvertFrom("#171717");

                ThemeButton.Foreground = Brushes.White;
                FontButton.Foreground = Brushes.White;
                OpenButton.Foreground = Brushes.White;
                DotsButton.Foreground = Brushes.White;
                isDark = true;
                return;
            }
            else
            {
                mainFlowDoc.Foreground = Brushes.Black;
                Background = Brushes.White;

                ThemeButton.Foreground = Brushes.Black;
                FontButton.Foreground = Brushes.Black;
                OpenButton.Foreground = Brushes.Black;
                DotsButton.Foreground = Brushes.Black;
                isDark = false;
            }



        }

        private void OpenClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog my = new OpenFileDialog();
            my.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            StreamReader reader;
            string text;

            my.ShowDialog();

            if (my.FileName != "")
            {
                reader = new StreamReader(my.FileName);
                text = reader.ReadToEnd();

                myParagraph.Inlines.Clear();
                myParagraph.Inlines.Add(text);

                HideButtons();
            }
        }
        private void HideButtons()
        {
            if (FontButton.Visibility == Visibility.Hidden && ThemeButton.Visibility == Visibility.Hidden)
            {
                FontButton.Visibility = 0;
                ThemeButton.Visibility = 0;
                OpenButton.Visibility = 0;
            }
            else
            {
                FontButton.Visibility = Visibility.Hidden; ThemeButton.Visibility = Visibility.Hidden; OpenButton.Visibility = Visibility.Hidden;
            }
        }

        private void MenuButtonHoverEnter(object sender, MouseEventArgs e)
        {
            foreach (object child in (sender as StackPanel).Children)
            {
                if (child is Label)
                {
                    (child as Label).FontSize += 5;
                }
                else if (child is Image)
                {
                    (child as Image).Height -= 15;
                }
            }
        }

        private void MenuButtonHoverLeave(object sender, MouseEventArgs e)
        {
            foreach (object child in (sender as StackPanel).Children)
            {
                if (child is Label)
                {
                    (child as Label).FontSize -= 5;
                }
                else if (child is Image)
                {
                    (child as Image).Height += 15;
                }
            }
        }
    }
}
