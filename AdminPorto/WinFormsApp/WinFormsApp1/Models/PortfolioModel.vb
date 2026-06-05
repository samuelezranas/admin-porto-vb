Imports System.Text.Json.Serialization

Public Class PortfolioModel
    <JsonPropertyName("id")>
    Public Property Id As String
    <JsonPropertyName("category_id")>
    Public Property CategoryId As String
    <JsonPropertyName("title")>
    Public Property Title As String
    <JsonPropertyName("description")>
    Public Property Description As String
    <JsonPropertyName("image_url")>
    Public Property ImageUrl As String
    <JsonPropertyName("tech_stack")>
    Public Property TechStack As String
    <JsonPropertyName("repository_url")>
    Public Property RepositoryUrl As String
    <JsonPropertyName("sort_order")>
    Public Property SortOrder As Integer
    <JsonPropertyName("is_active")>
    Public Property IsActive As Boolean
    <JsonPropertyName("created_at")>
    Public Property CreatedAt As DateTime?
End Class
