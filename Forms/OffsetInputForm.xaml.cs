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

namespace Beametric.Forms
{
    public partial class OffsetInputForm : Window
    {
        public string OffsetXValue
        {
            get { return OffsetX.Text; }
        }

        public string OffsetYValue
        {
            get { return OffsetY.Text; }
        }

        public string OffsetZValue
        {
            get { return OffsetZ.Text; }
        }
        public OffsetInputForm()
        {
            InitializeComponent();
        }

        private void OffsetAccept(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void OffsetCancelled(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
