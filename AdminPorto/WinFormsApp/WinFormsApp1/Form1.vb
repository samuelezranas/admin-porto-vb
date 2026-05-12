Imports System.Net.Http
Imports System.Text.Json

Public Class Form1
    Private ReadOnly httpClient As New HttpClient()
    Private apiBaseUrl As String = "https://www.samuelezranas.codes/api"
    Private currentPage As String = "Dashboard"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set dark theme
        Me.BackColor = Color.FromArgb(25, 12, 35)
        Me.ForeColor = Color.White

        ' Setup navigation buttons
        Dim navButtons = {btnDashboard, btnAbout, btnCertification, btnPortfolio, btnContact}
        For Each btn In navButtons
            btn.BackColor = Color.Transparent
            btn.FlatStyle = FlatStyle.Flat
            btn.FlatAppearance.BorderColor = Color.FromArgb(150, 80, 150)
            btn.FlatAppearance.BorderSize = 2
            btn.Cursor = Cursors.Hand
            AddHandler btn.Click, AddressOf NavButton_Click
        Next

        ' Setup action buttons
        btnRefresh.Cursor = Cursors.Hand
        btnGoToWebsite.Cursor = Cursors.Hand
        btnLogout.Cursor = Cursors.Hand

        ' Load dashboard
        ShowDashboard()
    End Sub

    Private Sub NavButton_Click(sender As Object, e As EventArgs)
        Dim button = CType(sender, Button)
        currentPage = button.Name.Replace("btn", "")
        Select Case currentPage
            Case "Dashboard"
                ShowDashboard()
            Case "About"
                ShowAbout()
            Case "Certification"
                ShowCertification()
            Case "Portfolio"
                ShowPortfolio()
            Case "Contact"
                ShowContact()
        End Select
    End Sub

    Private Sub ShowDashboard()
        pnlContent.Controls.Clear()
        currentPage = "Dashboard"
        btnDashboard.BackColor = Color.FromArgb(100, 50, 100)
        btnAbout.BackColor = Color.Transparent
        btnCertification.BackColor = Color.Transparent
        btnPortfolio.BackColor = Color.Transparent
        btnContact.BackColor = Color.Transparent

        Dim panel = New Panel With {
            .Dock = DockStyle.Fill,
            .AutoScroll = True,
            .BackColor = Color.FromArgb(25, 12, 35)
        }

        Dim titleLabel = New Label With {
            .Text = "📊 Google Analytics",
            .Font = New Font("Segoe UI", 20, FontStyle.Bold),
            .ForeColor = Color.White,
            .Location = New Point(40, 40),
            .AutoSize = True
        }
        panel.Controls.Add(titleLabel)

        Dim statPanel1 = CreateStatCard("About Photos", "3", New Point(40, 120))
        Dim statPanel2 = CreateStatCard("Certifications", "16", New Point(320, 120))
        Dim statPanel3 = CreateStatCard("Portfolio Projects", "10", New Point(600, 120))
        Dim statPanel4 = CreateStatCard("Messages", "3", New Point(880, 120))

        panel.Controls.Add(statPanel1)
        panel.Controls.Add(statPanel2)
        panel.Controls.Add(statPanel3)
        panel.Controls.Add(statPanel4)

        Dim noteLabel = New Label With {
            .Text = "GA4_PROPERTY_ID belum ditur di environment Vercel.",
            .Font = New Font("Segoe UI", 11),
            .ForeColor = Color.Yellow,
            .Location = New Point(40, 280),
            .Size = New Size(1000, 50),
            .BackColor = Color.FromArgb(80, 40, 60),
            .Padding = New Padding(10)
        }
        panel.Controls.Add(noteLabel)

        pnlContent.Controls.Add(panel)
    End Sub

    Private Sub ShowAbout()
        pnlContent.Controls.Clear()
        currentPage = "About"
        btnDashboard.BackColor = Color.Transparent
        btnAbout.BackColor = Color.FromArgb(100, 50, 100)
        btnCertification.BackColor = Color.Transparent
        btnPortfolio.BackColor = Color.Transparent
        btnContact.BackColor = Color.Transparent

        Dim panel = New Panel With {
            .Dock = DockStyle.Fill,
            .AutoScroll = True,
            .BackColor = Color.FromArgb(25, 12, 35)
        }

        Dim titleLabel = New Label With {
            .Text = "About Settings",
            .Font = New Font("Segoe UI", 18, FontStyle.Bold),
            .ForeColor = Color.White,
            .Location = New Point(40, 40),
            .AutoSize = True
        }
        panel.Controls.Add(titleLabel)

        ' Title field
        Dim titleLbl = New Label With {
            .Text = "Title:",
            .Font = New Font("Segoe UI", 11),
            .ForeColor = Color.White,
            .Location = New Point(40, 100)
        }
        titleLbl.AutoSize = True
        panel.Controls.Add(titleLbl)

        Dim titleTxt = New TextBox With {
            .Text = "Hello, everyone. This is Samuel Ezra.",
            .Location = New Point(40, 130),
            .Size = New Size(500, 35),
            .BackColor = Color.FromArgb(50, 25, 50),
            .ForeColor = Color.White,
            .BorderStyle = BorderStyle.FixedSingle
        }
        panel.Controls.Add(titleTxt)

        ' Description field
        Dim descLbl = New Label With {
            .Text = "Description:",
            .Font = New Font("Segoe UI", 11),
            .ForeColor = Color.White,
            .Location = New Point(40, 180)
        }
        descLbl.AutoSize = True
        panel.Controls.Add(descLbl)

        Dim descTxt = New TextBox With {
            .Text = "I am an Information Technology undergraduate focused on software engineering, interface design, and visual storytelling. I enjoy building products that are both technically strong and visually memorable...",
            .Location = New Point(40, 210),
            .Size = New Size(500, 120),
            .BackColor = Color.FromArgb(50, 25, 50),
            .ForeColor = Color.White,
            .BorderStyle = BorderStyle.FixedSingle,
            .Multiline = True
        }
        panel.Controls.Add(descTxt)

        ' Social Link
        Dim linkLbl = New Label With {
            .Text = "Social Link:",
            .Font = New Font("Segoe UI", 11),
            .ForeColor = Color.White,
            .Location = New Point(40, 350)
        }
        linkLbl.AutoSize = True
        panel.Controls.Add(linkLbl)

        Dim linkTxt = New TextBox With {
            .Text = "https://drive.google.com/",
            .Location = New Point(40, 380),
            .Size = New Size(500, 35),
            .BackColor = Color.FromArgb(50, 25, 50),
            .ForeColor = Color.White,
            .BorderStyle = BorderStyle.FixedSingle
        }
        panel.Controls.Add(linkTxt)

        ' Save button
        Dim saveBtn = New Button With {
            .Text = "💾 Save About",
            .Location = New Point(40, 440),
            .Size = New Size(500, 45),
            .BackColor = Color.FromArgb(150, 80, 150),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Segoe UI", 12, FontStyle.Bold),
            .Cursor = Cursors.Hand
        }
        panel.Controls.Add(saveBtn)

        pnlContent.Controls.Add(panel)
    End Sub

    Private Sub ShowCertification()
        pnlContent.Controls.Clear()
        currentPage = "Certification"
        btnDashboard.BackColor = Color.Transparent
        btnAbout.BackColor = Color.Transparent
        btnCertification.BackColor = Color.FromArgb(100, 50, 100)
        btnPortfolio.BackColor = Color.Transparent
        btnContact.BackColor = Color.Transparent

        Dim panel = New Panel With {
            .Dock = DockStyle.Fill,
            .AutoScroll = True,
            .BackColor = Color.FromArgb(25, 12, 35)
        }

        Dim titleLabel = New Label With {
            .Text = "📜 List Sertifikat",
            .Font = New Font("Segoe UI", 18, FontStyle.Bold),
            .ForeColor = Color.White,
            .Location = New Point(40, 40),
            .AutoSize = True
        }
        panel.Controls.Add(titleLabel)

        Dim descLabel = New Label With {
            .Text = "Gunakan tombol Tambah untuk membuat data sertifikat baru.",
            .Font = New Font("Segoe UI", 11),
            .ForeColor = Color.Gray,
            .Location = New Point(40, 90),
            .Size = New Size(600, 30)
        }
        panel.Controls.Add(descLabel)

        ' Add button
        Dim addBtn = New Button With {
            .Text = "➕ Tambah",
            .Location = New Point(1100, 40),
            .Size = New Size(120, 45),
            .BackColor = Color.FromArgb(100, 150, 100),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Segoe UI", 11, FontStyle.Bold),
            .Cursor = Cursors.Hand
        }
        panel.Controls.Add(addBtn)

        ' Sample certificates
        Dim certs = {
            New With {.Name = "Pengenalan ke Logika Pemrograman (Programming Logic 101)", .Organization = "Dicoding Indonesia", .Year = 2024, .Order = 0},
            New With {.Name = "Belajar Dasar Visualisasi Data", .Organization = "Dicoding Academy", .Year = 2024, .Order = 0},
            New With {.Name = "Belajar Dasar AI", .Organization = "Dicoding Academy", .Year = 2024, .Order = 0},
            New With {.Name = "Belajar Dasar Structured Query Language (SQL)", .Organization = "Dicoding", .Year = 2024, .Order = 0}
        }

        Dim yPos = 150
        For Each cert In certs
            Dim certPanel = CreateCertificateCard(cert.Name, cert.Organization & " · " & cert.Year, cert.Order, New Point(40, yPos))
            panel.Controls.Add(certPanel)
            yPos += 200
        Next

        pnlContent.Controls.Add(panel)
    End Sub

    Private Sub ShowPortfolio()
        pnlContent.Controls.Clear()
        currentPage = "Portfolio"
        btnDashboard.BackColor = Color.Transparent
        btnAbout.BackColor = Color.Transparent
        btnCertification.BackColor = Color.Transparent
        btnPortfolio.BackColor = Color.FromArgb(100, 50, 100)
        btnContact.BackColor = Color.Transparent

        Dim panel = New Panel With {
            .Dock = DockStyle.Fill,
            .AutoScroll = True,
            .BackColor = Color.FromArgb(25, 12, 35)
        }

        Dim titleLabel = New Label With {
            .Text = "💼 Portfolio Projects",
            .Font = New Font("Segoe UI", 18, FontStyle.Bold),
            .ForeColor = Color.White,
            .Location = New Point(40, 40),
            .AutoSize = True
        }
        panel.Controls.Add(titleLabel)

        ' Add button
        Dim addBtn = New Button With {
            .Text = "➕ Tambah",
            .Location = New Point(1100, 40),
            .Size = New Size(120, 45),
            .BackColor = Color.FromArgb(100, 150, 100),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Segoe UI", 11, FontStyle.Bold),
            .Cursor = Cursors.Hand
        }
        panel.Controls.Add(addBtn)

        ' Sample projects
        Dim yPos = 130
        For i = 1 To 3
            Dim projectPanel = CreateProjectCard("Project " & i, "Description of project " & i, New Point(40, yPos))
            panel.Controls.Add(projectPanel)
            yPos += 180
        Next

        pnlContent.Controls.Add(panel)
    End Sub

    Private Sub ShowContact()
        pnlContent.Controls.Clear()
        currentPage = "Contact"
        btnDashboard.BackColor = Color.Transparent
        btnAbout.BackColor = Color.Transparent
        btnCertification.BackColor = Color.Transparent
        btnPortfolio.BackColor = Color.Transparent
        btnContact.BackColor = Color.FromArgb(100, 50, 100)

        Dim panel = New Panel With {
            .Dock = DockStyle.Fill,
            .AutoScroll = True,
            .BackColor = Color.FromArgb(25, 12, 35)
        }

        Dim titleLabel = New Label With {
            .Text = "💬 Messages",
            .Font = New Font("Segoe UI", 18, FontStyle.Bold),
            .ForeColor = Color.White,
            .Location = New Point(40, 40),
            .AutoSize = True
        }
        panel.Controls.Add(titleLabel)

        ' Messages list
        Dim yPos = 120
        For i = 1 To 3
            Dim msgPanel = CreateMessageCard("Sender Name " & i, "Message subject " & i, "This is a sample message from a visitor...", New Point(40, yPos))
            panel.Controls.Add(msgPanel)
            yPos += 180
        Next

        pnlContent.Controls.Add(panel)
    End Sub

    Private Function CreateStatCard(title As String, value As String, location As Point) As Panel
        Dim card = New Panel With {
            .Size = New Size(260, 120),
            .Location = location,
            .BackColor = Color.FromArgb(50, 25, 50),
            .BorderStyle = BorderStyle.FixedSingle
        }

        Dim border = New Label With {
            .BackColor = Color.FromArgb(150, 80, 150),
            .Size = New Size(2, 120),
            .Location = New Point(0, 0)
        }
        card.Controls.Add(border)

        Dim titleLbl = New Label With {
            .Text = title,
            .Font = New Font("Segoe UI", 11),
            .ForeColor = Color.Gray,
            .Location = New Point(15, 20),
            .AutoSize = True
        }
        card.Controls.Add(titleLbl)

        Dim valueLbl = New Label With {
            .Text = value,
            .Font = New Font("Segoe UI", 32, FontStyle.Bold),
            .ForeColor = Color.White,
            .Location = New Point(15, 50),
            .AutoSize = True
        }
        card.Controls.Add(valueLbl)

        Return card
    End Function

    Private Function CreateCertificateCard(name As String, details As String, order As Integer, location As Point) As Panel
        Dim card = New Panel With {
            .Size = New Size(1120, 180),
            .Location = location,
            .BackColor = Color.FromArgb(50, 25, 50),
            .BorderStyle = BorderStyle.FixedSingle
        }

        Dim border = New Label With {
            .BackColor = Color.FromArgb(150, 80, 150),
            .Size = New Size(2, 180),
            .Location = New Point(0, 0)
        }
        card.Controls.Add(border)

        Dim nameLbl = New Label With {
            .Text = name,
            .Font = New Font("Segoe UI", 13, FontStyle.Bold),
            .ForeColor = Color.White,
            .Location = New Point(15, 15),
            .Size = New Size(900, 40),
            .AutoEllipsis = True
        }
        card.Controls.Add(nameLbl)

        Dim detailsLbl = New Label With {
            .Text = details,
            .Font = New Font("Segoe UI", 10),
            .ForeColor = Color.Gray,
            .Location = New Point(15, 55),
            .AutoSize = True
        }
        card.Controls.Add(detailsLbl)

        Dim orderLbl = New Label With {
            .Text = "Order: " & order,
            .Font = New Font("Segoe UI", 10),
            .ForeColor = Color.Gray,
            .Location = New Point(15, 75),
            .AutoSize = True
        }
        card.Controls.Add(orderLbl)

        ' Up button
        Dim upBtn = New Button With {
            .Text = "⬆ Up",
            .Location = New Point(15, 105),
            .Size = New Size(80, 35),
            .BackColor = Color.FromArgb(100, 50, 100),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Segoe UI", 9),
            .Cursor = Cursors.Hand
        }
        card.Controls.Add(upBtn)

        ' Down button
        Dim downBtn = New Button With {
            .Text = "⬇ Down",
            .Location = New Point(105, 105),
            .Size = New Size(80, 35),
            .BackColor = Color.FromArgb(100, 50, 100),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Segoe UI", 9),
            .Cursor = Cursors.Hand
        }
        card.Controls.Add(downBtn)

        ' Status badge
        Dim statusBadge = New Label With {
            .Text = "Active",
            .Font = New Font("Segoe UI", 9),
            .ForeColor = Color.FromArgb(100, 200, 100),
            .Location = New Point(1020, 20),
            .BackColor = Color.FromArgb(50, 100, 50),
            .Size = New Size(80, 25),
            .TextAlign = ContentAlignment.MiddleCenter,
            .BorderStyle = BorderStyle.FixedSingle
        }
        card.Controls.Add(statusBadge)

        Return card
    End Function

    Private Function CreateProjectCard(name As String, description As String, location As Point) As Panel
        Dim card = New Panel With {
            .Size = New Size(1120, 150),
            .Location = location,
            .BackColor = Color.FromArgb(50, 25, 50),
            .BorderStyle = BorderStyle.FixedSingle
        }

        Dim border = New Label With {
            .BackColor = Color.FromArgb(150, 80, 150),
            .Size = New Size(2, 150),
            .Location = New Point(0, 0)
        }
        card.Controls.Add(border)

        Dim nameLbl = New Label With {
            .Text = name,
            .Font = New Font("Segoe UI", 13, FontStyle.Bold),
            .ForeColor = Color.White,
            .Location = New Point(15, 15),
            .AutoSize = True
        }
        card.Controls.Add(nameLbl)

        Dim descLbl = New Label With {
            .Text = description,
            .Font = New Font("Segoe UI", 10),
            .ForeColor = Color.Gray,
            .Location = New Point(15, 45),
            .Size = New Size(900, 40)
        }
        card.Controls.Add(descLbl)

        ' Edit button
        Dim editBtn = New Button With {
            .Text = "✏️ Edit",
            .Location = New Point(15, 95),
            .Size = New Size(80, 35),
            .BackColor = Color.FromArgb(100, 50, 100),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Segoe UI", 9),
            .Cursor = Cursors.Hand
        }
        card.Controls.Add(editBtn)

        ' Delete button
        Dim delBtn = New Button With {
            .Text = "🗑️ Delete",
            .Location = New Point(105, 95),
            .Size = New Size(80, 35),
            .BackColor = Color.FromArgb(150, 50, 50),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Segoe UI", 9),
            .Cursor = Cursors.Hand
        }
        card.Controls.Add(delBtn)

        Return card
    End Function

    Private Function CreateMessageCard(sender As String, subject As String, message As String, location As Point) As Panel
        Dim card = New Panel With {
            .Size = New Size(1120, 150),
            .Location = location,
            .BackColor = Color.FromArgb(50, 25, 50),
            .BorderStyle = BorderStyle.FixedSingle
        }

        Dim border = New Label With {
            .BackColor = Color.FromArgb(150, 80, 150),
            .Size = New Size(2, 150),
            .Location = New Point(0, 0)
        }
        card.Controls.Add(border)

        Dim senderLbl = New Label With {
            .Text = "From: " & sender,
            .Font = New Font("Segoe UI", 11, FontStyle.Bold),
            .ForeColor = Color.White,
            .Location = New Point(15, 15),
            .AutoSize = True
        }
        card.Controls.Add(senderLbl)

        Dim subjLbl = New Label With {
            .Text = "Subject: " & subject,
            .Font = New Font("Segoe UI", 10),
            .ForeColor = Color.Yellow,
            .Location = New Point(15, 40),
            .AutoSize = True
        }
        card.Controls.Add(subjLbl)

        Dim msgLbl = New Label With {
            .Text = message,
            .Font = New Font("Segoe UI", 10),
            .ForeColor = Color.Gray,
            .Location = New Point(15, 65),
            .Size = New Size(900, 50)
        }
        card.Controls.Add(msgLbl)

        ' Reply button
        Dim replyBtn = New Button With {
            .Text = "↩️ Reply",
            .Location = New Point(15, 120),
            .Size = New Size(80, 25),
            .BackColor = Color.FromArgb(100, 50, 100),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Segoe UI", 9),
            .Cursor = Cursors.Hand
        }
        card.Controls.Add(replyBtn)

        Return card
    End Function

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        ' Refresh current page
        Select Case currentPage
            Case "Dashboard"
                ShowDashboard()
            Case "About"
                ShowAbout()
            Case "Certification"
                ShowCertification()
            Case "Portfolio"
                ShowPortfolio()
            Case "Contact"
                ShowContact()
        End Select
    End Sub

    Private Sub btnGoToWebsite_Click(sender As Object, e As EventArgs) Handles btnGoToWebsite.Click
        Try
            System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo With {
                .FileName = "https://www.samuelezranas.codes/",
                .UseShellExecute = True
            })
        Catch ex As Exception
            MessageBox.Show("Failed to open website: " & ex.Message)
        End Try
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

End Class
