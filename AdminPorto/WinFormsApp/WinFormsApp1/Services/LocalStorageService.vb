Imports System.IO
Imports System.Text.Json

Public Class LocalStorageService
    Private dataFolder As String

    Public Sub New()
        dataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "AdminPanel")
        If Not Directory.Exists(dataFolder) Then
            Directory.CreateDirectory(dataFolder)
        End If
    End Sub

    Public Function SaveCertification(cert As CertificationModel) As Boolean
        Try
            Dim filePath = Path.Combine(dataFolder, "certifications.json")
            Dim certifications As List(Of CertificationModel) = LoadCertifications()

            If certifications.Any(Function(c) c.Id = cert.Id) Then
                Dim index = certifications.FindIndex(Function(c) c.Id = cert.Id)
                certifications(index) = cert
            Else
                cert.Id = Guid.NewGuid().ToString()
                certifications.Add(cert)
            End If

            Dim json = JsonSerializer.Serialize(certifications, New JsonSerializerOptions With {.WriteIndented = True})
            File.WriteAllText(filePath, json)
            Return True
        Catch ex As Exception
            Debug.WriteLine("Error saving certification: " & ex.Message)
            Return False
        End Try
    End Function

    Public Function LoadCertifications() As List(Of CertificationModel)
        Try
            Dim filePath = Path.Combine(dataFolder, "certifications.json")
            If File.Exists(filePath) Then
                Dim json = File.ReadAllText(filePath)
                Dim result = JsonSerializer.Deserialize(Of List(Of CertificationModel))(json)
                If result IsNot Nothing Then
                    Return result
                End If
            End If
        Catch ex As Exception
            Debug.WriteLine("Error loading certifications: " & ex.Message)
        End Try
        Return New List(Of CertificationModel)
    End Function

    Public Function DeleteCertification(id As String) As Boolean
        Try
            Dim filePath = Path.Combine(dataFolder, "certifications.json")
            Dim certifications = LoadCertifications()
            certifications.RemoveAll(Function(c) c.Id = id)

            Dim json = JsonSerializer.Serialize(certifications, New JsonSerializerOptions With {.WriteIndented = True})
            File.WriteAllText(filePath, json)
            Return True
        Catch ex As Exception
            Debug.WriteLine("Error deleting certification: " & ex.Message)
            Return False
        End Try
    End Function

    Public Function SaveAbout(about As AboutModel) As Boolean
        Try
            Dim filePath = Path.Combine(dataFolder, "about.json")
            Dim json = JsonSerializer.Serialize(about, New JsonSerializerOptions With {.WriteIndented = True})
            File.WriteAllText(filePath, json)
            Return True
        Catch ex As Exception
            Debug.WriteLine("Error saving about: " & ex.Message)
            Return False
        End Try
    End Function

    Public Function LoadAbout() As AboutModel
        Try
            Dim filePath = Path.Combine(dataFolder, "about.json")
            If File.Exists(filePath) Then
                Dim json = File.ReadAllText(filePath)
                Return JsonSerializer.Deserialize(Of AboutModel)(json)
            End If
        Catch ex As Exception
            Debug.WriteLine("Error loading about: " & ex.Message)
        End Try
        Return New AboutModel()
    End Function

End Class
