using System;
using System.Windows.Forms;

namespace MyVN
{
    public partial class MainForm : Form
    {
        private readonly Button _nextBtn;

        public MainForm()
        {
            // === пара настроек окна ===
            Text = "My Visual Novel";
            ClientSize = new System.Drawing.Size(800, 600);   // стартовый размер
            StartPosition = FormStartPosition.CenterScreen;

            // === создаём кнопку «Дальше» ===
            _nextBtn = new Button
            {
                Text = "Дальше",
                AutoSize = true,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right
            };
            // позиционируем после установки ClientSize,
            // чтобы кнопка прилипла к правому-нижнему краю
            _nextBtn.Location = new System.Drawing.Point(
                ClientSize.Width - _nextBtn.PreferredSize.Width - 20,
                ClientSize.Height - _nextBtn.PreferredSize.Height - 20);

            _nextBtn.Click += NextBtn_Click;

            // === добавляем контрол на форму ===
            Controls.Add(_nextBtn);
        }

        // обработчик клика
        private void NextBtn_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Здесь будет логика перехода");
        }
    }
}
