namespace AssetManager.UI.Forms
{
    partial class TransactionHistoryForm
    {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            materialLabel1 = new ReaLTaiizor.Controls.MaterialLabel();
            dgvTransactions = new DataGridView();
            btnClose = new ReaLTaiizor.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            SuspendLayout();
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(217, 35);
            materialLabel1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(140, 19);
            materialLabel1.TabIndex = 0;
            materialLabel1.Text = "Transaction History";
            // 
            // dgvTransactions
            // 
            dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransactions.Location = new Point(52, 79);
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.Size = new Size(466, 182);
            dgvTransactions.TabIndex = 1;
            // 
            // btnClose
            // 
            btnClose.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnClose.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnClose.Depth = 0;
            btnClose.HighEmphasis = true;
            btnClose.Icon = null;
            btnClose.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnClose.Location = new Point(250, 274);
            btnClose.Margin = new Padding(4, 6, 4, 6);
            btnClose.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnClose.Name = "btnClose";
            btnClose.NoAccentTextColor = Color.Empty;
            btnClose.Size = new Size(66, 36);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            btnClose.UseAccentColor = false;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // TransactionHistoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(595, 320);
            Controls.Add(btnClose);
            Controls.Add(dgvTransactions);
            Controls.Add(materialLabel1);
            Name = "TransactionHistoryForm";
            Text = "TransactionHistoryForm";
            Load += TransactionHistoryForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ReaLTaiizor.Controls.MaterialLabel materialLabel1;
        private DataGridView dgvTransactions;
        private ReaLTaiizor.Controls.MaterialButton btnClose;
    }
}