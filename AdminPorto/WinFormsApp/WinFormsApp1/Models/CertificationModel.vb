Imports System.Text.Json.Serialization

Public Class CertificationModel
    <JsonPropertyName("id")>
    Public Property Id As String
    <JsonPropertyName("title")>
    Public Property Title As String
    <JsonPropertyName("issuer")>
    Public Property Issuer As String
    <JsonPropertyName("year")>
    Public Property Year As String
    <JsonPropertyName("image_url")>
    Public Property ImageUrl As String
    <JsonPropertyName("credential_url")>
    Public Property CredentialUrl As String
    <JsonPropertyName("sort_order")>
    Public Property SortOrder As Integer
    <JsonPropertyName("is_active")>
    Public Property IsActive As Boolean
    <JsonPropertyName("created_at")>
    Public Property CreatedAt As DateTime?
End Class
