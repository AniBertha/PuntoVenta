namespace PuntoDeVenta
{
    partial class FormLogin
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.linea = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picPswd = new System.Windows.Forms.PictureBox();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.lblPswd = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.panelSombra = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPswd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(154, 58);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(100, 20);
            this.txtUser.TabIndex = 0;
            this.txtUser.Tag = "";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(154, 109);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(100, 20);
            this.txtPwd.TabIndex = 1;
            this.txtPwd.UseSystemPasswordChar = true;
            // 
            // linea
            // 
            this.linea.BackColor = System.Drawing.Color.SlateGray;
            this.linea.Enabled = false;
            this.linea.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.linea.FlatAppearance.BorderSize = 0;
            this.linea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.linea.ForeColor = System.Drawing.SystemColors.ControlText;
            this.linea.Location = new System.Drawing.Point(0, 200);
            this.linea.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.linea.Name = "linea";
            this.linea.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.linea.Size = new System.Drawing.Size(500, 78);
            this.linea.TabIndex = 6;
            this.linea.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.picPswd);
            this.panel1.Controls.Add(this.picUser);
            this.panel1.Controls.Add(this.lblPswd);
            this.panel1.Controls.Add(this.lblUser);
            this.panel1.Controls.Add(this.btnIngresar);
            this.panel1.Controls.Add(this.txtPwd);
            this.panel1.Controls.Add(this.txtUser);
            this.panel1.Location = new System.Drawing.Point(101, 47);
            this.panel1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 200);
            this.panel1.TabIndex = 8;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // picPswd
            // 
            this.picPswd.Image = global::PuntoDeVenta.Properties.Resources.password;
            this.picPswd.Location = new System.Drawing.Point(49, 110);
            this.picPswd.Name = "picPswd";
            this.picPswd.Size = new System.Drawing.Size(16, 16);
            this.picPswd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picPswd.TabIndex = 6;
            this.picPswd.TabStop = false;
            // 
            // picUser
            // 
            this.picUser.Image = global::PuntoDeVenta.Properties.Resources.user;
            this.picUser.Location = new System.Drawing.Point(49, 58);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(16, 16);
            this.picUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picUser.TabIndex = 5;
            this.picUser.TabStop = false;
            // 
            // lblPswd
            // 
            this.lblPswd.AutoSize = true;
            this.lblPswd.BackColor = System.Drawing.Color.Transparent;
            this.lblPswd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPswd.Location = new System.Drawing.Point(71, 110);
            this.lblPswd.Name = "lblPswd";
            this.lblPswd.Size = new System.Drawing.Size(77, 16);
            this.lblPswd.TabIndex = 4;
            this.lblPswd.Text = "Contraseña";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.BackColor = System.Drawing.Color.Transparent;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(71, 58);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(69, 16);
            this.lblUser.TabIndex = 3;
            this.lblUser.Text = "Id Usuario";
            this.lblUser.Click += new System.EventHandler(this.lblUser_Click);
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.YellowGreen;
            this.btnIngresar.BackgroundImage = global::PuntoDeVenta.Properties.Resources.comprobado1;
            this.btnIngresar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnIngresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIngresar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnIngresar.FlatAppearance.BorderSize = 0;
            this.btnIngresar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnIngresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.ForeColor = System.Drawing.Color.Black;
            this.btnIngresar.Location = new System.Drawing.Point(125, 153);
            this.btnIngresar.Margin = new System.Windows.Forms.Padding(0);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(50, 37);
            this.btnIngresar.TabIndex = 2;
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.BackColor = System.Drawing.Color.SlateGray;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblError.Location = new System.Drawing.Point(12, 253);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(478, 15);
            this.lblError.TabIndex = 9;
            this.lblError.Text = "Datos incorrectos, asegúrese de ingresar su id de usuario y contraseña correctame" +
    "nte.";
            this.lblError.Visible = false;
            // 
            // panelSombra
            // 
            this.panelSombra.BackColor = System.Drawing.Color.Black;
            this.panelSombra.ForeColor = System.Drawing.Color.Black;
            this.panelSombra.Location = new System.Drawing.Point(104, 50);
            this.panelSombra.Name = "panelSombra";
            this.panelSombra.Size = new System.Drawing.Size(300, 200);
            this.panelSombra.TabIndex = 7;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.YellowGreen;
            this.ClientSize = new System.Drawing.Size(500, 325);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelSombra);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.linea);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(500, 350);
            this.MinimumSize = new System.Drawing.Size(500, 325);
            this.Name = "FormLogin";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPswd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Button linea;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPswd;
        private System.Windows.Forms.PictureBox picUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.PictureBox picPswd;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Panel panelSombra;
    }
}

