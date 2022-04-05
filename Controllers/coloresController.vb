Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports mery_asp

Namespace Controllers
    Public Class coloresController
        Inherits System.Web.Mvc.Controller

        Private db As New productosEntities

        ' GET: colores
        Function Index() As ActionResult
            Return View(db.colores.ToList())
        End Function

        ' GET: colores/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim colore As colore = db.colores.Find(id)
            If IsNothing(colore) Then
                Return HttpNotFound()
            End If
            Return View(colore)
        End Function

        ' GET: colores/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: colores/Create
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        'más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="colores,color,estado")> ByVal colore As colore) As ActionResult
            If ModelState.IsValid Then
                db.colores.Add(colore)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(colore)
        End Function

        ' GET: colores/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim colore As colore = db.colores.Find(id)
            If IsNothing(colore) Then
                Return HttpNotFound()
            End If
            Return View(colore)
        End Function

        ' POST: colores/Edit/5
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        'más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="colores,color,estado")> ByVal colore As colore) As ActionResult
            If ModelState.IsValid Then
                db.Entry(colore).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(colore)
        End Function

        ' GET: colores/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim colore As colore = db.colores.Find(id)
            If IsNothing(colore) Then
                Return HttpNotFound()
            End If
            Return View(colore)
        End Function

        ' POST: colores/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim colore As colore = db.colores.Find(id)
            db.colores.Remove(colore)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
