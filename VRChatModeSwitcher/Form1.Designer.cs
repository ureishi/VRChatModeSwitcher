﻿namespace VRChatModeSwitcher
{
    partial class VRChatModeSwitcher
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.labelLink = new System.Windows.Forms.Label();
            this.textBoxLink = new System.Windows.Forms.TextBox();
            this.buttonSelectVR = new System.Windows.Forms.Button();
            this.buttonSelectDesktop = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelParallel = new System.Windows.Forms.Label();
            this.intboxParallel = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.intboxParallel)).BeginInit();
            this.SuspendLayout();
            // 
            // labelLink
            // 
            this.labelLink.AutoSize = true;
            this.labelLink.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelLink.Location = new System.Drawing.Point(14, 11);
            this.labelLink.Name = "labelLink";
            this.labelLink.Size = new System.Drawing.Size(55, 15);
            this.labelLink.TabIndex = 0;
            this.labelLink.Text = "起動リンク";
            // 
            // textBoxLink
            // 
            this.textBoxLink.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLink.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxLink.Location = new System.Drawing.Point(16, 31);
            this.textBoxLink.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxLink.Multiline = true;
            this.textBoxLink.Name = "textBoxLink";
            this.textBoxLink.ReadOnly = true;
            this.textBoxLink.Size = new System.Drawing.Size(228, 158);
            this.textBoxLink.TabIndex = 1;
            // 
            // buttonSelectVR
            // 
            this.buttonSelectVR.Font = new System.Drawing.Font("Meiryo UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonSelectVR.Location = new System.Drawing.Point(16, 197);
            this.buttonSelectVR.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSelectVR.Name = "buttonSelectVR";
            this.buttonSelectVR.Size = new System.Drawing.Size(111, 50);
            this.buttonSelectVR.TabIndex = 2;
            this.buttonSelectVR.Text = "VR";
            this.buttonSelectVR.UseVisualStyleBackColor = true;
            // 
            // buttonSelectDesktop
            // 
            this.buttonSelectDesktop.Font = new System.Drawing.Font("Meiryo UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonSelectDesktop.Location = new System.Drawing.Point(133, 197);
            this.buttonSelectDesktop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSelectDesktop.Name = "buttonSelectDesktop";
            this.buttonSelectDesktop.Size = new System.Drawing.Size(111, 50);
            this.buttonSelectDesktop.TabIndex = 3;
            this.buttonSelectDesktop.Text = "Desktop";
            this.buttonSelectDesktop.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(169, 254);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // labelParallel
            // 
            this.labelParallel.AutoSize = true;
            this.labelParallel.Location = new System.Drawing.Point(14, 258);
            this.labelParallel.Name = "labelParallel";
            this.labelParallel.Size = new System.Drawing.Size(67, 15);
            this.labelParallel.TabIndex = 5;
            this.labelParallel.Text = "同時起動数";
            // 
            // intboxParallel
            // 
            this.intboxParallel.Location = new System.Drawing.Point(87, 254);
            this.intboxParallel.Name = "intboxParallel";
            this.intboxParallel.Size = new System.Drawing.Size(54, 23);
            this.intboxParallel.TabIndex = 6;
            this.intboxParallel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // VRChatModeSwitcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 287);
            this.Controls.Add(this.intboxParallel);
            this.Controls.Add(this.labelParallel);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSelectDesktop);
            this.Controls.Add(this.buttonSelectVR);
            this.Controls.Add(this.textBoxLink);
            this.Controls.Add(this.labelLink);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VRChatModeSwitcher";
            this.Text = "VRChat Mode Switcher";
            ((System.ComponentModel.ISupportInitialize)(this.intboxParallel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLink;
        private System.Windows.Forms.TextBox textBoxLink;
        private System.Windows.Forms.Button buttonSelectVR;
        private System.Windows.Forms.Button buttonSelectDesktop;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelParallel;
        private System.Windows.Forms.NumericUpDown intboxParallel;
    }
}
