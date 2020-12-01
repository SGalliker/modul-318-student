namespace MyTransportApp
{
    partial class MainForm
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
            this.txtStartStation = new System.Windows.Forms.TextBox();
            this.txtEndStation = new System.Windows.Forms.TextBox();
            this.lblStartStation = new System.Windows.Forms.Label();
            this.lblEndStation = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvSearchResults = new System.Windows.Forms.DataGridView();
            this.clmnStationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnEndStation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnDepartureTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnArrivalTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPlatform = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchResults)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStartStation
            // 
            this.txtStartStation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartStation.Location = new System.Drawing.Point(12, 57);
            this.txtStartStation.Name = "txtStartStation";
            this.txtStartStation.Size = new System.Drawing.Size(387, 30);
            this.txtStartStation.TabIndex = 0;
            // 
            // txtEndStation
            // 
            this.txtEndStation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndStation.Location = new System.Drawing.Point(452, 57);
            this.txtEndStation.Name = "txtEndStation";
            this.txtEndStation.Size = new System.Drawing.Size(387, 30);
            this.txtEndStation.TabIndex = 1;
            // 
            // lblStartStation
            // 
            this.lblStartStation.AutoSize = true;
            this.lblStartStation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartStation.Location = new System.Drawing.Point(12, 34);
            this.lblStartStation.Name = "lblStartStation";
            this.lblStartStation.Size = new System.Drawing.Size(95, 20);
            this.lblStartStation.TabIndex = 2;
            this.lblStartStation.Text = "Startstation";
            // 
            // lblEndStation
            // 
            this.lblEndStation.AutoSize = true;
            this.lblEndStation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndStation.Location = new System.Drawing.Point(448, 34);
            this.lblEndStation.Name = "lblEndStation";
            this.lblEndStation.Size = new System.Drawing.Size(88, 20);
            this.lblEndStation.TabIndex = 3;
            this.lblEndStation.Text = "Endstation";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(452, 130);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(102, 30);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvSearchResults
            // 
            this.dgvSearchResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSearchResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearchResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnStationName,
            this.clmnEndStation,
            this.clmnDepartureTime,
            this.clmnArrivalTime,
            this.clmnPlatform});
            this.dgvSearchResults.Location = new System.Drawing.Point(12, 166);
            this.dgvSearchResults.Name = "dgvSearchResults";
            this.dgvSearchResults.RowHeadersWidth = 51;
            this.dgvSearchResults.Size = new System.Drawing.Size(1199, 696);
            this.dgvSearchResults.TabIndex = 5;
            this.dgvSearchResults.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSearchResults_CellContentClick);
            // 
            // clmnStationName
            // 
            this.clmnStationName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnStationName.HeaderText = "Station";
            this.clmnStationName.MinimumWidth = 6;
            this.clmnStationName.Name = "clmnStationName";
            // 
            // clmnEndStation
            // 
            this.clmnEndStation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnEndStation.HeaderText = "Endstation";
            this.clmnEndStation.MinimumWidth = 6;
            this.clmnEndStation.Name = "clmnEndStation";
            // 
            // clmnDepartureTime
            // 
            this.clmnDepartureTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnDepartureTime.HeaderText = "Departure";
            this.clmnDepartureTime.MinimumWidth = 6;
            this.clmnDepartureTime.Name = "clmnDepartureTime";
            // 
            // clmnArrivalTime
            // 
            this.clmnArrivalTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnArrivalTime.HeaderText = "Arrival";
            this.clmnArrivalTime.MinimumWidth = 6;
            this.clmnArrivalTime.Name = "clmnArrivalTime";
            // 
            // clmnPlatform
            // 
            this.clmnPlatform.HeaderText = "Platform";
            this.clmnPlatform.MinimumWidth = 6;
            this.clmnPlatform.Name = "clmnPlatform";
            this.clmnPlatform.Width = 125;
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 874);
            this.Controls.Add(this.dgvSearchResults);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblEndStation);
            this.Controls.Add(this.lblStartStation);
            this.Controls.Add(this.txtEndStation);
            this.Controls.Add(this.txtStartStation);
            this.Name = "MainForm";
            this.Text = "MyTransport";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStartStation;
        private System.Windows.Forms.TextBox txtEndStation;
        private System.Windows.Forms.Label lblStartStation;
        private System.Windows.Forms.Label lblEndStation;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvSearchResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnStationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnEndStation;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnDepartureTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnArrivalTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnPlatform;
    }
}

