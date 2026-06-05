Imports System.Net.Http
Imports System.Text
Imports System.Text.Json
Imports System.Net.Http.Headers

Public Class ApiService
    Private ReadOnly httpClient As HttpClient
    Private ReadOnly baseUrl As String
    Private ReadOnly apiKey As String

    Public Sub New(baseUrl As String, apiKey As String)
        Me.baseUrl = baseUrl.TrimEnd("/"c)
        Me.apiKey = apiKey
        Me.httpClient = New HttpClient()
        ' Supabase expects the apikey header and Authorization Bearer
        httpClient.DefaultRequestHeaders.Add("apikey", apiKey)
        httpClient.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", apiKey)
        httpClient.DefaultRequestHeaders.Add("Accept", "application/json")
    End Sub

    Private ReadOnly Property RestUrlPrefix As String
        Get
            Return baseUrl & "/rest/v1"
        End Get
    End Property

    Public Async Function GetCertificationsAsync() As Task(Of List(Of CertificationModel))
        Try
            Dim url = RestUrlPrefix & "/certifications?select=*"
            Dim response = Await httpClient.GetAsync(url)
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
            Dim url = RestUrlPrefix & "/portfolio_projects?select=*"
            Dim response = Await httpClient.GetAsync(url)
            If response.IsSuccessStatusCode Then
                Dim content = Await response.Content.ReadAsStringAsync()
                Dim options = New JsonSerializerOptions With {.PropertyNameCaseInsensitive = True}
                Return JsonSerializer.Deserialize(Of List(Of PortfolioModel))(content, options)
            End If
        Catch ex As Exception
            Debug.WriteLine("Error fetching portfolio_projects: " & ex.Message)
        End Try
        Return New List(Of PortfolioModel)
    End Function

    Public Async Function GetAboutAsync() As Task(Of AboutModel)
        Try
            Dim url = RestUrlPrefix & "/about_settings?select=*"
            Dim response = Await httpClient.GetAsync(url)
            If response.IsSuccessStatusCode Then
                Dim content = Await response.Content.ReadAsStringAsync()
                Dim options = New JsonSerializerOptions With {.PropertyNameCaseInsensitive = True}
                Dim list = JsonSerializer.Deserialize(Of List(Of AboutModel))(content, options)
                If list IsNot Nothing AndAlso list.Count > 0 Then
                    Return list(0)
                End If
            End If
        Catch ex As Exception
            Debug.WriteLine("Error fetching about_settings: " & ex.Message)
        End Try
        Return New AboutModel()
    End Function

    Public Async Function GetMessagesAsync() As Task(Of List(Of MessageModel))
        Try
            Dim url = RestUrlPrefix & "/contact_message?select=*"
            Dim response = Await httpClient.GetAsync(url)
            If response.IsSuccessStatusCode Then
                Dim content = Await response.Content.ReadAsStringAsync()
                Dim options = New JsonSerializerOptions With {.PropertyNameCaseInsensitive = True}
                Return JsonSerializer.Deserialize(Of List(Of MessageModel))(content, options)
            End If
        Catch ex As Exception
            Debug.WriteLine("Error fetching contact_message: " & ex.Message)
        End Try
        Return New List(Of MessageModel)
    End Function

    Public Async Function CreateCertificationAsync(cert As CertificationModel) As Task(Of CertificationModel)
        Try
            Dim json = JsonSerializer.Serialize(cert)
            Dim content = New StringContent(json, Encoding.UTF8, "application/json")
            ' Ask PostgREST/Supabase to return the created row
            content.Headers.ContentType = New MediaTypeHeaderValue("application/json")
            Dim request = New HttpRequestMessage(HttpMethod.Post, RestUrlPrefix & "/certifications")
            request.Content = content
            request.Headers.Add("Prefer", "return=representation")
            Dim response = Await httpClient.SendAsync(request)
            If response.IsSuccessStatusCode Then
                Dim resp = Await response.Content.ReadAsStringAsync()
                Dim options = New JsonSerializerOptions With {.PropertyNameCaseInsensitive = True}
                Dim list = JsonSerializer.Deserialize(Of List(Of CertificationModel))(resp, options)
                If list IsNot Nothing AndAlso list.Count > 0 Then
                    Return list(0)
                End If
            End If
        Catch ex As Exception
            Debug.WriteLine("Error creating certification: " & ex.Message)
        End Try
        Return Nothing
    End Function

    Public Async Function UpdateAboutAsync(about As AboutModel) As Task(Of Boolean)
        Try
            If about.Id <= 0 Then
                Return False
            End If
            Dim url = RestUrlPrefix & "/about_settings?id=eq." & about.Id

            ' Strip out nulls or unneeded fields for the update if necessary, here we send the changed fields
            Dim options = New JsonSerializerOptions With {
                .DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            }
            Dim json = JsonSerializer.Serialize(New With {
                .title = about.Title,
                .lead = about.Lead,
                .resume_url = about.ResumeUrl,
                .updated_at = DateTime.UtcNow
            }, options)

            Dim content = New StringContent(json, Encoding.UTF8, "application/json")
            Dim request = New HttpRequestMessage(New HttpMethod("PATCH"), url)
            request.Content = content
            request.Headers.Add("Prefer", "return=representation")
            Dim response = Await httpClient.SendAsync(request)
            Return response.IsSuccessStatusCode
        Catch ex As Exception
            Debug.WriteLine("Error updating about_settings: " & ex.Message)
        End Try
        Return False
    End Function

    Public Async Function DeleteCertificationAsync(id As String) As Task(Of Boolean)
        Try
            Dim url = RestUrlPrefix & "/certifications?id=eq." & id
            Dim request = New HttpRequestMessage(HttpMethod.Delete, url)
            Dim response = Await httpClient.SendAsync(request)
            Return response.IsSuccessStatusCode
        Catch ex As Exception
            Debug.WriteLine("Error deleting certification: " & ex.Message)
        End Try
        Return False
    End Function

End Class
