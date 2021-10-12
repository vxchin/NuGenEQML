namespace Genetibase.MathX
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Windows.Forms;
    using Attrs;
    using Fonts;
    using Nodes;
    using UI;

    public class NuGenEQML : UserControl
    {
        public event MouseEventHandler Event_MouseDown;
        public event EventHandler Event_OnGotFocus;
        public event EventHandler Event_OnLostFocus;
        public event EventHandler Event_OnSelectionChanged;
        public event EventHandler Event_OnUndoRedoStackChanged;
        public event EventHandler Event_OnValidationError;

        public NuGenEQML()
        {
            container_ = null;
            schemaName_ = "MathML_XMLSchema.xsd";
            xmlSource_ =
                "<?xml version='1.0' ?><math xmlns='http://www.w3.org/1998/Math/MathML' display='block'><mrow/></math>";
            backgroundColor_ = Color.White;
            fontCollection = null;
            entityManager = null;


            InitializeComponent();

            FontsProvider fontsProvider = new FontsProvider();
            fontCollection = fontsProvider.LoadAll();
            entityManager = new EntityManager(fontCollection);


            uiMenu = new ControlWithMenu(entityManager, fontCollection);
            uiMenu.AllowDrop = true;

            uiMenu.BackColor = Color.White;
            uiMenu.Dock = DockStyle.Fill;

            uiMenu.Location = new Point(0, 0);
            uiMenu.Name = "m_EditControl";
            uiMenu.OffsetX = 0;
            uiMenu.OffsetY = 0;
            uiMenu.Size = new Size(0x256, 0xe2);
            uiMenu.TabIndex = 0;

            Controls.Add(uiMenu);
            uiMenu.SetBounds(0, 0, Size.Width, Size.Height);
            uiMenu.DoResize(Size.Width, Size.Height, true, false);
            ResetWidth();

            uiMenu.Event_OnUndoRedoStackChanged += new EventHandler(OnUndoRedo);
            uiMenu.Event_OnValidationError += new ValidationHandler(OnValidationErrorHandler);

            uiMenu.Event_MouseDown += new MouseEventHandler(OnMouseDownHandler);
            uiMenu.Event_OnGotFocus += new EventHandler(OnGotFocusHandler);
            uiMenu.Event_OnLostFocus += new EventHandler(OnLostFocusHandler);
            uiMenu.KeyPress += new KeyPressEventHandler(KeyPressHandler);
            uiMenu.Event_OnSelectionChanged += new OnChangeSelection(SelectionChangedHandler);
            uiMenu.Focus();
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
            }
            catch
            {
            }
            if (disposing && (container_ != null))
            {
                container_.Dispose();
            }
            base.Dispose(disposing);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ResetWidth();
        }

        public void pub_Command_SubScript()
        {
            uiMenu.Command_SubScript();
        }

        public void pub_Command_SubSupScript()
        {
            uiMenu.Command_SubSupScript();
        }

        public void pub_Command_SupScript()
        {
            uiMenu.Command_SupScript();
        }

        public void pub_Copy()
        {
            uiMenu.Copy();
        }

        public bool pub_CopyActive()
        {
            bool flag1 = false;
            try
            {
                return uiMenu.CopyActive();
            }
            catch
            {
                return flag1;
            }
        }

        public void pub_Cut()
        {
            uiMenu.Cut();
        }

        public bool pub_CutActive()
        {
            try
            {
                return uiMenu.CutActive();
            }
            catch
            {
                return false;
            }
        }

        public void pub_Delete()
        {
            uiMenu.Delete();
        }

        public Bitmap pub_Export2Image(float fontSize, int nResolution, ref int ImgBaseline)
        {
            try
            {
                return uiMenu.Export2Image(PixelFormat.Format24bppRgb, fontSize, nResolution, ref ImgBaseline);
            }
            catch
            {
                return null;
            }
        }

        public Image pub_Export2Image(float fontSize = 12F, int resolution = 300)
        {
            var i = 0;
            return pub_Export2Image(fontSize, resolution, ref i);
        }


        public string pub_GetXML(bool bStrip_Namespace)
        {
            try
            {
                xmlSource_ = uiMenu.GetXML(bStrip_Namespace);
                return xmlSource_;
            }
            catch
            {
                return "";
            }
        }

        public void pub_Insert_MathML(string sXML, bool bValidate)
        {
            try
            {
                uiMenu.Insert_MathML(sXML, bValidate);
            }
            catch
            {
            }
        }

        public void pub_InsertAction()
        {
            uiMenu.InsertAction();
        }

        public void pub_InsertBrackets(string sEntityName1, string sEntityName2, bool bStretchy)
        {
            uiMenu.InsertBrackets(sEntityName1, sEntityName2, bStretchy);
        }

        public void pub_InsertEntity_Identifier(string entityName, bool bItalic, bool bBold)
        {
            uiMenu.InsertEntity_Identifier(entityName, bItalic, bBold);
        }

        public void pub_InsertEntity_Open_IdentifierDictionary_Dialog()
        {
            uiMenu.InsertEntity_Open_IdentifierDictionary_Dialog(true);
        }

        public void pub_InsertEntity_Open_OperatorDictionary_Dialog()
        {
            uiMenu.InsertEntity_Open_IdentifierDictionary_Dialog(false);
        }

        public void pub_InsertEntity_Operator(string content, bool insertByName)
        {
            uiMenu.InsertEntity_Operator(content, insertByName);
        }

        public void pub_InsertFenced()
        {
            uiMenu.InsertFenced();
        }

        public void pub_InsertFraction()
        {
            uiMenu.InsertFraction();
        }

        public void pub_InsertFraction_Bevelled()
        {
            uiMenu.InsertFraction_Bevelled();
        }

        public void pub_InsertMatrix(int rows, int cols)
        {
            try
            {
                uiMenu.InsertMatrix(rows, cols);
            }
            catch
            {
            }
        }

        public void pub_InsertMatrixDialog()
        {
            uiMenu.InsertMatrixDialog();
        }

        public void pub_InsertOver()
        {
            uiMenu.InsertOver();
        }

        public void pub_InsertOverAccent(string entityName)
        {
            uiMenu.InsertOverAccent(entityName);
        }

        public void pub_InsertPhantom()
        {
            uiMenu.InsertPhantom();
        }

        public void pub_InsertPrime(string entityName)
        {
            uiMenu.InsertPrime(entityName);
        }

        public void pub_InsertRoot()
        {
            uiMenu.InsertRoot();
        }

        public void pub_InsertSqrt()
        {
            uiMenu.InsertSqrt();
        }

        public void pub_InsertStretchyArrow_Over(string entityName)
        {
            uiMenu.InsertStretchyArrow_Over(entityName);
        }

        public void pub_InsertStretchyArrow_Under(string entityName)
        {
            uiMenu.InsertStretchyArrow_Under(entityName);
        }

        public void pub_InsertStretchyArrow_UnderOver(string entityName)
        {
            uiMenu.InsertStretchyArrow_UnderOver(entityName);
        }

        public void pub_InsertSubScript()
        {
            uiMenu.InsertSubScript();
        }

        public void pub_InsertSubSupScript()
        {
            uiMenu.InsertSubSupScript();
        }

        public void pub_InsertSuperScript()
        {
            uiMenu.InsertSuperScript();
        }

        public void pub_InsertText()
        {
            uiMenu.InsertText();
        }

        public void pub_InsertUnder()
        {
            uiMenu.InsertUnder();
        }

        public void pub_InsertUnderAccent(string entityName)
        {
            uiMenu.InsertUnderAccent(entityName);
        }

        public void pub_InsertUnderOver()
        {
            uiMenu.InsertUnderOver();
        }

        public bool LoadFromFile(string filename)
        {
            try
            {
                StreamReader reader = new StreamReader(filename);
                string xml = reader.ReadToEnd();
                reader.Close();

                return pub_LoadXML(xml);
            }
            catch
            {
                return false;
            }
        }

        public bool pub_LoadXML(string sXML)
        {
            try
            {
                xmlSource_ = sXML;
                uiMenu.LoadXML(sXML);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void pub_Paste()
        {
            uiMenu.Paste();
        }

        public void pub_Redo()
        {
            uiMenu.Redo();
        }

        public bool pub_RedoActive()
        {
            try
            {
                return uiMenu.RedoActive();
            }
            catch
            {
                return false;
            }
        }

        public bool pub_Save(string fileName)
        {
            try
            {
                uiMenu.Save(fileName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool pub_SavePure(string fileName)
        {
            try
            {
                uiMenu.SavePure(fileName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool pub_SaveAsJPEG(string fileName, float fontSize, int ImgResolution, ref int ImgBaseline)
        {
            try
            {
                uiMenu.SaveAsJPEG(fileName, fontSize, ImgResolution, ref ImgBaseline);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void pub_SelectAll()
        {
            try
            {
                uiMenu.SelectAll();
            }
            catch
            {
            }
        }

        public void pub_SetDisplayStyle(bool bDisplayStyle)
        {
            try
            {
                Nodes.Attribute attribute;
                if (uiMenu.builder_ == null)
                {
                    return;
                }
                Node node = null;
                node = uiMenu.builder_.getRoot();
                if (node == null)
                {
                    return;
                }
                if (bDisplayStyle)
                {
                    if (node.attrs != null)
                    {
                        attribute = node.attrs.Get("display");
                        if (attribute != null)
                        {
                            attribute.val = "block";
                        }
                    }
                    else
                    {
                        node.attrs = new AttributeList();
                        node.attrs.Add(new Nodes.Attribute("display", "block", ""));
                    }
                }
                else if (node.attrs != null)
                {
                    attribute = node.attrs.Get("display");
                    if (attribute != null)
                    {
                        node.attrs.Remove(attribute);
                    }
                }
                node.displayStyle = bDisplayStyle;
                uiMenu.ReRender();
            }
            catch
            {
            }
        }

        public void pub_SetSize(int x, int y, int w, int h)
        {
            try
            {
                SetBounds(x, y, w, h);
            }
            catch
            {
            }
        }

        public void pub_ShowPropertiesDialog()
        {
            uiMenu.ShowPropertiesDialog();
        }

        public void pub_ShowStyleDialog()
        {
            uiMenu.StyleProperties();
        }

        public void pub_Undo()
        {
            uiMenu.Undo();
        }

        public bool pub_UndoActive()
        {
            bool flag1 = false;
            try
            {
                return uiMenu.UndoActive();
            }
            catch
            {
                return flag1;
            }
        }

        public void pub_InsertChar(char c)
        {
            uiMenu.pub_InsertChar(c);
        }

        private void ResetWidth()
        {
            if (uiMenu != null)
            {
                uiMenu.SetWidth(ClientRectangle.Width);
            }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            uiMenu.SetSchemas(schemaName_);

            uiMenu.SetFonts(fontCollection);
            try
            {
                uiMenu.LoadXML(xmlSource_, "", true);
            }
            catch
            {
            }
            uiMenu.Invalidate();
            uiMenu.Focus();
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources =
                new ComponentResourceManager(typeof(NuGenEQML));
            SuspendLayout();
            // 
            // MathMLControl
            // 
            BackColor = Color.White;
            DoubleBuffered = true;
            Name = "MathMLControl";
            resources.ApplyResources(this, "$this");
            Load += new EventHandler(OnLoad);
            ResumeLayout(false);
        }

        private void OnUndoRedo(object sender, EventArgs e)
        {
            try
            {
                Event_OnUndoRedoStackChanged?.Invoke(this, EventArgs.Empty);
            }
            catch
            {
            }
        }

        private void OnMouseDownHandler(object sender, MouseEventArgs e)
        {
            try
            {
                Event_MouseDown?.Invoke(this, new MouseEventArgs(e.Button, e.Clicks, e.X, e.Y, e.Delta));
            }
            catch
            {
            }
        }

        private void KeyPressHandler(object sender, KeyPressEventArgs e)
        {
            try
            {
                OnKeyPress(e);
            }
            catch
            {
            }
        }

        private void OnValidationErrorHandler(object sender, ValidationErrorArgs e)
        {
            try
            {
                Event_OnValidationError?.Invoke(this, new ValidationErrorEventArgs(e.Message, e.Line, e.Pos));
            }
            catch
            {
            }
        }

        private void OnGotFocusHandler(object sender, EventArgs e)
        {
            try
            {
                Event_OnGotFocus?.Invoke(this, EventArgs.Empty);
            }
            catch
            {
            }
        }

        private void OnLostFocusHandler(object sender, EventArgs e)
        {
            try
            {
                Event_OnLostFocus?.Invoke(this, EventArgs.Empty);
            }
            catch
            {
            }
        }

        private void SelectionChangedHandler(object sender, SelectionArgs e)
        {
            try
            {
                Event_OnSelectionChanged?.Invoke(this, new OnMathMLSelectionChanged(e.HasSelection));
            }
            catch
            {
            }
        }


        [Browsable(false)]
        public override Color BackColor
        {
            get => base.BackColor;
            set => base.BackColor = value;
        }

        [Browsable(false)]
        public override Image BackgroundImage
        {
            get => base.BackgroundImage;
            set => base.BackgroundImage = value;
        }

        [Browsable(false)]
        public override Color ForeColor
        {
            get => base.ForeColor;
            set => base.ForeColor = value;
        }

        [DefaultValue(typeof(Color), "White")]
        public Color MC_BackgroundColor
        {
            get => backgroundColor_;
            set
            {
                backgroundColor_ = value;
                BackColor = backgroundColor_;
            }
        }

        [DefaultValue(true)]
        [Description("Gets or sets whether end-users are allowed to edit data.")]
        public bool MC_Editable
        {
            get => uiMenu.Editable;
            set => uiMenu.Editable = value;
        }

        [DefaultValue(HAlign.LEFT)]
        [Description("Get or sets the horizontal alignment of whole content.")]
        public HAlign MC_HAlign
        {
            get => uiMenu.HAlign;
            set => uiMenu.HAlign = value;
        }

        [DefaultValue(VAlign.TOP)]
        [Description("Get or sets the vertical alignment of whole content.")]
        public VAlign MC_VAlign
        {
            get => uiMenu.VAlign;
            set => uiMenu.VAlign = value;
        }

        public bool MC_DisplayStyle
        {
            get
            {
                var result = uiMenu?.builder_?.getRoot()?.displayStyle;
                return result.HasValue && result.Value;
            }
        }

        [DefaultValue(true)]
        public bool AutoCloseBrackets
        {
            get => uiMenu is null || uiMenu.AutoCloseBrackets;
            set
            {
                if (uiMenu != null) uiMenu.AutoCloseBrackets = value;
            }
        }

        [DefaultValue(true)]
        public bool MC_EnableStretchyBrackets
        {
            get => uiMenu is null || !uiMenu.NonStretchyBrackets;
            set
            {
                if (uiMenu != null) uiMenu.NonStretchyBrackets = !value;
            }
        }

        [DefaultValue(12F)]
        public float MC_FontSize
        {
            get
            {
                if (uiMenu is null) return 12F;
                try
                {
                    return uiMenu.FontSize;
                }
                catch
                {
                    return 12F;
                }
            }
            set
            {
                if (uiMenu is null) return;
                try
                {
                    uiMenu.FontSize = value;
                }
                catch
                {
                }
            }
        }

        [DefaultValue(true)]
        public bool MC_UseDefaultContextMenu
        {
            get => uiMenu is null || uiMenu.UseDefaultContextMenu;
            set
            {
                if (uiMenu != null) uiMenu.UseDefaultContextMenu = value;
            }
        }

        [DefaultValue(false)]
        public bool ParentControl_DesignMode
        {
            get => uiMenu != null && uiMenu.ParentControl_DesignMode;
            set
            {
                if (uiMenu != null) uiMenu.ParentControl_DesignMode = value;
            }
        }

        [Browsable(false)]
        public override RightToLeft RightToLeft
        {
            get => base.RightToLeft;
            set => base.RightToLeft = value;
        }

        private string schemaName_;
        private string xmlSource_;
        private Color backgroundColor_;
        private FontCollection fontCollection;
        private EntityManager entityManager;

        private ControlWithMenu uiMenu;
        private Container container_;
    }
}