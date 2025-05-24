namespace Proyecto_final1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            textPrompt = new TextBox();
            buttonInvestigar = new Button();
            textResultado = new TextBox();
            buttonExportar = new Button();
            buttonSalir = new Button();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Cyan;
            label1.Location = new Point(178, 129);
            label1.Name = "label1";
            label1.Size = new Size(369, 38);
            label1.TabIndex = 0;
            label1.Text = "Ingrese lo que quiera buscar";
            // 
            // textPrompt
            // 
            textPrompt.BackColor = Color.MidnightBlue;
            textPrompt.ForeColor = Color.Cyan;
            textPrompt.Location = new Point(128, 196);
            textPrompt.Name = "textPrompt";
            textPrompt.Size = new Size(241, 27);
            textPrompt.TabIndex = 1;
            // 
            // buttonInvestigar
            // 
            buttonInvestigar.BackColor = Color.DarkBlue;
            buttonInvestigar.FlatStyle = FlatStyle.Flat;
            buttonInvestigar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonInvestigar.ForeColor = Color.Cyan;
            buttonInvestigar.Location = new Point(431, 187);
            buttonInvestigar.Name = "buttonInvestigar";
            buttonInvestigar.Size = new Size(145, 38);
            buttonInvestigar.TabIndex = 2;
            buttonInvestigar.Text = "Buscar";
            buttonInvestigar.UseVisualStyleBackColor = false;
            buttonInvestigar.Click += buttonInvestigar_Click;
            // 
            // textResultado
            // 
            textResultado.BackColor = Color.DarkBlue;
            textResultado.ForeColor = Color.Cyan;
            textResultado.Location = new Point(48, 262);
            textResultado.Name = "textResultado";
            textResultado.Size = new Size(679, 27);
            textResultado.TabIndex = 3;
            // 
            // buttonExportar
            // 
            buttonExportar.BackColor = Color.DarkBlue;
            buttonExportar.FlatStyle = FlatStyle.Flat;
            buttonExportar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonExportar.ForeColor = Color.Cyan;
            buttonExportar.Location = new Point(292, 323);
            buttonExportar.Name = "buttonExportar";
            buttonExportar.Size = new Size(169, 45);
            buttonExportar.TabIndex = 4;
            buttonExportar.Text = "Exportar a Word";
            buttonExportar.UseVisualStyleBackColor = false;
            buttonExportar.Click += buttonExportar_Click;
            // 
            // buttonSalir
            // 
            buttonSalir.BackColor = Color.DarkBlue;
            buttonSalir.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonSalir.ForeColor = Color.Red;
            buttonSalir.Location = new Point(29, 413);
            buttonSalir.Name = "buttonSalir";
            buttonSalir.Size = new Size(121, 35);
            buttonSalir.TabIndex = 5;
            buttonSalir.Text = "Salir";
            buttonSalir.UseVisualStyleBackColor = false;
            buttonSalir.Click += buttonSalir_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Image = (Image)resources.GetObject("label2.Image");
            label2.ImageAlign = ContentAlignment.TopCenter;
            label2.Location = new Point(168, 32);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 6;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(241, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(241, 114);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MidnightBlue;
            ClientSize = new Size(746, 481);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(buttonSalir);
            Controls.Add(buttonExportar);
            Controls.Add(textResultado);
            Controls.Add(buttonInvestigar);
            Controls.Add(textPrompt);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Proyecto Final1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textPrompt;
        private Button buttonInvestigar;
        private TextBox textResultado;
        private Button buttonExportar;
        private Button buttonSalir;
        private Label label2;
        private PictureBox pictureBox1;
    }
}
