Imports System.Text.Json.Serialization

Public Class MessageModel
    <JsonPropertyName("id")>
    Public Property Id As String
    <JsonPropertyName("name")>
    Public Property Name As String
    <JsonPropertyName("email")>
    Public Property Email As String
    <JsonPropertyName("message")>
    Public Property Message As String
    <JsonPropertyName("created_at")>
    Public Property CreatedAt As DateTime?
End Class
