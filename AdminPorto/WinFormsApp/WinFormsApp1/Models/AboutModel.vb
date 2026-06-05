Imports System.Text.Json.Serialization

Public Class AboutModel
    <JsonPropertyName("id")>
    Public Property Id As Integer
    <JsonPropertyName("title")>
    Public Property Title As String
    <JsonPropertyName("lead")>
    Public Property Lead As String
    <JsonPropertyName("resume_url")>
    Public Property ResumeUrl As String
    <JsonPropertyName("updated_at")>
    Public Property UpdatedAt As DateTime?
End Class
