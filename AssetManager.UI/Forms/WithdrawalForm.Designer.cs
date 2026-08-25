namespace AssetManager.UI.Forms
{
    partial class WithdrawalForm
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
            lblAssetType = new ReaLTaiizor.Controls.MaterialLabel();
            lblAmount = new ReaLTaiizor.Controls.MaterialLabel();
            cmbAssetType = new ComboBox();
            txtAmount = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            btnWithdrawal = new ReaLTaiizor.Controls.MaterialButton();
            btnCancel = new ReaLTaiizor.Controls.MaterialButton();
            SuspendLayout();
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(151, 21);
            materialLabel1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(81, 19);
            materialLabel1.TabIndex = 0;
            materialLabel1.Text = "Withdrawal";
            // 
            // lblAssetType
            // 
            lblAssetType.AutoSize = true;
            lblAssetType.Depth = 0;
            lblAssetType.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblAssetType.Location = new Point(152, 115);
            lblAssetType.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblAssetType.Name = "lblAssetType";
            lblAssetType.Size = new Size(79, 19);
            lblAssetType.TabIndex = 1;
            lblAssetType.Text = "Asset Type";
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Depth = 0;
            lblAmount.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblAmount.Location = new Point(163, 222);
            lblAmount.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(57, 19);
            lblAmount.TabIndex = 2;
            lblAmount.Text = "Amount";
            // 
            // cmbAssetType
            // 
            cmbAssetType.FormattingEnabled = true;
            cmbAssetType.Location = new Point(94, 147);
            cmbAssetType.Name = "cmbAssetType";
            cmbAssetType.Size = new Size(198, 23);
            cmbAssetType.TabIndex = 3;
            // 
            // txtAmount
            // 
            txtAmount.AnimateReadOnly = false;
            txtAmount.AutoCompleteMode = AutoCompleteMode.None;
            txtAmount.AutoCompleteSource = AutoCompleteSource.None;
            txtAmount.BackgroundImageLayout = ImageLayout.None;
            txtAmount.CharacterCasing = CharacterCasing.Normal;
            txtAmount.Depth = 0;
            txtAmount.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtAmount.HideSelection = true;
            txtAmount.LeadingIcon = null;
            txtAmount.Location = new Point(66, 254);
            txtAmount.MaxLength = 32767;
            txtAmount.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtAmount.Name = "txtAmount";
            txtAmount.PasswordChar = '\0';
            txtAmount.PrefixSuffixText = null;
            txtAmount.ReadOnly = false;
            txtAmount.RightToLeft = RightToLeft.No;
            txtAmount.SelectedText = "";
            txtAmount.SelectionLength = 0;
            txtAmount.SelectionStart = 0;
            txtAmount.ShortcutsEnabled = true;
            txtAmount.Size = new Size(250, 48);
            txtAmount.TabIndex = 4;
            txtAmount.TabStop = false;
            txtAmount.TextAlign = HorizontalAlignment.Left;
            txtAmount.TrailingIcon = null;
            txtAmount.UseSystemPasswordChar = false;
            // 
            // btnWithdrawal
            // 
            btnWithdrawal.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnWithdrawal.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnWithdrawal.Depth = 0;
            btnWithdrawal.HighEmphasis = true;
            btnWithdrawal.Icon = null;
            btnWithdrawal.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnWithdrawal.Location = new Point(66, 331);
            btnWithdrawal.Margin = new Padding(4, 6, 4, 6);
            btnWithdrawal.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnWithdrawal.Name = "btnWithdrawal";
            btnWithdrawal.NoAccentTextColor = Color.Empty;
            btnWithdrawal.Size = new Size(117, 36);
            btnWithdrawal.TabIndex = 5;
            btnWithdrawal.Text = "Withdrawal";
            btnWithdrawal.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            btnWithdrawal.UseAccentColor = false;
            btnWithdrawal.UseVisualStyleBackColor = true;
            btnWithdrawal.Click += btnWithdrawal_Click;
            // 
            // btnCancel
            // 
            btnCancel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCancel.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnCancel.Depth = 0;
            btnCancel.HighEmphasis = true;
            btnCancel.Icon = null;
            btnCancel.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnCancel.Location = new Point(239, 331);
            btnCancel.Margin = new Padding(4, 6, 4, 6);
            btnCancel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnCancel.Name = "btnCancel";
            btnCancel.NoAccentTextColor = Color.Empty;
            btnCancel.Size = new Size(77, 36);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            btnCancel.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            btnCancel.UseAccentColor = false;
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // WithdrawalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(389, 448);
            Controls.Add(btnCancel);
            Controls.Add(btnWithdrawal);
            Controls.Add(txtAmount);
            Controls.Add(cmbAssetType);
            Controls.Add(lblAmount);
            Controls.Add(lblAssetType);
            Controls.Add(materialLabel1);
            Name = "WithdrawalForm";
            Text = "WithdrawalForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ReaLTaiizor.Controls.MaterialLabel materialLabel1;
        private ReaLTaiizor.Controls.MaterialLabel lblAssetType;
        private ReaLTaiizor.Controls.MaterialLabel lblAmount;
        private ComboBox cmbAssetType;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtAmount;
        private ReaLTaiizor.Controls.MaterialButton btnWithdrawal;
        private ReaLTaiizor.Controls.MaterialButton btnCancel;
    }
}