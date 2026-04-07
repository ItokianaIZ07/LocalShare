namespace LocalShare
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            splitContainer1 = new SplitContainer();
            panelSidebar = new Panel();
            footer1 = new Panel();
            ipLabel = new Label();
            ipText = new TextBox();
            connexionState = new Label();
            Title = new Label();
            sendButton = new Button();
            receiveButton = new Button();
            panelMain = new Panel();
            panelMode = new Panel();
            deviceList = new Panel();
            deviceLabel = new Label();
            searchLayout = new FlowLayoutPanel();
            searchBox = new TextBox();
            searchButton = new Button();
            searchLabel = new Label();
            panel2 = new Panel();
            validPseudo = new CheckBox();
            pseudoBox = new TextBox();
            panel1 = new Panel();
            radioGroup = new RadioButton();
            radioSolo = new RadioButton();
            modeTitle = new Label();
            sendView = new SendView();
            receiveView = new ReceiveView();
            mainLayout = new TableLayoutPanel();
            dropZone = new Panel();
            dropLabel = new Label();
            bottomLayout = new TableLayoutPanel();
            logBox = new RichTextBox();
            statusStrip = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panelSidebar.SuspendLayout();
            footer1.SuspendLayout();
            panelMain.SuspendLayout();
            panelMode.SuspendLayout();
            deviceList.SuspendLayout();
            searchLayout.SuspendLayout();
            panel2.SuspendLayout();
            mainLayout.SuspendLayout();
            dropZone.SuspendLayout();
            bottomLayout.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panelSidebar);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panelMain);
            splitContainer1.Size = new Size(978, 562);
            splitContainer1.SplitterDistance = 273;
            splitContainer1.TabIndex = 0;
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(30, 30, 35);
            panelSidebar.Controls.Add(footer1);
            panelSidebar.Controls.Add(Title);
            panelSidebar.Controls.Add(sendButton);
            panelSidebar.Controls.Add(receiveButton);
            panelSidebar.Dock = DockStyle.Fill;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(273, 562);
            panelSidebar.TabIndex = 0;
            // 
            // footer1
            // 
            footer1.Controls.Add(ipLabel);
            footer1.Controls.Add(ipText);
            footer1.Controls.Add(connexionState);
            footer1.Dock = DockStyle.Bottom;
            footer1.Location = new Point(0, 479);
            footer1.Name = "footer1";
            footer1.Size = new Size(273, 83);
            footer1.TabIndex = 6;
            // 
            // ipLabel
            // 
            ipLabel.AutoSize = true;
            ipLabel.Font = new Font("Yu Gothic Medium", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            ipLabel.ForeColor = SystemColors.ButtonHighlight;
            ipLabel.Location = new Point(0, 0);
            ipLabel.Name = "ipLabel";
            ipLabel.Size = new Size(121, 31);
            ipLabel.TabIndex = 4;
            ipLabel.Text = "NET Stat";
            // 
            // ipText
            // 
            ipText.Enabled = false;
            ipText.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ipText.Location = new Point(0, 34);
            ipText.Multiline = true;
            ipText.Name = "ipText";
            ipText.Size = new Size(270, 46);
            ipText.TabIndex = 3;
            ipText.TextAlign = HorizontalAlignment.Center;
            // 
            // connexionState
            // 
            connexionState.AutoSize = true;
            connexionState.Font = new Font("SimSun", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            connexionState.ForeColor = Color.FromArgb(255, 128, 0);
            connexionState.Location = new Point(127, 9);
            connexionState.Name = "connexionState";
            connexionState.Size = new Size(125, 18);
            connexionState.TabIndex = 5;
            connexionState.Text = "Not Connected";
            // 
            // Title
            // 
            Title.AutoSize = true;
            Title.Font = new Font("Segoe UI Semibold", 14F);
            Title.ForeColor = Color.White;
            Title.Location = new Point(20, 20);
            Title.Name = "Title";
            Title.Size = new Size(217, 38);
            Title.TabIndex = 0;
            Title.Text = "📂 LocalXShare";
            // 
            // sendButton
            // 
            sendButton.Cursor = Cursors.Hand;
            sendButton.Location = new Point(30, 100);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(160, 50);
            sendButton.TabIndex = 1;
            sendButton.Text = "Envoyer";
            sendButton.Click += sendButton_Click;
            // 
            // receiveButton
            // 
            receiveButton.Cursor = Cursors.Hand;
            receiveButton.Location = new Point(30, 180);
            receiveButton.Name = "receiveButton";
            receiveButton.Size = new Size(160, 50);
            receiveButton.TabIndex = 2;
            receiveButton.Text = "Recevoir";
            receiveButton.Click += receiveButton_Click;
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(24, 24, 28);
            panelMain.Controls.Add(panelMode);
            panelMain.Controls.Add(sendView);
            panelMain.Controls.Add(receiveView);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(701, 562);
            panelMain.TabIndex = 0;
            // 
            // panelMode
            // 
            panelMode.BackColor = Color.FromArgb(28, 28, 32);
            panelMode.Controls.Add(deviceList);
            panelMode.Controls.Add(panel2);
            panelMode.Controls.Add(panel1);
            panelMode.Controls.Add(radioGroup);
            panelMode.Controls.Add(radioSolo);
            panelMode.Controls.Add(modeTitle);
            panelMode.Dock = DockStyle.Right;
            panelMode.Location = new Point(411, 0);
            panelMode.Name = "panelMode";
            panelMode.Padding = new Padding(10);
            panelMode.Size = new Size(290, 562);
            panelMode.TabIndex = 0;
            // 
            // deviceList
            // 
            deviceList.BorderStyle = BorderStyle.FixedSingle;
            deviceList.Controls.Add(deviceLabel);
            deviceList.Controls.Add(searchLayout);
            deviceList.Controls.Add(searchLabel);
            deviceList.Dock = DockStyle.Right;
            deviceList.Location = new Point(10, 81);
            deviceList.Margin = new Padding(8);
            deviceList.Name = "deviceList";
            deviceList.Size = new Size(270, 410);
            deviceList.TabIndex = 2;
            // 
            // deviceLabel
            // 
            deviceLabel.AutoSize = true;
            deviceLabel.Dock = DockStyle.Top;
            deviceLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            deviceLabel.ForeColor = SystemColors.Control;
            deviceLabel.Location = new Point(0, 148);
            deviceLabel.Name = "deviceLabel";
            deviceLabel.Size = new Size(136, 32);
            deviceLabel.TabIndex = 4;
            deviceLabel.Text = "Device List";
            // 
            // searchLayout
            // 
            searchLayout.Controls.Add(searchBox);
            searchLayout.Controls.Add(searchButton);
            searchLayout.Dock = DockStyle.Top;
            searchLayout.Location = new Point(0, 22);
            searchLayout.Name = "searchLayout";
            searchLayout.Size = new Size(268, 126);
            searchLayout.TabIndex = 3;
            // 
            // searchBox
            // 
            searchBox.Location = new Point(3, 3);
            searchBox.Name = "searchBox";
            searchBox.PlaceholderText = "IP address";
            searchBox.Size = new Size(224, 31);
            searchBox.TabIndex = 1;
            searchBox.TextAlign = HorizontalAlignment.Center;
            // 
            // searchButton
            // 
            searchButton.Cursor = Cursors.Hand;
            searchButton.FlatStyle = FlatStyle.System;
            searchButton.ForeColor = Color.FromArgb(0, 122, 255);
            searchButton.Location = new Point(233, 3);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(32, 34);
            searchButton.TabIndex = 2;
            searchButton.Text = "🔍";
            searchButton.UseVisualStyleBackColor = true;
            // 
            // searchLabel
            // 
            searchLabel.AutoSize = true;
            searchLabel.Dock = DockStyle.Top;
            searchLabel.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            searchLabel.ForeColor = SystemColors.ButtonHighlight;
            searchLabel.Location = new Point(0, 0);
            searchLabel.Name = "searchLabel";
            searchLabel.Size = new Size(199, 22);
            searchLabel.TabIndex = 0;
            searchLabel.Text = "Search for Ip Addr";
            // 
            // panel2
            // 
            panel2.Controls.Add(validPseudo);
            panel2.Controls.Add(pseudoBox);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(10, 491);
            panel2.Name = "panel2";
            panel2.Size = new Size(270, 61);
            panel2.TabIndex = 4;
            // 
            // validPseudo
            // 
            validPseudo.AutoSize = true;
            validPseudo.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            validPseudo.ForeColor = Color.FromArgb(224, 224, 224);
            validPseudo.Location = new Point(3, 3);
            validPseudo.Name = "validPseudo";
            validPseudo.Size = new Size(147, 29);
            validPseudo.TabIndex = 1;
            validPseudo.Text = "valid pseudo";
            validPseudo.UseVisualStyleBackColor = true;
            validPseudo.CheckedChanged += validPseudo_CheckedChanged;
            // 
            // pseudoBox
            // 
            pseudoBox.AllowDrop = true;
            pseudoBox.BorderStyle = BorderStyle.FixedSingle;
            pseudoBox.Dock = DockStyle.Bottom;
            pseudoBox.ForeColor = Color.FromArgb(0, 0, 64);
            pseudoBox.Location = new Point(0, 30);
            pseudoBox.Multiline = true;
            pseudoBox.Name = "pseudoBox";
            pseudoBox.PlaceholderText = "Pseudo";
            pseudoBox.Size = new Size(270, 31);
            pseudoBox.TabIndex = 0;
            pseudoBox.TextAlign = HorizontalAlignment.Center;
            pseudoBox.TextChanged += pseudoBox_TextChanged;
            // 
            // panel1
            // 
            panel1.Location = new Point(5, 531);
            panel1.Name = "panel1";
            panel1.Size = new Size(195, 34);
            panel1.TabIndex = 3;
            // 
            // radioGroup
            // 
            radioGroup.Dock = DockStyle.Top;
            radioGroup.ForeColor = Color.White;
            radioGroup.Location = new Point(10, 57);
            radioGroup.Name = "radioGroup";
            radioGroup.Size = new Size(270, 24);
            radioGroup.TabIndex = 0;
            radioGroup.Text = "👥 Groupe";
            // 
            // radioSolo
            // 
            radioSolo.Checked = true;
            radioSolo.Dock = DockStyle.Top;
            radioSolo.ForeColor = Color.White;
            radioSolo.Location = new Point(10, 33);
            radioSolo.Name = "radioSolo";
            radioSolo.Size = new Size(270, 24);
            radioSolo.TabIndex = 1;
            radioSolo.TabStop = true;
            radioSolo.Text = "🔹 Solo (P2P)";
            // 
            // modeTitle
            // 
            modeTitle.Dock = DockStyle.Top;
            modeTitle.Font = new Font("Segoe UI Semibold", 11F);
            modeTitle.ForeColor = Color.White;
            modeTitle.Location = new Point(10, 10);
            modeTitle.Name = "modeTitle";
            modeTitle.Size = new Size(270, 23);
            modeTitle.TabIndex = 2;
            modeTitle.Text = "Mode de partage";
            // 
            // sendView
            // 
            sendView.AllowDrop = true;
            sendView.BackColor = Color.FromArgb(24, 24, 28);
            sendView.Dock = DockStyle.Fill;
            sendView.Location = new Point(0, 0);
            sendView.MinimumSize = new Size(450, 350);
            sendView.Name = "sendView";
            sendView.Size = new Size(701, 562);
            sendView.TabIndex = 0;
            sendView.DragDrop += DropZone_DragDrop;
            sendView.DragEnter += DropZone_DragEnter;
            // 
            // receiveView
            // 
            receiveView.BackColor = Color.FromArgb(24, 24, 28);
            receiveView.Dock = DockStyle.Fill;
            receiveView.Location = new Point(0, 0);
            receiveView.Name = "receiveView";
            receiveView.Size = new Size(701, 562);
            receiveView.TabIndex = 1;
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 3;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            mainLayout.Controls.Add(dropZone, 1, 1);
            mainLayout.Controls.Add(bottomLayout, 1, 2);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 0);
            mainLayout.Name = "mainLayout";
            mainLayout.RowCount = 3;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 85F));
            mainLayout.Size = new Size(723, 568);
            mainLayout.TabIndex = 0;
            // 
            // dropZone
            // 
            dropZone.BackColor = Color.FromArgb(35, 35, 40);
            dropZone.BorderStyle = BorderStyle.FixedSingle;
            dropZone.Controls.Add(dropLabel);
            dropZone.Cursor = Cursors.Hand;
            dropZone.Dock = DockStyle.Fill;
            dropZone.Location = new Point(147, 58);
            dropZone.Name = "dropZone";
            dropZone.Padding = new Padding(10);
            dropZone.Size = new Size(427, 194);
            dropZone.TabIndex = 0;
            dropZone.DragDrop += DropZone_DragDrop;
            // 
            // dropLabel
            // 
            dropLabel.Dock = DockStyle.Fill;
            dropLabel.Font = new Font("Segoe UI Semibold", 13F);
            dropLabel.ForeColor = Color.Gray;
            dropLabel.Location = new Point(10, 10);
            dropLabel.Name = "dropLabel";
            dropLabel.Size = new Size(405, 172);
            dropLabel.TabIndex = 0;
            dropLabel.Text = "Glissez vos fichiers ici 📂";
            dropLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // bottomLayout
            // 
            bottomLayout.ColumnCount = 1;
            bottomLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            bottomLayout.Controls.Add(logBox, 0, 1);
            bottomLayout.Dock = DockStyle.Fill;
            bottomLayout.Location = new Point(147, 258);
            bottomLayout.Name = "bottomLayout";
            bottomLayout.RowCount = 2;
            bottomLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            bottomLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            bottomLayout.Size = new Size(427, 307);
            bottomLayout.TabIndex = 1;
            // 
            // logBox
            // 
            logBox.Location = new Point(20, 30);
            logBox.Margin = new Padding(20);
            logBox.Name = "logBox";
            logBox.Size = new Size(387, 257);
            logBox.TabIndex = 0;
            logBox.Text = "";
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(24, 24);
            statusStrip.Items.AddRange(new ToolStripItem[] { statusLabel });
            statusStrip.Location = new Point(0, 562);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(978, 32);
            statusStrip.TabIndex = 1;
            // 
            // statusLabel
            // 
            statusLabel.ForeColor = Color.White;
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(43, 25);
            statusLabel.Text = "Prêt";
            // 
            // Form1
            // 
            AutoScroll = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(978, 594);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(800, 500);
            Name = "Form1";
            Text = "LocalXShare";
            Load += Form1_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panelSidebar.ResumeLayout(false);
            panelSidebar.PerformLayout();
            footer1.ResumeLayout(false);
            footer1.PerformLayout();
            panelMain.ResumeLayout(false);
            panelMode.ResumeLayout(false);
            deviceList.ResumeLayout(false);
            deviceList.PerformLayout();
            searchLayout.ResumeLayout(false);
            searchLayout.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            mainLayout.ResumeLayout(false);
            dropZone.ResumeLayout(false);
            bottomLayout.ResumeLayout(false);
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private SplitContainer splitContainer1;
        private Panel panelSidebar;
        private Panel panelMain;
        private Panel dropZone;
        private Label dropLabel;
        private Label Title;
        private Button sendButton;
        private Button receiveButton;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel statusLabel;
        private TableLayoutPanel mainLayout;
        private TableLayoutPanel bottomLayout;
        private RichTextBox logBox;

        // 🔹 NEW fields for mode selection
        private Panel panelMode;
        private Label modeTitle;
        private RadioButton radioSolo;
        private RadioButton radioGroup;
        private Panel panel1;
        private TextBox pseudoBox;
        private CheckBox validPseudo;
        private Label ipLabel;
        private TextBox ipText;
        private Label connexionState;

        private SendView sendView;
        private ReceiveView receiveView;
        private Panel footer1;
        private Panel panel2;
        private Panel deviceList;
        private FlowLayoutPanel searchLayout;
        private TextBox searchBox;
        private Button searchButton;
        private Label searchLabel;
        private Label deviceLabel;
    }
}