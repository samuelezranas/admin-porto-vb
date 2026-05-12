Public Class ThemeColors
    ' Dark Theme Colors
    Public Shared ReadOnly BackgroundDark As Color = Color.FromArgb(25, 12, 35)
    Public Shared ReadOnly BackgroundMedium As Color = Color.FromArgb(50, 25, 50)
    Public Shared ReadOnly BackgroundLight As Color = Color.FromArgb(80, 40, 60)

    ' Accent Colors
    Public Shared ReadOnly AccentPrimary As Color = Color.FromArgb(150, 80, 150)
    Public Shared ReadOnly AccentSecondary As Color = Color.FromArgb(100, 50, 100)

    ' Status Colors
    Public Shared ReadOnly StatusActive As Color = Color.FromArgb(100, 200, 100)
    Public Shared ReadOnly StatusInactive As Color = Color.FromArgb(200, 100, 100)
    Public Shared ReadOnly StatusWarning As Color = Color.FromArgb(255, 200, 100)

    ' Text Colors
    Public Shared ReadOnly TextPrimary As Color = Color.White
    Public Shared ReadOnly TextSecondary As Color = Color.Gray
    Public Shared ReadOnly TextDanger As Color = Color.FromArgb(255, 100, 100)
    Public Shared ReadOnly TextSuccess As Color = Color.FromArgb(100, 255, 100)
    Public Shared ReadOnly TextWarning As Color = Color.Yellow
End Class

Public Class ThemeHelper

    Public Shared Sub ApplyButtonStyle(button As Button)
        button.BackColor = Color.Transparent
        button.ForeColor = ThemeColors.TextPrimary
        button.FlatStyle = FlatStyle.Flat
        button.FlatAppearance.BorderColor = ThemeColors.AccentPrimary
        button.FlatAppearance.BorderSize = 2
        button.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        button.Cursor = Cursors.Hand
    End Sub

    Public Shared Sub ApplyCardStyle(panel As Panel)
        panel.BackColor = ThemeColors.BackgroundMedium
        panel.BorderStyle = BorderStyle.FixedSingle
        panel.ForeColor = ThemeColors.TextPrimary
    End Sub

    Public Shared Sub ApplyInputStyle(textBox As TextBox)
        textBox.BackColor = ThemeColors.BackgroundMedium
        textBox.ForeColor = ThemeColors.TextPrimary
        textBox.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Public Shared Sub ApplyLabelStyle(label As Label)
        label.ForeColor = ThemeColors.TextPrimary
        label.BackColor = Color.Transparent
    End Sub

    Public Shared Sub ApplyPanelStyle(panel As Panel)
        panel.BackColor = ThemeColors.BackgroundDark
        panel.ForeColor = ThemeColors.TextPrimary
    End Sub

    Public Shared Function CreateStatusBadge(status As String) As Label
        Dim badge = New Label With {
            .Text = status,
            .Font = New Font("Segoe UI", 9),
            .Size = New Size(80, 25),
            .TextAlign = ContentAlignment.MiddleCenter,
            .BorderStyle = BorderStyle.FixedSingle
        }

        Select Case status.ToLower()
            Case "active"
                badge.ForeColor = ThemeColors.StatusActive
                badge.BackColor = Color.FromArgb(50, 100, 50)
            Case "inactive"
                badge.ForeColor = ThemeColors.StatusInactive
                badge.BackColor = Color.FromArgb(100, 50, 50)
            Case Else
                badge.ForeColor = ThemeColors.TextSecondary
                badge.BackColor = ThemeColors.BackgroundMedium
        End Select

        Return badge
    End Function

End Class
