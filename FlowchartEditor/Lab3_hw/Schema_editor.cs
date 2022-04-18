using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Lab3_hw
{
    public partial class Schema_editor : Form
    {
        
        private Bitmap drawArea;
        private Blocks_handler bh;

        private BlockType currentBlock;
        private ActionType currentAction;
        private Point lastMouseLocation;

        private bool drawingConnection;
        private bool movingBlock;
        private ConnectionPoint connectionOrigin;

        private Button[] actionButtons;


        public Schema_editor()
        {
            InitializeComponent();
            drawArea = new Bitmap(schema_pictureBox.Size.Width, schema_pictureBox.Size.Height);
            schema_pictureBox.Image = drawArea;
            bh = new Blocks_handler();

            currentAction = ActionType.None;
            lastMouseLocation = new Point(0, 0);
            drawingConnection = false;
            movingBlock = false;
            
            actionButtons = new Button[] { decisionButton, operationButton, startButton, endButton, trashButton, connectButton };
        }

        private void Schema_editor_Load(object sender, EventArgs e)
        {
            
        }

        #region PICTURE BOX HANDLERS
        private void schema_pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            bh.DrawBlocks(g);

            if (drawingConnection)
            {
                g.DrawLine(Toolbox.arrowPen,
                    connectionOrigin.RelativePosition.X + connectionOrigin.owner.Position.X,
                    connectionOrigin.RelativePosition.Y + connectionOrigin.owner.Position.Y,
                    schema_pictureBox.PointToClient(MousePosition).X,
                    schema_pictureBox.PointToClient(MousePosition).Y
                );
            }
        }

        private void schema_pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    PerformLMBAction(sender, e);
                    break;
                case MouseButtons.Right:
                    PerformRMBAction(sender, e);
                    break;
                case MouseButtons.Middle:
                    if (bh.ActiveBlock != null && drawingConnection == false)
                        movingBlock = true;
                    break;
            }
        }

        private void schema_pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (drawingConnection)
                    {
                        // Try connecting 
                        ConnectionPoint connectionTarget = bh.GetConnectionPointAtPosition(e.Location);
                        if (connectionTarget != null && connectionTarget.InUse == false && connectionTarget.EndPoint == EndPoint.In)
                            Connection.CreateConnection(connectionOrigin, connectionTarget);
                    }
                    drawingConnection = false;
                    schema_pictureBox.Invalidate();
                    break;
                case MouseButtons.Middle:
                    movingBlock = false;
                    break;
            }
            
        }

        private void schema_pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            Point mouseLocationDelta = new Point(e.X - lastMouseLocation.X, e.Y - lastMouseLocation.Y);
            lastMouseLocation = e.Location;

            switch (e.Button)
            {
                case MouseButtons.Middle:
                    MoveActiveBlock(mouseLocationDelta);
                    break;
                case MouseButtons.Left:
                    break;
            }

            if (drawingConnection)
                schema_pictureBox.Invalidate();


        }

        #endregion

        #region SCHEMA MANAGEMENT HANDLERS
        private void newschema_button_Click(object sender, EventArgs e)
        {
            HighlightActionButton(null);

            New_schema size_form = new New_schema();
            if (size_form.ShowDialog() == DialogResult.OK)
            {
                ResizePictureBox(new Size((int)size_form.new_width, (int)size_form.new_height));
            }
            bh = new Blocks_handler();

        }

        private void saveschema_button_Click(object sender, EventArgs e)
        {
            HighlightActionButton(null);

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
            sfd.FilterIndex = 1;


            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            StreamWriter fileStream = new StreamWriter(sfd.OpenFile());
            if (fileStream == null)
                return;

            SchemaData schemaData = new SchemaData(schema_pictureBox.Size, bh.GetBlockData());
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(schemaData, options);
            fileStream.Write(json);
            MessageBox.Show(Properties.strings.FileSavedMessage, Properties.strings.FileSavedCaption, 
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            fileStream.Close();
        }

        private void loadschema_button_Click(object sender, EventArgs e)
        {
            HighlightActionButton(null);

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
            ofd.FilterIndex = 1;

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            StreamReader fileStream = new StreamReader(ofd.OpenFile());
            if (fileStream == null)
                return;

            string json = fileStream.ReadToEnd();
            ParseJson(json);
            fileStream.Close();

            schema_pictureBox.Invalidate();
        }

        #endregion

        #region ACTION PANEL HANDLERS

        private void startButton_Click(object sender, EventArgs e)
        {
            HighlightActionButton(startButton);
            currentAction = ActionType.PlaceBlock;
            currentBlock = BlockType.StartBlock;
        }

        private void endButton_Click(object sender, EventArgs e)
        {
            HighlightActionButton(endButton);
            currentAction = ActionType.PlaceBlock;
            currentBlock = BlockType.EndBlock;
        }

        private void operationButton_Click(object sender, EventArgs e)
        {
            HighlightActionButton(operationButton);
            currentAction = ActionType.PlaceBlock;
            currentBlock = BlockType.OperationBlock;
        }

        private void decisionButton_Click(object sender, EventArgs e)
        {
            HighlightActionButton(decisionButton);
            currentAction = ActionType.PlaceBlock;
            currentBlock = BlockType.DecisionBlock;
        }

        private void trashButton_Click(object sender, EventArgs e)
        {
            HighlightActionButton(trashButton);
            currentAction = ActionType.RemoveBlock;
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            HighlightActionButton(connectButton);
            currentAction = ActionType.ConnectBlocks;
        }

        #endregion

        #region UTILITY METHODS

        public void MoveActiveBlock(Point mouseLocationDelta)
        {
            if (bh.ActiveBlock == null)
                return;

            bh.ActiveBlock.Move(mouseLocationDelta.X, mouseLocationDelta.Y, schema_pictureBox.Size);
            schema_pictureBox.Invalidate();
        }

        public void HighlightActionButton(Button buttonToHighlight)
        {
            foreach (Button b in actionButtons)
            {
                b.BackColor = SystemColors.ButtonFace;
            }
            if (buttonToHighlight != null)
                buttonToHighlight.BackColor = SystemColors.ButtonHighlight;
        }

        public void PerformLMBAction(object sender, MouseEventArgs e)
        {
            switch (currentAction)
            {
                case ActionType.PlaceBlock:
                    if (bh.ActiveBlock != null && movingBlock == true)
                        break; // Do not permit removing blocks while moving another

                    if (currentBlock == BlockType.StartBlock && bh.HasStartBlock)
                    {
                        MessageBox.Show(Properties.strings.StartBlockPresentMessage, Properties.strings.StartBlockPresentCaption, 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break; // If trying to place a start block but one is already present
                    }
                        

                    bh.AddBlock(Block.GetBlockOfType(currentBlock, e.Location, schema_pictureBox.Size));
                    break;
                case ActionType.RemoveBlock:
                    if (bh.ActiveBlock != null && movingBlock == true)
                        break; // Do not permit removing blocks while moving another

                    Block blockToRemove = bh.GetBlockAtPosition(e.Location);
                    if (blockToRemove == null)
                        break;
                    bh.RemoveBlock(blockToRemove);
                    UpdateTextBox();
                    break;
                case ActionType.ConnectBlocks:
                    connectionOrigin = bh.GetConnectionPointAtPosition(e.Location);
                    if (connectionOrigin == null || connectionOrigin.InUse == true || connectionOrigin.EndPoint == EndPoint.In)
                        break;
                    drawingConnection = true;
                    break;
            }
            schema_pictureBox.Invalidate();
        }

        public void PerformRMBAction(object sender, MouseEventArgs e)
        {
            Block blockToEdit = bh.GetBlockAtPosition(e.Location);
            bh.ActiveBlock = blockToEdit;

            UpdateTextBox();
            schema_pictureBox.Invalidate();
        }

        public void UpdateTextBox()
        {
            if (bh.ActiveBlock == null || bh.ActiveBlock is Start_block || bh.ActiveBlock is End_block)
            {
                blockTextBox.Text = string.Empty;
                blockTextBox.Enabled = false;
                return;
            }

            blockTextBox.Enabled = true;
            blockTextBox.Text = bh.ActiveBlock.Text;

        }

        public void ParseJson(string json)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            try
            {
                SchemaData schemaData = (SchemaData)JsonSerializer.Deserialize(json, typeof(SchemaData), options);
                if (bh.TryLoadBlockData(schemaData.BlockData) == false)
                    throw new Exception();
                MessageBox.Show(Properties.strings.FileLoadedMessage, Properties.strings.FileLoadedCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResizePictureBox(schemaData.Size);

            }
            catch
            {
                MessageBox.Show(Properties.strings.FileLoadingErrorMessage, Properties.strings.FileLoadingErrorCaption, 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        public void ResizePictureBox(Size newSize)
        {
            SuspendLayout();
            schema_pictureBox.Size = newSize;
            drawArea = new Bitmap(schema_pictureBox.Size.Width, schema_pictureBox.Size.Height);
            schema_pictureBox.Image = drawArea;
            ResumeLayout();
        }

        #endregion

        private void blockTextBox_TextChanged(object sender, EventArgs e)
        {
            // if text was changed then the textbox must have been enabled which means
            // there is an active block. But just for the sake of it we will check if it's not null
            if (bh.ActiveBlock == null)
                return;

            if (bh.ActiveBlock.GetBlockType() == BlockType.StartBlock || bh.ActiveBlock.GetBlockType() == BlockType.EndBlock)
                return;

            bh.ActiveBlock.Text = blockTextBox.Text;
            schema_pictureBox.Invalidate();
        }

        #region LANGUAGE
        private void polish_button_Click(object sender, EventArgs e)
        {
            ChangeLanguage("pl-PL");
        }

        private void english_button_Click(object sender, EventArgs e)
        {
            ChangeLanguage("en-GB");
        }

        private void ChangeLanguage(string languageCode)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(languageCode);
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Schema_editor));

            foreach (Control groupBox in schema_tableLayoutPanel.Controls)
            {
                resources.ApplyResources(groupBox, groupBox.Name, new CultureInfo(languageCode));
                foreach (Control c in groupBox.Controls)
                {
                    resources.ApplyResources(c, c.Name, new CultureInfo(languageCode));
                }
            }
        }

        #endregion


    }




}
