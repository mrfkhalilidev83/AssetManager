namespace AssetManager.UI.Forms
{
    partial class DepositForm
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
            lblAssetType = new ReaLTaiizor.Controls.MaterialLabel();
            cmbAssetType = new ComboBox();
            lblAmount = new ReaLTaiizor.Controls.MaterialLabel();
            txtAmount = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            btnDeposit = new ReaLTaiizor.Controls.MaterialButton();
            btnCancel = new ReaLTaiizor.Controls.MaterialButton();
            materialLabel1 = new ReaLTaiizor.Controls.MaterialLabel();
            SuspendLayout();
            // 
            // lblAssetType
            // 
            lblAssetType.AutoSize = true;
            lblAssetType.Depth = 0;
            lblAssetType.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblAssetType.Location = new Point(150, 81);
            lblAssetType.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblAssetType.Name = "lblAssetType";
            lblAssetType.Size = new Size(79, 19);
            lblAssetType.TabIndex = 0;
            lblAssetType.Text = "Asset Type";
            // 
            // cmbAssetType
            // 
            cmbAssetType.FormattingEnabled = true;
            cmbAssetType.Location = new Point(91, 114);
            cmbAssetType.Name = "cmbAssetType";
            cmbAssetType.Size = new Size(198, 23);
            cmbAssetType.TabIndex = 1;
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Depth = 0;
            lblAmount.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblAmount.Location = new Point(160, 183);
            lblAmount.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(57, 19);
            lblAmount.TabIndex = 2;
            lblAmount.Text = "Amount";
            // 
            // txtAmount
            // 
            txtAmount.AnimateReadOnly = false;
            txtAmount.AutoCompleteMode = AutoCompleteMode.None;
            txtAmount.AutoCompleteSource = AutoCompleteSource.None;
            txtAmount.BackgroundImageLayout = ImageLayout.None;
            txtAmount.CharacterCasing = CharacterCasing.Normal;
            txtAmount.Depth = 0;
            txtAmount.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtAmount.HideSelection = true;
            txtAmount.LeadingIcon = null;
            txtAmount.Location = new Point(64, 218);
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
            txtAmount.TabIndex = 3;
            txtAmount.TabStop = false;
            txtAmount.TextAlign = HorizontalAlignment.Left;
            txtAmount.TrailingIcon = null;
            txtAmount.UseSystemPasswordChar = false;
            // 
            // btnDeposit
            // 
            btnDeposit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDeposit.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnDeposit.Depth = 0;
            btnDeposit.HighEmphasis = true;
            btnDeposit.Icon = null;
            btnDeposit.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnDeposit.Location = new Point(64, 317);
            btnDeposit.Margin = new Padding(4, 6, 4, 6);
            btnDeposit.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnDeposit.Name = "btnDeposit";
            btnDeposit.NoAccentTextColor = Color.Empty;
            btnDeposit.Size = new Size(81, 36);
            btnDeposit.TabIndex = 4;
            btnDeposit.Text = "Deposit";
            btnDeposit.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            btnDeposit.UseAccentColor = false;
            btnDeposit.UseVisualStyleBackColor = true;
            btnDeposit.Click += btnDeposit_Click;
            // 
            // btnCancel
            // 
            btnCancel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCancel.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnCancel.Depth = 0;
            btnCancel.HighEmphasis = true;
            btnCancel.Icon = null;
            btnCancel.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnCancel.Location = new Point(237, 317);
            btnCancel.Margin = new Padding(4, 6, 4, 6);
            btnCancel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnCancel.Name = "btnCancel";
            btnCancel.NoAccentTextColor = Color.Empty;
            btnCancel.Size = new Size(77, 36);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            btnCancel.UseAccentColor = false;
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(161, 15);
            materialLabel1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(55, 19);
            materialLabel1.TabIndex = 6;
            materialLabel1.Text = "Deposit";
            // 
            // DepositForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(389, 448);
            Controls.Add(materialLabel1);
            Controls.Add(btnCancel);
            Controls.Add(btnDeposit);
            Controls.Add(txtAmount);
            Controls.Add(lblAmount);
            Controls.Add(cmbAssetType);
            Controls.Add(lblAssetType);
            Name = "DepositForm";
            Text = "DepositForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ReaLTaiizor.Controls.MaterialLabel lblAssetType;
        private ComboBox cmbAssetType;
        private ReaLTaiizor.Controls.MaterialLabel lblAmount;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtAmount;
        private ReaLTaiizor.Controls.MaterialButton btnDeposit;
        private ReaLTaiizor.Controls.MaterialButton btnCancel;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel1;
    }
}