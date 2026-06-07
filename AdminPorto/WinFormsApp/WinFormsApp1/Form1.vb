Imports System.Net.Http
Imports System.Text.Json

Public Class Form1
    ' Inisialisasi Service
    Private _apiService As ApiService
    Private currentPage As String = "Dashboard"

    ' TODO: Ganti dengan URL dan Anon Key Supabase portofoliomu sendiri
    Private Const SUPABASE_URL As String = "https://jnioqbsqbodsmqzwcgqz.supabase.co"
    Private Const SUPABASE_KEY As String = "sb_publishable_gmEmuBGVgPTU8-rP02HIzQ_E2R1Twfh"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Tambahkan ini agar aplikasi tampil fullscreen dan terpusat
        Me.WindowState = FormWindowState.Maximized

        ' 1. Inisialisasi API Service
        _apiService = New ApiService(SUPABASE_URL, SUPABASE_KEY)

        ' 2. Atur Tema Dark Mode (Sesuai desain awalmu)
        Me.BackColor = Color.FromArgb(25, 12, 35)
        Me.ForeColor = Color.White

        ' 3. Setup Tombol Navigasi
        Dim navButtons = {btnDashboard, btnAbout, btnCertification, btnPortfolio, btnContact}
        For Each btn In navButtons
            btn.BackColor = Color.Transparent
            btn.FlatStyle = FlatStyle.Flat
            btn.FlatAppearance.BorderColor = Color.FromArgb(150, 80, 150)
            btn.FlatAppearance.BorderSize = 2
            btn.Cursor = Cursors.Hand
            AddHandler btn.Click, AddressOf NavButton_Click
        Next

        ' 4. Setup Tombol Aksi Tambahan
        btnRefresh.Cursor = Cursors.Hand
        btnGoToWebsite.Cursor = Cursors.Hand
        btnLogout.Cursor = Cursors.Hand

        ' 5. Load Halaman Pertama (Dashboard)
        ShowDashboard()
    End Sub

    ' --- LOGIKA NAVIGASI ---

    Private Async Sub NavButton_Click(sender As Object, e As EventArgs)
        Dim button = CType(sender, Button)
        currentPage = button.Name.Replace("btn", "")

        ' Reset semua warna background tombol navigasi menjadi transparan
        ResetNavButtons()
        ' Beri warna aktif pada tombol yang sedang diklik
        button.BackColor = Color.FromArgb(100, 50, 100)

        ' Panggil halaman yang sesuai secara asinkron
        Select Case currentPage
            Case "Dashboard"
                ShowDashboard()
            Case "About"
                Await ShowAbout()
            Case "Certification"
                Await ShowCertification()
            Case "Portfolio"
                Await ShowPortfolio()
            Case "Contact"
                Await ShowContact()
        End Select
    End Sub

    Private Sub ResetNavButtons()
        Dim navButtons = {btnDashboard, btnAbout, btnCertification, btnPortfolio, btnContact}
        For Each btn In navButtons
            btn.BackColor = Color.Transparent
        Next
    End Sub

    ' --- HALAMAN DINAMIS (KONEKSI SUPABASE) ---

    Private Async Sub ShowDashboard()
        pnlContent.Controls.Clear()
        currentPage = "Dashboard"

        Dim panel = CreateBasePanel()

        Dim titleLabel = New Label With {
            .Text = "📊 Google Analytics & Stats",
            .Font = New Font("Segoe UI", 20, FontStyle.Bold),
            .ForeColor = Color.White,
            .Location = New Point(40, 40),
            .AutoSize = True
        }
        AddControlToCenterPanel(panel, titleLabel)

        ' Untuk stats, hitung dari database
        Dim certs = Await _apiService.GetCertificationsAsync()
        Dim portfolios = Await _apiService.GetPortfoliosAsync()
        Dim messages = Await _apiService.GetMessagesAsync()

        Dim statPanel1 = CreateStatCard("About Photos", "3", New Point(40, 120)) ' Asumsi 3 untuk photo
        Dim statPanel2 = CreateStatCard("Certifications", certs.Count.ToString(), New Point(320, 120))
        Dim statPanel3 = CreateStatCard("Portfolio Projects", portfolios.Count.ToString(), New Point(600, 120))
        Dim statPanel4 = CreateStatCard("Messages", messages.Count.ToString(), New Point(880, 120))

        AddControlToCenterPanel(panel, statPanel1)
        AddControlToCenterPanel(panel, statPanel2)
        AddControlToCenterPanel(panel, statPanel3)
        AddControlToCenterPanel(panel, statPanel4)

        Dim noteLabel = New Label With {
            .Text = "GA4_PROPERTY_ID belum diatur di environment Vercel.",
            .Font = New Font("Segoe UI", 11),
            .ForeColor = Color.Yellow,
            .Location = New Point(40, 280),
            .Size = New Size(1000, 50),
            .BackColor = Color.FromArgb(80, 40, 60),
            .Padding = New Padding(10)
        }
        AddControlToCenterPanel(panel, noteLabel)

        pnlContent.Controls.Add(panel)
    End Sub

    Private Async Function ShowAbout() As Task
        pnlContent.Controls.Clear()
        currentPage = "About"

        Dim panel = CreateBasePanel()
        pnlContent.Controls.Add(panel)

        ' Tampilkan indikator loading sederhana
        Dim loadingLbl = New Label With {.Text = "Loading About data...", .Location = New Point(40, 100), .ForeColor = Color.Gray, .AutoSize = True}
        AddControlToCenterPanel(panel, loadingLbl)

        ' Ambil data asli dari Supabase
        Dim aboutData = Await _apiService.GetAboutAsync()
        ' Kita ambil innerPanel jika BasePanel memiliki Controls
        If panel.Controls.Count > 0 AndAlso TypeOf panel.Controls(0) Is Panel Then
            panel.Controls(0).Controls.Remove(loadingLbl)
        Else
            panel.Controls.Remove(loadingLbl)
        End If

        Dim titleLabel = New Label With {
            .Text = "About Settings",
            .Font = New Font("Segoe UI", 18, FontStyle.Bold),
            .ForeColor = Color.White,
            .Location = New Point(40, 40),
            .AutoSize = True
        }
        AddControlToCenterPanel(panel, titleLabel)

        ' Membuat input field menggunakan helper generator. Kita pass innerPanel
        Dim innerPanelForInputs As Panel = If(panel.Controls.Count > 0 AndAlso TypeOf panel.Controls(0) Is Panel, panel.Controls(0), panel)
        Dim titleTxt = CreateInput("Title:", aboutData.Title, 100, innerPanelForInputs)
        Dim descTxt = CreateInput("Lead:", aboutData.Lead, 180, innerPanelForInputs, True)
        Dim linkTxt = CreateInput("Resume URL:", aboutData.ResumeUrl, 350, innerPanelForInputs)

        ' Tombol Simpan
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

        ' Event handler klik untuk mengupdate data ke Supabase
        AddHandler saveBtn.Click, Async Sub()
                                      saveBtn.Enabled = False
                                      saveBtn.Text = "⌛ Saving..."

                                      aboutData.Title = titleTxt.Text
                                      aboutData.Lead = descTxt.Text
                                      aboutData.ResumeUrl = linkTxt.Text

                                      Dim success = Await _apiService.UpdateAboutAsync(aboutData)
                                      MessageBox.Show(If(success, "Data About berhasil diperbarui!", "Gagal memperbarui data."))

                                      saveBtn.Enabled = True
                                      saveBtn.Text = "💾 Save About"
                                  End Sub

        innerPanelForInputs.Controls.Add(saveBtn)
    End Function

    Private Async Function ShowCertification() As Task
        pnlContent.Controls.Clear()
        currentPage = "Certification"

        Dim panel = CreateBasePanel()
        pnlContent.Controls.Add(panel)

        Dim titleLabel = New Label With {
            .Text = "📜 List Sertifikat",
            .Font = New Font("Segoe UI", 18, FontStyle.Bold),
            .ForeColor = Color.White,
            .Location = New Point(40, 40),
            .AutoSize = True
        }
        AddControlToCenterPanel(panel, titleLabel)

        Dim addBtn = New Button With {
            .Text = "➕ Tambah",
            .Location = New Point(1060, 40), ' Adjust location suitable for width 1200
            .Size = New Size(120, 45),
            .BackColor = Color.FromArgb(100, 150, 100),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Segoe UI", 11, FontStyle.Bold),
            .Cursor = Cursors.Hand
        }

        AddHandler addBtn.Click, Async Sub(s, e)
                                     Await ShowCertificationForm(Nothing)
                                 End Sub

        AddControlToCenterPanel(panel, addBtn)

        ' Ambil list sertifikat asli dari Supabase
        Dim certs = Await _apiService.GetCertificationsAsync()

        Dim yPos = 150
        For Each cert In certs
            Dim certPanel = CreateCertificateCard(cert.Title, cert.Issuer & " · " & cert.Year, cert.SortOrder, New Point(40, yPos))

            ' Edit Button
            Dim editBtn = New Button With {
                .Text = "✏️ Edit",
                .Location = New Point(830, 105),
                .Size = New Size(80, 35),
                .BackColor = Color.FromArgb(50, 100, 150),
                .ForeColor = Color.White,
                .FlatStyle = FlatStyle.Flat,
                .Cursor = Cursors.Hand
            }

            Dim currentCert = cert ' Copy for closure
            AddHandler editBtn.Click, Async Sub(s, e)
                                          Await ShowCertificationForm(currentCert)
                                      End Sub

            ' Delete Button
            Dim delBtn = New Button With {
                .Text = "🗑️ Delete",
                .Location = New Point(930, 105),
                .Size = New Size(80, 35),
                .BackColor = Color.FromArgb(150, 50, 50),
                .ForeColor = Color.White,
                .FlatStyle = FlatStyle.Flat,
                .Cursor = Cursors.Hand
            }

            AddHandler delBtn.Click, Async Sub()
                                         If MessageBox.Show("Hapus sertifikat: " & currentCert.Title & "?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                                             Await _apiService.DeleteCertificationAsync(currentCert.Id)
                                             Await ShowCertification() ' Refresh halaman setelah menghapus
                                         End If
                                     End Sub

            certPanel.Controls.Add(editBtn)
            certPanel.Controls.Add(delBtn)
            AddControlToCenterPanel(panel, certPanel)
            yPos += 200
        Next
    End Function

    Private Async Function ShowPortfolio() As Task
        pnlContent.Controls.Clear()
        currentPage = "Portfolio"

        Dim panel = CreateBasePanel()
        pnlContent.Controls.Add(panel)

        Dim titleLabel = New Label With {
            .Text = "💼 Portfolio Projects",
            .Font = New Font("Segoe UI", 18, FontStyle.Bold),
            .ForeColor = Color.White,
            .Location = New Point(40, 40),
            .AutoSize = True
        }
        AddControlToCenterPanel(panel, titleLabel)

        Dim addBtn = New Button With {
            .Text = "➕ Tambah",
            .Location = New Point(1060, 40), ' Adjust location suitable for width 1200
            .Size = New Size(120, 45),
            .BackColor = Color.FromArgb(100, 150, 100),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Segoe UI", 11, FontStyle.Bold),
            .Cursor = Cursors.Hand
        }

        AddHandler addBtn.Click, Async Sub(s, e)
                                     Await ShowPortfolioForm(Nothing)
                                 End Sub

        AddControlToCenterPanel(panel, addBtn)

        Dim portfolios = Await _apiService.GetPortfoliosAsync()

        Dim yPos = 130
        For Each item In portfolios
            Dim projectPanel = CreateProjectCard(item.Title, item.Description, New Point(40, yPos))

            ' Edit Button
            Dim editBtn = New Button With {
                .Text = "✏️ Edit",
                .Location = New Point(830, 20),
                .Size = New Size(80, 35),
                .BackColor = Color.FromArgb(50, 100, 150),
                .ForeColor = Color.White,
                .FlatStyle = FlatStyle.Flat,
                .Cursor = Cursors.Hand
            }

            Dim currentPortfolio = item
            AddHandler editBtn.Click, Async Sub(s, e)
                                          Await ShowPortfolioForm(currentPortfolio)
                                      End Sub

            ' Delete Button
            Dim delBtn = New Button With {
                .Text = "🗑️ Delete",
                .Location = New Point(930, 20),
                .Size = New Size(80, 35),
                .BackColor = Color.FromArgb(150, 50, 50),
                .ForeColor = Color.White,
                .FlatStyle = FlatStyle.Flat,
                .Cursor = Cursors.Hand
            }

            AddHandler delBtn.Click, Async Sub()
                                         If MessageBox.Show("Hapus project: " & currentPortfolio.Title & "?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                                             ' Note: Buat metode DeletePortfolioAsync 
                                             MessageBox.Show("Metode Hapus Portfolio belum tersedia di API Service.", "Belum Tersedia", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                             ' Await _apiService.DeletePortfolioAsync(currentPortfolio.Id)
                                             ' Await ShowPortfolio() ' Refresh halaman setelah menghapus
                                         End If
                                     End Sub

            projectPanel.Controls.Add(editBtn)
            projectPanel.Controls.Add(delBtn)
            AddControlToCenterPanel(panel, projectPanel)
            yPos += 180
        Next
    End Function

    Private Async Function ShowContact() As Task
        pnlContent.Controls.Clear()
        currentPage = "Contact"

        Dim panel = CreateBasePanel()
        pnlContent.Controls.Add(panel)

        Dim titleLabel = New Label With {
            .Text = "💬 Messages",
            .Font = New Font("Segoe UI", 18, FontStyle.Bold),
            .ForeColor = Color.White,
            .Location = New Point(40, 40),
            .AutoSize = True
        }
        AddControlToCenterPanel(panel, titleLabel)

        Dim messages = Await _apiService.GetMessagesAsync()

        Dim yPos = 120
        For Each msg In messages
            Dim msgPanel = CreateMessageCard(msg.Name, msg.Email, msg.Message, New Point(40, yPos))
            AddControlToCenterPanel(panel, msgPanel)
            yPos += 180
        Next
    End Function

    ' --- FORMS MANAJEMEN DATA ---

    Private Async Function ShowCertificationForm(cert As CertificationModel) As Task
        pnlContent.Controls.Clear()

        Dim isEdit As Boolean = cert IsNot Nothing
        If cert Is Nothing Then cert = New CertificationModel()

        Dim panel = CreateBasePanel()
        pnlContent.Controls.Add(panel)

        Dim titleLabel = New Label With {
            .Text = If(isEdit, "✏️ Edit Sertifikat", "➕ Tambah Sertifikat"),
            .Font = New Font("Segoe UI", 18, FontStyle.Bold),
            .ForeColor = Color.White,
            .Location = New Point(40, 40),
            .AutoSize = True
        }
        AddControlToCenterPanel(panel, titleLabel)

        Dim innerPanelForInputs As Panel = If(panel.Controls.Count > 0 AndAlso TypeOf panel.Controls(0) Is Panel, panel.Controls(0), panel)

        ' Membuat input field menggunakan helper generator
        Dim titleTxt = CreateInput("Judul Sertifikat:", cert.Title, 100, innerPanelForInputs)
        Dim issuerTxt = CreateInput("Penerbit (Issuer):", cert.Issuer, 180, innerPanelForInputs)
        Dim yearTxt = CreateInput("Tahun (Year):", cert.Year, 260, innerPanelForInputs)

        ' Tombol Simpan
        Dim saveBtn = New Button With {
            .Text = "💾 Simpan",
            .Location = New Point(40, 340),
            .Size = New Size(240, 45),
            .BackColor = Color.FromArgb(150, 80, 150),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Segoe UI", 12, FontStyle.Bold),
            .Cursor = Cursors.Hand
        }

        Dim cancelBtn = New Button With {
            .Text = "❌ Batal",
            .Location = New Point(300, 340),
            .Size = New Size(240, 45),
            .BackColor = Color.FromArgb(80, 80, 80),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Segoe UI", 12, FontStyle.Bold),
            .Cursor = Cursors.Hand
        }

        AddHandler cancelBtn.Click, Async Sub()
                                        Await ShowCertification()
                                    End Sub

        ' Note: Untuk update belum ada methodnya di API service, implementasikan sesuai kebutuhan
        ' Sementara ini hanya membuat UI dan Create 
        AddHandler saveBtn.Click, Async Sub()
                                      saveBtn.Enabled = False
                                      cert.Title = titleTxt.Text
                                      cert.Issuer = issuerTxt.Text
                                      cert.Year = yearTxt.Text

                                      Dim success As Boolean = False
                                      If Not isEdit Then
                                          Dim result = Await _apiService.CreateCertificationAsync(cert)
                                          success = result IsNot Nothing
                                      Else
                                          MessageBox.Show("Metode Edit Sertifikat belum tersedia di API Service. Buatlah API update pada Service.", "Belum Tersedia", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                          ' Contoh jika sudah dibuat:
                                          ' success = Await _apiService.UpdateCertificationAsync(cert)
                                          saveBtn.Enabled = True
                                          Exit Sub
                                      End If

                                      MessageBox.Show(If(success, "Data Sertifikat berhasil disimpan!", "Gagal menyimpan data."))
                                      Await ShowCertification()
                                  End Sub

        innerPanelForInputs.Controls.Add(saveBtn)
        innerPanelForInputs.Controls.Add(cancelBtn)
    End Function

    Private Async Function ShowPortfolioForm(portfolio As PortfolioModel) As Task
        pnlContent.Controls.Clear()

        Dim isEdit As Boolean = portfolio IsNot Nothing
        If portfolio Is Nothing Then portfolio = New PortfolioModel()

        Dim panel = CreateBasePanel()
        pnlContent.Controls.Add(panel)

        Dim titleLabel = New Label With {
            .Text = If(isEdit, "✏️ Edit Project", "➕ Tambah Project"),
            .Font = New Font("Segoe UI", 18, FontStyle.Bold),
            .ForeColor = Color.White,
            .Location = New Point(40, 40),
            .AutoSize = True
        }
        AddControlToCenterPanel(panel, titleLabel)

        Dim innerPanelForInputs As Panel = If(panel.Controls.Count > 0 AndAlso TypeOf panel.Controls(0) Is Panel, panel.Controls(0), panel)

        ' Membuat input field menggunakan helper generator
        Dim titleTxt = CreateInput("Judul Project:", portfolio.Title, 100, innerPanelForInputs)
        Dim descTxt = CreateInput("Deskripsi:", portfolio.Description, 180, innerPanelForInputs, True)

        ' Tombol Simpan
        Dim saveBtn = New Button With {
            .Text = "💾 Simpan",
            .Location = New Point(40, 340),
            .Size = New Size(240, 45),
            .BackColor = Color.FromArgb(150, 80, 150),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Segoe UI", 12, FontStyle.Bold),
            .Cursor = Cursors.Hand
        }

        Dim cancelBtn = New Button With {
            .Text = "❌ Batal",
            .Location = New Point(300, 340),
            .Size = New Size(240, 45),
            .BackColor = Color.FromArgb(80, 80, 80),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Segoe UI", 12, FontStyle.Bold),
            .Cursor = Cursors.Hand
        }

        AddHandler cancelBtn.Click, Async Sub()
                                        Await ShowPortfolio()
                                    End Sub

        ' Note: Untuk update belum ada methodnya di API service, implementasikan sesuai kebutuhan
        ' Sementara ini hanya membuat UI dan Create 
        AddHandler saveBtn.Click, Async Sub()
                                      saveBtn.Enabled = False
                                      portfolio.Title = titleTxt.Text
                                      portfolio.Description = descTxt.Text

                                      Dim success As Boolean = False
                                      Dim msg = "Penyimpanan untuk model portfolio belum tersedia di backend/API service."

                                      MessageBox.Show(msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                      saveBtn.Enabled = True

                                  End Sub

        innerPanelForInputs.Controls.Add(saveBtn)
        innerPanelForInputs.Controls.Add(cancelBtn)
    End Function

    ' --- UTILITY & GENERIC GENERATORS ---

    Private Function CreateBasePanel() As Panel
        ' Gunakan Center Panel untuk membuat layout di tengah di layat full screen
        Dim outerPanel = New Panel With {
            .Dock = DockStyle.Fill,
            .AutoScroll = True,
            .BackColor = Color.FromArgb(25, 12, 35)
        }

        ' Membuat panel dalam yang terpusat yang memiliki lebar fix maksimal
        Dim innerPanel = New Panel With {
            .Width = 1200,
            .AutoSize = True,
            .AutoSizeMode = AutoSizeMode.GrowAndShrink,
            .MinimumSize = New Size(1200, 800),
            .BackColor = Color.FromArgb(25, 12, 35)
        }

        ' Memastikan posisinya ditengah
        AddHandler outerPanel.Resize, Sub(s, e)
                                          innerPanel.Left = (outerPanel.ClientSize.Width - innerPanel.Width) \ 2
                                      End Sub

        outerPanel.Controls.Add(innerPanel)
        Return outerPanel
    End Function

    ' Helper untuk mendapatkan innerPanel agar controls ditambah di tengah, bukan di OuterPanel
    Private Sub AddControlToCenterPanel(basePanel As Panel, control As Control)
        If basePanel.Controls.Count > 0 AndAlso TypeOf basePanel.Controls(0) Is Panel Then
            basePanel.Controls(0).Controls.Add(control)
        Else
            basePanel.Controls.Add(control)
        End If
    End Sub

    Private Function CreateInput(labelText As String, value As String, yPos As Integer, parent As Panel, Optional isMultiline As Boolean = False) As TextBox
        Dim lbl = New Label With {.Text = labelText, .Location = New Point(40, yPos), .AutoSize = True, .Font = New Font("Segoe UI", 11), .ForeColor = Color.White}
        Dim txt = New TextBox With {
            .Text = value,
            .Location = New Point(40, yPos + 30),
            .Size = New Size(500, If(isMultiline, 120, 35)),
            .BackColor = Color.FromArgb(50, 25, 50),
            .ForeColor = Color.White,
            .Multiline = isMultiline,
            .BorderStyle = BorderStyle.FixedSingle
        }
        parent.Controls.Add(lbl)
        parent.Controls.Add(txt)
        Return txt
    End Function

    ' --- CARD UI COMPONENTS ---

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

        ' Tombol Up dan Down bawaan UI kamu tetap dipertahankan
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

    ' --- GLOBAL ACTION BUTTONS ---

    Private Async Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Select Case currentPage
            Case "Dashboard" : ShowDashboard()
            Case "About" : Await ShowAbout()
            Case "Certification" : Await ShowCertification()
            Case "Portfolio" : Await ShowPortfolio()
            Case "Contact" : Await ShowContact()
        End Select
    End Sub

    Private Sub btnGoToWebsite_Click(sender As Object, e As EventArgs) Handles btnGoToWebsite.Click
        Try
            System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo With {
                .FileName = "https://www.samuelezranas.codes/",
                .UseShellExecute = True
            })
        Catch ex As Exception
            MessageBox.Show("Gagal membuka website: " & ex.Message)
        End Try
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If MessageBox.Show("Apakah kamu yakin ingin keluar?", "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub
End Class