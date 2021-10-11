using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sample3
{
    public class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Application.EnableVisualStyles();
            Application.DoEvents();
        }

        private void save_mathml (object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.InitialDirectory = "c:\\" ;
            dialog.Filter = "Mathml files (*.mathml)|*.mathml|All files (*.*)|*.*" ;
            dialog.FilterIndex = 1 ;
            dialog.RestoreDirectory = true ;
            
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                mathMLControl1.pub_Save (dialog.FileName); 
            }
        }

        private void save_mathml_pure (object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.InitialDirectory = "c:\\" ;
            dialog.Filter = "Mathml files (*.mathml)|*.mathml|All files (*.*)|*.*" ;
            dialog.FilterIndex = 1 ;
            dialog.RestoreDirectory = true ;
            
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                mathMLControl1.pub_SavePure (dialog.FileName); 
            }
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            mathMLControl1.pub_LoadXML("<math xmlns=\"http://www.w3.org/1998/Math/MathML\"><mi>Y</mi><mo>&equals;</mo><msqrt><mrow><mn>1</mn><mo>&plus;</mo><msup><mi>X</mi><mrow><mn>2</mn></mrow></msup></mrow></msqrt><mo>&plus;</mo></math>");
        }

        [STAThread]
        static void Main()
        {
            Application.Run(new Form2());
        }

        private System.Windows.Forms.TextBox textBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private SplitContainer mainContainer;
        private Panel topPanel;
        private SplitContainer contentContainer;
        private PropertyGrid propertyGrid;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_ = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.mainContainer = new System.Windows.Forms.SplitContainer();
            this.contentContainer = new System.Windows.Forms.SplitContainer();
            this.topPanel = new System.Windows.Forms.Panel();
            this.mathMLControl1 = new Genetibase.MathX.NuGenEQML();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).BeginInit();
            this.mainContainer.Panel1.SuspendLayout();
            this.mainContainer.Panel2.SuspendLayout();
            this.mainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contentContainer)).BeginInit();
            this.contentContainer.Panel1.SuspendLayout();
            this.contentContainer.Panel2.SuspendLayout();
            this.contentContainer.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_
            // 
            this.button_.Location = new System.Drawing.Point(3, 3);
            this.button_.Name = "button_";
            this.button_.Size = new System.Drawing.Size(76, 21);
            this.button_.TabIndex = 1;
            this.button_.Text = "Save";
            this.button_.Click += new System.EventHandler(this.save_mathml);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(610, 272);
            this.textBox1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(85, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 21);
            this.button1.TabIndex = 1;
            this.button1.Text = "Export";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(165, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 21);
            this.button2.TabIndex = 1;
            this.button2.Text = "Load";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(247, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 21);
            this.button3.TabIndex = 1;
            this.button3.Text = "SavePure";
            this.button3.Click += new System.EventHandler(this.save_mathml_pure);
            // 
            // mainContainer
            // 
            this.mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContainer.Location = new System.Drawing.Point(0, 28);
            this.mainContainer.Name = "mainContainer";
            // 
            // mainContainer.Panel1
            // 
            this.mainContainer.Panel1.Controls.Add(this.contentContainer);
            // 
            // mainContainer.Panel2
            // 
            this.mainContainer.Panel2.Controls.Add(this.propertyGrid);
            this.mainContainer.Size = new System.Drawing.Size(894, 605);
            this.mainContainer.SplitterDistance = 610;
            this.mainContainer.TabIndex = 3;
            // 
            // contentContainer
            // 
            this.contentContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentContainer.Location = new System.Drawing.Point(0, 0);
            this.contentContainer.Name = "contentContainer";
            this.contentContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // contentContainer.Panel1
            // 
            this.contentContainer.Panel1.Controls.Add(this.mathMLControl1);
            // 
            // contentContainer.Panel2
            // 
            this.contentContainer.Panel2.Controls.Add(this.textBox1);
            this.contentContainer.Size = new System.Drawing.Size(610, 605);
            this.contentContainer.SplitterDistance = 329;
            this.contentContainer.TabIndex = 0;
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.button_);
            this.topPanel.Controls.Add(this.button1);
            this.topPanel.Controls.Add(this.button2);
            this.topPanel.Controls.Add(this.button3);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(894, 28);
            this.topPanel.TabIndex = 4;
            // 
            // mathMLControl1
            // 
            this.mathMLControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mathMLControl1.Location = new System.Drawing.Point(0, 0);
            this.mathMLControl1.MC_FontSize = 14F;
            this.mathMLControl1.Name = "mathMLControl1";
            this.mathMLControl1.Size = new System.Drawing.Size(610, 329);
            this.mathMLControl1.TabIndex = 0;
            this.mathMLControl1.Event_OnSelectionChanged += new System.EventHandler(this.mathMLControl1_Event_OnSelectionChanged);
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.SelectedObject = this.mathMLControl1;
            this.propertyGrid.Size = new System.Drawing.Size(280, 605);
            this.propertyGrid.TabIndex = 0;
            // 
            // Form2
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(894, 633);
            this.Controls.Add(this.mainContainer);
            this.Controls.Add(this.topPanel);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.mainContainer.Panel1.ResumeLayout(false);
            this.mainContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).EndInit();
            this.mainContainer.ResumeLayout(false);
            this.contentContainer.Panel1.ResumeLayout(false);
            this.contentContainer.Panel2.ResumeLayout(false);
            this.contentContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contentContainer)).EndInit();
            this.contentContainer.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private Genetibase.MathX.NuGenEQML mathMLControl1;
        private Button button_;

        private void mathMLControl1_Event_OnSelectionChanged(object sender, System.EventArgs e)
        {
            textBox1.Text = mathMLControl1.pub_GetXML(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mathMLControl1.pub_Export();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.InitialDirectory = "c:\\" ;
            dialog.Filter = "Mathml files (*.mathml)|*.mathml|All files (*.*)|*.*" ;
            dialog.FilterIndex = 1 ;
            dialog.RestoreDirectory = true ;
            
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                mathMLControl1 .LoadFromFile(dialog.FileName);
            }
        } 
    }
}