using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LocalShare
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer slideTimer = new System.Windows.Forms.Timer();
        private Control currentView;
        private Control targetView;

        public Form1()
        {
            InitializeComponent();
            ApplyModernStyle();
            InitEvents();

            slideTimer.Interval = 10;
            slideTimer.Tick += SlideTimer_Tick;
        }

        private void SafeUI(Action action)
        {
            if (this.InvokeRequired)
                this.Invoke(action);
            else
                action();
        }

        private void ApplyModernStyle()
        {
            this.BackColor = Color.FromArgb(24, 24, 28);
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.StartPosition = FormStartPosition.CenterScreen;

            StyleButton(sendButton, true);
            StyleButton(receiveButton, false);

            logBox.BackColor = Color.FromArgb(20, 20, 20);
            logBox.ForeColor = Color.LightGreen;
            logBox.Font = new Font("Consolas", 10);
            logBox.BorderStyle = BorderStyle.None;
        }

        private void StyleButton(Button btn, bool primary)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;

            btn.BackColor = primary
                ? Color.FromArgb(0, 122, 255)
                : Color.FromArgb(45, 45, 50);

            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        }

        private void InitEvents()
        {
            dropZone.AllowDrop = true;
            dropZone.DragEnter += DropZone_DragEnter;
            dropZone.DragDrop += DropZone_DragDrop;
        }

        private void DropZone_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                dropZone.BackColor = Color.FromArgb(50, 50, 60);
            }
        }

        private void DropZone_DragDrop(object sender, DragEventArgs e)
        {
            dropZone.BackColor = Color.FromArgb(35, 35, 40);

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (var file in files)
            {
                Log("📂 Fichier reçu : " + Path.GetFileName(file));
            }

            statusLabel.Text = files.Length + " fichier(s) ajouté(s)";
        }

        private void Log(string message)
        {
            logBox.AppendText(message + Environment.NewLine);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateIpAddr(Network.CurrentIp);
            initializePseudoBoxContent();
            updateConnexionState();

            Network.IpChanged += OnNetworkIpChanged;

            currentView = sendView;
            ShowViewInstant(sendView);
        }

        // 🔥 Animation Slide
        private void AnimateSlide(Control newView)
        {
            if (currentView == newView) return;

            targetView = newView;
            targetView.Left = panelMain.Width;
            targetView.Visible = true;

            slideTimer.Start();
        }

        private void SlideTimer_Tick(object sender, EventArgs e)
        {
            int speed = 40;

            currentView.Left -= speed;
            targetView.Left -= speed;

            if (targetView.Left <= 0)
            {
                slideTimer.Stop();

                currentView.Visible = false;
                targetView.Left = 0;

                currentView = targetView;
            }
        }

        private void ShowViewInstant(Control view)
        {
            foreach (Control ctrl in panelMain.Controls)
            {
                if (ctrl != panelMode)
                    ctrl.Visible = false;
            }

            view.Visible = true;
            view.Dock = DockStyle.Fill;
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            AnimateSlide(sendView);
        }

        private void receiveButton_Click(object sender, EventArgs e)
        {
            AnimateSlide(receiveView);
        }

        private void OnNetworkIpChanged(string newIp)
        {
            SafeUI(() =>
            {
                updateIpAddr(newIp);
                updateConnexionState();
            });
        }

        private void updateIpAddr(string addr)
        {
            ipText.Text = addr;
        }

        private void updateConnexionState()
        {
            SafeUI(() =>
            {
                if (Network.IsConnected())
                {
                    connexionState.ForeColor = Color.Green;
                    connexionState.Text = "Connected";
                }
                else
                {
                    connexionState.ForeColor = Color.Orange;
                    connexionState.Text = "Not Connected";
                }
            });
        }

        private void initializePseudoBoxContent()
        {
            string content = FileWriter.GetFileContent("config.conf");
            if (content.Trim().Length > 0)
            {
                pseudoBox.Text = content.Split("/")[1];
            }
        }

        private void pseudoBox_TextChanged(object sender, EventArgs e)
        {
            if (!isSyntaxValid(pseudoBox.Text))
            {
                MessageBox.Show("Le pseudo ne doit pas contenir de caractère spéciaux sauf pour '_'");
                pseudoBox.Text = pseudoBox.Text.Substring(0, pseudoBox.TextLength - 1);
                return;
            }
            if (isOptimalLength(pseudoBox.Text))
            {
                FileWriter.Write("config.conf", "pseudo*:/" + pseudoBox.Text, true);
            }
            else
            {
                MessageBox.Show("" +
                    "Le pseudo ne doit pas dépasser 10 caractères\n" +
                    "Veillez entrer un autre pseudo"
                    );
                pseudoBox.Text = "";
                FileWriter.Write("config.conf", "pseudo*:/ ", true);
            }
        }

        private bool isSyntaxValid(string content)
        {
            return (!content.Contains("/") && !content.Contains("\\") && !content.Contains("*")
                    && !content.Contains("-") && !content.Contains("&"));
        }

        private bool isOptimalLength(string pseudo)
        {
            pseudo = pseudo.Trim();
            return pseudo.Length >= 0 && pseudo.Length <= 20;
        }

        private void changePseudoBoxState()
        {
            pseudoBox.Enabled = !pseudoBox.Enabled;
        }

        private void validPseudo_CheckedChanged(object sender, EventArgs e)
        {
            changePseudoBoxState();
        }
    }
}