
namespace Lab3_hw
{
    partial class Schema_editor
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Schema_editor));
            this.schema_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.schema_panel = new System.Windows.Forms.Panel();
            this.schema_pictureBox = new System.Windows.Forms.PictureBox();
            this.file_groupBox = new System.Windows.Forms.GroupBox();
            this.loadschema_button = new System.Windows.Forms.Button();
            this.saveschema_button = new System.Windows.Forms.Button();
            this.newschema_button = new System.Windows.Forms.Button();
            this.edition_groupBox = new System.Windows.Forms.GroupBox();
            this.connectButton = new Lab3_hw.ConnectButton();
            this.trashButton = new Lab3_hw.TrashButton();
            this.decisionButton = new Lab3_hw.DecisionButton();
            this.operationButton = new Lab3_hw.OperationButton();
            this.endButton = new Lab3_hw.EndButton();
            this.startButton = new Lab3_hw.StartButton();
            this.blockTextLabel = new System.Windows.Forms.Label();
            this.blockTextBox = new System.Windows.Forms.RichTextBox();
            this.language_groupBox = new System.Windows.Forms.GroupBox();
            this.english_button = new System.Windows.Forms.Button();
            this.polish_button = new System.Windows.Forms.Button();
            this.schema_tableLayoutPanel.SuspendLayout();
            this.schema_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.schema_pictureBox)).BeginInit();
            this.file_groupBox.SuspendLayout();
            this.edition_groupBox.SuspendLayout();
            this.language_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // schema_tableLayoutPanel
            // 
            resources.ApplyResources(this.schema_tableLayoutPanel, "schema_tableLayoutPanel");
            this.schema_tableLayoutPanel.Controls.Add(this.schema_panel, 0, 0);
            this.schema_tableLayoutPanel.Controls.Add(this.file_groupBox, 1, 0);
            this.schema_tableLayoutPanel.Controls.Add(this.edition_groupBox, 1, 1);
            this.schema_tableLayoutPanel.Controls.Add(this.language_groupBox, 1, 2);
            this.schema_tableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.schema_tableLayoutPanel.Name = "schema_tableLayoutPanel";
            // 
            // schema_panel
            // 
            resources.ApplyResources(this.schema_panel, "schema_panel");
            this.schema_panel.Controls.Add(this.schema_pictureBox);
            this.schema_panel.Name = "schema_panel";
            this.schema_tableLayoutPanel.SetRowSpan(this.schema_panel, 3);
            // 
            // schema_pictureBox
            // 
            this.schema_pictureBox.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.schema_pictureBox, "schema_pictureBox");
            this.schema_pictureBox.Name = "schema_pictureBox";
            this.schema_pictureBox.TabStop = false;
            this.schema_pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.schema_pictureBox_Paint);
            this.schema_pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.schema_pictureBox_MouseDown);
            this.schema_pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.schema_pictureBox_MouseMove);
            this.schema_pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.schema_pictureBox_MouseUp);
            // 
            // file_groupBox
            // 
            this.file_groupBox.Controls.Add(this.loadschema_button);
            this.file_groupBox.Controls.Add(this.saveschema_button);
            this.file_groupBox.Controls.Add(this.newschema_button);
            resources.ApplyResources(this.file_groupBox, "file_groupBox");
            this.file_groupBox.Name = "file_groupBox";
            this.file_groupBox.TabStop = false;
            // 
            // loadschema_button
            // 
            resources.ApplyResources(this.loadschema_button, "loadschema_button");
            this.loadschema_button.Name = "loadschema_button";
            this.loadschema_button.UseVisualStyleBackColor = true;
            this.loadschema_button.Click += new System.EventHandler(this.loadschema_button_Click);
            // 
            // saveschema_button
            // 
            resources.ApplyResources(this.saveschema_button, "saveschema_button");
            this.saveschema_button.Name = "saveschema_button";
            this.saveschema_button.UseVisualStyleBackColor = true;
            this.saveschema_button.Click += new System.EventHandler(this.saveschema_button_Click);
            // 
            // newschema_button
            // 
            resources.ApplyResources(this.newschema_button, "newschema_button");
            this.newschema_button.Name = "newschema_button";
            this.newschema_button.UseVisualStyleBackColor = true;
            this.newschema_button.Click += new System.EventHandler(this.newschema_button_Click);
            // 
            // edition_groupBox
            // 
            this.edition_groupBox.Controls.Add(this.connectButton);
            this.edition_groupBox.Controls.Add(this.trashButton);
            this.edition_groupBox.Controls.Add(this.decisionButton);
            this.edition_groupBox.Controls.Add(this.operationButton);
            this.edition_groupBox.Controls.Add(this.endButton);
            this.edition_groupBox.Controls.Add(this.startButton);
            this.edition_groupBox.Controls.Add(this.blockTextLabel);
            this.edition_groupBox.Controls.Add(this.blockTextBox);
            resources.ApplyResources(this.edition_groupBox, "edition_groupBox");
            this.edition_groupBox.Name = "edition_groupBox";
            this.edition_groupBox.TabStop = false;
            // 
            // connectButton
            // 
            resources.ApplyResources(this.connectButton, "connectButton");
            this.connectButton.Name = "connectButton";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // trashButton
            // 
            resources.ApplyResources(this.trashButton, "trashButton");
            this.trashButton.Name = "trashButton";
            this.trashButton.UseVisualStyleBackColor = true;
            this.trashButton.Click += new System.EventHandler(this.trashButton_Click);
            // 
            // decisionButton
            // 
            resources.ApplyResources(this.decisionButton, "decisionButton");
            this.decisionButton.Name = "decisionButton";
            this.decisionButton.UseVisualStyleBackColor = true;
            this.decisionButton.Click += new System.EventHandler(this.decisionButton_Click);
            // 
            // operationButton
            // 
            resources.ApplyResources(this.operationButton, "operationButton");
            this.operationButton.Name = "operationButton";
            this.operationButton.UseVisualStyleBackColor = true;
            this.operationButton.Click += new System.EventHandler(this.operationButton_Click);
            // 
            // endButton
            // 
            resources.ApplyResources(this.endButton, "endButton");
            this.endButton.Name = "endButton";
            this.endButton.UseVisualStyleBackColor = true;
            this.endButton.Click += new System.EventHandler(this.endButton_Click);
            // 
            // startButton
            // 
            resources.ApplyResources(this.startButton, "startButton");
            this.startButton.Name = "startButton";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // blockTextLabel
            // 
            resources.ApplyResources(this.blockTextLabel, "blockTextLabel");
            this.blockTextLabel.Name = "blockTextLabel";
            // 
            // blockTextBox
            // 
            resources.ApplyResources(this.blockTextBox, "blockTextBox");
            this.blockTextBox.Name = "blockTextBox";
            this.blockTextBox.TextChanged += new System.EventHandler(this.blockTextBox_TextChanged);
            // 
            // language_groupBox
            // 
            this.language_groupBox.Controls.Add(this.english_button);
            this.language_groupBox.Controls.Add(this.polish_button);
            resources.ApplyResources(this.language_groupBox, "language_groupBox");
            this.language_groupBox.Name = "language_groupBox";
            this.language_groupBox.TabStop = false;
            // 
            // english_button
            // 
            resources.ApplyResources(this.english_button, "english_button");
            this.english_button.Name = "english_button";
            this.english_button.UseVisualStyleBackColor = true;
            this.english_button.Click += new System.EventHandler(this.english_button_Click);
            // 
            // polish_button
            // 
            resources.ApplyResources(this.polish_button, "polish_button");
            this.polish_button.Name = "polish_button";
            this.polish_button.UseVisualStyleBackColor = true;
            this.polish_button.Click += new System.EventHandler(this.polish_button_Click);
            // 
            // Schema_editor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.schema_tableLayoutPanel);
            this.Name = "Schema_editor";
            this.Load += new System.EventHandler(this.Schema_editor_Load);
            this.schema_tableLayoutPanel.ResumeLayout(false);
            this.schema_panel.ResumeLayout(false);
            this.schema_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.schema_pictureBox)).EndInit();
            this.file_groupBox.ResumeLayout(false);
            this.edition_groupBox.ResumeLayout(false);
            this.edition_groupBox.PerformLayout();
            this.language_groupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel schema_tableLayoutPanel;
        private System.Windows.Forms.Panel schema_panel;
        private System.Windows.Forms.PictureBox schema_pictureBox;
        private System.Windows.Forms.GroupBox file_groupBox;
        private System.Windows.Forms.GroupBox edition_groupBox;
        private System.Windows.Forms.GroupBox language_groupBox;
        private System.Windows.Forms.Button loadschema_button;
        private System.Windows.Forms.Button saveschema_button;
        private System.Windows.Forms.Button newschema_button;
        private System.Windows.Forms.Button english_button;
        private System.Windows.Forms.Button polish_button;
        private System.Windows.Forms.RichTextBox blockTextBox;
        private System.Windows.Forms.Label blockTextLabel;
        private StartButton startButton;
        private EndButton endButton;
        private OperationButton operationButton;
        private DecisionButton decisionButton;
        private TrashButton trashButton;
        private ConnectButton connectButton;
    }
}

