namespace Facade
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Attrs;
    using MathTable;
    using Nodes;

    internal class MatrixPropertiesDialog : Form
    {
        internal class MathTableButton : Button
        {
            public int row;
            public int col;
        }

        public MatrixPropertiesDialog()
        {
            numRows = 6;
            numCols = 6;
            buttonsOrigin = new Point(40, 0xd8);
            container = null;
            success_ = false;
            bWidth = 0x18;
            bHeight = 0x18;
            canvasWidth = 10;
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && container != null)
            {
                container.Dispose();
            }
            base.Dispose(disposing);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Return:
                    Success = true;
                    Close();
                    break;
                case Keys.Escape:
                    Success = false;
                    Close();
                    break;
                default:
                    return base.ProcessDialogKey(keyData);
            }
            return true;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(MatrixPropertiesDialog));
            this.tableAlignmentGroup = new System.Windows.Forms.GroupBox();
            this.tablealignAxis = new System.Windows.Forms.RadioButton();
            this.tablealignbaseline = new System.Windows.Forms.RadioButton();
            this.tablealigncenter = new System.Windows.Forms.RadioButton();
            this.tablealignbottom = new System.Windows.Forms.RadioButton();
            this.tablealigntop_ = new System.Windows.Forms.RadioButton();
            this.rowAlignmentGroup = new System.Windows.Forms.GroupBox();
            this.rowalignaxis = new System.Windows.Forms.RadioButton();
            this.rowalignbaseline = new System.Windows.Forms.RadioButton();
            this.rowaligncenter = new System.Windows.Forms.RadioButton();
            this.rowalignbottom = new System.Windows.Forms.RadioButton();
            this.rowaligntop = new System.Windows.Forms.RadioButton();
            this.columnAlignmentGroup = new System.Windows.Forms.GroupBox();
            this.colaligncenter = new System.Windows.Forms.RadioButton();
            this.colalignright = new System.Windows.Forms.RadioButton();
            this.colalignleft = new System.Windows.Forms.RadioButton();
            this.rowLinesGroup = new System.Windows.Forms.GroupBox();
            this.tablelinestylesolid = new System.Windows.Forms.RadioButton();
            this.tablelinestyledashed = new System.Windows.Forms.RadioButton();
            this.tablelinestylenone = new System.Windows.Forms.RadioButton();
            this.rowspacing = new System.Windows.Forms.TextBox();
            this.columnLinesGroup = new System.Windows.Forms.GroupBox();
            this.collinestylesolid = new System.Windows.Forms.RadioButton();
            this.collinestyledashed = new System.Windows.Forms.RadioButton();
            this.collinestylenone = new System.Windows.Forms.RadioButton();
            this.colSpacing_ = new System.Windows.Forms.TextBox();
            this.tableFrameGroup = new System.Windows.Forms.GroupBox();
            this.tablelinesolid = new System.Windows.Forms.RadioButton();
            this.tablelinedashed = new System.Windows.Forms.RadioButton();
            this.tablelinenone = new System.Windows.Forms.RadioButton();
            this.tablespacing = new System.Windows.Forms.TextBox();
            this.equalCols = new System.Windows.Forms.CheckBox();
            this.equalRows = new System.Windows.Forms.CheckBox();
            this.cancelButton = new Glass.GlassButton();
            this.okButton = new Glass.GlassButton();
            this.tabcontrol = new System.Windows.Forms.TabControl();
            this.tableTab = new System.Windows.Forms.TabPage();
            this.group7 = new System.Windows.Forms.GroupBox();
            this.rowstab = new System.Windows.Forms.TabPage();
            this.group8 = new System.Windows.Forms.GroupBox();
            this.group9 = new System.Windows.Forms.GroupBox();
            this.colsTab = new System.Windows.Forms.TabPage();
            this.group10 = new System.Windows.Forms.GroupBox();
            this.group11 = new System.Windows.Forms.GroupBox();
            this.cellsTab = new System.Windows.Forms.TabPage();
            this.cellRowAlignmentGroup = new System.Windows.Forms.GroupBox();
            this.rowalignaxis_ = new System.Windows.Forms.RadioButton();
            this.rowalignbaseline_ = new System.Windows.Forms.RadioButton();
            this.rowaligncenter_ = new System.Windows.Forms.RadioButton();
            this.rowalignbottom_ = new System.Windows.Forms.RadioButton();
            this.rowaligntop_ = new System.Windows.Forms.RadioButton();
            this.cellColumnAlignmentGroup = new System.Windows.Forms.GroupBox();
            this.raligncenter = new System.Windows.Forms.RadioButton();
            this.rowalignright = new System.Windows.Forms.RadioButton();
            this.rowalignleft = new System.Windows.Forms.RadioButton();
            this.selAllbutton = new Glass.GlassButton();
            this.tableAlignmentGroup.SuspendLayout();
            this.rowAlignmentGroup.SuspendLayout();
            this.columnAlignmentGroup.SuspendLayout();
            this.rowLinesGroup.SuspendLayout();
            this.columnLinesGroup.SuspendLayout();
            this.tableFrameGroup.SuspendLayout();
            this.tabcontrol.SuspendLayout();
            this.tableTab.SuspendLayout();
            this.group7.SuspendLayout();
            this.rowstab.SuspendLayout();
            this.group8.SuspendLayout();
            this.group9.SuspendLayout();
            this.colsTab.SuspendLayout();
            this.group10.SuspendLayout();
            this.group11.SuspendLayout();
            this.cellsTab.SuspendLayout();
            this.cellRowAlignmentGroup.SuspendLayout();
            this.cellColumnAlignmentGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableAlignmentGroup
            // 
            this.tableAlignmentGroup.Controls.Add(this.tablealignAxis);
            this.tableAlignmentGroup.Controls.Add(this.tablealignbaseline);
            this.tableAlignmentGroup.Controls.Add(this.tablealigncenter);
            this.tableAlignmentGroup.Controls.Add(this.tablealignbottom);
            this.tableAlignmentGroup.Controls.Add(this.tablealigntop_);
            this.tableAlignmentGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resources.ApplyResources(this.tableAlignmentGroup, "tableAlignmentGroup");
            this.tableAlignmentGroup.Name = "tableAlignmentGroup";
            this.tableAlignmentGroup.TabStop = false;
            // 
            // tablealignAxis
            // 
            this.tablealignAxis.Checked = true;
            resources.ApplyResources(this.tablealignAxis, "tablealignAxis");
            this.tablealignAxis.Name = "tablealignAxis";
            this.tablealignAxis.TabStop = true;
            this.tablealignAxis.CheckedChanged += this.taAxisClick;
            // 
            // tablealignbaseline
            // 
            resources.ApplyResources(this.tablealignbaseline, "tablealignbaseline");
            this.tablealignbaseline.Name = "tablealignbaseline";
            this.tablealignbaseline.CheckedChanged += this.taBaselineClick;
            // 
            // tablealigncenter
            // 
            resources.ApplyResources(this.tablealigncenter, "tablealigncenter");
            this.tablealigncenter.Name = "tablealigncenter";
            this.tablealigncenter.CheckedChanged += this.taCenterClick;
            // 
            // tablealignbottom
            // 
            resources.ApplyResources(this.tablealignbottom, "tablealignbottom");
            this.tablealignbottom.Name = "tablealignbottom";
            this.tablealignbottom.CheckedChanged += this.taBottomClick;
            // 
            // tablealigntop_
            // 
            resources.ApplyResources(this.tablealigntop_, "tablealigntop_");
            this.tablealigntop_.Name = "tablealigntop_";
            this.tablealigntop_.CheckedChanged += this.tatopClick;
            // 
            // rowAlignmentGroup
            // 
            this.rowAlignmentGroup.Controls.Add(this.rowalignaxis);
            this.rowAlignmentGroup.Controls.Add(this.rowalignbaseline);
            this.rowAlignmentGroup.Controls.Add(this.rowaligncenter);
            this.rowAlignmentGroup.Controls.Add(this.rowalignbottom);
            this.rowAlignmentGroup.Controls.Add(this.rowaligntop);
            this.rowAlignmentGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resources.ApplyResources(this.rowAlignmentGroup, "rowAlignmentGroup");
            this.rowAlignmentGroup.Name = "rowAlignmentGroup";
            this.rowAlignmentGroup.TabStop = false;
            // 
            // rowalignaxis
            // 
            resources.ApplyResources(this.rowalignaxis, "rowalignaxis");
            this.rowalignaxis.Name = "rowalignaxis";
            this.rowalignaxis.CheckedChanged += this.raaxisClick;
            // 
            // rowalignbaseline
            // 
            this.rowalignbaseline.Checked = true;
            resources.ApplyResources(this.rowalignbaseline, "rowalignbaseline");
            this.rowalignbaseline.Name = "rowalignbaseline";
            this.rowalignbaseline.TabStop = true;
            this.rowalignbaseline.CheckedChanged += this.raBaselineClick;
            // 
            // rowaligncenter
            // 
            resources.ApplyResources(this.rowaligncenter, "rowaligncenter");
            this.rowaligncenter.Name = "rowaligncenter";
            this.rowaligncenter.CheckedChanged += this.raCenterClick;
            // 
            // rowalignbottom
            // 
            resources.ApplyResources(this.rowalignbottom, "rowalignbottom");
            this.rowalignbottom.Name = "rowalignbottom";
            this.rowalignbottom.CheckedChanged += this.raBottomClick;
            // 
            // rowaligntop
            // 
            resources.ApplyResources(this.rowaligntop, "rowaligntop");
            this.rowaligntop.Name = "rowaligntop";
            this.rowaligntop.CheckedChanged += this.raTopClick;
            // 
            // columnAlignmentGroup
            // 
            this.columnAlignmentGroup.Controls.Add(this.colaligncenter);
            this.columnAlignmentGroup.Controls.Add(this.colalignright);
            this.columnAlignmentGroup.Controls.Add(this.colalignleft);
            this.columnAlignmentGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resources.ApplyResources(this.columnAlignmentGroup, "columnAlignmentGroup");
            this.columnAlignmentGroup.Name = "columnAlignmentGroup";
            this.columnAlignmentGroup.TabStop = false;
            // 
            // colaligncenter
            // 
            this.colaligncenter.Checked = true;
            resources.ApplyResources(this.colaligncenter, "colaligncenter");
            this.colaligncenter.Name = "colaligncenter";
            this.colaligncenter.TabStop = true;
            this.colaligncenter.CheckedChanged += this.caCenterclick;
            // 
            // colalignright
            // 
            resources.ApplyResources(this.colalignright, "colalignright");
            this.colalignright.Name = "colalignright";
            this.colalignright.CheckedChanged += this.caRightClick;
            // 
            // colalignleft
            // 
            resources.ApplyResources(this.colalignleft, "colalignleft");
            this.colalignleft.Name = "colalignleft";
            this.colalignleft.CheckedChanged += this.caLeftClick;
            // 
            // rowLinesGroup
            // 
            this.rowLinesGroup.Controls.Add(this.tablelinestylesolid);
            this.rowLinesGroup.Controls.Add(this.tablelinestyledashed);
            this.rowLinesGroup.Controls.Add(this.tablelinestylenone);
            this.rowLinesGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resources.ApplyResources(this.rowLinesGroup, "rowLinesGroup");
            this.rowLinesGroup.Name = "rowLinesGroup";
            this.rowLinesGroup.TabStop = false;
            // 
            // tablelinestylesolid
            // 
            resources.ApplyResources(this.tablelinestylesolid, "tablelinestylesolid");
            this.tablelinestylesolid.Name = "tablelinestylesolid";
            this.tablelinestylesolid.CheckedChanged += this.tlsolidClick;
            // 
            // tablelinestyledashed
            // 
            resources.ApplyResources(this.tablelinestyledashed, "tablelinestyledashed");
            this.tablelinestyledashed.Name = "tablelinestyledashed";
            this.tablelinestyledashed.CheckedChanged += this.tlDashedClick;
            // 
            // tablelinestylenone
            // 
            this.tablelinestylenone.Checked = true;
            resources.ApplyResources(this.tablelinestylenone, "tablelinestylenone");
            this.tablelinestylenone.Name = "tablelinestylenone";
            this.tablelinestylenone.TabStop = true;
            this.tablelinestylenone.CheckedChanged += this.tlNoneClick;
            // 
            // rowspacing
            // 
            this.rowspacing.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.rowspacing, "rowspacing");
            this.rowspacing.Name = "rowspacing";
            this.rowspacing.TextChanged += this.rspacingchanged;
            // 
            // columnLinesGroup
            // 
            this.columnLinesGroup.Controls.Add(this.collinestylesolid);
            this.columnLinesGroup.Controls.Add(this.collinestyledashed);
            this.columnLinesGroup.Controls.Add(this.collinestylenone);
            this.columnLinesGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resources.ApplyResources(this.columnLinesGroup, "columnLinesGroup");
            this.columnLinesGroup.Name = "columnLinesGroup";
            this.columnLinesGroup.TabStop = false;
            // 
            // collinestylesolid
            // 
            resources.ApplyResources(this.collinestylesolid, "collinestylesolid");
            this.collinestylesolid.Name = "collinestylesolid";
            this.collinestylesolid.CheckedChanged += this.clSolidClick;
            // 
            // collinestyledashed
            // 
            resources.ApplyResources(this.collinestyledashed, "collinestyledashed");
            this.collinestyledashed.Name = "collinestyledashed";
            this.collinestyledashed.CheckedChanged += this.clDashedClick;
            // 
            // collinestylenone
            // 
            this.collinestylenone.Checked = true;
            resources.ApplyResources(this.collinestylenone, "collinestylenone");
            this.collinestylenone.Name = "collinestylenone";
            this.collinestylenone.TabStop = true;
            this.collinestylenone.CheckedChanged += this.clNoneClick;
            // 
            // colSpacing_
            // 
            this.colSpacing_.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.colSpacing_, "colSpacing_");
            this.colSpacing_.Name = "colSpacing_";
            this.colSpacing_.TextChanged += this.cspacingChanged;
            // 
            // tableFrameGroup
            // 
            this.tableFrameGroup.Controls.Add(this.tablelinesolid);
            this.tableFrameGroup.Controls.Add(this.tablelinedashed);
            this.tableFrameGroup.Controls.Add(this.tablelinenone);
            this.tableFrameGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resources.ApplyResources(this.tableFrameGroup, "tableFrameGroup");
            this.tableFrameGroup.Name = "tableFrameGroup";
            this.tableFrameGroup.TabStop = false;
            // 
            // tablelinesolid
            // 
            resources.ApplyResources(this.tablelinesolid, "tablelinesolid");
            this.tablelinesolid.Name = "tablelinesolid";
            this.tablelinesolid.CheckedChanged += this.tlSolidChecked;
            // 
            // tablelinedashed
            // 
            resources.ApplyResources(this.tablelinedashed, "tablelinedashed");
            this.tablelinedashed.Name = "tablelinedashed";
            this.tablelinedashed.CheckedChanged += this.tlDashedChecked;
            // 
            // tablelinenone
            // 
            this.tablelinenone.Checked = true;
            resources.ApplyResources(this.tablelinenone, "tablelinenone");
            this.tablelinenone.Name = "tablelinenone";
            this.tablelinenone.TabStop = true;
            this.tablelinenone.CheckedChanged += this.tlNoneChecked;
            // 
            // tablespacing
            // 
            resources.ApplyResources(this.tablespacing, "tablespacing");
            this.tablespacing.Name = "tablespacing";
            this.tablespacing.TextChanged += this.tspacingChanged;
            // 
            // equalCols
            // 
            resources.ApplyResources(this.equalCols, "equalCols");
            this.equalCols.Name = "equalCols";
            this.equalCols.CheckedChanged += this.EqualColsChanged;
            // 
            // equalRows
            // 
            resources.ApplyResources(this.equalRows, "equalRows");
            this.equalRows.Name = "equalRows";
            this.equalRows.CheckedChanged += this.EqualRowsCheckedChanged;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Click += this.OnCancel;
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.Name = "okButton";
            this.okButton.Click += this.OnOk;
            // 
            // tabcontrol
            // 
            this.tabcontrol.Controls.Add(this.tableTab);
            this.tabcontrol.Controls.Add(this.rowstab);
            this.tabcontrol.Controls.Add(this.colsTab);
            this.tabcontrol.Controls.Add(this.cellsTab);
            resources.ApplyResources(this.tabcontrol, "tabcontrol");
            this.tabcontrol.Name = "tabcontrol";
            this.tabcontrol.SelectedIndex = 0;
            this.tabcontrol.SelectedIndexChanged += this.TabChange;
            // 
            // tableTab
            // 
            this.tableTab.Controls.Add(this.group7);
            this.tableTab.Controls.Add(this.tableFrameGroup);
            this.tableTab.Controls.Add(this.tableAlignmentGroup);
            resources.ApplyResources(this.tableTab, "tableTab");
            this.tableTab.Name = "tableTab";
            // 
            // group7
            // 
            this.group7.Controls.Add(this.tablespacing);
            this.group7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resources.ApplyResources(this.group7, "group7");
            this.group7.Name = "group7";
            this.group7.TabStop = false;
            // 
            // rowstab
            // 
            this.rowstab.Controls.Add(this.group8);
            this.rowstab.Controls.Add(this.group9);
            this.rowstab.Controls.Add(this.rowLinesGroup);
            this.rowstab.Controls.Add(this.rowAlignmentGroup);
            resources.ApplyResources(this.rowstab, "rowstab");
            this.rowstab.Name = "rowstab";
            // 
            // group8
            // 
            this.group8.Controls.Add(this.rowspacing);
            this.group8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resources.ApplyResources(this.group8, "group8");
            this.group8.Name = "group8";
            this.group8.TabStop = false;
            // 
            // group9
            // 
            this.group9.Controls.Add(this.equalRows);
            this.group9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resources.ApplyResources(this.group9, "group9");
            this.group9.Name = "group9";
            this.group9.TabStop = false;
            // 
            // colsTab
            // 
            this.colsTab.Controls.Add(this.group10);
            this.colsTab.Controls.Add(this.group11);
            this.colsTab.Controls.Add(this.columnLinesGroup);
            this.colsTab.Controls.Add(this.columnAlignmentGroup);
            resources.ApplyResources(this.colsTab, "colsTab");
            this.colsTab.Name = "colsTab";
            // 
            // group10
            // 
            this.group10.Controls.Add(this.colSpacing_);
            this.group10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resources.ApplyResources(this.group10, "group10");
            this.group10.Name = "group10";
            this.group10.TabStop = false;
            // 
            // group11
            // 
            this.group11.Controls.Add(this.equalCols);
            this.group11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resources.ApplyResources(this.group11, "group11");
            this.group11.Name = "group11";
            this.group11.TabStop = false;
            // 
            // cellsTab
            // 
            this.cellsTab.Controls.Add(this.cellRowAlignmentGroup);
            this.cellsTab.Controls.Add(this.cellColumnAlignmentGroup);
            resources.ApplyResources(this.cellsTab, "cellsTab");
            this.cellsTab.Name = "cellsTab";
            // 
            // cellRowAlignmentGroup
            // 
            this.cellRowAlignmentGroup.Controls.Add(this.rowalignaxis_);
            this.cellRowAlignmentGroup.Controls.Add(this.rowalignbaseline_);
            this.cellRowAlignmentGroup.Controls.Add(this.rowaligncenter_);
            this.cellRowAlignmentGroup.Controls.Add(this.rowalignbottom_);
            this.cellRowAlignmentGroup.Controls.Add(this.rowaligntop_);
            this.cellRowAlignmentGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resources.ApplyResources(this.cellRowAlignmentGroup, "cellRowAlignmentGroup");
            this.cellRowAlignmentGroup.Name = "cellRowAlignmentGroup";
            this.cellRowAlignmentGroup.TabStop = false;
            // 
            // rowalignaxis_
            // 
            resources.ApplyResources(this.rowalignaxis_, "rowalignaxis_");
            this.rowalignaxis_.Name = "rowalignaxis_";
            this.rowalignaxis_.CheckedChanged += this.raAxisChecked;
            // 
            // rowalignbaseline_
            // 
            this.rowalignbaseline_.Checked = true;
            resources.ApplyResources(this.rowalignbaseline_, "rowalignbaseline_");
            this.rowalignbaseline_.Name = "rowalignbaseline_";
            this.rowalignbaseline_.TabStop = true;
            this.rowalignbaseline_.CheckedChanged += this.raBaselineChecked;
            // 
            // rowaligncenter_
            // 
            resources.ApplyResources(this.rowaligncenter_, "rowaligncenter_");
            this.rowaligncenter_.Name = "rowaligncenter_";
            this.rowaligncenter_.CheckedChanged += this.raCenterChecked;
            // 
            // rowalignbottom_
            // 
            resources.ApplyResources(this.rowalignbottom_, "rowalignbottom_");
            this.rowalignbottom_.Name = "rowalignbottom_";
            this.rowalignbottom_.CheckedChanged += this.raBottomChecked;
            // 
            // rowaligntop_
            // 
            resources.ApplyResources(this.rowaligntop_, "rowaligntop_");
            this.rowaligntop_.Name = "rowaligntop_";
            this.rowaligntop_.CheckedChanged += this.raTopChecked;
            // 
            // cellColumnAlignmentGroup
            // 
            this.cellColumnAlignmentGroup.Controls.Add(this.raligncenter);
            this.cellColumnAlignmentGroup.Controls.Add(this.rowalignright);
            this.cellColumnAlignmentGroup.Controls.Add(this.rowalignleft);
            this.cellColumnAlignmentGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resources.ApplyResources(this.cellColumnAlignmentGroup, "cellColumnAlignmentGroup");
            this.cellColumnAlignmentGroup.Name = "cellColumnAlignmentGroup";
            this.cellColumnAlignmentGroup.TabStop = false;
            // 
            // raligncenter
            // 
            this.raligncenter.Checked = true;
            resources.ApplyResources(this.raligncenter, "raligncenter");
            this.raligncenter.Name = "raligncenter";
            this.raligncenter.TabStop = true;
            this.raligncenter.CheckedChanged += this.rCenterCheck;
            // 
            // rowalignright
            // 
            resources.ApplyResources(this.rowalignright, "rowalignright");
            this.rowalignright.Name = "rowalignright";
            this.rowalignright.CheckedChanged += this.raRightChecked;
            // 
            // rowalignleft
            // 
            resources.ApplyResources(this.rowalignleft, "rowalignleft");
            this.rowalignleft.Name = "rowalignleft";
            this.rowalignleft.CheckedChanged += this.raLeftChecked;
            // 
            // selAllbutton
            // 
            this.selAllbutton.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.selAllbutton, "selAllbutton");
            this.selAllbutton.Name = "selAllbutton";
            this.selAllbutton.Click += this.SelectAllClick;
            // 
            // MatrixPropertiesDialog
            // 
            this.AcceptButton = this.okButton;
            resources.ApplyResources(this, "$this");
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.tabcontrol);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.selAllbutton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MatrixPropertiesDialog";
            this.tableAlignmentGroup.ResumeLayout(false);
            this.rowAlignmentGroup.ResumeLayout(false);
            this.columnAlignmentGroup.ResumeLayout(false);
            this.rowLinesGroup.ResumeLayout(false);
            this.columnLinesGroup.ResumeLayout(false);
            this.tableFrameGroup.ResumeLayout(false);
            this.tabcontrol.ResumeLayout(false);
            this.tableTab.ResumeLayout(false);
            this.group7.ResumeLayout(false);
            this.group7.PerformLayout();
            this.rowstab.ResumeLayout(false);
            this.group8.ResumeLayout(false);
            this.group8.PerformLayout();
            this.group9.ResumeLayout(false);
            this.colsTab.ResumeLayout(false);
            this.group10.ResumeLayout(false);
            this.group10.PerformLayout();
            this.group11.ResumeLayout(false);
            this.cellsTab.ResumeLayout(false);
            this.cellRowAlignmentGroup.ResumeLayout(false);
            this.cellColumnAlignmentGroup.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        public void SetTarget(Node node)
        {
            center = new Point(bWidth + canvasWidth, tabcontrol.Height + 30);
            if (node != null)
            {
                matrix = new MTable(node);
                numRows = matrix.RowCount;
                numCols = matrix.ColCount;
            }
            if (node == null) return;
            CreateButtons();
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    buttons[i][j].Visible = false;
                    buttons[i][j].FlatStyle = FlatStyle.Flat;
                }
            }
            RecalcButtons();
            SelectTableTab();
            switch (matrix.align)
            {
                case TableAlign.TOP:
                    tablealigntop_.Checked = true;
                    break;
                case TableAlign.BOTTOM:
                    tablealignbottom.Checked = true;
                    break;
                case TableAlign.CENTER:
                    tablealigncenter.Checked = true;
                    break;
                case TableAlign.BASELINE:
                    tablealignbaseline.Checked = true;
                    break;
                case TableAlign.AXIS:
                    tablealignAxis.Checked = true;
                    break;
            }
            switch (matrix.frame)
            {
                case TableLineStyle.NONE:
                    tablelinenone.Checked = true;
                    break;
                case TableLineStyle.SOLID:
                    tablelinesolid.Checked = true;
                    break;
                case TableLineStyle.DASHED:
                    tablelinedashed.Checked = true;
                    break;
            }
            equalRows.Checked = matrix.equalRows;
            equalCols.Checked = matrix.equalColumns;
            tablespacing.Text = matrix.framespacing;
        }

        private void taCenterClick(object sender, EventArgs e)
        {
            SetTableAlign();
        }

        private void taBaselineClick(object sender, EventArgs e)
        {
            SetTableAlign();
        }

        private void taAxisClick(object sender, EventArgs e)
        {
            SetTableAlign();
        }

        private void SetTableAlign()
        {
            if (tablealigntop_.Checked)
            {
                matrix.align = TableAlign.TOP;
            }
            else if (tablealigncenter.Checked)
            {
                matrix.align = TableAlign.CENTER;
            }
            else if (tablealignAxis.Checked)
            {
                matrix.align = TableAlign.AXIS;
            }
            else if (tablealignbaseline.Checked)
            {
                matrix.align = TableAlign.BASELINE;
            }
            else if (tablealignbottom.Checked)
            {
                matrix.align = TableAlign.BOTTOM;
            }
        }

        private void EqualRowsCheckedChanged(object sender, EventArgs e)
        {
            matrix.equalRows = equalRows.Checked;
        }

        private void raTopClick(object sender, EventArgs e)
        {
            SetRowAlign();
        }

        private void raBottomClick(object sender, EventArgs e)
        {
            SetRowAlign();
        }

        private void raCenterClick(object sender, EventArgs e)
        {
            SetRowAlign();
        }

        private void raBaselineClick(object sender, EventArgs e)
        {
            SetRowAlign();
        }

        private void raaxisClick(object sender, EventArgs e)
        {
            SetRowAlign();
        }

        private void TabChange(object sender, EventArgs e)
        {
            switch (tabcontrol.SelectedIndex)
            {
                case 0 when matrix.selKind_ != TableCellKind.SelAll:
                    SelectTableTab();
                    break;
                case 1 when matrix.selKind_ != TableCellKind.RowSelected:
                    SelectRowTab(0);
                    break;
                case 2 when matrix.selKind_ != TableCellKind.ColSelected:
                    SelectColTab(0);
                    break;
                case 3 when matrix.selKind_ != TableCellKind.RowColSelected &&
                            matrix.selKind_ != TableCellKind.BottomSelected:
                    SelectCellTab(0, 0);
                    break;
            }
            Recheck();
        }

        private void SetRowAlign()
        {
            if (rowaligntop.Checked)
            {
                matrix.SetRowAlign(RowAlign.TOP);
            }
            else if (rowaligncenter.Checked)
            {
                matrix.SetRowAlign(RowAlign.CENTER);
            }
            else if (rowalignbaseline.Checked)
            {
                matrix.SetRowAlign(RowAlign.BASELINE);
            }
            else if (rowalignaxis.Checked)
            {
                matrix.SetRowAlign(RowAlign.AXIS);
            }
            else if (rowalignbottom.Checked)
            {
                matrix.SetRowAlign(RowAlign.BOTTOM);
            }
            RecalcButtons();
        }

        private void rspacingchanged(object sender, EventArgs e)
        {
            matrix.SetRowSpacing(rowspacing.Text);
        }

        private void tlNoneClick(object sender, EventArgs e)
        {
            SetLineStyle();
        }

        private void tlsolidClick(object sender, EventArgs e)
        {
            SetLineStyle();
        }

        private void tlDashedClick(object sender, EventArgs e)
        {
            SetLineStyle();
        }

        private void SetLineStyle()
        {
            if (tablelinestylenone.Checked)
            {
                matrix.SetLineStyle(TableLineStyle.NONE);
            }
            else if (tablelinestylesolid.Checked)
            {
                matrix.SetLineStyle(TableLineStyle.SOLID);
            }
            else if (tablelinestyledashed.Checked)
            {
                matrix.SetLineStyle(TableLineStyle.DASHED);
            }
            Invalidate();
        }

        private void EqualColsChanged(object sender, EventArgs e)
        {
            matrix.equalColumns = equalCols.Checked;
        }

        private void caLeftClick(object sender, EventArgs e)
        {
            SetColAlign();
        }

        private void caCenterclick(object sender, EventArgs e)
        {
            SetColAlign();
        }

        private void caRightClick(object sender, EventArgs e)
        {
            SetColAlign();
        }

        private void tspacingChanged(object sender, EventArgs e)
        {
            matrix.framespacing = tablespacing.Text;
        }

        private void SetColAlign()
        {
            if (colalignleft.Checked)
            {
                matrix.SetColAlign(HAlign.LEFT);
            }
            else if (colaligncenter.Checked)
            {
                matrix.SetColAlign(HAlign.CENTER);
            }
            else if (colalignright.Checked)
            {
                matrix.SetColAlign(HAlign.RIGHT);
            }
            RecalcButtons();
        }

        private void cspacingChanged(object sender, EventArgs e)
        {
            matrix.SetColSpacing(colSpacing_.Text);
        }

        private void clNoneClick(object sender, EventArgs e)
        {
            SetTableLineStyle();
        }

        private void clSolidClick(object sender, EventArgs e)
        {
            SetTableLineStyle();
        }

        private void clDashedClick(object sender, EventArgs e)
        {
            SetTableLineStyle();
        }

        private void SetTableLineStyle()
        {
            if (collinestylenone.Checked)
            {
                matrix.SetTableLineStyle(TableLineStyle.NONE);
            }
            else if (collinestylesolid.Checked)
            {
                matrix.SetTableLineStyle(TableLineStyle.SOLID);
            }
            else if (collinestyledashed.Checked)
            {
                matrix.SetTableLineStyle(TableLineStyle.DASHED);
            }
            Invalidate();
        }

        private void raLeftChecked(object sender, EventArgs e)
        {
            SetRowColAlign();
        }

        private void rCenterCheck(object sender, EventArgs e)
        {
            SetRowColAlign();
        }

        private void raRightChecked(object sender, EventArgs e)
        {
            SetRowColAlign();
        }

        private void SetRowColAlign()
        {
            if (rowalignleft.Checked)
            {
                matrix.SetColAlign(HAlign.LEFT);
            }
            else if (raligncenter.Checked)
            {
                matrix.SetColAlign(HAlign.CENTER);
            }
            else if (rowalignright.Checked)
            {
                matrix.SetColAlign(HAlign.RIGHT);
            }
            RecalcButtons();
        }

        private void tlNoneChecked(object sender, EventArgs e)
        {
            SetFrame();
        }

        private void raTopChecked(object sender, EventArgs e)
        {
            PropogateRowAlign();
        }

        private void raBottomChecked(object sender, EventArgs e)
        {
            PropogateRowAlign();
        }

        private void raCenterChecked(object sender, EventArgs e)
        {
            PropogateRowAlign();
        }

        private void raBaselineChecked(object sender, EventArgs e)
        {
            PropogateRowAlign();
        }

        private void raAxisChecked(object sender, EventArgs e)
        {
            PropogateRowAlign();
        }

        private void PropogateRowAlign()
        {
            if (rowaligntop_.Checked)
            {
                matrix.SetRowAlign(RowAlign.TOP);
            }
            else if (rowaligncenter_.Checked)
            {
                matrix.SetRowAlign(RowAlign.CENTER);
            }
            else if (rowalignbaseline_.Checked)
            {
                matrix.SetRowAlign(RowAlign.BASELINE);
            }
            else if (rowalignaxis_.Checked)
            {
                matrix.SetRowAlign(RowAlign.AXIS);
            }
            else if (rowalignbottom_.Checked)
            {
                matrix.SetRowAlign(RowAlign.BOTTOM);
            }
            RecalcButtons();
        }

        private void SelectAllClick(object sender, EventArgs e)
        {
            SelectTableTab();
        }

        private void WholeRowClick(object sender, EventArgs e)
        {
            SelectRowTab(((MathTableButton)sender).row);
            Recheck();
        }

        private void WholeColClick(object sender, EventArgs e)
        {
            SelectColTab(((MathTableButton)sender).col);
            Recheck();
        }

        private void ButtonsClick(object sender, EventArgs e)
        {
            SelectCellTab(((MathTableButton)sender).row, ((MathTableButton)sender).col);
            Recheck();
        }

        private void tlSolidChecked(object sender, EventArgs e)
        {
            SetFrame();
        }

        private void bottomsClick(object sender, EventArgs e)
        {
            int col = ((MathTableButton)sender).col;
            int row = ((MathTableButton)sender).row;
            SelectCellTab(row, col);
            Recheck();
        }

        private void SelectTableTab()
        {
            matrix.SelectAll();
            tabcontrol.SelectedIndex = 0;
            RecalcButtons();
        }

        private void SelectRowTab(int row)
        {
            matrix.SetCurRow(row);
            tabcontrol.SelectedIndex = 1;
            RecalcButtons();
        }

        private void SelectColTab(int col)
        {
            matrix.SetCurCol(col);
            tabcontrol.SelectedIndex = 2;
            RecalcButtons();
        }

        private void SelectCellTab(int row, int col)
        {
            matrix.SetCurRowCol(row, col);
            RecalcButtons();
            tabcontrol.SelectedIndex = 3;
        }

        private void CreateButtons()
        {
            int hhh = 0;
            int hh = 0;
            hh = ClientRectangle.Height - (center.Y - bHeight) - 30;
            hhh = center.Y + numRows * (bHeight + canvasWidth) - (center.Y - bHeight);
            if (hhh <= hh)
            {
                while (hhh < hh - 10)
                {
                    Height -= 10;
                    hh = ClientRectangle.Height - (center.Y - bHeight) - 30;
                }
                okButton.Location = new Point(ClientRectangle.Width - cancelButton.Width - okButton.Width - 10 - 10,
                    ClientRectangle.Height - okButton.Height - 10);
                cancelButton.Location = new Point(ClientRectangle.Width - cancelButton.Width - 10,
                    ClientRectangle.Height - okButton.Height - 10);
            }
            else
            {
                while (hhh > hh)
                {
                    bHeight -= 2;
                    bWidth -= 2;
                    canvasWidth--;
                    hhh = center.Y + numRows * (bHeight + canvasWidth) - (center.Y - bHeight);
                }
            }
            selAllbutton.Location = new Point(center.X - bWidth, center.Y - bHeight);
            selAllbutton.Size = new Size(bWidth * 2 / 3, bHeight * 2 / 3);
            bottoms = new MathTableButton[numRows];
            buttons = new MathTableButton[numRows][];
            rowButtons = new MathTableButton[numRows];
            colButtons = new MathTableButton[numCols];
            for (int i = 0; i < numRows; i++)
            {
                buttons[i] = new MathTableButton[numCols];
            }
            for (int i = 0; i < numCols; i++)
            {
                colButtons[i] = new MathTableButton();
                colButtons[i].Location = new Point(center.X + i * (bWidth + canvasWidth), center.Y - bHeight);
                colButtons[i].Name = $"Col_{i}";
                colButtons[i].Size = new Size(bWidth, bHeight * 2 / 3);
                colButtons[i].col = i;
                colButtons[i].Click += WholeColClick;
                Controls.AddRange(new Control[] { colButtons[i] });
                colButtons[i].FlatStyle = FlatStyle.Flat;
            }
            for (int i = 0; i < numRows; i++)
            {
                rowButtons[i] = new MathTableButton();
                rowButtons[i].Location = new Point(center.X - bWidth, center.Y + i * (bHeight + canvasWidth));
                rowButtons[i].Name = $"Row_{i}";
                rowButtons[i].Size = new Size(bWidth * 2 / 3, bHeight);
                rowButtons[i].row = i;
                rowButtons[i].Click += WholeRowClick;
                Controls.AddRange(new Control[] { rowButtons[i] });
                rowButtons[i].FlatStyle = FlatStyle.Flat;

                bottoms[i] = new MathTableButton();
                bottoms[i].row = i;
                bottoms[i].col = matrix.ColCount;
                bottoms[i].BackColor = SystemColors.ControlLightLight;
                bottoms[i].FlatStyle = FlatStyle.Flat;
                bottoms[i].Location = new Point(buttonsOrigin.X + numCols * 0x22, buttonsOrigin.Y + i * 0x22);
                bottoms[i].Name = $"Cell_{i}_{numCols}";
                bottoms[i].Size = new Size(0x18, 0x18);
                bottoms[i].Click += bottomsClick;
                Controls.AddRange(new Control[] { bottoms[i] });
                bottoms[i].FlatStyle = FlatStyle.Flat;

                for (int j = 0; j < numCols; j++)
                {
                    buttons[i][j] = new MathTableButton();
                    buttons[i][j].row = i;
                    buttons[i][j].col = j;
                    buttons[i][j].BackColor = SystemColors.ControlLightLight;
                    buttons[i][j].FlatStyle = FlatStyle.Flat;
                    buttons[i][j].Location = new Point(buttonsOrigin.X + j * 0x22, buttonsOrigin.Y + i * 0x22);
                    buttons[i][j].Name = $"Cell_{i}_{j}";
                    buttons[i][j].Size = new Size(0x18, 0x18);
                    buttons[i][j].Click += ButtonsClick;
                    buttons[i][j].FlatStyle = FlatStyle.Flat;
                    Controls.AddRange(new Control[] { buttons[i][j] });
                }
            }
        }

        private void RecalcButtons()
        {
            for (int i = 0; i < numRows; i++)
            {
                bottoms[i].BackColor = Color.LightGray;
                for (int j = 0; j < numCols; j++) buttons[i][j].BackColor = Color.LightGray;
            }
            switch (matrix.selKind_)
            {
                case TableCellKind.SelAll:
                    for (int i = 0; i < numRows; i++)
                        for (int j = 0; j < numCols; j++)
                            buttons[i][j].BackColor = Color.LightBlue;
                    break;
                case TableCellKind.RowSelected:
                    for (int i = 0; i < numCols; i++)
                        buttons[matrix.curRow][i].BackColor = Color.LightBlue;
                    break;
                case TableCellKind.ColSelected:
                    for (int i = 0; i < numRows; i++)
                        buttons[i][matrix.curCol].BackColor = Color.LightBlue;
                    break;
                case TableCellKind.RowColSelected:
                    if (matrix.curCol >= matrix.ColCount)
                    {
                        if (matrix.curCol == matrix.ColCount)
                            bottoms[matrix.curRow].BackColor = Color.LightBlue;
                    }
                    else
                        buttons[matrix.curRow][matrix.curCol].BackColor = Color.LightBlue;
                    break;
                case TableCellKind.BottomSelected:
                    bottoms[matrix.curRow].BackColor = Color.LightBlue;
                    break;
            }
            for (int i = 0; i < matrix.RowCount; i++)
            {
                MRow row = matrix.GetRow(i);
                if (!row.isLabeled)
                {
                    bottoms[i].Visible = false;
                    continue;
                }
                bottoms[i].Visible = true;
                MCell cell = row.cell;
                int hv = 0;
                int rv = 0;
                HAlign hAlign = cell.GetColAlign();
                RowAlign rowAlign = cell.GetRowAlign();
                switch (hAlign)
                {
                    case HAlign.LEFT:
                        hv = -canvasWidth / 2;
                        break;
                    case HAlign.CENTER:
                        hv = 0;
                        break;
                    case HAlign.RIGHT:
                        hv = canvasWidth / 2;
                        break;
                }

                switch (rowAlign)
                {
                    case RowAlign.TOP:
                        rv = -canvasWidth / 2;
                        break;
                    case RowAlign.BOTTOM:
                        rv = canvasWidth / 2;
                        break;
                    case RowAlign.CENTER:
                    case RowAlign.BASELINE:
                    case RowAlign.AXIS:
                        rv = 0;
                        break;
                }

                bottoms[i].Location = new Point(center.X + cell.colSpan * (bWidth + canvasWidth) + hv + 30,
                    center.Y + i * (bHeight + canvasWidth) + rv);
                bottoms[i].Size = cell.tableAttrs is null
                    ? new Size(bWidth, bHeight)
                    : new Size(bWidth * cell.tableAttrs.columnSpan + canvasWidth * (cell.tableAttrs.columnSpan - 1),
                        bHeight * cell.tableAttrs.rowSpan + canvasWidth * (cell.tableAttrs.rowSpan - 1));
            }
            for (int i = 0; i < matrix.RowCount; i++)
            {
                MRow row = matrix.GetRow(i);
                for (int j = 0; j < row.Count; j++)
                {
                    MCell cell = row.Get(j);
                    buttons[i][cell.colSpan].Visible = true;
                    int halignV = 0;
                    int ralignV = 0;
                    HAlign hAlign = cell.GetColAlign();
                    RowAlign rowAlign = cell.GetRowAlign();
                    switch (hAlign)
                    {
                        case HAlign.LEFT:
                            halignV = -canvasWidth / 2;
                            break;
                        case HAlign.CENTER:
                            halignV = 0;
                            break;
                        case HAlign.RIGHT:
                            halignV = canvasWidth / 2;
                            break;
                    }

                    switch (rowAlign)
                    {
                        case RowAlign.TOP:
                            ralignV = -canvasWidth / 2;
                            break;
                        case RowAlign.BOTTOM:
                            ralignV = canvasWidth / 2;
                            break;
                        case RowAlign.CENTER:
                        case RowAlign.BASELINE:
                        case RowAlign.AXIS:
                            ralignV = 0;
                            break;
                    }

                    buttons[i][cell.colSpan].Location =
                        new Point(center.X + cell.colSpan * (bWidth + canvasWidth) + halignV,
                            center.Y + i * (bHeight + canvasWidth) + ralignV);
                    buttons[i][cell.colSpan].Size = cell.tableAttrs is null
                        ? new Size(bWidth, bHeight)
                        : new Size(bWidth * cell.tableAttrs.columnSpan + canvasWidth * (cell.tableAttrs.columnSpan - 1),
                            bHeight * cell.tableAttrs.rowSpan + canvasWidth * (cell.tableAttrs.rowSpan - 1));
                }
            }
        }

        private void Recheck()
        {
            bool fpouind;
            MCell lrow;
            switch (matrix.selKind_)
            {
                case TableCellKind.SelAll:
                    return;

                case TableCellKind.RowSelected:
                    int cRow = matrix.curRow;
                    RowAlign rowAlign = RowAlign.UNKNOWN;
                    bool changed = true;
                    MRow row = matrix.GetRow(cRow);
                    for (int i = 0; i < row.cells.Count; i++)
                    {
                        MCell cell = matrix.Get(cRow, i);
                        if (cell is null) continue;
                        if (i > 0 && cell.rowAlign != rowAlign) changed = false;
                        rowAlign = cell.rowAlign;
                    }
                    if (changed)
                    {
                        switch (rowAlign)
                        {
                            case RowAlign.TOP:
                                rowaligntop.Checked = true;
                                break;
                            case RowAlign.CENTER:
                                rowaligncenter.Checked = true;
                                break;
                            case RowAlign.BASELINE:
                                rowalignbaseline.Checked = true;
                                break;
                            case RowAlign.AXIS:
                                rowalignaxis.Checked = true;
                                break;
                            case RowAlign.BOTTOM:
                                rowalignbottom.Checked = true;
                                break;
                        }
                    }
                    else
                    {
                        rowaligntop.Checked = false;
                        rowaligncenter.Checked = false;
                        rowalignbaseline.Checked = false;
                        rowalignaxis.Checked = false;
                        rowalignbottom.Checked = false;
                    }
                    rowspacing.Text = row.spacing;
                    switch (row.lines)
                    {
                        case TableLineStyle.NONE:
                            tablelinestylenone.Checked = true;
                            return;
                        case TableLineStyle.SOLID:
                            tablelinestylesolid.Checked = true;
                            return;
                        case TableLineStyle.DASHED:
                            tablelinestyledashed.Checked = true;
                            return;
                    }
                    return;
                case TableCellKind.ColSelected:
                    int ccol = matrix.curCol;
                    HAlign columnAlign = HAlign.UNKNOWN;
                    bool need = true;
                    for (int i = 0; i < numRows; i++)
                    {
                        MCell cell = matrix.Get(i, ccol);
                        if (cell != null)
                        {
                            if (i > 0 && cell.columnAlign != columnAlign)
                            {
                                need = false;
                            }
                            columnAlign = cell.columnAlign;
                        }
                    }
                    if (need)
                    {
                        switch (columnAlign)
                        {
                            case HAlign.LEFT:
                                colalignleft.Checked = true;
                                break;
                            case HAlign.CENTER:
                                colaligncenter.Checked = true;
                                break;
                            case HAlign.RIGHT:
                                colalignright.Checked = true;
                                break;
                        }
                    }
                    else
                    {
                        colalignleft.Checked = false;
                        colaligncenter.Checked = false;
                        colalignright.Checked = false;
                    }
                    colSpacing_.Text = matrix.GetColSpacing(ccol);
                    switch (matrix.GetTableLineStyle(ccol))
                    {
                        case TableLineStyle.NONE:
                            collinestylenone.Checked = true;
                            return;
                        case TableLineStyle.SOLID:
                            collinestylesolid.Checked = true;
                            return;
                        case TableLineStyle.DASHED:
                            collinestyledashed.Checked = true;
                            return;
                    }
                    return;
                case TableCellKind.RowColSelected:
                case TableCellKind.BottomSelected:
                    fpouind = false;
                    lrow = null;
                    if (matrix.selKind_ != TableCellKind.RowColSelected)
                    {
                        if (matrix.selKind_ == TableCellKind.BottomSelected)
                        {
                            MRow mRow = matrix.GetRow(matrix.curRow);
                            if (mRow.isLabeled && mRow.cell != null)
                            {
                                lrow = mRow.cell;
                                fpouind = true;
                            }
                        }
                        break;
                    }
                    lrow = matrix.Get(matrix.curRow, matrix.curCol);
                    fpouind = true;
                    break;
                default:
                    return;
            }
            if (!fpouind) return;
            switch (lrow.columnAlign)
            {
                case HAlign.LEFT:
                    rowalignleft.Checked = true;
                    break;
                case HAlign.CENTER:
                    raligncenter.Checked = true;
                    break;
                case HAlign.RIGHT:
                    rowalignright.Checked = true;
                    break;
            }
            switch (lrow.rowAlign)
            {
                case RowAlign.TOP:
                    rowaligntop_.Checked = true;
                    break;
                case RowAlign.CENTER:
                    rowaligncenter_.Checked = true;
                    break;
                case RowAlign.BASELINE:
                    rowalignbaseline_.Checked = true;
                    break;
                case RowAlign.AXIS:
                    rowalignaxis_.Checked = true;
                    break;
                case RowAlign.BOTTOM:
                    rowalignbottom_.Checked = true;
                    break;
            }
        }

        private void tlDashedChecked(object sender, EventArgs e)
        {
            SetFrame();
        }

        private void OnOk(object sender, EventArgs e)
        {
            Success = true;
            Close();
        }

        private void OnCancel(object sender, EventArgs e)
        {
            Success = false;
            Close();
        }

        private void SetFrame()
        {
            if (tablelinenone.Checked)
            {
                matrix.frame = TableLineStyle.NONE;
            }
            else if (tablelinesolid.Checked)
            {
                matrix.frame = TableLineStyle.SOLID;
            }
            else if (tablelinedashed.Checked)
            {
                matrix.frame = TableLineStyle.DASHED;
            }
            Invalidate();
        }

        private void tatopClick(object sender, EventArgs e)
        {
            SetTableAlign();
        }

        private void taBottomClick(object sender, EventArgs e)
        {
            SetTableAlign();
        }


        public bool Success
        {
            get { return success_; }
            set { success_ = value; }
        }


        private GroupBox tableAlignmentGroup;
        private GroupBox rowAlignmentGroup;
        private RadioButton rowalignaxis;
        private RadioButton rowalignbaseline;
        private RadioButton rowaligncenter;
        private RadioButton rowalignbottom;
        private RadioButton rowaligntop;
        private RadioButton colaligncenter;
        private RadioButton colalignright;
        private RadioButton colalignleft;
        private RadioButton tablelinestylesolid;
        private RadioButton tablelinestyledashed;
        private GroupBox columnAlignmentGroup;
        private RadioButton tablelinestylenone;
        private RadioButton collinestylesolid;
        private RadioButton collinestyledashed;
        private RadioButton collinestylenone;
        private GroupBox tableFrameGroup;
        private RadioButton tablelinesolid;
        private RadioButton tablelinedashed;
        private RadioButton tablelinenone;
        private CheckBox equalRows;
        private CheckBox equalCols;
        private GroupBox rowLinesGroup;
        private TextBox rowspacing;
        private TextBox colSpacing_;
        private Glass.GlassButton cancelButton;
        private Glass.GlassButton okButton;
        private MathTableButton[][] buttons;
        private MathTableButton[] bottoms;
        private MathTableButton[] rowButtons;
        private MathTableButton[] colButtons;
        private int numRows;
        private int numCols;
        private GroupBox columnLinesGroup;
        private Point buttonsOrigin;
        private Container container;
        private bool success_;
        private TabControl tabcontrol;
        private TabPage tableTab;
        private TabPage rowstab;
        private TabPage colsTab;
        private TabPage cellsTab;
        private Glass.GlassButton selAllbutton;
        private GroupBox cellRowAlignmentGroup;
        private RadioButton tablealigntop_;
        private GroupBox cellColumnAlignmentGroup;
        private GroupBox group11;
        private GroupBox group9;
        private RadioButton raligncenter;
        private RadioButton rowalignright;
        private RadioButton rowalignleft;
        private RadioButton rowalignaxis_;
        private RadioButton rowalignbaseline_;
        private RadioButton rowaligncenter_;
        private RadioButton rowalignbottom_;
        private RadioButton tablealignbottom;
        private RadioButton rowaligntop_;
        private GroupBox group7;
        private GroupBox group8;
        private GroupBox group10;
        private TextBox tablespacing;
        public MTable matrix;
        private Point center;
        private int bWidth;
        private int bHeight;
        private RadioButton tablealigncenter;
        private int canvasWidth;
        private RadioButton tablealignbaseline;
        private RadioButton tablealignAxis;
    }
}