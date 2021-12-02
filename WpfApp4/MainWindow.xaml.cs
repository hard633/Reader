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
using System.Windows.Controls;

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
            if (menuGrid.Visibility == Visibility.Collapsed) { menuGrid.Visibility = Visibility.Visible; }
            else menuGrid.Visibility = Visibility.Collapsed;

        }

        private void FontClick(object sender, RoutedEventArgs e)
        {
            FontDialogWindow newWindow = new FontDialogWindow(myParagraph);
            TextProperties newStyle;

            newWindow.ShowDialog();
            newStyle = new TextProperties(newWindow.exampleText);
            newStyle.SetParagraphStyle(myParagraph);


        }

        private void ThemeClick(object sender, RoutedEventArgs e)
        {
            if (isDark == false)
            {
                mainFlowDoc.Foreground = Brushes.White;
                Background = (Brush)new BrushConverter().ConvertFrom("#171717");
                fontImage.ImageSource = new BitmapImage(new Uri(@"..\..\..\mainMenuIcons\upperMenuIcons\fontCustomizationIconDark.png", UriKind.RelativeOrAbsolute));
                isDark = true;
                return;
            }
            else
            {
                mainFlowDoc.Foreground = Brushes.Black;
                Background = Brushes.White;

                DotsButton.Foreground = Brushes.Black;
                isDark = false;
            }



        }

        private void MenuButtonHoverEnter(object sender, MouseEventArgs e)
        {
            foreach (object child in (sender as StackPanel).Children)
            {
                if (child is Label)
                {
                    (child as Label).FontSize += 8;
                }
                else if (child is Image)
                {
                    (child as Image).Height -= 20;
                }
            }
        }

        private void MenuButtonHoverLeave(object sender, MouseEventArgs e)
        {
            foreach (object child in (sender as StackPanel).Children)
            {
                if (child is Label)
                {
                    (child as Label).FontSize -= 8;
                }
                else if (child is Image)
                {
                    (child as Image).Height += 20;
                }
            }
        }

        private void FontCustomizationHoverEnter(object sender, MouseEventArgs e)
        {
            (sender as Button).BorderBrush = Brushes.Black;
            (sender as Button).BorderThickness = new Thickness(1);
        }
    }
}
