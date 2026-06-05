<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        pnlHeader = New Panel()
        pnlHeaderRight = New Panel()
        btnLogout = New Button()
        btnGoToWebsite = New Button()
        btnRefresh = New Button()
        lblTitle = New Label()
        pnlNavigation = New Panel()
        btnContact = New Button()
        btnPortfolio = New Button()
        btnCertification = New Button()
        btnAbout = New Button()
        btnDashboard = New Button()
        pnlContent = New Panel()
        pnlHeader.SuspendLayout()
        pnlHeaderRight.SuspendLayout()
        pnlNavigation.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.FromArgb(CByte(25), CByte(12), CByte(35))
        pnlHeader.Controls.Add(pnlHeaderRight)
        pnlHeader.Controls.Add(lblTitle)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(1383, 90)
        pnlHeader.TabIndex = 0
        ' 
        ' pnlHeaderRight
        ' 
        pnlHeaderRight.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        pnlHeaderRight.Controls.Add(btnLogout)
        pnlHeaderRight.Controls.Add(btnGoToWebsite)
        pnlHeaderRight.Controls.Add(btnRefresh)
        pnlHeaderRight.Location = New Point(883, 25)
        pnlHeaderRight.Name = "pnlHeaderRight"
        pnlHeaderRight.Size = New Size(480, 50)
        pnlHeaderRight.TabIndex = 1
        ' 
        ' btnLogout
        ' 
        btnLogout.BackColor = Color.Transparent
        btnLogout.Cursor = Cursors.Hand
        btnLogout.FlatAppearance.BorderColor = Color.FromArgb(CByte(150), CByte(80), CByte(150))
        btnLogout.FlatAppearance.BorderSize = 2
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnLogout.ForeColor = Color.White
        btnLogout.Location = New Point(320, 5)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(120, 40)
        btnLogout.TabIndex = 2
        btnLogout.Text = "🚪 Logout"
        btnLogout.UseVisualStyleBackColor = False
        ' 
        ' btnGoToWebsite
        ' 
        btnGoToWebsite.BackColor = Color.Transparent
        btnGoToWebsite.Cursor = Cursors.Hand
        btnGoToWebsite.FlatAppearance.BorderColor = Color.FromArgb(CByte(150), CByte(80), CByte(150))
        btnGoToWebsite.FlatAppearance.BorderSize = 2
        btnGoToWebsite.FlatStyle = FlatStyle.Flat
        btnGoToWebsite.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnGoToWebsite.ForeColor = Color.White
        btnGoToWebsite.Location = New Point(165, 5)
        btnGoToWebsite.Name = "btnGoToWebsite"
        btnGoToWebsite.Size = New Size(150, 40)
        btnGoToWebsite.TabIndex = 1
        btnGoToWebsite.Text = "🔗 Go to Website"
        btnGoToWebsite.UseVisualStyleBackColor = False
        ' 
        ' btnRefresh
        ' 
        btnRefresh.BackColor = Color.Transparent
        btnRefresh.Cursor = Cursors.Hand
        btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(CByte(150), CByte(80), CByte(150))
        btnRefresh.FlatAppearance.BorderSize = 2
        btnRefresh.FlatStyle = FlatStyle.Flat
        btnRefresh.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnRefresh.ForeColor = Color.White
        btnRefresh.Location = New Point(10, 5)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(150, 40)
        btnRefresh.TabIndex = 0
        btnRefresh.Text = "🔄 Refresh"
        btnRefresh.UseVisualStyleBackColor = False
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 24F, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(20, 20)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(511, 65)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Website Admin Panel"
        ' 
        ' pnlNavigation
        ' 
        pnlNavigation.BackColor = Color.FromArgb(CByte(25), CByte(12), CByte(35))
        pnlNavigation.Controls.Add(btnContact)
        pnlNavigation.Controls.Add(btnPortfolio)
        pnlNavigation.Controls.Add(btnCertification)
        pnlNavigation.Controls.Add(btnAbout)
        pnlNavigation.Controls.Add(btnDashboard)
        pnlNavigation.Dock = DockStyle.Top
        pnlNavigation.Location = New Point(0, 90)
        pnlNavigation.Name = "pnlNavigation"
        pnlNavigation.Size = New Size(1383, 65)
        pnlNavigation.TabIndex = 1
        ' 
        ' btnContact
        ' 
        btnContact.BackColor = Color.Transparent
        btnContact.FlatAppearance.BorderColor = Color.FromArgb(CByte(150), CByte(80), CByte(150))
        btnContact.FlatAppearance.BorderSize = 2
        btnContact.FlatStyle = FlatStyle.Flat
        btnContact.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        btnContact.ForeColor = Color.White
        btnContact.Location = New Point(573, 10)
        btnContact.Name = "btnContact"
        btnContact.Size = New Size(122, 40)
        btnContact.TabIndex = 4
        btnContact.Text = "Contact"
        btnContact.UseVisualStyleBackColor = False
        ' 
        ' btnPortfolio
        ' 
        btnPortfolio.BackColor = Color.Transparent
        btnPortfolio.FlatAppearance.BorderColor = Color.FromArgb(CByte(150), CByte(80), CByte(150))
        btnPortfolio.FlatAppearance.BorderSize = 2
        btnPortfolio.FlatStyle = FlatStyle.Flat
        btnPortfolio.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        btnPortfolio.ForeColor = Color.White
        btnPortfolio.Location = New Point(446, 10)
        btnPortfolio.Name = "btnPortfolio"
        btnPortfolio.Size = New Size(121, 40)
        btnPortfolio.TabIndex = 3
        btnPortfolio.Text = "Portfolio"
        btnPortfolio.UseVisualStyleBackColor = False
        ' 
        ' btnCertification
        ' 
        btnCertification.BackColor = Color.Transparent
        btnCertification.FlatAppearance.BorderColor = Color.FromArgb(CByte(150), CByte(80), CByte(150))
        btnCertification.FlatAppearance.BorderSize = 2
        btnCertification.FlatStyle = FlatStyle.Flat
        btnCertification.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        btnCertification.ForeColor = Color.White
        btnCertification.Location = New Point(281, 10)
        btnCertification.Name = "btnCertification"
        btnCertification.Size = New Size(159, 40)
        btnCertification.TabIndex = 2
        btnCertification.Text = "Certification"
        btnCertification.UseVisualStyleBackColor = False
        ' 
        ' btnAbout
        ' 
        btnAbout.BackColor = Color.Transparent
        btnAbout.FlatAppearance.BorderColor = Color.FromArgb(CByte(150), CByte(80), CByte(150))
        btnAbout.FlatAppearance.BorderSize = 2
        btnAbout.FlatStyle = FlatStyle.Flat
        btnAbout.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        btnAbout.ForeColor = Color.White
        btnAbout.Location = New Point(178, 10)
        btnAbout.Name = "btnAbout"
        btnAbout.Size = New Size(97, 40)
        btnAbout.TabIndex = 1
        btnAbout.Text = "About"
        btnAbout.UseVisualStyleBackColor = False
        ' 
        ' btnDashboard
        ' 
        btnDashboard.BackColor = Color.Transparent
        btnDashboard.FlatAppearance.BorderColor = Color.FromArgb(CByte(150), CByte(80), CByte(150))
        btnDashboard.FlatAppearance.BorderSize = 2
        btnDashboard.FlatStyle = FlatStyle.Flat
        btnDashboard.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        btnDashboard.ForeColor = Color.White
        btnDashboard.Location = New Point(20, 10)
        btnDashboard.Name = "btnDashboard"
        btnDashboard.Size = New Size(152, 40)
        btnDashboard.TabIndex = 0
        btnDashboard.Text = "Dashboard"
        btnDashboard.UseVisualStyleBackColor = False
        ' 
        ' pnlContent
        ' 
        pnlContent.BackColor = Color.FromArgb(CByte(25), CByte(12), CByte(35))
        pnlContent.Dock = DockStyle.Fill
        pnlContent.ForeColor = Color.White
        pnlContent.Location = New Point(0, 155)
        pnlContent.Name = "pnlContent"
        pnlContent.Size = New Size(1383, 583)
        pnlContent.TabIndex = 2
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(25), CByte(12), CByte(35))
        ClientSize = New Size(1383, 738)
        Controls.Add(pnlContent)
        Controls.Add(pnlNavigation)
        Controls.Add(pnlHeader)
        ForeColor = Color.White
        Name = "Form1"
        Text = "Website Admin Panel"
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        pnlHeaderRight.ResumeLayout(False)
        pnlNavigation.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents pnlNavigation As Panel
    Friend WithEvents pnlContent As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnDashboard As Button
    Friend WithEvents btnAbout As Button
    Friend WithEvents btnCertification As Button
    Friend WithEvents btnPortfolio As Button
    Friend WithEvents btnContact As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnGoToWebsite As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents pnlHeaderRight As Panel

End Class
