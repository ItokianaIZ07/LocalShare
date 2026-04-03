using System.Drawing;
using System.Windows.Forms;

namespace LocalShare
{
    public class SendView : UserControl
    {
        public Panel DropZone;
        public RichTextBox LogBox;

        public SendView()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(24, 24, 28);

            TableLayoutPanel layout = new TableLayoutPanel();
            layout.Dock = DockStyle.Fill;
            layout.RowCount = 2;
            layout.ColumnCount = 1;

            // Drop zone
            DropZone = new Panel();
            DropZone.BackColor = Color.FromArgb(35, 35, 40);
            DropZone.Dock = DockStyle.Fill;

            Label dropLabel = new Label();
            dropLabel.Text = "Glissez vos fichiers ici 📂";
            dropLabel.ForeColor = Color.Gray;
            dropLabel.Dock = DockStyle.Fill;
            dropLabel.TextAlign = ContentAlignment.MiddleCenter;

            DropZone.Controls.Add(dropLabel);

            // Log box
            LogBox = new RichTextBox();
            LogBox.Dock = DockStyle.Fill;

            layout.Controls.Add(DropZone, 0, 0);
            layout.Controls.Add(LogBox, 0, 1);

            this.Controls.Add(layout);
        }
    }
}