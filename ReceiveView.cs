using System.Drawing;
using System.Windows.Forms;

namespace LocalShare
{
    public class ReceiveView : UserControl
    {
        public Label infoLabel;

        public ReceiveView()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(24, 24, 28);

            infoLabel = new Label();
            infoLabel.Text = "En attente de réception 📡";
            infoLabel.ForeColor = Color.White;
            infoLabel.Dock = DockStyle.Fill;
            infoLabel.TextAlign = ContentAlignment.MiddleCenter;
            infoLabel.Font = new Font("Segoe UI", 14, FontStyle.Bold);

            this.Controls.Add(infoLabel);
        }
    }
}