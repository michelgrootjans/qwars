﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QWars.Win
{
    public partial class CreateTaskView : Form
    {
        public CreateTaskView()
        {
            InitializeComponent();
        }

        public object PlayerId { get; set; }
    }
}
