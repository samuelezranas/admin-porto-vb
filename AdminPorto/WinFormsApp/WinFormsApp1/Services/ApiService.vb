Imports System.Net.Http
Imports System.Text
Imports System.Text.Json

Public Class ApiService
    Private ReadOnly httpClient As HttpClient
    Private ReadOnly baseUrl As String

    Public Sub New(baseUrl As String)
        Me.baseUrl = baseUrl
        Me.httpClient = New HttpClient()
    End Sub

    Public Async Function GetCertificationsAsync() As Task(Of List(Of CertificationModel))
        Try
            Dim response = Await httpClient.GetAsync(baseUrl & "/certifications")
            If response.IsSuccessStatusCode Then
                Dim content = Await response.Content.ReadAsStringAsync()
                Dim options = New JsonSerializerOptions With {.PropertyNameCaseInsensitive = True}
                Return JsonSerializer.Deserialize(Of List(Of CertificationModel))(content, options)
            End If
        Catch ex As Exception
            Debug.WriteLine("Error fetching certifications: " & ex.Message)
        End Try
        Return New List(Of CertificationModel)
    End Function

    Public Async Function GetPortfoliosAsync() As Task(Of List(Of PortfolioModel))
        Try
            Dim response = Await httpClient.GetAsync(baseUrl & "/portfolios")
            If response.IsSuccessStatusCode Then
                Dim content = Await response.Content.ReadAsStringAsync()
                Dim options = New JsonSerializerOptions With {.PropertyNameCaseInsensitive = True}
                Return JsonSerializer.Deserialize(Of List(Of PortfolioModel))(content, options)
            End If
        Catch ex As Exception
            Debug.WriteLine("Error fetching portfolios: " & ex.Message)
        End Try
        Return New List(Of PortfolioModel)
    End Function

    Public Async Function GetAboutAsync() As Task(Of AboutModel)
        Try
            Dim response = Await httpClient.GetAsync(baseUrl & "/about")
            If response.IsSuccessStatusCode Then
                Dim content = Await response.Content.ReadAsStringAsync()
                Dim options = New JsonSerializerOptions With {.PropertyNameCaseInsensitive = True}
                Return JsonSerializer.Deserialize(Of AboutModel)(content, options)
            End If
        Catch ex As Exception
            Debug.WriteLine("Error fetching about: " & ex.Message)
        End Try
        Return New AboutModel()
    End Function

    Public Async Function GetMessagesAsync() As Task(Of List(Of MessageModel))
        Try
            Dim response = Await httpClient.GetAsync(baseUrl & "/messages")
            If response.IsSuccessStatusCode Then
                Dim content = Await response.Content.ReadAsStringAsync()
                Dim options = New JsonSerializerOptions With {.PropertyNameCaseInsensitive = True}
                Return JsonSerializer.Deserialize(Of List(Of MessageModel))(content, options)
            End If
        Catch ex As Exception
            Debug.WriteLine("Error fetching messages: " & ex.Message)
        End Try
        Return New List(Of MessageModel)
    End Function

    Public Async Function CreateCertificationAsync(cert As CertificationModel) As Task(Of Boolean)
        Try
            Dim json = JsonSerializer.Serialize(cert)
            Dim content = New StringContent(json, Encoding.UTF8, "application/json")
            Dim response = Await httpClient.PostAsync(baseUrl & "/certifications", content)
            Return response.IsSuccessStatusCode
        Catch ex As Exception
            Debug.WriteLine("Error creating certification: " & ex.Message)
        End Try
        Return False
    End Function

    Public Async Function UpdateAboutAsync(about As AboutModel) As Task(Of Boolean)
        Try
            Dim json = JsonSerializer.Serialize(about)
            Dim content = New StringContent(json, Encoding.UTF8, "application/json")
            Dim response = Await httpClient.PutAsync(baseUrl & "/about/" & about.Id, content)
            Return response.IsSuccessStatusCode
        Catch ex As Exception
            Debug.WriteLine("Error updating about: " & ex.Message)
        End Try
        Return False
    End Function

    Public Async Function DeleteCertificationAsync(id As String) As Task(Of Boolean)
        Try
            Dim response = Await httpClient.DeleteAsync(baseUrl & "/certifications/" & id)
            Return response.IsSuccessStatusCode
        Catch ex As Exception
            Debug.WriteLine("Error deleting certification: " & ex.Message)
        End Try
        Return False
    End Function

End Class
