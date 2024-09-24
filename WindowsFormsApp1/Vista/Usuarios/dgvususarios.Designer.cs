namespace WindowsFormsApp1.Vista.Usuarios
{
    partial class dgvususarios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dgvususarios));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvusuario = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCrearUsuario = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.btnEliminar = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.btnEditar = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvusuario)).BeginInit();
            this.bunifuPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvusuario, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.bunifuPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.04605F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.94703F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.00692F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1946, 1106);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvusuario
            // 
            this.dgvusuario.AllowCustomTheming = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvusuario.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvusuario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvusuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvusuario.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvusuario.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvusuario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvusuario.ColumnHeadersHeight = 40;
            this.dgvusuario.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.dgvusuario.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvusuario.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvusuario.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dgvusuario.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvusuario.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.dgvusuario.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgvusuario.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.dgvusuario.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.dgvusuario.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvusuario.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.dgvusuario.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvusuario.CurrentTheme.Name = null;
            this.dgvusuario.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvusuario.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvusuario.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvusuario.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dgvusuario.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvusuario.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvusuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvusuario.EnableHeadersVisualStyles = false;
            this.dgvusuario.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgvusuario.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.dgvusuario.HeaderBgColor = System.Drawing.Color.Empty;
            this.dgvusuario.HeaderForeColor = System.Drawing.Color.White;
            this.dgvusuario.Location = new System.Drawing.Point(4, 413);
            this.dgvusuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvusuario.Name = "dgvusuario";
            this.dgvusuario.ReadOnly = true;
            this.dgvusuario.RowHeadersVisible = false;
            this.dgvusuario.RowHeadersWidth = 62;
            this.dgvusuario.RowTemplate.Height = 40;
            this.dgvusuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvusuario.Size = new System.Drawing.Size(1938, 688);
            this.dgvusuario.TabIndex = 30;
            this.dgvusuario.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // bunifuPanel1
            // 
            this.bunifuPanel1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.bunifuPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel1.BackgroundImage")));
            this.bunifuPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuPanel1.BorderRadius = 3;
            this.bunifuPanel1.BorderThickness = 1;
            this.bunifuPanel1.Controls.Add(this.label10);
            this.bunifuPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuPanel1.Location = new System.Drawing.Point(4, 5);
            this.bunifuPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bunifuPanel1.Name = "bunifuPanel1";
            this.bunifuPanel1.ShowBorders = true;
            this.bunifuPanel1.Size = new System.Drawing.Size(1938, 200);
            this.bunifuPanel1.TabIndex = 28;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.label10.Font = new System.Drawing.Font("MS Reference Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Location = new System.Drawing.Point(758, 41);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(426, 102);
            this.label10.TabIndex = 38;
            this.label10.Text = "Administración de \r\nUsuarios\r\n";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.btnCrearUsuario, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnEliminar, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnEditar, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 215);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1938, 188);
            this.tableLayoutPanel2.TabIndex = 29;
            // 
            // btnCrearUsuario
            // 
            this.btnCrearUsuario.AllowAnimations = true;
            this.btnCrearUsuario.AllowMouseEffects = true;
            this.btnCrearUsuario.AllowToggling = false;
            this.btnCrearUsuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCrearUsuario.AnimationSpeed = 200;
            this.btnCrearUsuario.AutoGenerateColors = false;
            this.btnCrearUsuario.AutoRoundBorders = false;
            this.btnCrearUsuario.AutoSizeLeftIcon = true;
            this.btnCrearUsuario.AutoSizeRightIcon = true;
            this.btnCrearUsuario.BackColor = System.Drawing.Color.Transparent;
            this.btnCrearUsuario.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(18)))), ((int)(((byte)(48)))));
            this.btnCrearUsuario.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCrearUsuario.BackgroundImage")));
            this.btnCrearUsuario.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnCrearUsuario.ButtonText = "Agregar nuevo Usuario";
            this.btnCrearUsuario.ButtonTextMarginLeft = 0;
            this.btnCrearUsuario.ColorContrastOnClick = 45;
            this.btnCrearUsuario.ColorContrastOnHover = 45;
            this.btnCrearUsuario.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnCrearUsuario.CustomizableEdges = borderEdges1;
            this.btnCrearUsuario.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCrearUsuario.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnCrearUsuario.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnCrearUsuario.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnCrearUsuario.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnCrearUsuario.Font = new System.Drawing.Font("Yu Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearUsuario.ForeColor = System.Drawing.Color.White;
            this.btnCrearUsuario.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCrearUsuario.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnCrearUsuario.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnCrearUsuario.IconMarginLeft = 11;
            this.btnCrearUsuario.IconPadding = 10;
            this.btnCrearUsuario.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCrearUsuario.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnCrearUsuario.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnCrearUsuario.IconSize = 25;
            this.btnCrearUsuario.IdleBorderColor = System.Drawing.Color.Transparent;
            this.btnCrearUsuario.IdleBorderRadius = 20;
            this.btnCrearUsuario.IdleBorderThickness = 1;
            this.btnCrearUsuario.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(18)))), ((int)(((byte)(48)))));
            this.btnCrearUsuario.IdleIconLeftImage = null;
            this.btnCrearUsuario.IdleIconRightImage = null;
            this.btnCrearUsuario.IndicateFocus = false;
            this.btnCrearUsuario.Location = new System.Drawing.Point(1421, 65);
            this.btnCrearUsuario.Name = "btnCrearUsuario";
            this.btnCrearUsuario.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnCrearUsuario.OnDisabledState.BorderRadius = 20;
            this.btnCrearUsuario.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnCrearUsuario.OnDisabledState.BorderThickness = 1;
            this.btnCrearUsuario.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnCrearUsuario.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnCrearUsuario.OnDisabledState.IconLeftImage = null;
            this.btnCrearUsuario.OnDisabledState.IconRightImage = null;
            this.btnCrearUsuario.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnCrearUsuario.onHoverState.BorderRadius = 20;
            this.btnCrearUsuario.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnCrearUsuario.onHoverState.BorderThickness = 1;
            this.btnCrearUsuario.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnCrearUsuario.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnCrearUsuario.onHoverState.IconLeftImage = null;
            this.btnCrearUsuario.onHoverState.IconRightImage = null;
            this.btnCrearUsuario.OnIdleState.BorderColor = System.Drawing.Color.Transparent;
            this.btnCrearUsuario.OnIdleState.BorderRadius = 20;
            this.btnCrearUsuario.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnCrearUsuario.OnIdleState.BorderThickness = 1;
            this.btnCrearUsuario.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(18)))), ((int)(((byte)(48)))));
            this.btnCrearUsuario.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnCrearUsuario.OnIdleState.IconLeftImage = null;
            this.btnCrearUsuario.OnIdleState.IconRightImage = null;
            this.btnCrearUsuario.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnCrearUsuario.OnPressedState.BorderRadius = 20;
            this.btnCrearUsuario.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnCrearUsuario.OnPressedState.BorderThickness = 1;
            this.btnCrearUsuario.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnCrearUsuario.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnCrearUsuario.OnPressedState.IconLeftImage = null;
            this.btnCrearUsuario.OnPressedState.IconRightImage = null;
            this.btnCrearUsuario.Size = new System.Drawing.Size(388, 58);
            this.btnCrearUsuario.TabIndex = 29;
            this.btnCrearUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCrearUsuario.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnCrearUsuario.TextMarginLeft = 0;
            this.btnCrearUsuario.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnCrearUsuario.UseDefaultRadiusAndThickness = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.AllowAnimations = true;
            this.btnEliminar.AllowMouseEffects = true;
            this.btnEliminar.AllowToggling = false;
            this.btnEliminar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEliminar.AnimationSpeed = 200;
            this.btnEliminar.AutoGenerateColors = false;
            this.btnEliminar.AutoRoundBorders = false;
            this.btnEliminar.AutoSizeLeftIcon = true;
            this.btnEliminar.AutoSizeRightIcon = true;
            this.btnEliminar.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminar.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(18)))), ((int)(((byte)(48)))));
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnEliminar.ButtonText = "Eliminar";
            this.btnEliminar.ButtonTextMarginLeft = 0;
            this.btnEliminar.ColorContrastOnClick = 45;
            this.btnEliminar.ColorContrastOnHover = 45;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btnEliminar.CustomizableEdges = borderEdges2;
            this.btnEliminar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnEliminar.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnEliminar.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnEliminar.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnEliminar.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnEliminar.Font = new System.Drawing.Font("Yu Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnEliminar.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnEliminar.IconMarginLeft = 11;
            this.btnEliminar.IconPadding = 10;
            this.btnEliminar.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnEliminar.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnEliminar.IconSize = 25;
            this.btnEliminar.IdleBorderColor = System.Drawing.Color.Transparent;
            this.btnEliminar.IdleBorderRadius = 20;
            this.btnEliminar.IdleBorderThickness = 1;
            this.btnEliminar.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(18)))), ((int)(((byte)(48)))));
            this.btnEliminar.IdleIconLeftImage = null;
            this.btnEliminar.IdleIconRightImage = null;
            this.btnEliminar.IndicateFocus = false;
            this.btnEliminar.Location = new System.Drawing.Point(847, 65);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnEliminar.OnDisabledState.BorderRadius = 20;
            this.btnEliminar.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnEliminar.OnDisabledState.BorderThickness = 1;
            this.btnEliminar.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnEliminar.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnEliminar.OnDisabledState.IconLeftImage = null;
            this.btnEliminar.OnDisabledState.IconRightImage = null;
            this.btnEliminar.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnEliminar.onHoverState.BorderRadius = 20;
            this.btnEliminar.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnEliminar.onHoverState.BorderThickness = 1;
            this.btnEliminar.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnEliminar.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.onHoverState.IconLeftImage = null;
            this.btnEliminar.onHoverState.IconRightImage = null;
            this.btnEliminar.OnIdleState.BorderColor = System.Drawing.Color.Transparent;
            this.btnEliminar.OnIdleState.BorderRadius = 20;
            this.btnEliminar.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnEliminar.OnIdleState.BorderThickness = 1;
            this.btnEliminar.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(18)))), ((int)(((byte)(48)))));
            this.btnEliminar.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.OnIdleState.IconLeftImage = null;
            this.btnEliminar.OnIdleState.IconRightImage = null;
            this.btnEliminar.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnEliminar.OnPressedState.BorderRadius = 20;
            this.btnEliminar.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnEliminar.OnPressedState.BorderThickness = 1;
            this.btnEliminar.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnEliminar.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.OnPressedState.IconLeftImage = null;
            this.btnEliminar.OnPressedState.IconRightImage = null;
            this.btnEliminar.Size = new System.Drawing.Size(243, 58);
            this.btnEliminar.TabIndex = 28;
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEliminar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnEliminar.TextMarginLeft = 0;
            this.btnEliminar.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnEliminar.UseDefaultRadiusAndThickness = true;
            // 
            // btnEditar
            // 
            this.btnEditar.AllowAnimations = true;
            this.btnEditar.AllowMouseEffects = true;
            this.btnEditar.AllowToggling = false;
            this.btnEditar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEditar.AnimationSpeed = 200;
            this.btnEditar.AutoGenerateColors = false;
            this.btnEditar.AutoRoundBorders = false;
            this.btnEditar.AutoSizeLeftIcon = true;
            this.btnEditar.AutoSizeRightIcon = true;
            this.btnEditar.BackColor = System.Drawing.Color.Transparent;
            this.btnEditar.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(18)))), ((int)(((byte)(48)))));
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnEditar.ButtonText = "Editar Usuario";
            this.btnEditar.ButtonTextMarginLeft = 0;
            this.btnEditar.ColorContrastOnClick = 45;
            this.btnEditar.ColorContrastOnHover = 45;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges3.BottomLeft = true;
            borderEdges3.BottomRight = true;
            borderEdges3.TopLeft = true;
            borderEdges3.TopRight = true;
            this.btnEditar.CustomizableEdges = borderEdges3;
            this.btnEditar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnEditar.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnEditar.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnEditar.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnEditar.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnEditar.Font = new System.Drawing.Font("Yu Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnEditar.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnEditar.IconMarginLeft = 11;
            this.btnEditar.IconPadding = 10;
            this.btnEditar.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditar.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnEditar.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnEditar.IconSize = 25;
            this.btnEditar.IdleBorderColor = System.Drawing.Color.Transparent;
            this.btnEditar.IdleBorderRadius = 20;
            this.btnEditar.IdleBorderThickness = 1;
            this.btnEditar.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(18)))), ((int)(((byte)(48)))));
            this.btnEditar.IdleIconLeftImage = null;
            this.btnEditar.IdleIconRightImage = null;
            this.btnEditar.IndicateFocus = false;
            this.btnEditar.Location = new System.Drawing.Point(168, 61);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnEditar.OnDisabledState.BorderRadius = 20;
            this.btnEditar.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnEditar.OnDisabledState.BorderThickness = 1;
            this.btnEditar.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnEditar.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnEditar.OnDisabledState.IconLeftImage = null;
            this.btnEditar.OnDisabledState.IconRightImage = null;
            this.btnEditar.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnEditar.onHoverState.BorderRadius = 20;
            this.btnEditar.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnEditar.onHoverState.BorderThickness = 1;
            this.btnEditar.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnEditar.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnEditar.onHoverState.IconLeftImage = null;
            this.btnEditar.onHoverState.IconRightImage = null;
            this.btnEditar.OnIdleState.BorderColor = System.Drawing.Color.Transparent;
            this.btnEditar.OnIdleState.BorderRadius = 20;
            this.btnEditar.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnEditar.OnIdleState.BorderThickness = 1;
            this.btnEditar.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(18)))), ((int)(((byte)(48)))));
            this.btnEditar.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnEditar.OnIdleState.IconLeftImage = null;
            this.btnEditar.OnIdleState.IconRightImage = null;
            this.btnEditar.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnEditar.OnPressedState.BorderRadius = 20;
            this.btnEditar.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnEditar.OnPressedState.BorderThickness = 1;
            this.btnEditar.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnEditar.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnEditar.OnPressedState.IconLeftImage = null;
            this.btnEditar.OnPressedState.IconRightImage = null;
            this.btnEditar.Size = new System.Drawing.Size(310, 65);
            this.btnEditar.TabIndex = 27;
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEditar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnEditar.TextMarginLeft = 0;
            this.btnEditar.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnEditar.UseDefaultRadiusAndThickness = true;
            // 
            // dgvususarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1946, 1106);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "dgvususarios";
            this.Text = "dgvususarios";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvusuario)).EndInit();
            this.bunifuPanel1.ResumeLayout(false);
            this.bunifuPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
        public System.Windows.Forms.Label label10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnEditar;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnEliminar;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnCrearUsuario;
        public Bunifu.UI.WinForms.BunifuDataGridView dgvusuario;
    }
}