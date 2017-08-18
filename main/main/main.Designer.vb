<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnAutomate = New System.Windows.Forms.Button()
        Me.btnSelectDb = New System.Windows.Forms.Button()
        Me.lblSelectedDb = New System.Windows.Forms.Label()
        Me.ofdSelectDb = New System.Windows.Forms.OpenFileDialog()
        Me.sfdHitCount = New System.Windows.Forms.SaveFileDialog()
        Me.SuspendLayout()
        '
        'btnAutomate
        '
        Me.btnAutomate.Enabled = False
        Me.btnAutomate.Location = New System.Drawing.Point(12, 54)
        Me.btnAutomate.Name = "btnAutomate"
        Me.btnAutomate.Size = New System.Drawing.Size(103, 23)
        Me.btnAutomate.TabIndex = 0
        Me.btnAutomate.Text = "Automate!"
        Me.btnAutomate.UseVisualStyleBackColor = True
        '
        'btnSelectDb
        '
        Me.btnSelectDb.Location = New System.Drawing.Point(12, 25)
        Me.btnSelectDb.Name = "btnSelectDb"
        Me.btnSelectDb.Size = New System.Drawing.Size(103, 23)
        Me.btnSelectDb.TabIndex = 1
        Me.btnSelectDb.Text = "Select Database"
        Me.btnSelectDb.UseVisualStyleBackColor = True
        '
        'lblSelectedDb
        '
        Me.lblSelectedDb.AutoSize = True
        Me.lblSelectedDb.Location = New System.Drawing.Point(9, 9)
        Me.lblSelectedDb.Name = "lblSelectedDb"
        Me.lblSelectedDb.Size = New System.Drawing.Size(151, 13)
        Me.lblSelectedDb.TabIndex = 2
        Me.lblSelectedDb.Text = "Please select a .db file to start."
        Me.lblSelectedDb.UseWaitCursor = True
        '
        'ofdSelectDb
        '
        Me.ofdSelectDb.Filter = "Database files (*.db)|*.db"
        '
        'sfdHitCount
        '
        Me.sfdHitCount.DefaultExt = "xls"
        Me.sfdHitCount.FileName = "Output"
        Me.sfdHitCount.Filter = "Excel worksheet|*.xls"
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(215, 83)
        Me.Controls.Add(Me.lblSelectedDb)
        Me.Controls.Add(Me.btnSelectDb)
        Me.Controls.Add(Me.btnAutomate)
        Me.Name = "main"
        Me.Text = "Automator v1.0"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnAutomate As Button
    Friend WithEvents btnSelectDb As Button
    Friend WithEvents lblSelectedDb As Label
    Friend WithEvents ofdSelectDb As OpenFileDialog
    Friend WithEvents sfdHitCount As SaveFileDialog
End Class
